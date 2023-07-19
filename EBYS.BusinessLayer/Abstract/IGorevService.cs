using EBYS.BusinessLayer.Dtos.Görev;

namespace EBYS.BusinessLayer.Abstract
{
	public interface IGorevService
	{
		public Task<IEnumerable<GorevDto>> GetGorevs();
		public Task<bool> DeleteGorev(Guid id);
		public Task<bool> UpdateGorev(UpdateGorevDto updateGorevDto);
		public Task CreateGorev(CreateGorevDto createGorevDto);
		public GorevPieDto GetGorevPieChart();
	}
}
