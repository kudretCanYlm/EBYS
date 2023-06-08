using EBYS.BusinessLayer.Dtos.Kullanici;

namespace EBYS.BusinessLayer.Abstract
{
	public interface IKullaniciService
	{
		public  Task<LoginJwtDto> Giris(GirisDto girisDto);
		public Task<IEnumerable<KullaniciListDto>> GetKullanicilar();
		public Task<bool> DeleteKullanici(Guid id,Guid userI);
		public Task<bool> CreateKullanici(CreateKullaniciDto createKullaniciDto);
		public Task<KullaniciListDto> GetKullanici(Guid id);
		public Task<bool> UpdateKullanici(UpdateKullaniciDto updateKullaniciDto);
	}
}
