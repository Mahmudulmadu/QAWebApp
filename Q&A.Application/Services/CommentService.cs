using QA.Application.DTOs;
using QA.Application.Interfaces.Services;
using QA.Domain.Models;
using Q_A.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace QA.Application.Services;

public class CommentService : ICommentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CommentService> _logger;

    public CommentService(IUnitOfWork unitOfWork, ILogger<CommentService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<(bool Success, string Message, Comment? Comment)> CreateCommentAsync(
        CommentCreateDto dto, int userId)
    {
        if (dto.QuestionId == null && dto.AnswerId == null)
            return (false, "Comment must belong to a question or an answer", null);

        var comment = new Comment
        {
            Body = dto.Body,
            UserId = userId,
            QuestionId = dto.QuestionId,
            AnswerId = dto.AnswerId,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Comments.AddAsync(comment);
        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Comment {CommentId} created by user {UserId}", comment.Id, userId);

        return (true, "Comment posted successfully", comment);
    }

    public async Task<List<Comment>> GetCommentsByQuestionIdAsync(int questionId)
        => await _unitOfWork.Comments.GetByQuestionIdAsync(questionId);

    public async Task<List<Comment>> GetCommentsByAnswerIdAsync(int answerId)
        => await _unitOfWork.Comments.GetByAnswerIdAsync(answerId);
}
