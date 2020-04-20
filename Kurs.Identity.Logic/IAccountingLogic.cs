using System.Threading.Tasks;
using Kurs.Identity.Data.Model;

namespace Kurs.Identity.Logic
{
    public interface IAccountingLogic
    {
        Task<object> Login(LoginDto dto);
        Task<object> UpdateToken(int userId);
        Task Register(UserDto dto);
    }
}