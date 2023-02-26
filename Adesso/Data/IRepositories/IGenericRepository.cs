using System;
namespace Adesso.Data.IRepositories
{
	public interface IGenericRepository<T> where T: class
	{
		IQueryable<T> GetAll();
		Task<T> GetById(int id);
		Task Create(T entity);
        void Update(T entity);
		Task Delete(T entity);
    }
}

