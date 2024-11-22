using Examination.System.Core.Models;

namespace Examination.System.Core.Interfaces.Services;
public interface IQuestionService
{
    IEnumerable<Question> GetQuestionsPool();
    Task AddAsync(Question question);
}
