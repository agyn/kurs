using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Kurs.Shared.Api.Controllers;
using Kurs.Shared.Data.Context;
using Kurs.Admin.Logic.CityLogic;
using Kurs.Shared.Data.Dtos;

namespace Kurs.Main.Api.Controllers
{
    public class CityController : CrudController<ICityLogic<City>, City>
    {
        public CityController(ICityLogic<City> logic) : base(logic)
        { }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> GetList(CitySearchDto dto)
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

        [HttpGet]
        [Route("GetCities")]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                return Ok(await Logic.GetCities());
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

    }
}
