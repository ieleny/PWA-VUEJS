using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCore;
using AspNetCore.Model;

namespace AspNetCore.Controllers
{
  [Route("api/products")]
  [ApiController]
  public class ProductController : ControllerBase
  {
      private readonly ApplicationDbContext _dbContext;

      public ProductController(ApplicationDbContext dbContext)
      {
        _dbContext = dbContext;
      }

      [HttpGet("all")]
      public async Task<ActionResult<List<Product>>> Get()
      {
        return await _dbContext.Products.ToListAsync();
      }

      [HttpGet("search/{id}")]
      public async Task<ActionResult<Product>> Search(string id)
      {
        return await _dbContext.Products.FindAsync(id);
      }

      [HttpPost("insert")]
      public async Task Insert ([FromForm] Product model)
      {

        await _dbContext.AddAsync(model);
        
        await _dbContext.SaveChangesAsync();

      }

      [HttpDelete("delete/{id}")]
      public async Task<ActionResult> Delete(string id)
      {

        var entity = await _dbContext.Products.FindAsync(id);

        _dbContext.Products.Remove(entity);
        
        await _dbContext.SaveChangesAsync();
        
        return Ok();

      }

      [HttpPut("update/{id}")]
      public async Task<IActionResult> Put(string id, Product model)
      {

        var exists = await _dbContext.Products.AnyAsync(f => f.Id == id);

        if (!exists)
        {
          return NotFound();
        }

        _dbContext.Products.Update(model);
        
        await _dbContext.SaveChangesAsync();

        return Ok();

      }



  }

}