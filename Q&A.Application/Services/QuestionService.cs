using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Q_A.Application.Interfaces;
using QA.Application.DTOs;
using QA.Application.Interfaces.Services;
using QA.Domain.Models;

namespace QA.Application.Services;

public class QuestionService : IQuestionService
{
    private readonly IUnitOfWork _uow;
    private readonly ITagService _tagService;
    private readonly ILogger<QuestionService> _logger;

    public QuestionService(
        IUnitOfWork uow,
        ITagService tagService,
        ILogger<QuestionService> logger)
    {
        _uow = uow;
        _tagService = tagService;
        _logger = logger;
    }

    public async Task<(bool, string, Question?)>
        CreateQuestionAsync(QuestionCreateDto dto, int userId)
    {
        var tags = await _tagService.GetOrCreateTagsAsync(dto.Tags);

        var question = new Question
        {
            Title = dto.Title,
            Body = dto.Body,
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            Tags = tags
        };

        await _uow.Questions.AddAsync(question);
        await _uow.SaveChangesAsync();

        return (true, "Question created", question);
    }

    public async Task<(bool, string)>
        UpdateQuestionAsync(int questionId, QuestionUpdateDto dto, int userId)
    {
        var question = await _uow.Questions.GetWithDetailsAsync(questionId);
        if (question == null) return (false, "Not found");
        if (question.UserId != userId) return (false, "Unauthorized");

        question.Title = dto.Title;
        question.Body = dto.Body;
        question.UpdatedAt = DateTime.UtcNow;

        question.Tags.Clear();
        var tags = await _tagService.GetOrCreateTagsAsync(dto.Tags);
        foreach (var tag in tags) question.Tags.Add(tag);

        _uow.Questions.Update(question);
        await _uow.SaveChangesAsync();

        return (true, "Updated");
    }

    public async Task<(bool, string)>
        DeleteQuestionAsync(int questionId, int userId)
    {
        var question = await _uow.Questions.GetByIdAsync(questionId);
        if (question == null) return (false, "Not found");
        if (question.UserId != userId) return (false, "Unauthorized");

        _uow.Questions.Remove(question);
        await _uow.SaveChangesAsync();

        return (true, "Deleted");
    }

    public async Task<Question?> GetQuestionByIdAsync(int questionId)
        => await _uow.Questions.GetWithDetailsAsync(questionId);

    public async Task<List<Question>> GetAllQuestionsAsync(string? search, string? tag)
    {
        IQueryable<Question> query = _uow.Questions.Query()
            .Include(q => q.User)
            .Include(q => q.Tags)
            .Include(q => q.Answers);

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(q => q.Title.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(tag))
        {
            query = query.Where(q => q.Tags.Any(t => t.Name == tag));
        }

        return await query
            .OrderByDescending(q => q.CreatedAt)
            .ToListAsync();
    }


    public async Task<List<Question>> GetLatestQuestionsAsync(int count)
        => await _uow.Questions.GetLatestAsync(count);

    public async Task IncrementViewCountAsync(int questionId)
    {
        var q = await _uow.Questions.GetByIdAsync(questionId);
        if (q == null) return;

        q.ViewCount++;
        _uow.Questions.Update(q);
        await _uow.SaveChangesAsync();
    }
}

