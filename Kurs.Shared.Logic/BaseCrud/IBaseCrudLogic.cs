using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Shared.Logic
{
    public interface IBaseCrudLogic<TEntity>
    {
        Task<int> Add(TEntity entity);
        Task Save();
        Task<TEntity> GetById(int id);
        Task Delete(int id);
        Task Update(TEntity entity);
    }
}
