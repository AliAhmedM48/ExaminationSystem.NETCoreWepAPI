using Examination.System.Core.ViewModels;
using FluentValidation;

namespace Examination.System.Core.Validation.Validators;

public class CourseCreateViewModelValidator : AbstractValidator<CourseCreateViewModel>
{
    public CourseCreateViewModelValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Course name is required.")
            .Length(3, 100).WithMessage("Course name must be between 3 and 100 characters.");

        RuleFor(c => c.DurationInHours)
            .InclusiveBetween(1, 1000).WithMessage("Duration in hours must be between 1 and 1000.");
    }
}

public class CourseEditViewModelValidator : AbstractValidator<CourseEditViewModel>
{
    public CourseEditViewModelValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Course name is required.")
            .Length(3, 100).WithMessage("Course name must be between 3 and 100 characters.");

        RuleFor(c => c.DurationInHours)
            .InclusiveBetween(1, 1000).WithMessage("Duration in hours must be between 1 and 1000.");
    }
}


