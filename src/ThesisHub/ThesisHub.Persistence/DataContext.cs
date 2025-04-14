using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThesisHub.Domain.Entities;

namespace ThesisHub.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Student & Department config
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Tutor & Department config
            modelBuilder.Entity<Tutor>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Tutors)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Project config

            var projectStatusConverter = new ValueConverter<ProjectStatusEnum, string>(
                v => v.ToString(),
                v => (ProjectStatusEnum)System.Enum.Parse(typeof(ProjectStatusEnum), v)
            );

            modelBuilder.Entity<Project>()
                .Property(p => p.ProjectStatus)
                .HasConversion(projectStatusConverter)
                .HasMaxLength(20);

            // Project & Student config
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Projects)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
