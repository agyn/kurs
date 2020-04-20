using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Kurs.Shared.Api.Controllers;
using Kurs.Shared.Data.Context;
using Kurs.Main.Logic.ExchangerLogic;
using Kurs.Shared.Data.Dtos;

namespace Kurs.Main.Api.Controllers
{
    public class ExchangerController : CrudController<IExchangerLogic<Exchanger>, Exchanger>
    {
        public ExchangerController(IExchangerLogic<Exchanger> logic) : base(logic)
        { }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> GetList(ExchangerSearchDto dto)
        {
            try
            {
                return Ok(await Logic.GetList(dto));
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
