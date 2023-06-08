using AutoMapper;
using EBYS.BusinessLayer.Abstract;
using EBYS.BusinessLayer.Dtos.Personel;
using EBYS.DataAccesLayer.Abstract;
using EBYS.DataAccesLayer.UnitOfWork;
using EBYS.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EBYS.BusinessLayer.Concrete
{
	public class PersonelManager : IPersonelService
	{
		private readonly IPersonelRepository _personelRepository;
		private readonly IMapper _mapper;
		private readonly ISirketRepository _sirketRepository;
		private readonly IDepartmanRepository _departmanRepository;
		private readonly IUnitOfWork _unitOfWork;

		public PersonelManager(IPersonelRepository personelRepository, IMapper mapper, ISirketRepository sirketRepository, IDepartmanRepository departmanRepository, IUnitOfWork unitOfWork)
		{
			_personelRepository = personelRepository;
			_mapper = mapper;
			_sirketRepository = sirketRepository;
			_departmanRepository = departmanRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task CreatePersonel(CreatePersonelDto createPersonelDto)
		{
			var sirketAny = await _sirketRepository.GetManyQuery(x => x.Id == createPersonelDto.SirketId).AnyAsync();
			var departmanAny = await _departmanRepository.GetManyQuery(x => x.Id == createPersonelDto.DepartmanId).AnyAsync();

			if (!sirketAny || !departmanAny)
				return;

			var entity = _mapper.Map<PersonelEntity>(createPersonelDto);

			_personelRepository.Add(entity);

			await _unitOfWork.SaveAsync();
		}

		public async Task<bool> DeletePersonel(Guid id)
		{
			var entity = await _personelRepository.GetById(id);

			if(entity == null) 
				return false;

			_personelRepository.Delete(entity);
			await _unitOfWork.SaveAsync();
			
			return true;
		}

		public async Task<IEnumerable<PersonelDto>> GetPersonels()
		{
			var personels=await _personelRepository
				.Table
				.Include(x=>x.Departman)
				.Include(x=>x.SirketEntity)
				.ToListAsync();

			return _mapper.Map<IEnumerable<PersonelDto>>(personels);
		}

		public async Task<bool> UpdatePersonel(UpdatePersonelDto updatePersonelDto)
		{
			var personel = await _personelRepository.GetById(updatePersonelDto.Id);

			if(personel == null) 
				return false;

			var sirketAny = await _sirketRepository.GetManyQuery(x => x.Id == updatePersonelDto.SirketId).AnyAsync();
			var departmanAny = await _departmanRepository.GetManyQuery(x => x.Id == updatePersonelDto.DepartmanId).AnyAsync();

			if (!sirketAny || !departmanAny)
				return false;

			personel = _mapper.Map(updatePersonelDto, personel);

			_personelRepository.Update(personel);
			await _unitOfWork.SaveAsync();

			return true;

		}
	}
}
