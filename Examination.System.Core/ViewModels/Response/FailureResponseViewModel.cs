using Examination.System.Core.Enums.Response;

namespace Examination.System.Core.ViewModels.Response;

public class FailureResponseViewModel<T> : ResponseViewModel<T>
{
    public FailureResponseViewModel(BusinessErrorCode businessErrorCode, string message = default, List<ValidationError> validationErrors = default)
    {
        IsSuccess = false;
        Data = default;
        Message = message;
        BusinessErrorCode = businessErrorCode;
        ValidationErrors = validationErrors;
    }
}
