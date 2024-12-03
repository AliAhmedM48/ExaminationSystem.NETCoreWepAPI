using Examination.System.Core.Entities.JoinEntities;

namespace Examination.System.Core.Entities.MainEntities;

public class Student : User
{
    public int? Age { get; set; }
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    public ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();
    public ICollection<InstructorStudentCourse> InstructorCourseStudents { get; set; } = new List<InstructorStudentCourse>();
    public ICollection<StudentExamQuestionChoice> StudentExamQuestionChoices { get; set; } = new List<StudentExamQuestionChoice>();

}
