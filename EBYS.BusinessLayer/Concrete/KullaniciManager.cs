using AutoMapper;
using EBYS.BusinessLayer.Abstract;
using EBYS.BusinessLayer.Dtos.Kullanici;
using EBYS.DataAccesLayer.Abstract;
using EBYS.DataAccesLayer.UnitOfWork;
using EBYS.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EBYS.BusinessLayer.Concrete
{
	public class KullaniciManager:IKullaniciService
	{
		private readonly IKullaniciRepository _kullaniciRepository;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;
		private readonly IUnitOfWork _unitOfWork;

		public KullaniciManager(IKullaniciRepository kullaniciRepository, IMapper mapper, IConfiguration configuration, IUnitOfWork unitOfWork)
		{
			_kullaniciRepository = kullaniciRepository;
			_mapper = mapper;
			_configuration = configuration;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> CreateKullanici(CreateKullaniciDto createKullaniciDto)
		{
			var user = _mapper.Map<KullaniciEntity>(createKullaniciDto);
			
			user.ToHashPassword();

			var anyUsername = await _kullaniciRepository.GetManyQuery(x => x.KullaniciAdi == createKullaniciDto.KullaniciAdi).AnyAsync();

			if (anyUsername)
				return false;

			_kullaniciRepository.Add(user);
			await _unitOfWork.SaveAsync();

			return true;
		}

		public async Task<bool> DeleteKullanici(Guid id,Guid userId)
		{
			var user = await _kullaniciRepository.GetById(id);

			if (user == null || user.Id==userId)
				return false;

			_kullaniciRepository.Delete(user);
			await _unitOfWork.SaveAsync();

			return true;
		}

		public async Task<KullaniciListDto> GetKullanici(Guid id)
		{
			var user = await _kullaniciRepository.GetById(id);

			return _mapper.Map<KullaniciListDto>(user);
		}

		public async Task<IEnumerable<KullaniciListDto>> GetKullanicilar()
		{
			var list=await _kullaniciRepository.GetAll();

			return _mapper.Map<IEnumerable<KullaniciListDto>>(list);
		}

		public async Task<LoginJwtDto> Giris(GirisDto girisDto)
		{
			var user = await _kullaniciRepository.Get(x => x.KullaniciAdi == girisDto.KullaniciAdi && x.Sifre == KullaniciEntity.ToHash(girisDto.Sifre));

			if (user == null)
				return null;

			var userJwt = _mapper.Map<LoginJwtDto>(user);

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration["Key"]);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, userJwt.Id.ToString()),
					new Claim(ClaimTypes.Role,Enum.GetName(userJwt.Role)),
					new Claim(ClaimTypes.DateOfBirth,DateTime.Now.Ticks.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(1.0),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			userJwt.Token = tokenHandler.WriteToken(token);

			userJwt.Password = null;

			return userJwt;
		}

        public async Task<bool> UpdateKullanici(UpdateKullaniciDto updateKullaniciDto)
        {
			var user = await _kullaniciRepository.GetById(updateKullaniciDto.Id);
            var anyUsername = await _kullaniciRepository.GetManyQuery(x =>x.Id!=updateKullaniciDto.Id && x.KullaniciAdi == updateKullaniciDto.KullaniciAdi).AnyAsync();


            if (user == null || anyUsername)
				return false;

			user=_mapper.Map(updateKullaniciDto, user);

			user.ToHashPassword();

			_kullaniciRepository.Update(user);
			await _unitOfWork.SaveAsync();
			
			return true;
        }
    }
}
