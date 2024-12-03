namespace Examination.System.Core.Enums.Response;

public static class BusinessSuccessMessage
{
    private static readonly Dictionary<BusinessSuccessCode, string> SuccessMessages = new()
    {
        #region Course
        { BusinessSuccessCode.CourseCreated, "Course created successfully." },
        { BusinessSuccessCode.CourseUpdated, "Course updated successfully." },
        { BusinessSuccessCode.CourseDeleted, "Course deleted successfully." },
        #endregion
        { BusinessSuccessCode.EntitySaved, "Entity saved successfully." },
        { BusinessSuccessCode.OperationCompleted, "Operation completed successfully." }
    };

    public static string GetMessage(BusinessSuccessCode code)
    {
        return SuccessMessages.TryGetValue(code, out string message)
            ? message
            : SuccessMessages[BusinessSuccessCode.OperationCompleted];
    }
}