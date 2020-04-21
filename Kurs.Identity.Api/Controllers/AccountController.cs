using System;
using System.Threading.Tasks;
using Kurs.Identity.Logic;
using Kurs.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kurs.Identity.Data.Model;

namespace Kurs.Identity.Api.Controllers
{
    
    public class AccountController : BaseController
    {
        private readonly IAccountingLogic _accountingLogic;
        public AccountController(IAccountingLogic accountingLogic)
        {
            _accountingLogic = accountingLogic;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var aa = CurrentUserId;
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                return Json(await _accountingLogic.Login(dto));
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _accountingLogic.Register(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        
        /// <summary>
        /// Обновление токена(refrech_Token)
        /// </summary>
        /// <returns></returns>
        [HttpGet("refresh")]
        public async Task<IActionResult> Refresh()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                return Json(await _accountingLogic.UpdateToken(CurrentUserId));
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex, CurrentUserId);
            }
        }
        
    }
}