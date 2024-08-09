using BackEnd.API.Database;
using BackEnd.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.API.Controllers;

[Route("v1/[Controller]")]
[ApiController]
public sealed class ProductsController(AppDbContext dbContext) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        await dbContext.Set<Product>().AddAsync(product);
        await dbContext.SaveChangesAsync();
        return Ok(product);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Product product)
    {
        dbContext.Set<Product>().Update(product);
        await dbContext.SaveChangesAsync();
        return Ok(product); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Product? product = await dbContext.Set<Product>().FindAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        dbContext.Remove(product);
        await dbContext.SaveChangesAsync();
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await dbContext.Set<Product>().AsNoTracking().ToListAsync());

    [HttpGet("id:{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await dbContext.Set<Product>().FindAsync(id));

    [HttpGet("name:{name}")]
    public async Task<IActionResult> GetByName(string name) => 
        Ok(await dbContext.Set<Product>().AsNoTracking().FirstOrDefaultAsync(product => product.Name == name));
}
