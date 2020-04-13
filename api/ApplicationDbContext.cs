using Microsoft.EntityFrameworkCore;
using AspNetCore.Model;

namespace AspNetCore 
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Product> Products { get; set; }
    
  }
}