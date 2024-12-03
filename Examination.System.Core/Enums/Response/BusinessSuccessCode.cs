namespace Examination.System.Core.Enums.Response;

public enum BusinessSuccessCode
{
    #region Course
    CourseCreated = 1000,
    CourseUpdated = 1001,
    CourseDeleted = 1002,
    #endregion

    #region Exam
    ExamCreated = 2000,
    ExamUpdated = 2001,
    ExamDeleted = 2002,
    #endregion

    #region Choice
    ChoiceCreated = 3000,
    ChoiceUpdated = 3001,
    ChoiceDeleted = 3002,
    #endregion

    #region QuestionChoice
    QuestionChoiceCreated = 4000,
    QuestionChoiceUpdated = 4001,
    QuestionChoiceDeleted = 4002,
    QuestionCorrectChoiceUpdated = 4003,
    #endregion

    EntitySaved = 1003,
    OperationCompleted = 1004
}
