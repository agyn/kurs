using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Kurs.Shared.Api.Controllers;
using Kurs.Main.Logic.KursLogic;
using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Kurs.Main.Api.Controllers
{
    public class KursController : CrudController<IKursLogic<Currency>, Currency>
    {
        public KursController(IKursLogic<Currency> logic) : base(logic)
        { }

        [HttpPut]
        [Route("Add")]
        public async override Task<IActionResult> Add([FromBody] Currency entity)
        {
            try
            {
                entity.UserId = CurrentUserId;
                return Json(await Logic.Add(entity));
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> GetList(KursSearchDto dto)
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

        [AllowAnonymous]
        [HttpGet]
        [Route("SearchAll")]
        public async Task<IActionResult> SearchAll(KursSearchDto dto)
        {
            try
            {
                dto.UserId = CurrentUserId;
                return Ok(await Logic.SearchAll(dto));
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
