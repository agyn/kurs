using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Dtos;
using Kurs.Shared.Data.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Main.Data.Repos.KursRepo
{
    public class KursRepo : BaseRepo<Currency>, IKursRepo<Currency>
    {
        public KursRepo(KursContext context) : base(context)
        {

        }

        public async Task<object> GetList(KursSearchDto dto)
        {
            var query = GetQueryable(x => (x.Name.Contains(dto.Name) || string.IsNullOrEmpty(dto.Name))
                      && x.UserId == dto.UserId)
          .OrderByDescending(x => x.DateUpdate)
          .Skip(dto.Count * dto.Page).Take(dto.Count);

            var result = await query
            .Select(x => new
            {
                x.Id,
                x.Name,
                x.Value,
                Exchanger = x.Exchanger.Name,
                x.ExchangerId,
                x.UserId
            }).ToListAsync();

            var total = await query.CountAsync();

            return new { total = total, result = result };
        }

        public async Task<object> SearchAll(KursSearchDto dto)
        {
            var query = GetQueryable(x => (x.Name.Contains(dto.Name) || string.IsNullOrEmpty(dto.Name)))
       .OrderByDescending(x => x.DateUpdate)
       .Skip(dto.Count * dto.Page).Take(dto.Count);

            var result = await query
            .Select(x => new
            {
                x.Name,
                x.Value,
                Exchanger = x.Exchanger.Name,
                City = x.Exchanger.City.Name
            }).ToListAsync();

            var total = await query.CountAsync();

            return new { total = total, result = result };
        }
    }
}
