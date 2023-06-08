using EBYS.BusinessLayer.Dtos.Personel;

namespace EBYS.BusinessLayer.Abstract
{
	public interface IPersonelService
	{
		public Task<IEnumerable<PersonelDto>> GetPersonels();
		public Task<bool> DeletePersonel(Guid id);
		public Task<bool> UpdatePersonel(UpdatePersonelDto updatePersonelDto);
		public Task CreatePersonel(CreatePersonelDto createPersonelDto);
	}
}
