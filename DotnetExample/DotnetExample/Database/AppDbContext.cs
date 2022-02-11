using DotnetExample.Cars;
using DotnetExample.Teams;
using DotnetExample.Users;
using Microsoft.EntityFrameworkCore;

namespace DotnetExample.Database;

// DbContext => reprezentarea bazei de date
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {}

    // DbSet => reprezentarea unui tabel
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Team> Teams { get; set; }
}
