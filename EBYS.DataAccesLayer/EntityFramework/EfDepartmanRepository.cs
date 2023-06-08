using EBYS.DataAccesLayer.Abstract;
using EBYS.DataAccesLayer.Concrete;
using EBYS.DataAccesLayer.Repository;
using EBYS.EntityLayer.Concrete;

namespace EBYS.DataAccesLayer.EntityFramework
{
	public class EfDepartmanRepository: BaseRepository<DepartmanEntity>,IDepartmanRepository
	{
		public EfDepartmanRepository(EBYSContext eBYSContext):base(eBYSContext) 
		{

		}
	}
}
