public class InstructorEditViewModel // : InstructorCreateViewModel
{
    public int Id { get; set; }
}

//public static class InstructorEditViewModelExtensions
//{
//    public static Instructor ToModel(this InstructorEditViewModel viewModel)
//    {
//        var instructor = InstructorCreateViewModelExtensions.ToModel(viewModel);
//        instructor.Id = viewModel.Id;
//        return instructor;
//    }
//}
