namespace Examination.System.Core.Enums.Response;

public enum BusinessErrorCode
{
    None = 000,
    TechnicalError = 1000,

    ValidationError = 101,

    #region Course
    CourseNotFound = 2000,
    #endregion

    #region Exam
    ExamNotFound = 3000,
    #endregion

    #region Choice
    ChoiceNotFound = 4000,
    ChoiceCreationError = 4001,
    ChoiceUpdatingError = 4002,
    #endregion

    #region Question
    QuestionNotFound = 5000,
    #endregion
}
