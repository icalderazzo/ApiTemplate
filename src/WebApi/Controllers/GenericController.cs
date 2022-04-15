using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<T> : ControllerBase
    {
        protected readonly IService<T> _service;
        protected ILogger<T> _logger;

        public GenericController(
            IService<T> service,
            ILogger<T> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(T model)
        {
            try
            {
                await _service.CreateAsync(model);
                return Created("", model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, T model)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                if(entity == null) return NotFound();

                await _service.UpdateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartial(int id, T model)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                if(entity == null) return NotFound();

                await _service.UpdateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);   
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                if(entity == null) return NotFound();

                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                
                if(result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<T>>> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}