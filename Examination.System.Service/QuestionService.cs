using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Core.Interfaces.Services;
using Examination.System.Core.Models;

namespace Examination.System.Service;
public class QuestionService : IQuestionService
{
    private readonly IRepository<Question> _repository;

    public QuestionService(IRepository<Question> repository)
    {
        _repository = repository;
    }
    public async Task AddAsync(Question question)
    {
        await _repository.AddAsync(question);
    }

    public IEnumerable<Question> GetQuestionsPool()
    {
        return _repository.GetAll().ToList();
    }
}
