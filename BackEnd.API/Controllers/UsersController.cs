using BackEnd.API.Database;
using BackEnd.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.API.Controllers;

[Route("v1/[Controller]")]
[ApiController]
public sealed class UsersController(AppDbContext dbContext) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        await dbContext.Set<User>().AddAsync(user);
        await dbContext.SaveChangesAsync();
        return Ok(user);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] User user)
    {
        dbContext.Set<User>().Update(user);
        await dbContext.SaveChangesAsync();
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        User? user = await dbContext.Set<User>().FindAsync(id);

        if (user is null) 
        {
            return NotFound();
        }

        dbContext.Set<User>().Remove(user);
        await dbContext.SaveChangesAsync();
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await dbContext.Set<User>().AsNoTracking().ToListAsync());

    [HttpGet("id:{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await dbContext.Set<User>().FindAsync(id));

    [HttpGet("username:{username}")]
    public async Task<IActionResult> GetByUserName(string userName) => Ok(await dbContext.Set<User>().AsNoTracking().FirstAsync(user => user.UserName == userName));

    [HttpGet("email:{email}")]
    public async Task<IActionResult> GetByEmail(string email) => Ok(await dbContext.Set<User>().AsNoTracking().FirstAsync(user => user.Email == email));
}
