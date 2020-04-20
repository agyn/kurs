using Kurs.Main.Data.Repos.CityRepo;
using Kurs.Main.Data.Repos.ExchangerRepo;
using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Dtos;
using Kurs.Shared.Logic;
using System.Threading.Tasks;

namespace Kurs.Main.Logic.ExchangerLogic
{
    public class ExchangerLogic : BaseCrudLogic<IExchangerRepo<Exchanger>, Exchanger>, IExchangerLogic<Exchanger>
    {
        public ExchangerLogic(IExchangerRepo<Exchanger> repo) : base(repo)
        {
        }

        public async Task<object> GetList(ExchangerSearchDto dto)
        {
            return await Repo.GetList(dto);
        }
    }
}
