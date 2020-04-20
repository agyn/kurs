using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Dtos;
using Kurs.Shared.Data.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Main.Data.Repos.CityRepo
{
    public class CityRepo : BaseRepo<City>, ICityRepo<City>
    {
        public CityRepo(KursContext context) : base(context)
        {

        }

        public async Task<object> GetList(CitySearchDto dto)
        {
            var query = GetQueryable(x => x.Name.Contains(dto.Name) || string.IsNullOrEmpty(dto.Name))
            .OrderByDescending(x => x.DateUpdate)
            .Skip(dto.Count * dto.Page).Take(dto.Count);

            var result = await query
            .Select(x => new
            {
                x.Id,
                x.Name
            }).ToListAsync();

            var total = await query.CountAsync();

            return new { total = total, result = result };
        }

    }
}
