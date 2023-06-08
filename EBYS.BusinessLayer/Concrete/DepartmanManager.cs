using AutoMapper;
using EBYS.BusinessLayer.Abstract;
using EBYS.BusinessLayer.Dtos.Departman;
using EBYS.DataAccesLayer.Abstract;
using EBYS.DataAccesLayer.UnitOfWork;
using EBYS.EntityLayer.Concrete;

namespace EBYS.BusinessLayer.Concrete
{
	public class DepartmanManager:IDepartmanService
	{
		private readonly IDepartmanRepository _departmanRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public DepartmanManager(IDepartmanRepository departmanRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_departmanRepository = departmanRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task AddDepartman(CreateDepartmanDto createDepartmanDto)
		{
			var departmanEntity = _mapper.Map<DepartmanEntity>(createDepartmanDto);
			
			_departmanRepository.Add(departmanEntity);

			await _unitOfWork.SaveAsync();
		}

		public async Task<bool> DeleteDepartman(Guid id)
		{
			var departman = await _departmanRepository.GetById(id);

			if (departman == null)
				return false;

			_departmanRepository.Delete(departman);

			await _unitOfWork.SaveAsync();
			
			return true;
		}

		public async Task<IEnumerable<DepartmanDto>> GetDepartmans()
		{
			var departmans=await _departmanRepository.GetAll();

			return _mapper.Map<IEnumerable<DepartmanDto>>(departmans);
		}

		public  async Task<bool> UpdateDepartman(UpdateDepartmanDto updateDepartmanDto)
		{
			var departman = await _departmanRepository.GetById(updateDepartmanDto.Id);

			if (departman == null)
				return false;

			departman = _mapper.Map(updateDepartmanDto, departman);

			_departmanRepository.Update(departman);

			await _unitOfWork.SaveAsync();

			return true;
		}
	}
}
