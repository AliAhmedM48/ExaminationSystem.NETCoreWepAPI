
using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Core.Interfaces.Services;
using Examination.System.Core.Models;
using Examination.System.Core.ViewModels.ExamQuestions;

namespace Examination.System.Service;

public class ExamQuestionsService : IExamQuestionsService
{
    private readonly IRepository<StudentExamQuestion> _repository;

    public ExamQuestionsService(IRepository<StudentExamQuestion> repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(ExamQuestionsCreateViewModel examQuestionsViewModel)
    {
        await _repository.AddAsync(new StudentExamQuestion
        {
            QuestionId = examQuestionsViewModel.QuestionId,
            ExamId = examQuestionsViewModel.ExamId,
            CreatedAt = DateTime.Now
        });

        await _repository.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<ExamQuestionsCreateViewModel> examQuestionsCreateViewModels)
    {
        foreach (var viewModel in examQuestionsCreateViewModels)
        {
            await _repository.AddAsync(new StudentExamQuestion()
            {
                ExamId = viewModel.ExamId,
                QuestionId = viewModel.QuestionId,
                CreatedAt = DateTime.Now
            });
        }

        await _repository.SaveChangesAsync();
    }
}

