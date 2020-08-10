using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wkapi.Data;
using wkapi.Models;

namespace wkapi.Controllers
{

    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById([FromServices] DataContext context, int id)
        {
            var category = await context.Categories
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post([FromServices] DataContext context, [FromBody]Category model)
        {
            if (ModelState.IsValid) {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return model;
            } 

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Delete([FromServices] DataContext context, int id)
        {
            if (ModelState.IsValid) {
                var category = await context.Categories
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return category;
            } 

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Put([FromServices] DataContext context, int id, [FromBody]Category model)
        {
            if (ModelState.IsValid) {
                var category = await context.Categories
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);

                if (category != null) {
                    context.Categories.Add(model);
                    context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return category;
                }

                
                return BadRequest(ModelState);
            } 

            return BadRequest(ModelState);
        }

    }
}