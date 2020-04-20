using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Kurs.Identity.Logic;
using Kurs.Identity.Data;
using Kurs.Identity.Data.Model;
using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Repos;

namespace Kurs.Identity.Logic
{
    public class AccountingLogic : IAccountingLogic
    {
        private readonly IIdentityLogic _identityLogic;
        private readonly IAccountingRepo _accountingRepo;
        private readonly IUserRepo _userRepo;
        public AccountingLogic(IIdentityLogic identityLogic, IAccountingRepo accountingRepo, IUserRepo userRepo)
        {
            _identityLogic = identityLogic;
            _accountingRepo = accountingRepo;
            _userRepo = userRepo;
        }

        public async Task<object> Login(LoginDto dto)
        {
            var user = await _accountingRepo.GetLogin(x => x.Login.Equals(dto.Login));
            if (user == null) throw new ArgumentException("Пользователь не найден!");

            var alg = SHA512.Create();
            alg.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
            var pwdhash = Convert.ToBase64String(alg.Hash);

            // Reset password
            /*var password2 = "Sgs123456#";
            var alg2 = SHA512.Create();
            alg2.ComputeHash(Encoding.UTF8.GetBytes(password2));
            var pwdhash2 = Convert.ToBase64String(alg2.Hash);*/

            if (user.Pwdhash != pwdhash) throw new ArgumentException("Неверный пароль!");

            return new
            {
                AccessToken = _identityLogic.GenerateAccessToken(user.Id),
                RefreshToken = _identityLogic.GenerateRefreshToken(user.Id),
                User = $"{user.Login}"
            };
        }

        public async Task<object> UpdateToken(int userId)
        {
            var user = await _accountingRepo.GetLogin(x => x.Id == userId);
            if (user == null) throw new ArgumentException("Пользователь не найден");
            return new
            {
                AccessToken = _identityLogic.GenerateAccessToken(user.Id),
                RefreshToken = _identityLogic.GenerateRefreshToken(user.Id),
                User = $"{user.Login}"
            };
        }

        public async Task Register(UserDto dto)
        {
            var alg = SHA512.Create();
            alg.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
            var pwdhash = Convert.ToBase64String(alg.Hash);
            
            var user = new User()
            {
                Login = dto.Login,
                PasswordHash = pwdhash
            };
            
            await _userRepo.Add(user);
        }
    }
}