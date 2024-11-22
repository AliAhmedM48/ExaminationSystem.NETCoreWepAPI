namespace Examination.System.Core.Models;

public class Exam : BaseModel
{
    public string Title { get; set; }
    public int? MaxGrade { get; set; }
    public int? MaxTime { get; set; }
    public DateTime? Date { get; set; }

    public int? CourseId { get; set; } // FK
    public Course Course { get; set; }

    public string? ExamType { get; set; }
    public decimal? Score { get; set; }
    public string? Feedback { get; set; }
    public ICollection<StudentExamQuestion> ExamQuestions { get; set; } = new List<StudentExamQuestion>();
    public ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();
}

public class QuizExam : Exam
{
}

public class FinalExam : Exam
{
}