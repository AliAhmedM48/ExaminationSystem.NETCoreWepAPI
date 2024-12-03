using Examination.System.Core.Entities.MainEntities;
using Examination.System.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Examination.System.Repository;

public class AppDbContext : DbContext
{
    private readonly ILogger<AppDbContext> _logger;

    public DbSet<Course> Courses { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<QuizExam> QuizExams { get; set; }
    public DbSet<FinalExam> FinalExams { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Choice> Choices { get; set; }

    //public DbSet<User> Users { get; set; }
    //public DbSet<Instructor> Instructors { get; set; }
    //public DbSet<Student> Students { get; set; }
    //public DbSet<StudentCourse> StudentCourses { get; set; }
    //public DbSet<InstructorCourse> InstructorCourses { get; set; }
    //public DbSet<StudentExamQuestionChoice> StudentExamQuestions { get; set; }
    //public DbSet<StudentExam> StudentExams { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options, ILogger<AppDbContext> logger) : base(options)
    {
        _logger = logger;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        optionsBuilder.EnableSensitiveDataLogging().LogTo(log => _logger.LogInformation(log), LogLevel.Information);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Course - Exam [One-to-Many]
        modelBuilder.Entity<Course>()
            .HasMany(c => c.Exams)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Exam>(Entity =>
            {
                Entity.UseTphMappingStrategy()
                    .HasDiscriminator(e => e.ExamType)
                    .HasValue<Exam>(ExamType.Base)
                    .HasValue<FinalExam>(ExamType.Final)
                    .HasValue<QuizExam>(ExamType.Quiz);

                Entity.Property(q => q.DifficultyLevel).HasConversion(q => q.ToString(), q => (DifficultyLevel)Enum.Parse(typeof(DifficultyLevel), q));
                Entity.Property(e => e.ExamType).HasConversion(et => et.ToString(), et => (ExamType)Enum.Parse(typeof(ExamType), et));
                Entity.Property(e => e.DurationInMinutes).HasColumnType("decimal(16,2)");
            });

        modelBuilder.Entity<Question>(Entity =>
        {
            Entity.Property(q => q.DifficultyLevel).HasConversion(q => q.ToString(), q => (DifficultyLevel)Enum.Parse(typeof(DifficultyLevel), q));
            Entity.HasMany(q => q.Choices).WithOne(q => q.Question).HasForeignKey(q => q.QuestionId).OnDelete(DeleteBehavior.Cascade);
            Entity.HasOne(q => q.CorrectChoice).WithOne().HasForeignKey<Question>(q => q.CorrectChoiceId);
        });

        //modelBuilder.Entity<User>().UseTpcMappingStrategy();


        //modelBuilder.Entity<StudentExamQuestionChoice>().Property(seq => seq.Score).HasColumnType("decimal(16,2)");
        //modelBuilder.Entity<Instructor>().Property(i => i.Salary).HasColumnType("decimal(16,2)");

        //modelBuilder.Entity<InstructorCourse>().HasIndex(ic => new { ic.InstructorId, ic.CourseId }).IsUnique();

        //modelBuilder.Entity<StudentCourse>().HasIndex(sc => new { sc.StudentId, sc.CourseId }).IsUnique();

        //modelBuilder.Entity<StudentExam>().HasIndex(se => new { se.ExamId, se.StudentId }).IsUnique();

        //modelBuilder.Entity<StudentExamQuestionChoice>().HasIndex(seq => new { seq.ExamId, seq.StudentId }).IsUnique();

        //modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique().HasFilter($"[{nameof(User.IsDeleted)}]=0");

        #region HasQueryFilter
        //modelBuilder.Entity<BaseModel>().HasQueryFilter(b => !b.IsDeleted);
        //modelBuilder.Entity<Exam>().HasQueryFilter(b => !b.IsDeleted);
        //modelBuilder.Entity<User>().HasQueryFilter(b => !b.IsDeleted);
        //modelBuilder.Entity<StudentExamQuestion>().HasQueryFilter(b => !b.IsDeleted);
        #endregion
    }
}
