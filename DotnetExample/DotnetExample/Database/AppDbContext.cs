using Microsoft.EntityFrameworkCore;

namespace DotnetExample.Database;

// DbContext => reprezentarea bazei de date
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {}
}
