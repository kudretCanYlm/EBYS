using EBYS.DataAccesLayer.Abstract;
using EBYS.DataAccesLayer.Concrete;
using EBYS.DataAccesLayer.Repository;
using EBYS.EntityLayer.Concrete;

namespace EBYS.DataAccesLayer.EntityFramework
{
	public class EfSirketRepository:BaseRepository<SirketEntity>,ISirketRepository
	{
        public EfSirketRepository(EBYSContext eBYSContext) : base(eBYSContext)
        {

        }
    }
}
