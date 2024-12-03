namespace Examination.System.Repository;
public static class DataSeeder
{
    public static async Task SeedData(AppDbContext appDbContext)
    {
        await SeedInstructors(appDbContext);
        await SeedCourses(appDbContext);
        await SeedQuestions(appDbContext);
        await SeedChoices(appDbContext);
        await SeedExams(appDbContext);
        await SeedStudents(appDbContext);
    }

    private static async Task SeedInstructors(AppDbContext appDbContext)
    {
        //if (appDbContext.Instructors.Any()) return;

        //var faker = new Faker<Instructor>()
        //      .RuleFor(i => i.FullName, f => f.Name.FullName())
        //      .RuleFor(i => i.Email, f => f.Internet.Email())
        //      .RuleFor(i => i.PhoneNumber, f => f.Phone.PhoneNumberFormat(0))
        //      .RuleFor(i => i.Salary, f => f.Finance.Amount(10000, 50000, 0))
        //      .RuleFor(i => i.CreatedAt, f => f.Date.Between(new DateTime(2015, 01, 01), new DateTime(2024, 09, 01)))
        //      .RuleFor(i => i.PasswordHash, f => f.Internet.Password(8));


        //var instructors = faker.Generate(5);
        //await appDbContext.Instructors.AddRangeAsync(instructors);
        //await appDbContext.SaveChangesAsync();
    }

    private static async Task SeedCourses(AppDbContext appDbContext)
    {
        //if (appDbContext.Courses.Any()) return;


        //var faker = new Faker<Course>()
        //    .RuleFor(c => c.Name, f => f.Lorem.Word())
        //    .RuleFor(c => c.Hours, f => f.Random.Int(10, 50))
        //    .RuleFor(c => c.CreatedAt, f => f.Date.Between(new DateTime(2015, 01, 01), DateTime.Now));
        //var courses = faker.Generate(10);
        //await appDbContext.Courses.AddRangeAsync(courses);
        //await appDbContext.SaveChangesAsync();
    }

    private static async Task SeedQuestions(AppDbContext appDbContext)
    {
        //if (appDbContext.Questions.Any()) return;

        //var faker = new Faker<Question>()
        //    .RuleFor(q => q.Body, f => f.Lorem.Sentence(10))
        //    .RuleFor(q => q.Grade, f => f.Random.Int(1, 10))
        //    .RuleFor(q => q.Difficulty, f => f.PickRandom<DifficultyLevel>())
        //    .RuleFor(q => q.CreatedAt, f => f.Date.Between(new DateTime(2015, 01, 01), DateTime.Now));

        //var questions = faker.Generate(50);
        //await appDbContext.Questions.AddRangeAsync(questions);
        //await appDbContext.SaveChangesAsync();
    }

    private static async Task SeedChoices(AppDbContext appDbContext)
    {
        //if (appDbContext.Choices.Any()) return;

        //var questionIds = appDbContext.Questions.Select(q => q.Id).ToList();

        //var faker = new Faker<Choice>()
        //    .RuleFor(c => c.Text, f => f.Lorem.Sentence(3))
        //    .RuleFor(c => c.IsCorrect, f => f.Random.Bool(0.25f)) // 25% chance of being correct
        //    .RuleFor(c => c.QuestionId, f => f.PickRandom(questionIds))
        //    .RuleFor(c => c.CreatedAt, f => f.Date.Between(new DateTime(2015, 01, 01), DateTime.Now));

        //var choices = faker.Generate(200); // Generate multiple choices per question
        //await appDbContext.Choices.AddRangeAsync(choices);
        //await appDbContext.SaveChangesAsync();
    }

    private static async Task SeedExams(AppDbContext appDbContext)
    {
        //if (!appDbContext.Exams.OfType<FinalExam>().Any())
        //{
        //    var fakerFinal = new Faker<FinalExam>()
        //   .RuleFor(e => e.Title, f => f.Lorem.Sentence(5))
        //   .RuleFor(e => e.MaxGrade, f => f.Random.Int(100, 200))
        //   .RuleFor(e => e.MaxTime, f => f.Random.Int(120, 180))
        //   .RuleFor(e => e.Date, f => f.Date.Future())
        //   .RuleFor(e => e.CourseId, (fakerFinal, f) => f.CourseId = fakerFinal.PickRandom(appDbContext.Courses.Select(c => c.Id).FirstOrDefault()));
        //    var finalExams = fakerFinal.Generate(5);
        //    await appDbContext.Exams.AddRangeAsync(finalExams);
        //}

        //if (!appDbContext.Exams.OfType<QuizExam>().Any())
        //{
        //    var fakerQuiz = new Faker<QuizExam>()
        //  .RuleFor(e => e.Title, f => f.Lorem.Sentence(3))
        //  .RuleFor(e => e.MaxGrade, f => f.Random.Int(50, 100))
        //  .RuleFor(e => e.MaxTime, f => f.Random.Int(30, 60))
        //  .RuleFor(e => e.Date, f => f.Date.Future())
        //  .RuleFor(e => e.CourseId, (fakerQuiz, f) => f.CourseId = fakerQuiz.PickRandom(appDbContext.Courses.Select(c => c.Id).FirstOrDefault()));
        //    var quizExams = fakerQuiz.Generate(10);
        //    await appDbContext.Exams.AddRangeAsync(quizExams);
        //}

        //await appDbContext.SaveChangesAsync();
    }
    private static async Task SeedStudents(AppDbContext appDbContext)
    {
        //if (appDbContext.Students.Any()) return;

        //var faker = new Faker<Student>()
        //    .RuleFor(s => s.FullName, f => f.Name.FullName())
        //    .RuleFor(s => s.PhoneNumber, f => f.Phone.PhoneNumber())
        //    .RuleFor(s => s.Email, f => f.Internet.Email())
        //    .RuleFor(s => s.PasswordHash, f => f.Internet.Password(8)) // Example password hash
        //    .RuleFor(s => s.Level, f => f.Random.Int(0, 100)) // Grade out of 100
        //    .RuleFor(s => s.Age, f => f.Random.Int(18, 30)) // Age range for students
        //    .RuleFor(s => s.CreatedAt, f => f.Date.Between(new DateTime(2015, 01, 01), DateTime.Now)); // Optional, if BaseModel has CreatedAt

        //// Generate 20 students
        //var students = faker.Generate(20);

        //// Add to database
        //await appDbContext.Students.AddRangeAsync(students);
        //await appDbContext.SaveChangesAsync();
    }

}
