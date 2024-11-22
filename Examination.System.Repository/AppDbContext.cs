using Examination.System.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Examination.System.Repository;

public class AppDbContext : DbContext
{
    //public DbSet<User> Users { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<InstructorCourse> InstructorCourses { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<FinalExam> FinalExams { get; set; }
    public DbSet<QuizExam> QuizExams { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<StudentExamQuestion> StudentExamQuestions { get; set; }
    public DbSet<Choice> Choices { get; set; }
    public DbSet<StudentExam> StudentExams { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .LogTo(log => Console.WriteLine(log), LogLevel.Information)
        .EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().UseTpcMappingStrategy();

        modelBuilder.Entity<Exam>()
            .HasDiscriminator(e => e.ExamType)
            .HasValue<FinalExam>("Final")
            .HasValue<QuizExam>("Quiz");

        modelBuilder.Entity<Exam>().Property(e => e.Score).HasColumnType("decimal(16,2)");
        modelBuilder.Entity<StudentExamQuestion>().Property(seq => seq.Score).HasColumnType("decimal(16,2)");
        modelBuilder.Entity<Instructor>().Property(i => i.Salary).HasColumnType("decimal(16,2)");

        modelBuilder.Entity<InstructorCourse>().HasIndex(ic => new { ic.InstructorId, ic.CourseId }).IsUnique();

        modelBuilder.Entity<StudentCourse>().HasIndex(sc => new { sc.StudentId, sc.CourseId }).IsUnique();

        modelBuilder.Entity<StudentExam>().HasIndex(se => new { se.ExamId, se.StudentId }).IsUnique();

        modelBuilder.Entity<StudentExamQuestion>().HasIndex(seq => new { seq.ExamId, seq.StudentId }).IsUnique();

        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique().HasFilter($"[{nameof(User.IsDeleted)}]=0");

        #region MyRegion

        //modelBuilder.Entity<BaseModel>().HasQueryFilter(b => !b.IsDeleted);
        //modelBuilder.Entity<Exam>().HasQueryFilter(b => !b.IsDeleted);
        //modelBuilder.Entity<User>().HasQueryFilter(b => !b.IsDeleted);
        //modelBuilder.Entity<StudentExamQuestion>().HasQueryFilter(b => !b.IsDeleted);


        //// Configure the discriminator
        //modelBuilder.Entity<Exam>()
        //    .HasDiscriminator(e => e.ExamType)
        //    .HasValue<QuizExam>(ExamType.Quiz)
        //    .HasValue<FinalExam>(ExamType.Final);

        //// Additional configurations
        //modelBuilder.Entity<Exam>()
        //    .Property(e => e.Title)
        //    .IsRequired()
        //    .HasMaxLength(200);

        //modelBuilder.Entity<Exam>()
        //    .Property(e => e.ExamType)
        //    .HasConversion<string>() // Store enum as string
        //    .IsRequired();

        //modelBuilder.Entity<Exam>()
        //    .HasOne(e => e.Course)
        //    .WithMany(c => c.Exams)
        //    .HasForeignKey(e => e.CourseId);

        //// Set relationships for ExamQuestion and Result (if not done already)
        //modelBuilder.Entity<Exam>()
        //    .HasMany(e => e.ExamQuestions)
        //    .WithOne(eq => eq.Exam)
        //    .HasForeignKey(eq => eq.ExamId);

        //modelBuilder.Entity<Exam>()
        //    .HasMany(e => e.Results)
        //    .WithOne(r => r.Exam)
        //    .HasForeignKey(r => r.ExamId);

        //modelBuilder.Entity<StudentCourse>().HasIndex(sc => new
        //{
        //    sc.StudentId,
        //    sc.CourseId
        //}).IsUnique();
        #endregion
    }
}
