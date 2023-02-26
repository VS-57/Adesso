using System;
namespace Adesso.Data.IRepositories
{
	public interface IGenericRepository<TEntity> where TEntity: class
	{
		IQueryable<TEntity> GetAll();
		Task<TEntity> GetById(int id);
		Task Create(TEntity entity);
        Task Update(TEntity entity);
		Task Delete(TEntity entity);
    }
}

