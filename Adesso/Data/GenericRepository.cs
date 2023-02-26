using System;
using Adesso.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Adesso.Data
{
	public class GenericRepository<T> : IGenericRepository<T> where T:class
	{
        private readonly MyDbContext dbContext;
		public GenericRepository(MyDbContext _dbContext)
		{
            dbContext = _dbContext;
		}

        public async Task Create(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>().AsNoTracking();
        }

        public Task<T> GetById(int id)
        {       
            return dbContext.Set<T>().FindAsync(id).AsTask();
        }

        public void Update(T entity)
        {
             dbContext.Set<T>().Update(entity);
             dbContext.SaveChanges();
        }
    }
}

