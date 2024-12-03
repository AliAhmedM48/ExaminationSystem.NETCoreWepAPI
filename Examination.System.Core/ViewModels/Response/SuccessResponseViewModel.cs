using Examination.System.Core.Enums.Response;

namespace Examination.System.Core.ViewModels.Response;

public class SuccessResponseViewModel<T> : ResponseViewModel<T>
{
    public SuccessResponseViewModel(T data, string message = default)
    {
        IsSuccess = true;
        Data = data;
        Message = message;
        BusinessErrorCode = BusinessErrorCode.None;
        ValidationErrors = default;
    }
}
