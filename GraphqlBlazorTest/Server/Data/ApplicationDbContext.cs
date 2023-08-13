using GraphqlBlazorTest.Shared;
using Microsoft.EntityFrameworkCore;

namespace GraphqlBlazorTest.Server.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
}
