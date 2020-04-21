using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Repos;
using Kurs.Shared.Data.Dtos;
using System.Threading.Tasks;

namespace Kurs.Main.Data.Repos.ExchangerRepo
{
    public interface IExchangerRepo<TEntity> : IBaseRepo<TEntity> where TEntity : BaseEntity
    {
        Task<object> GetList(ExchangerSearchDto dto);
        Task<object> GetExchangers(int currentUserId);
    }
}
