using Examination.System.Core.Entities.MainEntities;
using Examination.System.Core.Enums.Response;
using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Core.Interfaces.Services.MainEntities;
using Examination.System.Core.Validation;
using Examination.System.Core.ViewModels;
using Examination.System.Core.ViewModels.Response;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Examination.System.Service.Services;
public class ChoiceService : IChoiceService
{
    private readonly IRepository<Choice> _repository;
    private readonly IValidator<ChoiceCreateViewModel> _validatorForCreation;
    private readonly IValidator<ChoiceEditViewModel> _validatorForEditing;
    private readonly ILogger<ChoiceService> _logger;

    public ChoiceService(IRepository<Choice> repository,
        IValidator<ChoiceCreateViewModel> validatorForCreation,
        IValidator<ChoiceEditViewModel> validatorForEditing,
        ILogger<ChoiceService> logger)
    {
        _repository = repository;
        _validatorForCreation = validatorForCreation;
        _validatorForEditing = validatorForEditing;
        _logger = logger;
    }

    public async Task<ResponseViewModel<ChoiceViewModel>> CreateAsync(ChoiceCreateViewModel choiceCreateViewModel)
    {
        ValidationHelper.ValidateArgumentsNullOrEmpty(choiceCreateViewModel);

        var validationErrors = await ValidationHelper.ValidateViewModelAsync(_validatorForCreation, choiceCreateViewModel);

        if (validationErrors != null)
        {
            return new FailureResponseViewModel<ChoiceViewModel>(
                BusinessErrorCode.ValidationError,
                BusinessErrorMessage.GetMessage(BusinessErrorCode.ValidationError),
                validationErrors); ;
        }


        var choice = choiceCreateViewModel.Map<Choice>();
        await _repository.AddAsync(choice);
        await _repository.SaveChangesAsync();
        var choiceViewModel = choice.Map<ChoiceViewModel>();
        return new SuccessResponseViewModel<ChoiceViewModel>(choiceViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.ChoiceCreated));
    }

    public async Task<ResponseViewModel<ChoiceViewModel>> EditAsync(ChoiceEditViewModel choiceEditViewModel)
    {
        ValidationHelper.ValidateArgumentsNullOrEmpty(choiceEditViewModel);

        var validationErrors = await ValidationHelper.ValidateViewModelAsync(_validatorForEditing, choiceEditViewModel);

        if (validationErrors != null)
        {
            return new FailureResponseViewModel<ChoiceViewModel>(
                BusinessErrorCode.ValidationError,
                BusinessErrorMessage.GetMessage(BusinessErrorCode.ValidationError),
                validationErrors); ;
        }

        var choice = choiceEditViewModel.Map<Choice>();

        var existingChoice = await _repository.GetByIdAsync(choice.Id);

        if (existingChoice == null) return new FailureResponseViewModel<ChoiceViewModel>(BusinessErrorCode.ChoiceNotFound,
            BusinessErrorMessage.GetMessage(BusinessErrorCode.ChoiceNotFound));

        choice.MapToExistingEntity(existingChoice);

        _repository.SaveInclude(choice, ec => ec.Text, ec => ec.QuestionId);

        await _repository.SaveChangesAsync();
        var choiceViewModel = choice.Map<ChoiceViewModel>();
        return new SuccessResponseViewModel<ChoiceViewModel>(choiceViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.ChoiceUpdated));
    }

    public async Task<ResponseViewModel<bool>> DeleteAsync(int id)
    {
        var choice = await _repository.GetByIdAsync(id);

        if (choice == null) return new FailureResponseViewModel<bool>(BusinessErrorCode.ChoiceNotFound, BusinessErrorMessage.GetMessage(BusinessErrorCode.ChoiceNotFound));

        _repository.Delete(choice);
        await _repository.SaveChangesAsync();

        return new SuccessResponseViewModel<bool>(true, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.ChoiceDeleted));
    }

    public async Task<ResponseViewModel<ChoiceViewModel>> GetByIdAsync(int id)
    {
        var choice = _repository.GetAll(c => c.Id == id);

        if (choice == null) return new FailureResponseViewModel<ChoiceViewModel>(BusinessErrorCode.ChoiceNotFound, BusinessErrorMessage.GetMessage(BusinessErrorCode.ChoiceNotFound));

        var choiceViewModel = await choice.ProjectToForFirstOrDefaultAsync<ChoiceViewModel>();

        return new SuccessResponseViewModel<ChoiceViewModel>(choiceViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.OperationCompleted));
    }

    public ResponseViewModel<IEnumerable<ChoiceViewModel>> GetAll()
    {
        var choices = _repository.GetAll();
        var choiceViewModels = choices.ProjectTo<ChoiceViewModel>().AsEnumerable();
        return new SuccessResponseViewModel<IEnumerable<ChoiceViewModel>>(choiceViewModels, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.OperationCompleted));
    }

    public async Task<ResponseViewModel<IEnumerable<ChoiceViewModel>>> CreateRangeForQuestionIdAsync(IEnumerable<ChoiceCreateViewModel> choiceCreateViewModels, int questionId)
    {

        ValidationHelper.ValidateArgumentsNullOrEmpty(choiceCreateViewModels);

        var validationErrors = await ValidationHelper.ValidateViewModelAsync(_validatorForCreation, choiceCreateViewModels);

        if (validationErrors != null)
        {
            return new FailureResponseViewModel<IEnumerable<ChoiceViewModel>>(
               BusinessErrorCode.ValidationError,
               BusinessErrorMessage.GetMessage(BusinessErrorCode.ValidationError),
               validationErrors);
        }

        var choices = choiceCreateViewModels.Select(viewModel => viewModel.Map<Choice>()).ToArray();

        foreach (var choice in choices)
        {
            choice.QuestionId = questionId;
        }

        await _repository.AddRangeAsync(choices);
        await _repository.SaveChangesAsync();

        var choiceViewModels = choices.Select(choice => choice.Map<ChoiceViewModel>());
        return new SuccessResponseViewModel<IEnumerable<ChoiceViewModel>>(choiceViewModels, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.ChoiceCreated));
    }

    public Task<ResponseViewModel<IEnumerable<ChoiceViewModel>>> EditRangeAsync(IEnumerable<ChoiceEditViewModel> choiceEditViewModels)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseViewModel<bool>> DeleteChoicesByQuestionIdAsync(int questionId)
    {

        var choices = _repository.GetAll(c => c.QuestionId == questionId);
        if (choices == null || !choices.Any())
        {
            return new FailureResponseViewModel<bool>(
                BusinessErrorCode.ChoiceNotFound,
                BusinessErrorMessage.GetMessage(BusinessErrorCode.ChoiceNotFound));
        }

        _repository.DeleteRange(choices);
        await _repository.SaveChangesAsync();

        return new SuccessResponseViewModel<bool>(true, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.ChoiceDeleted));
    }

    public ResponseViewModel<IEnumerable<ChoiceViewModel>> GetAllByQuestionId(int questionId)
    {
        var choices = _repository.GetAll(c => c.QuestionId == questionId);
        if (choices == null || !choices.Any())
        {
            return new FailureResponseViewModel<IEnumerable<ChoiceViewModel>>(
                BusinessErrorCode.ChoiceNotFound,
                BusinessErrorMessage.GetMessage(BusinessErrorCode.ChoiceNotFound));
        }

        var choiceViewModels = choices.Select(choice => choice.Map<ChoiceViewModel>());
        return new SuccessResponseViewModel<IEnumerable<ChoiceViewModel>>(choiceViewModels, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.OperationCompleted));
    }

}
