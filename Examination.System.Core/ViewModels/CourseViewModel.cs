namespace Examination.System.Core.ViewModels;

public class CourseViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DurationInHours { get; set; }
}

public class CourseCreateViewModel
{
    public string Name { get; set; }
    public int DurationInHours { get; set; }
}

public class CourseEditViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? DurationInHours { get; set; }
}