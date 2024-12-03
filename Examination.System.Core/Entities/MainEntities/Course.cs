using Examination.System.Core.Entities.JoinEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination.System.Core.Entities.MainEntities;

public class Course : BaseModel
{
    public string Name { get; set; }
    public int DurationInHours { get; set; }

    public ICollection<Exam> Exams { get; set; }

    [NotMapped]
    public ICollection<InstructorCourse> InstructorCourses { get; set; }
    [NotMapped]
    public ICollection<StudentCourse> StudentCourses { get; set; }
    [NotMapped]
    public ICollection<InstructorStudentCourse> InstructorCourseStudents { get; set; }

}
