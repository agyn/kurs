using Kurs.Shared.Logic;
using Kurs.Shared.Data.Dtos;
using System.Threading.Tasks;

namespace Kurs.Main.Logic.ExchangerLogic
{
    public interface IExchangerLogic<TEntity> : IBaseCrudLogic<TEntity>
    {
        Task<object> GetList(ExchangerSearchDto dto);
    }
}
