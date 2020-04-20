using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Main.Data.Repos.KursRepo
{
    public class KursRepo : BaseRepo<Currency>, IKursRepo<Currency>
    {
        public KursRepo(KursContext context) : base(context)
        {

        }
        
        public async Task<object> GetList()
        {
            return await Repo.ToListAsync();
        }
    }
}
