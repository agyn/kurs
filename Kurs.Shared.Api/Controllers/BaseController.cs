using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Kurs.Shared.Api.Controllers
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    [AllowAnonymous]
    [Route("[controller]")]
    public class BaseController : Controller
    {
        private int _userId = 0;

        protected int CurrentUserId
        {
            get
            {
                if (_userId != 0) return _userId;

                var claimValue = User
                    .Claims
                    .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?
                    .Value;
                
                if (claimValue == null)
                {
                    return _userId;
                }
                _userId = int.Parse(claimValue);

                return _userId;
            }
        }

        protected IActionResult ExceptionResult(Exception ex, object args = null)
        {
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var msg = $"{controllerName} {actionName} {ex.Message}";

            if (ex is ArgumentException)
            {
                //#if DEBUG
                return BadRequest(ex.Message);
                //#else
                //            return BadRequest(msg);
                //#endif
            }

            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
#if DEBUG
            return Json(ex);
#else
            return Json(msg);
#endif
        }

        protected IActionResult ExceptionResult(Exception ex, params object[] args)
        {
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var msg = $"{controllerName} {actionName} {ex.Message}";

            if (ex is ArgumentException)
            {
                //#if DEBUG
                return BadRequest(ex);
                //#else
                //            return BadRequest(msg);
                //#endif
            }

            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
#if DEBUG
            return Json(ex);
#else
            return Json(msg);
#endif
        }
    }
}