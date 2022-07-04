using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext :DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            :base(options) 
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Student;User Id=sa;Password=my!Password;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StudentCourse>().HasKey(x => new
            {
                x.StudentId,
                x.CourseId
            });


            modelBuilder.Entity<Student>(x =>
            {
                x.Property(x => x.Name).IsUnicode(true);
                x.Property(x => x.PhoneNumber).IsUnicode(false);
            });

            modelBuilder.Entity<Course>(x =>
            {
                x.Property(x => x.Name).IsUnicode(true);
                x.Property(x => x.Description).IsUnicode(true);
            });

            modelBuilder.Entity<Resource>(x =>
            {
                x.Property(x => x.Name).IsUnicode(true);
                x.Property(x => x.Url).IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(x =>
            {
                x.Property(x => x.Content).IsUnicode(false);
            });


            // This describes the one-to-many model. One student has multiple courses or homework and one course has many students
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<Homework>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<Resource>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<Homework>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(sc => sc.CourseId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
