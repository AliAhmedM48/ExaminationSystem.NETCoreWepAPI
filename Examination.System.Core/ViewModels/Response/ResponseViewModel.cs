using Examination.System.Core.Enums.Response;

namespace Examination.System.Core.ViewModels.Response;
public abstract class ResponseViewModel<T>
{
    public bool IsSuccess { get; protected set; }
    public T Data { get; protected set; }
    public BusinessErrorCode BusinessErrorCode { get; protected set; }
    public string Message { get; protected set; }
    public IEnumerable<ValidationError> ValidationErrors { get; protected set; }
}
