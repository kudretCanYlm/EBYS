using EBYS.DataAccesLayer.Concrete;
using EBYS.EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EBYS.DataAccesLayer.Repository
{
	public abstract class BaseRepository<T> where T : BaseEntity
	{
		private EBYSContext dbContext;
		private readonly DbSet<T> dbSet;

        protected BaseRepository(EBYSContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> Table => dbSet.Where(x=>x.isDeleted==false).AsQueryable();

		public IQueryable<T> TableNoTracking => dbSet.Where(x => x.isDeleted == false).AsNoTracking();

		public virtual void Add(T entity)
		{
			entity.CreatedAt = DateTime.Now;
			dbSet.Attach(entity);
			dbContext.Entry(entity).State = EntityState.Added;
		}
		public virtual void Update(T entity)
		{
			entity.ModifiedAt = DateTime.Now;
			dbSet.Attach(entity);
			dbContext.Entry(entity).State = EntityState.Modified;
		}

		public virtual void UpdateMany(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				entity.ModifiedAt = DateTime.Now;
				dbSet.Attach(entity);
				dbContext.Entry(entity).State = EntityState.Modified;
			}
		}

		public virtual void Delete(T entity)
		{
			entity.DeletedAt = DateTime.Now;
			entity.isDeleted = true;
			dbSet.Attach(entity);
			dbContext.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Delete(Expression<Func<T, bool>> where)
		{
			IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
			foreach (T obj in objects)
			{
				obj.DeletedAt = DateTime.Now;
				obj.isDeleted = true;
				dbSet.Attach(obj);
				dbContext.Entry(obj).State = EntityState.Modified;
			}
		}
		public virtual async Task<T> GetById(Guid id)
		{
			return await dbSet.Where(x => x.isDeleted == false && x.Id == id).FirstOrDefaultAsync();
		}
		public virtual async Task<T> GetById(string id)
		{
			return await dbSet.FindAsync(id);
		}
		public virtual async Task<IReadOnlyList<T>> GetAll()
		{
			return await dbSet.Where(x => x.isDeleted == false).ToListAsync();
		}

		public virtual async Task<IReadOnlyList<T>> GetMany(Expression<Func<T, bool>> where)
		{
			return await dbSet.Where(x => x.isDeleted == false).Where(where).ToListAsync();
		}

		public virtual IQueryable<T> GetManyQuery(Expression<Func<T, bool>> where)
		{
			return dbSet.Where(x => x.isDeleted == false).Where(where);
		}

		public async Task<T> Get(Expression<Func<T, bool>> where)
		{
			return await dbSet.Where(where).FirstOrDefaultAsync<T>();
		}

		public void Dispose()
		{
			dbContext.Dispose();
		}
	}
}
