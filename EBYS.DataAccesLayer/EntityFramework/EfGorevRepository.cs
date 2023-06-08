using EBYS.DataAccesLayer.Abstract;
using EBYS.DataAccesLayer.Concrete;
using EBYS.DataAccesLayer.Repository;
using EBYS.EntityLayer.Concrete;

namespace EBYS.DataAccesLayer.EntityFramework
{
	public class EfGorevRepository:BaseRepository<GorevEntity>,IGorevRepository
	{
        public EfGorevRepository(EBYSContext eBYSContext) : base(eBYSContext)
        {

        }
    }
}
