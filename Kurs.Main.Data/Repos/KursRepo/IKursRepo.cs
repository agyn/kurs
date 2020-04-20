using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Main.Data.Repos.KursRepo
{
    public interface IKursRepo<TEntity> : IBaseRepo<TEntity> where TEntity : BaseEntity
    {
        Task<object> GetList();
    }
}
