using Examination.System.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination.System.Api.Data;

public class AppDbContext : DbContext
{
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Database=ExaminationSystem; Trusted_Connection=True; TrustServerCertificate=True")
        .LogTo(log => Console.WriteLine(log), LogLevel.Information)
        .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
