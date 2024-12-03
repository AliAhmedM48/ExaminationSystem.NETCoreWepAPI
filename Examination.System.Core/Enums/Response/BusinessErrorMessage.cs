namespace Examination.System.Core.Enums.Response;

public static class BusinessErrorMessage
{
    private static readonly Dictionary<BusinessErrorCode, string> ErrorMessages = new()
    {
        { BusinessErrorCode.None, "No error." },
        { BusinessErrorCode.TechnicalError, "An unexpected error occurred. Please contact support." },
        { BusinessErrorCode.ValidationError, "Validation failed: One or more fields contain invalid values. Please review the errors and try again." },
        #region Course
        { BusinessErrorCode.CourseNotFound, "The specified course could not be found." },
        #endregion

        #region Question
        { BusinessErrorCode.QuestionNotFound, "The specified question could not be found." },
        #endregion


        #region Exam
        { BusinessErrorCode.ExamNotFound, "The specified exam could not be found." },
        #endregion
    };

    public static string GetMessage(BusinessErrorCode code)
    {
        return ErrorMessages.TryGetValue(code, out string message) ?
            message : "An unexpected error occurred. Please contact support.";
    }
}
