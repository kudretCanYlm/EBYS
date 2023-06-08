using AutoMapper;
using EBYS.BusinessLayer.Abstract;
using EBYS.BusinessLayer.Dtos.Görev;
using EBYS.DataAccesLayer.Abstract;
using EBYS.DataAccesLayer.UnitOfWork;
using EBYS.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EBYS.BusinessLayer.Concrete
{
	public class GorevManager:IGorevService
	{
		private readonly IGorevRepository _gorevRepository;
		private readonly IPersonelRepository _personelRepository;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public GorevManager(IGorevRepository gorevRepository, IPersonelRepository personelRepository, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_gorevRepository = gorevRepository;
			_personelRepository = personelRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task CreateGorev(CreateGorevDto createGorevDto)
		{
			var personelAny = await _personelRepository.GetManyQuery(x => x.Id == createGorevDto.PersonelId).AnyAsync();

			if (!personelAny)
				return;

			var entity = _mapper.Map<GorevEntity>(createGorevDto);

			_gorevRepository.Add(entity);
			await _unitOfWork.SaveAsync();
		}

		public async Task<bool> DeleteGorev(Guid id)
		{
			var gorev=await _gorevRepository.GetById(id);

			if (gorev == null)
				return false;

			_gorevRepository.Delete(gorev);
			await _unitOfWork.SaveAsync();

			return true;
		}

		public async Task<IEnumerable<GorevDto>> GetGorevs()
		{
			var gorevs = await _gorevRepository
				.Table
				.Include(x => x.Personel)
				.ToListAsync();

			return _mapper.Map<IEnumerable<GorevDto>>(gorevs);
		}

		public async Task<bool> UpdateGorev(UpdateGorevDto updateGorevDto)
		{
			var personelAny = await _personelRepository.GetManyQuery(x => x.Id == updateGorevDto.PersonelId).AnyAsync();

			var gorev = await _gorevRepository.GetById(updateGorevDto.Id);

			if (gorev == null || !personelAny)
				return false;

			gorev = _mapper.Map(updateGorevDto, gorev);

			_gorevRepository.Update(gorev);
			await _unitOfWork.SaveAsync();

			return true;
		}
	}
}
