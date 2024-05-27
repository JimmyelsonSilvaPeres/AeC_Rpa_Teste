using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<int> Creat(TEntity entity);
        Task<int> CreatRange(IEnumerable<TEntity> entity);
     
        IQueryable<TEntity> GetAll();
    }
}
