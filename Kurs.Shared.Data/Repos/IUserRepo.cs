using System.Collections.Generic;
using System.Threading.Tasks;
using Kurs.Shared.Data.Context;

namespace Kurs.Shared.Data.Repos
{
    public interface IUserRepo : IBaseRepo<User>
    {
        //Task<UserViewDto> GetUserById( int id);

        //Task<object> UpdateUser(UserDto dto);

        //Task<List<string>> GetRolesList(int userId);
    }
}