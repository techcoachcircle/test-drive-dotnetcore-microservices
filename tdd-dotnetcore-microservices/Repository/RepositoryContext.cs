using Microsoft.EntityFrameworkCore;
using tdd_dotnetcore_microservices.Models;

namespace tdd_dotnetcore_microservices.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options):base(options){ }

        public DbSet<Employee> Employees { get; set; }
    }
}
