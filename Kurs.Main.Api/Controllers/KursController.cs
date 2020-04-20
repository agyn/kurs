using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Kurs.Shared.Api.Controllers;
using Kurs.Main.Logic.KursLogic;
using Kurs.Shared.Data.Context;

namespace Kurs.Main.Api.Controllers
{
    public class KursController : CrudController<IKursLogic<Currency>, Currency>
    {
        public KursController(IKursLogic<Currency> logic) : base(logic)
        { }

        [HttpGet]
        [Route("GetList")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                return Ok(await Logic.GetList());
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
