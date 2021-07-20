using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Domain.Common;
using ProductApp.Persistence.Context;

namespace ProductApp.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ProductAppDbContext _dbContext;
        private readonly DbSet<T> dbSet;
        public GenericRepository(ProductAppDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }
        #region Implementation of IGenericRepository<T>

        public async  Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        #endregion
    }
}
