using EBYS.BusinessLayer.Dtos.Sirket;

namespace EBYS.BusinessLayer.Abstract
{
	public interface ISirketService
	{
		public Task<IEnumerable<SirketDto>> GetSirkets();
		public Task AddSirket(CreateSirketDto createSirketDto);
		public Task<bool> DeleteSiket(Guid id);
		public Task<bool> UpdateSiket(UpdateSirketDto updateSirketDto);
	}
}
