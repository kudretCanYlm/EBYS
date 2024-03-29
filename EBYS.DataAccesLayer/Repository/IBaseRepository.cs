﻿using EBYS.EntityLayer.Abstract;
using System.Linq.Expressions;

namespace EBYS.DataAccesLayer.Repository
{
	public interface IBaseRepository<T>  where T : BaseEntity
	{
		IQueryable<T> Table { get; }
		void Add(T entity);
		void Update(T entity);
		void UpdateMany(IEnumerable<T> entities);
		void Delete(T entity);
		void Delete(Expression<Func<T, bool>> where);
		Task<T> GetById(Guid id);
		Task<T> GetById(string id);
		Task<T> Get(Expression<Func<T, bool>> where);
		Task<IReadOnlyList<T>> GetAll();
		Task<IReadOnlyList<T>> GetMany(Expression<Func<T, bool>> where);
		IQueryable<T> GetManyQuery(Expression<Func<T, bool>> where);
	}
}
