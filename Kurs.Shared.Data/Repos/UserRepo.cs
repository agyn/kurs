using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurs.Shared.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Kurs.Shared.Data.Repos
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(KursContext context) : base(context)
        {
        }

        // public async Task<UserViewDto> GetUserById(int id)
        // {
        //     return await Repo.Where(x => x.Id == id).Select(x => new
        //         UserViewDto()
        //         {
        //             Id = x.Id,
        //             Iin = x.Iin,
        //             Login = x.Login,
        //             FirstName = x.FirstName,
        //             LastName = x.LastName,
        //             MiddleName = x.MiddleName,
        //             CompanyId = x.CompanyId,
        //             UmgId = x.UmgId,
        //             LpuId = x.LpuId,
        //             PositionId = x.PositionId,
        //             //BranchCompanyId = x.BranchCompanyId, LPUId = x.LPUId, PositionId = x.PositionId, Login = x.Login,
        //             Phone = x.Phone,
        //             Email = x.Email,
        //             IsBlocked = x.IsBlocked,
        //         }).FirstOrDefaultAsync(x => x.Id == id);
        // }

        // public async Task<object> UpdateUser(UserDto dto)
        // {
        //     var user = await Context.Users.FirstOrDefaultAsync(x => x.Id == dto.Id);
        //     if (user == null)
        //         throw new ArgumentException("Not found");

        //     user.CompanyId = dto.CompanyId;
        //     user.UmgId = dto.UmgId;
        //     user.LpuId = dto.LpuId;
        //     user.PositionId = dto.PositionId;
        //     user.Phone = dto.Phone;
        //     user.Email = dto.Email;
        //     user.IsBlocked = dto.IsBlocked;
        //     await Context.SaveChangesAsync();
        //     return new {IsSuccess = true};
        // }

    }
}