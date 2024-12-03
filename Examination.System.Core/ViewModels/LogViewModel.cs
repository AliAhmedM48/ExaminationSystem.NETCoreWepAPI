namespace Examination.System.Core.ViewModels;
public class LogViewModel
{
    public string Message { get; set; }
    public object Data { get; set; }
    public DateTime DateTime { get; set; }
    public string EndPoint { get; set; }
    public int UserId { get; set; }
}