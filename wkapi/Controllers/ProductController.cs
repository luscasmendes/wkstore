using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wkapi.Data;
using wkapi.Models;

namespace wkapi.Controllers
{

    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.Include(x => x.Category).ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            var product = await context.Products
                                .Include(x => x.Category)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post([FromServices] DataContext context, [FromBody]Product model)
        {
            if (ModelState.IsValid) {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            } 

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> Delete([FromServices] DataContext context, int id)
        {
            if (ModelState.IsValid) {
                var product = await context.Products
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return product;
            } 

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> Put([FromServices] DataContext context, int id, [FromBody]Product model)
        {
            if (ModelState.IsValid) {
                var product = await context.Products
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);

                if (product != null) {
                    context.Products.Add(model);
                    context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return product;
                }

                
                return BadRequest(ModelState);
            } 

            return BadRequest(ModelState);
        }

    

    }
}