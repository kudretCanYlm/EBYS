using EBYS.DataAccesLayer.Abstract;
using EBYS.DataAccesLayer.Concrete;
using EBYS.DataAccesLayer.Repository;
using EBYS.EntityLayer.Concrete;

namespace EBYS.DataAccesLayer.EntityFramework
{
	public class EfPersonelRepository:BaseRepository<PersonelEntity>,IPersonelRepository
	{
        public EfPersonelRepository(EBYSContext eBYSContext) : base(eBYSContext)
        {

        }
    }
}
