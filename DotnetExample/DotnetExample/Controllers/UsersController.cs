using DotnetExample.Database;
using DotnetExample.Models;
using DotnetExample.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetExample.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    // Dependency Injection
    public UsersController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<User> Post(UserRequest entity)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Username = entity.Username,
            Email = entity.Email
        };

        var result = await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    [HttpPost("{id}/cars")]
    public async Task<Car> PostCar([FromRoute] string id, [FromBody] CarRequest entity)
    {
        var owner = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (owner is null)
        {
            throw new ArgumentException("User not found");
        }

        var car = new Car
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Owner = owner,
            Name = entity.Name,
            Color = entity.Color
        };

        var result = await _dbContext.Cars.AddAsync(car);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    [HttpGet("cars")]
    public async Task<List<Car>> GetCars()
    {
        // .Include joins two tables
        var queryable = _dbContext.Cars.Include(car => car.Owner);
        return await queryable.ToListAsync();
    }
}
