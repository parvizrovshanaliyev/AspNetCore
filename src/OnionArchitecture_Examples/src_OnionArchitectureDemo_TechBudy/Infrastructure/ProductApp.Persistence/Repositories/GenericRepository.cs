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
        public GenericRepository(ProductAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region Implementation of IGenericRepository<T>

        public async  Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        #endregion
    }
}
