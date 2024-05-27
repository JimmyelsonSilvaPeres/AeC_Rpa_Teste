using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
                      where TEntity : class
    {
        protected readonly Context context;

        public RepositoryBase(Context context)
        {
            this.context = context;
        }
        public DbSet<TEntity> _dbset => context.Set<TEntity>();

        public async Task<int> Creat(TEntity entity)
        {
            await _dbset.AddAsync(entity);
            return await context.SaveChangesAsync();
        }
        public async Task<int> CreatRange(IEnumerable<TEntity> entity)
        {
            await _dbset.AddRangeAsync(entity);
            return await context.SaveChangesAsync();
        }
        public IQueryable<TEntity> GetAll() => _dbset;
    }
}
