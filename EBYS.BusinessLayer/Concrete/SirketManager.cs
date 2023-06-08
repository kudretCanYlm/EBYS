using AutoMapper;
using EBYS.BusinessLayer.Abstract;
using EBYS.BusinessLayer.Dtos.Sirket;
using EBYS.DataAccesLayer.Abstract;
using EBYS.DataAccesLayer.UnitOfWork;
using EBYS.EntityLayer.Concrete;

namespace EBYS.BusinessLayer.Concrete
{
	public class SirketManager:ISirketService
	{
		private readonly ISirketRepository _sirketRepository;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public SirketManager(ISirketRepository sirketRepository, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_sirketRepository = sirketRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task AddSirket(CreateSirketDto createSirketDto)
		{
			_sirketRepository.Add(_mapper.Map<SirketEntity>(createSirketDto));
			await _unitOfWork.SaveAsync();
		}

		public async Task<bool> DeleteSiket(Guid id)
		{
			var sirket = await _sirketRepository.GetById(id);

			if(sirket==null)
				return false;

			_sirketRepository.Delete(sirket);
			await _unitOfWork.SaveAsync();

			return true;
		}

		public async Task<IEnumerable<SirketDto>> GetSirkets()
		{
			var list=await _sirketRepository.GetAll();

			return _mapper.Map<IEnumerable<SirketDto>>(list);
		}

		public async Task<bool> UpdateSiket(UpdateSirketDto updateSirketDto)
		{
			var sirket = await _sirketRepository.GetById(updateSirketDto.Id);

			if (sirket == null)
				return false;

			sirket = _mapper.Map(updateSirketDto, sirket);

			_sirketRepository.Update(sirket);
			await _unitOfWork.SaveAsync();

			return true;
		}
	}
}
