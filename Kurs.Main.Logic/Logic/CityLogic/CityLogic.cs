using Kurs.Admin.Logic.CityLogic;
using Kurs.Main.Data.Repos.CityRepo;
using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Dtos;
using Kurs.Shared.Logic;
using System.Threading.Tasks;

namespace Pet.Admin.Logic.CityLogic
{
    public class CityLogic : BaseCrudLogic<ICityRepo<City>, City>, ICityLogic<City>
    {
        public CityLogic(ICityRepo<City> repo) : base(repo)
        {
        }

        public async Task<object> GetCities()
        {
            return await Repo.GetCities();
        }

        public async Task<object> GetList(CitySearchDto dto)
        {
            return await Repo.GetList(dto);
        }
    }
}
