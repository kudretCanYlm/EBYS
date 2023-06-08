using EBYS.BusinessLayer.Abstract;
using EBYS.BusinessLayer.Concrete;
using EBYS.BusinessLayer.Dtos.Kullanici;
using EBYS.DataAccesLayer.Concrete;
using EBYS.EntityLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
	
namespace EBYS.BlazorServer.Data
{
	public static class SqlServerExtensions
	{
		public static void ApplyMigration(this WebApplication app) 
		{
			using (var serviceScope = app.Services.CreateScope())
			{
				var db=serviceScope.ServiceProvider.GetService<EBYSContext>();

				db.Database.Migrate();

				var state = db.Kullanici.Any();

				if (!state)
				{
					var kullaniciEntity = new KullaniciEntity
					{
						Id = Guid.NewGuid(),
						Ad = "Test",
						KullaniciAdi = "test123",
						Sifre = "test123",
						Role = RoleEnum.Admin,
						CreatedAt = DateTime.Now,
						isDeleted = false,
					};

					kullaniciEntity.ToHashPassword();

					db.Add(kullaniciEntity);
					db.SaveChanges();

				}

			}

			
			
		}
	}
}
