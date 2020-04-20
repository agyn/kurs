using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kurs.Identity.Data.Model;
using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Repos;

namespace Kurs.Identity.Data
{
    public interface IAccountingRepo : IUserRepo
    {
        Task<UserForLogin> GetLogin(Expression<Func<User, bool>> expression);
    }
}