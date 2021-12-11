using DotnetExample.Models;
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
}
