using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Repos;
using Microsoft.EntityFrameworkCore;
using Kurs.Shared.Data.Dtos;
using System.Threading.Tasks;
using System.Linq;

namespace Kurs.Main.Data.Repos.ExchangerRepo
{
    public class ExchangerRepo : BaseRepo<Exchanger>, IExchangerRepo<Exchanger>
    {
        public ExchangerRepo(KursContext context) : base(context)
        {
        }

        public async Task<object> GetExchangers(int currentUserId)
        {
            return await Repo.Where(x => x.UserId == currentUserId).ToListAsync();
        }

        public async Task<object> GetList(ExchangerSearchDto dto)
        {
                        var query = GetQueryable(x => (x.Name.Contains(dto.Name) || string.IsNullOrEmpty(dto.Name)) 
                        && (x.Phone.Contains(dto.Phone) ||string.IsNullOrEmpty(dto.Phone) )
                        && (x.Phone.Contains(dto.Address) ||string.IsNullOrEmpty(dto.Address) )
                        && x.UserId == dto.UserId )
            .OrderByDescending(x => x.DateUpdate)
            .Skip(dto.Count * dto.Page).Take(dto.Count);

            var result = await query
            .Select(x => new
            {
                x.Id,
                x.Name,
                x.Phone,
                x.Address,
                City = x.City.Name,
                x.CityId,
                x.UserId
            }).ToListAsync();

            var total = await query.CountAsync();

            return new { total = total, result = result };
        }
    }
}
