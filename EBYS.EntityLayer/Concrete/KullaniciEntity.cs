using EBYS.EntityLayer.Abstract;
using System.Security.Cryptography;
using System.Text;

namespace EBYS.EntityLayer.Concrete
{
	public class KullaniciEntity:BaseEntity
	{
		public string Ad { get; set; }
		public string KullaniciAdi { get; set; }
		public string Sifre { get; set; }
		public RoleEnum Role { get;set; }

		public void ToHashPassword()
		{
			// Create a SHA256   
			using (SHA256 sha256Hash = SHA256.Create())
			{
				// ComputeHash - returns byte array  
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(this.Sifre));

				// Convert byte array to a string   
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}

				this.Sifre = builder.ToString();
			}
		}

		public static string ToHash(string value)
		{
			using (SHA256 sha256Hash = SHA256.Create())
			{
				// ComputeHash - returns byte array  
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

				// Convert byte array to a string   
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}

				return builder.ToString();
			}
		}

	}

	public enum RoleEnum
	{
		Admin,
		User
	}


}
