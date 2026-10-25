using Microsoft.EntityFrameworkCore;
using TutorManagment.API.Entities;

namespace TutorManagment.API.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Progress> Progresses { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasOne(l => l.StudentProfile);
            //.WithOne(s => s.User)         
            //.HasForeignKey<Student>(s => s.UserID);

        modelBuilder.Entity<Lesson>()
            .HasOne(l => l.Progress)
            .WithOne(p => p.Lesson)
            .HasForeignKey<Progress>(p => p.LessonID);

        modelBuilder.Entity<Student>()
            .HasMany(l => l.Lessons) 
            .WithOne(s => s.Student) 
            .HasForeignKey(s => s.StudentID);

        modelBuilder.Entity<Student>()
            .HasMany(p => p.Payments) 
            .WithOne(s => s.Student)         
            .HasForeignKey(s => s.StudentID);

    }
}
