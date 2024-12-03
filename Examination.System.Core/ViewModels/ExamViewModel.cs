using Examination.System.Core.Enums;

namespace Examination.System.Core.ViewModels;

public class ExamViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal DurationInMinutes { get; set; }
    public int NoOfQuestions { get; set; }
    public int ScorePerQuestion { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public ExamType ExamType { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public string CourseTitle { get; set; }
}

public class ExamCreateViewModel
{
    public string Title { get; set; }
    public decimal DurationInMinutes { get; set; }
    public int NoOfQuestions { get; set; }
    public int ScorePerQuestion { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public ExamType ExamType { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public int CourseId { get; set; }

}

public class ExamEditViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal DurationInMinutes { get; set; }
    public int NoOfQuestions { get; set; }
    public int ScorePerQuestion { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public ExamType ExamType { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public int CourseId { get; set; }
}
