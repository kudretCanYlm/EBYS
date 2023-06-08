using EBYS.EntityLayer.Concrete;

namespace EBYS.BusinessLayer.Dtos.Kullanici
{
	public class KullaniciListDto
	{
		public Guid Id { get; set; }
		public string Ad { get; set; }
		public RoleEnum Role { get; set; }
	}
}
