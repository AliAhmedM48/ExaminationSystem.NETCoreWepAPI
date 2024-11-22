namespace Examination.System.Core.Models;

public class StudentExamQuestion : BaseModel
{
    public int ExamId { get; set; }
    public Exam Exam { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int Order { get; set; }
    public decimal Score { get; set; }
    public string Feedback { get; set; }
}
