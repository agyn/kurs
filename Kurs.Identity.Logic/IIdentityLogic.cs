using System.Collections.Generic;

namespace Kurs.Identity.Logic
{
    public interface IIdentityLogic
    {
        string GenerateAccessToken(int userId);
        string GenerateRefreshToken(int userId);
    }
}