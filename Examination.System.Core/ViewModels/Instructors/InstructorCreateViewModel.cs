namespace Examination.System.Core.ViewModels.Instructors;

public class InstructorCreateViewModel
{
    public string Name { get; set; }
    public string Mobile { get; set; }
}

//public static class InstructorCreateViewModelExtensions
//{
//    public static Instructor ToModel(this InstructorCreateViewModel viewModel)
//    {
//        return new Instructor()
//        {
//            FullName = viewModel.Name,
//            PhoneNumber = viewModel.Mobile,
//            CreatedAt = DateTime.Now
//        };
//    }
//}

