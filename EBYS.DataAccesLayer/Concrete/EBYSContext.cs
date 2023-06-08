using EBYS.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EBYS.DataAccesLayer.Concrete
{
	public class EBYSContext:DbContext
	{
		public EBYSContext(DbContextOptions<EBYSContext> options):base(options) 
		{
			//ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			//ChangeTracker.AutoDetectChangesEnabled = false;
		}

		public DbSet<DepartmanEntity> Departman { get; set; }
		public DbSet<GorevEntity> Gorev { get; set; }
		public DbSet<KullaniciEntity> Kullanici { get; set; }
		public DbSet<PersonelEntity> Personel { get; set; }
		public DbSet<SirketEntity> Sirket { get; set; }

	}
}
