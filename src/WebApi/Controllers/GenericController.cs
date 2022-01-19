using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class GenericController<T> : ControllerBase
    {
        protected readonly IService<T> _service;

        public GenericController(IService<T> service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(T model)
        {
            try
            {
                _service.Create(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(T model)
        {
            try
            {
                _service.Update(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<T> Get(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<T>> GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}