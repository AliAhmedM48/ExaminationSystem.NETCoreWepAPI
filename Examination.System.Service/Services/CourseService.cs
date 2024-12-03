using Examination.System.Core.Entities.MainEntities;
using Examination.System.Core.Enums.Response;
using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Core.Interfaces.Services.MainEntities;
using Examination.System.Core.ViewModels;
using Examination.System.Core.ViewModels.Response;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Examination.System.Service.Services;

public class CourseService : ICourseService
{
    private readonly IRepository<Course> _repository;
    private readonly IValidator<CourseCreateViewModel> _validatorForCreation;
    private readonly IValidator<CourseEditViewModel> _validatorForEditing;
    private readonly ILogger<CourseService> _logger;

    public CourseService(IRepository<Course> repository,
        IValidator<CourseCreateViewModel> validatorForCreation,
        IValidator<CourseEditViewModel> validatorForEditing,
        ILogger<CourseService> logger)
    {
        _repository = repository;
        _validatorForCreation = validatorForCreation;
        _validatorForEditing = validatorForEditing;
        _logger = logger;
    }

    public async Task<ResponseViewModel<CourseViewModel>> CreateAsync(CourseCreateViewModel courseCreateViewModel)
    {
        if (courseCreateViewModel == null)
        {
            _logger.LogError("Attempted to create a course with null data.");
            throw new ArgumentNullException(nameof(courseCreateViewModel), "The course creation data cannot be null. Provide valid input.");
        }

        var validationResult = await _validatorForCreation.ValidateAsync(courseCreateViewModel);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(e => new ValidationError(e.PropertyName, e.ErrorMessage)).ToList();
            return new FailureResponseViewModel<CourseViewModel>(BusinessErrorCode.ValidationError, BusinessErrorMessage.GetMessage(BusinessErrorCode.ValidationError), validationErrors);
        }

        var course = courseCreateViewModel.Map<Course>();
        await _repository.AddAsync(course);
        await _repository.SaveChangesAsync();
        var courseViewModel = course.Map<CourseViewModel>();
        return new SuccessResponseViewModel<CourseViewModel>(courseViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.CourseCreated));
    }

    public async Task<ResponseViewModel<CourseViewModel>> EditAsync(CourseEditViewModel courseEditViewModel)
    {
        if (courseEditViewModel == null)
        {
            _logger.LogError("Attempted to edit a course with null data.");
            throw new ArgumentNullException(nameof(courseEditViewModel), "The course editing data cannot be null. Provide valid input.");
        }

        var validationResult = await _validatorForEditing.ValidateAsync(courseEditViewModel);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(e => new ValidationError(e.PropertyName, e.ErrorMessage)).ToList();
            return new FailureResponseViewModel<CourseViewModel>(
                BusinessErrorCode.ValidationError,
                BusinessErrorMessage.GetMessage(BusinessErrorCode.ValidationError),
                validationErrors);
        }

        var course = courseEditViewModel.Map<Course>();

        var existingCourse = await _repository.GetByIdAsync(course.Id);

        if (existingCourse == null) return new FailureResponseViewModel<CourseViewModel>(BusinessErrorCode.CourseNotFound,
            BusinessErrorMessage.GetMessage(BusinessErrorCode.CourseNotFound));

        course.MapToExistingEntity(existingCourse);

        _repository.SaveInclude(course, ec => ec.Name, ec => ec.DurationInHours);

        await _repository.SaveChangesAsync();
        var courseViewModel = course.Map<CourseViewModel>();
        return new SuccessResponseViewModel<CourseViewModel>(courseViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.CourseUpdated));
    }

    public async Task<ResponseViewModel<bool>> DeleteAsync(int id)
    {
        var course = await _repository.GetByIdAsync(id);

        if (course == null) return new FailureResponseViewModel<bool>(BusinessErrorCode.CourseNotFound, BusinessErrorMessage.GetMessage(BusinessErrorCode.CourseNotFound));

        _repository.Delete(course);
        await _repository.SaveChangesAsync();

        return new SuccessResponseViewModel<bool>(true, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.CourseDeleted));
    }

    public async Task<ResponseViewModel<CourseViewModel>> GetByIdAsync(int id)
    {
        var course = await _repository.GetByIdAsync(id);

        if (course == null) return new FailureResponseViewModel<CourseViewModel>(BusinessErrorCode.CourseNotFound, BusinessErrorMessage.GetMessage(BusinessErrorCode.CourseNotFound));

        var courseViewModel = course.Map<CourseViewModel>();
        return new SuccessResponseViewModel<CourseViewModel>(courseViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.OperationCompleted));
    }

    public ResponseViewModel<IEnumerable<CourseViewModel>> GetAll()
    {
        var courses = _repository.GetAll();
        var courseViewModels = courses.ProjectTo<CourseViewModel>().AsEnumerable();
        return new SuccessResponseViewModel<IEnumerable<CourseViewModel>>(courseViewModels, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.OperationCompleted));
    }
}
