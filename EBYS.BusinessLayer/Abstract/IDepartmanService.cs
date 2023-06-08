using EBYS.BusinessLayer.Dtos.Departman;

namespace EBYS.BusinessLayer.Abstract
{
	public interface IDepartmanService
	{
		public Task<IEnumerable<DepartmanDto>> GetDepartmans();
		public Task AddDepartman(CreateDepartmanDto createDepartmanDto);
		public Task<bool> DeleteDepartman(Guid id);
		public Task<bool> UpdateDepartman(UpdateDepartmanDto updateDepartmanDto);
	}
}
