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

        [HttpPut]
        [Route("AddExchanger")]
        public async virtual Task<IActionResult> AddExchanger([FromBody] Exchanger entity)
        {
            entity.UserId = CurrentUserId;
            try
            {
                return Json(await Logic.Add(entity));
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> GetList(ExchangerSearchDto dto)
        {
            try
            {
                dto.UserId = CurrentUserId;
                return Ok(await Logic.GetList(dto));
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet]
        [Route("GetExchangers")]
        public async Task<IActionResult> GetExchangers()
        {
            try
            {
                
                return Ok(await Logic.GetExchangers(CurrentUserId));
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
