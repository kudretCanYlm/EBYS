using EBYS.EntityLayer.Concrete;

namespace EBYS.BusinessLayer.Dtos.Kullanici
{
	public class LoginJwtDto
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Token { get; set; }
		public RoleEnum Role { get; set; }
		public Guid Id { get; set; }
	}
}
