using CareerAPI.Application.Repositories;
using CareerAPI.Domain.Entities;
using CareerAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        readonly private ICategoryWriteRepository _categoryWriteRepository;
        readonly private ICategoryReadRepository _categoryReadRepository;

        public CategoryController(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository )
        {
            this._categoryWriteRepository = categoryWriteRepository;
            this._categoryReadRepository = categoryReadRepository;
        }

        /*[HttpGet]
        public async Task<IActionResult> Get()
        {
            
            return Ok(_categoryReadRepository.GetAll());
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
            Category category =  await _categoryReadRepository.GetByIdAsync(id);
            return Ok(category);
        }*/
        /*
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            await _categoryWriteRepository.RemoveAsync(id);
            await _categoryWriteRepository.SaveAsync();
            return Ok();
        }
        */
    }
}
