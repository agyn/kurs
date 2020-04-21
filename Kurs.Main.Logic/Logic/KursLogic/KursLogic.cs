using Kurs.Main.Data.Repos.CityRepo;
using Kurs.Main.Data.Repos.ExchangerRepo;
using Kurs.Main.Data.Repos.KursRepo;
using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Dtos;
using Kurs.Shared.Logic;
using System.Threading.Tasks;

namespace Kurs.Main.Logic.KursLogic
{
    public class KursLogic : BaseCrudLogic<IKursRepo<Currency>, Currency>, IKursLogic<Currency>
    {
        public KursLogic(IKursRepo<Currency> repo) : base(repo)
        {
        }

        public async Task<object> GetList(KursSearchDto dto)
        {
            return await Repo.GetList(dto);
        }

        public async Task<object> SearchAll(KursSearchDto dto)
        {
            return await Repo.SearchAll(dto);
        }
    }
}
