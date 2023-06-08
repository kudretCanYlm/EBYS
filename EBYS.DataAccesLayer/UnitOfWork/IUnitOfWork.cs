namespace EBYS.DataAccesLayer.UnitOfWork
{
	public interface IUnitOfWork 
	{
		Task CommitAsync();
		Task SaveAsync();
		Task BeginTransactionAsync();
		Task RollbackAsync();
	}
}
