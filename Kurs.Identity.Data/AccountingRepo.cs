using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kurs.Identity.Data;
using Kurs.Identity.Data.Model;
using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Repos;
using Microsoft.EntityFrameworkCore;

namespace Ias.Identity.Data
{
    public class AccountingRepo : UserRepo , IAccountingRepo
    {
        public AccountingRepo(KursContext context) : base(context)
        {}
        
        public async Task<UserForLogin> GetLogin(Expression<Func<User, bool>> expression)
        {
            return await Repo
                .AsQueryable()
                .Where(expression)
                .Select(x => new UserForLogin
                    {Id = x.Id, Pwdhash = x.PasswordHash, Login = x.Login})
                .FirstOrDefaultAsync();
        }
    }
}