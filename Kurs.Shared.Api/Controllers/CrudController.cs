using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kurs.Shared.Logic;

namespace Kurs.Shared.Api.Controllers
{
    public class CrudController<TILogic, TEntity> : BaseController where TILogic : IBaseCrudLogic<TEntity>
    {
        protected TILogic Logic { get; set; }
        public CrudController(TILogic logic)
        {
            Logic = logic;
        }

        [HttpPut]
        [Route("Add")]
        public async virtual Task<IActionResult> Add([FromBody] TEntity entity)
        {
            try
            {
                return Json(await Logic.Add(entity));
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await Logic.Delete(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] TEntity entity)
        {
            try
            {
                await Logic.Update(entity);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await Logic.GetById(id));
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }


    }
}
