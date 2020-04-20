using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kurs.Shared.Data.Repos
{
    public interface IBaseRepo<TEntity>
    {
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> expression);
        Task<int> Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entity);
        Task Save();
        Task<TEntity> GetById(int id);
        Task Delete(int id);
        Task DeleteRange(IEnumerable<TEntity> entities);
        Task Update(TEntity entity);
        Task UpdateRange(IEnumerable<TEntity> entity);
        Task<int> GetMaxId();
    }
}