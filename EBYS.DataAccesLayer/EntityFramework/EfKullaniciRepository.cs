using EBYS.DataAccesLayer.Abstract;
using EBYS.DataAccesLayer.Concrete;
using EBYS.DataAccesLayer.Repository;
using EBYS.EntityLayer.Concrete;

namespace EBYS.DataAccesLayer.EntityFramework
{
	public class EfKullaniciRepository:BaseRepository<KullaniciEntity>,IKullaniciRepository
	{
        public EfKullaniciRepository(EBYSContext eBYSContext) : base(eBYSContext)
        {

        }
    }
}
