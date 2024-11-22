namespace Examination.System.Core.ViewModels.Instructors;

public class InstructorViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

//public static class InstructorViewModelExtensions
//{
//    public static InstructorViewModel ToViewModel(this Instructor viewModel)
//    {

//        if (viewModel is null) return null;

//        return new InstructorViewModel()
//        {
//            Id = viewModel.Id,
//            Name = viewModel.FullName,
//        };
//    }
//    public static IEnumerable<InstructorViewModel> ToViewModel(this IQueryable<Instructor> instructors)
//    {
//        return instructors.Select(x => new InstructorViewModel()
//        {
//            Id = x.Id,
//            Name = x.FullName,
//        });
//    }
//}