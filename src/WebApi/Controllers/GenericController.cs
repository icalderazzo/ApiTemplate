using AutoMapper;
using Core.Domain;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.Responses;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TDomain, TResponse> : ControllerBase 
        where TDomain : BaseModel 
        where TResponse : BaseResponse 
    {
        protected readonly IService<TDomain> _service;
        protected ILogger<TDomain> _logger;
        protected IMapper _mapper;

        public GenericController(
            IService<TDomain> service,
            ILogger<TDomain> logger,
            IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TDomain model)
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
        public async Task<IActionResult> Update(int id, TDomain model)
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
        public async Task<IActionResult> UpdatePartial(int id, TDomain model)
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
        public async Task<ActionResult<TDomain>> Get(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                
                if(result == null) return NotFound();

                return Ok(_mapper.Map<TResponse>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TDomain>>> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(_mapper.Map<List<TResponse>>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}