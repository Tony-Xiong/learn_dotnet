using Microsoft.EntityFrameworkCore;
using WebApiDemo.Domains;

namespace WebApiDemo.Domains;

public class InMemoryContext : DbContext
{
    public InMemoryContext(DbContextOptions<InMemoryContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
    
    public DbSet<DmBook> Books { get; set; } = null!;
    
    public DbSet<WebApiDemo.Domains.Movie> Movie { get; set; }
}