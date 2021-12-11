using DotnetExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetExample.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
}