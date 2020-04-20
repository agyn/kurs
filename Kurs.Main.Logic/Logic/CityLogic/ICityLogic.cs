using Kurs.Shared.Data.Dtos;
using Kurs.Shared.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Admin.Logic.CityLogic
{
    public interface ICityLogic<TEntity> : IBaseCrudLogic<TEntity>
    {
        Task<object> GetList(CitySearchDto dto);
    }
}
