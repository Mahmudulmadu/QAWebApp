using QA.Application.DTOs;
using QA.Application.Interfaces.Services;
using QA.Domain.Models;
using Q_A.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace QA.Application.Services;

public class AnswerService : IAnswerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AnswerService> _logger;

    public AnswerService(IUnitOfWork unitOfWork, ILogger<AnswerService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<(bool Success, string Message, Answer? Answer)> CreateAnswerAsync(AnswerCreateDto dto, int userId)
    {
        var question = await _unitOfWork.Questions.GetByIdAsync(dto.QuestionId);
        if (question == null)
            return (false, "Question not found", null);

        var answer = new Answer
        {
            Body = dto.Body,
            QuestionId = dto.QuestionId,
            UserId = userId
        };

        await _unitOfWork.Answers.AddAsync(answer);
        await _unitOfWork.SaveChangesAsync();

        return (true, "Answer posted successfully", answer);
    }

    public async Task<(bool Success, string Message)> UpdateAnswerAsync(int answerId, AnswerUpdateDto dto, int userId)
    {
        var answer = await _unitOfWork.Answers.GetByIdAsync(answerId);
        if (answer == null)
            return (false, "Answer not found");

        if (answer.UserId != userId)
            return (false, "You do not have permission to update this answer");

        answer.Body = dto.Body;
        answer.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.Answers.Update(answer);
        await _unitOfWork.SaveChangesAsync();

        return (true, "Answer updated successfully");
    }

    public async Task<(bool Success, string Message)> DeleteAnswerAsync(int answerId, int userId)
    {
        var answer = await _unitOfWork.Answers.GetByIdAsync(answerId);
        if (answer == null)
            return (false, "Answer not found");

        if (answer.UserId != userId)
            return (false, "You do not have permission to delete this answer");

        _unitOfWork.Answers.Remove(answer);
        await _unitOfWork.SaveChangesAsync();

        return (true, "Answer deleted successfully");
    }

    public async Task<(bool Success, string Message)> AcceptAnswerAsync(int answerId, int userId)
    {
        var answer = await _unitOfWork.Answers.GetWithQuestionAsync(answerId);
        if (answer == null)
            return (false, "Answer not found");

        if (answer.Question.UserId != userId)
            return (false, "Only question owner can accept an answer");

        var existing = await _unitOfWork.Answers.FindAsync(
            a => a.QuestionId == answer.QuestionId && a.IsAccepted
        );

        foreach (var a in existing)
            a.IsAccepted = false;

        answer.IsAccepted = true;

        await _unitOfWork.SaveChangesAsync();
        return (true, "Answer accepted successfully");
    }

    public async Task<Answer?> GetAnswerByIdAsync(int answerId)
        => await _unitOfWork.Answers.GetByIdAsync(answerId);

    public async Task<List<Answer>> GetAnswersByQuestionIdAsync(int questionId)
        => await _unitOfWork.Answers.GetByQuestionIdAsync(questionId);
}
