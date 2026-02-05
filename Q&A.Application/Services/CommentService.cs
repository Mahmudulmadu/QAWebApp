using Microsoft.Extensions.Logging;
using Q_A.Application.DTOs;
using Q_A.Application.Interfaces;
using QA.Application.DTOs;
using QA.Application.Interfaces.Services;
using QA.Domain.Models;

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

    public async Task<(bool Success, string Message)> UpdateCommentAsync(
    int commentId, CommentUpdateDto dto, int userId)
    {
        var comment = await _unitOfWork.Comments.GetByIdAsync(commentId);
        if (comment == null) return (false, "Not found");
        if (comment.UserId != userId) return (false, "Unauthorized");

        comment.Body = dto.Body;
        _unitOfWork.Comments.Update(comment);
        await _unitOfWork.SaveChangesAsync();

        return (true, "Updated");
    }

    public async Task<(bool Success, string Message)> DeleteCommentAsync(
        int commentId, int userId)
    {
        var comment = await _unitOfWork.Comments.GetByIdAsync(commentId);
        if (comment == null) return (false, "Not found");
        if (comment.UserId != userId) return (false, "Unauthorized");

        _unitOfWork.Comments.Remove(comment);
        await _unitOfWork.SaveChangesAsync();

        return (true, "Deleted");
    }


    public async Task<List<Comment>> GetCommentsByQuestionIdAsync(int questionId)
        => await _unitOfWork.Comments.GetByQuestionIdAsync(questionId);

    public async Task<List<Comment>> GetCommentsByAnswerIdAsync(int answerId)
        => await _unitOfWork.Comments.GetByAnswerIdAsync(answerId);
}
