using Microsoft.EntityFrameworkCore;
using ThesisHub.Domain.Entities;

namespace ThesisHub.Persistence
{
    public class ThesisHubContext : DbContext
    {
        public ThesisHubContext(DbContextOptions<ThesisHubContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
    }
}
