using Microsoft.EntityFrameworkCore;
using ThesisHub.Web.Models.Entities;

namespace ThesisHub.Web.Data
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
