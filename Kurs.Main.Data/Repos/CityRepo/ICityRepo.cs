using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Dtos;
using Kurs.Shared.Data.Repos;
using System.Threading.Tasks;

namespace Kurs.Main.Data.Repos.CityRepo
{
    public interface ICityRepo<TEntity> : IBaseRepo<TEntity> where TEntity : BaseEntity
    {
        Task<object> GetList(CitySearchDto dto);
        Task<object> GetCities();
    }
}
