using Kurs.Shared.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Main.Logic.KursLogic
{
    public interface IKursLogic<TEntity> : IBaseCrudLogic<TEntity>
    {
        Task<object> GetList();
    }
}
