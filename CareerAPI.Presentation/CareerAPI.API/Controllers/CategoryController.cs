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

        [HttpGet]

        public async Task Get()
        {

            // Manuel veri ekleme işlemi
            /*
            await _categoryWriteRepository.AddRangeAsync(new() 
            {
                
            new() { Id = Guid.NewGuid(), CategoryName = "Yazılım", CreatedDate= DateTime.UtcNow  },
            new() { Id = Guid.NewGuid(), CategoryName = "Veritabanı", CreatedDate = DateTime.UtcNow },
            new() { Id = Guid.NewGuid(), CategoryName = "Animasyon", CreatedDate = DateTime.UtcNow },
            }); 

            await _categoryWriteRepository.SaveAsync();*/

            //Tracking İşlemi
            /*
           Category c = await _categoryReadRepository.GetByIdAsync("4e796cd6-e868-4002-9182-d0dc5f102c97" , false);
            c.CategoryName = "Yazılım";
            await _categoryWriteRepository.SaveAsync();*/
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
            Category category =  await _categoryReadRepository.GetByIdAsync(id);
            return Ok(category);
        }
    }
}
