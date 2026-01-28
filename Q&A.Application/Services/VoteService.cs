using Microsoft.Extensions.Logging;
using Q_A.Application.Interfaces;
using QA.Application.DTOs;
using QA.Application.Interfaces;
using QA.Application.Interfaces.Services;
using QA.Domain.Models;

namespace QA.Application.Services;

public class VoteService : IVoteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<VoteService> _logger;

    public VoteService(IUnitOfWork unitOfWork, ILogger<VoteService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<(bool Success, string Message)> VoteAsync(VoteDto dto, int userId)
    {
        if (dto.QuestionId == null && dto.AnswerId == null)
            return (false, "Vote must be associated with a question or answer");

        var existingVote = await _unitOfWork.Votes
            .GetUserVoteAsync(userId, dto.QuestionId, dto.AnswerId);

        // Remove vote (same type)
        if (existingVote != null && existingVote.Type == dto.Type)
        {
            _unitOfWork.Votes.Remove(existingVote);
            await UpdateVoteCount(dto.QuestionId, dto.AnswerId, -(int)dto.Type);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Vote removed");
        }

        // Change vote
        if (existingVote != null)
        {
            var delta = (int)dto.Type - (int)existingVote.Type;
            existingVote.Type = dto.Type;

            await UpdateVoteCount(dto.QuestionId, dto.AnswerId, delta);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Vote updated");
        }

        // New vote
        var vote = new Vote
        {
            Type = dto.Type,
            UserId = userId,
            QuestionId = dto.QuestionId,
            AnswerId = dto.AnswerId
        };

        await _unitOfWork.Votes.AddAsync(vote);
        await UpdateVoteCount(dto.QuestionId, dto.AnswerId, (int)dto.Type);
        await _unitOfWork.SaveChangesAsync();

        return (true, "Vote recorded");
    }

    public async Task<int> GetVoteCountAsync(int? questionId, int? answerId)
    {
        if (questionId.HasValue)
            return (await _unitOfWork.Questions.GetByIdAsync(questionId.Value))?.VoteCount ?? 0;

        if (answerId.HasValue)
            return (await _unitOfWork.Answers.GetByIdAsync(answerId.Value))?.VoteCount ?? 0;

        return 0;
    }

    public async Task<bool> HasUserVotedAsync(int userId, int? questionId, int? answerId)
    {
        return await _unitOfWork.Votes.HasUserVotedAsync(userId, questionId, answerId);
    }

    private async Task UpdateVoteCount(int? questionId, int? answerId, int delta)
    {
        if (questionId.HasValue)
        {
            var q = await _unitOfWork.Questions.GetByIdAsync(questionId.Value);
            if (q != null) q.VoteCount += delta;
        }

        if (answerId.HasValue)
        {
            var a = await _unitOfWork.Answers.GetByIdAsync(answerId.Value);
            if (a != null) a.VoteCount += delta;
        }
    }
}
