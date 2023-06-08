using EBYS.DataAccesLayer.Concrete;

namespace EBYS.DataAccesLayer.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private EBYSContext dbcontext;

		public UnitOfWork(EBYSContext dbcontext)
		{
			this.dbcontext = dbcontext;
		}

		public async Task CommitAsync()
		{
			await dbcontext.Database.CommitTransactionAsync();
		}

		public async Task SaveAsync()
		{
			await dbcontext.SaveChangesAsync();
		}

		public async Task RollbackAsync()
		{
			await dbcontext.Database.RollbackTransactionAsync();
		}

		public async Task BeginTransactionAsync()
		{
			await dbcontext.Database.BeginTransactionAsync();
		}
	}
}
