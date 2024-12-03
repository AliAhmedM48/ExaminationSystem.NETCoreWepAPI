using Examination.System.Core.Entities.JoinEntities;
using Examination.System.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination.System.Core.Entities.MainEntities;

public class Exam : BaseModel
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
    public Course Course { get; set; }


    [NotMapped]
    public int InstructorId { get; set; }

    [NotMapped]
    public Instructor Instructor { get; set; }



    [NotMapped]
    public ICollection<StudentExam> StudentExams { get; set; }
    [NotMapped]
    public ICollection<ExamQuestion> ExamQuestions { get; set; }
}

public class QuizExam : Exam
{

}

public class FinalExam : Exam
{
}