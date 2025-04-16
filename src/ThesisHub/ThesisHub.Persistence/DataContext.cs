using Microsoft.EntityFrameworkCore;
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
        public DbSet<Project> ProjectTutors { get; set; }
        public DbSet<Document> Documents { get; set; }

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

            // Project & Student config
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Projects)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProjectTutors & Project config
            modelBuilder.Entity<ProjectTutor>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTutors)
                .HasForeignKey(pt => pt.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProjectTutors & Tutor config
            modelBuilder.Entity<ProjectTutor>()
                .HasOne(pt => pt.Tutor)
                .WithMany(t => t.ProjectTutors)
                .HasForeignKey(pt => pt.TutorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Document & Project config
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Project)
                .WithMany(p => p.Documents)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
