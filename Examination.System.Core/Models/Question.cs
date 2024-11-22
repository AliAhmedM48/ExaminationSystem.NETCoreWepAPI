namespace Examination.System.Core.Models;

public class Question : BaseModel
{
    public string Body { get; set; }
    public int Grade { get; set; }
    public DifficultyLevel Difficulty { get; set; }
    public ICollection<StudentExamQuestion> ExamQuestions { get; set; } = new List<StudentExamQuestion>();
    public ICollection<Choice> Choices { get; set; } = new List<Choice>();

}
