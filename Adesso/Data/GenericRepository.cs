using System;
using Adesso.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Adesso.Data
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity:class
	{
        private readonly MyDbContext dbContext;
		public GenericRepository(MyDbContext _dbContext)
		{
            dbContext = _dbContext;
		}

        public async Task Create(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsNoTracking();
        }

        public Task<TEntity> GetById(int id)
        {
            return dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Task Update(TEntity entity)
        {
             dbContext.Set<TEntity>().Update(entity);
             dbContext.SaveChanges();
        }
    }
}

