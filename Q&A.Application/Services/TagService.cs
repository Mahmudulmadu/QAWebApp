using Microsoft.Extensions.Logging;
using Q_A.Application.Interfaces;
using QA.Application.Interfaces;
using QA.Application.Interfaces.Services;
using QA.Domain.Models;

namespace QA.Application.Services;

public class TagService : ITagService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TagService> _logger;

    public TagService(IUnitOfWork unitOfWork, ILogger<TagService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<List<Tag>> GetOrCreateTagsAsync(string tagsString)
    {
        var tagNames = tagsString.Split(',')
            .Select(t => t.Trim().ToLower())
            .Where(t => !string.IsNullOrWhiteSpace(t))
            .Distinct();

        var tags = new List<Tag>();

        foreach (var name in tagNames)
        {
            var tag = await _unitOfWork.Tags.GetByNameAsync(name);

            if (tag == null)
            {
                tag = new Tag { Name = name };
                await _unitOfWork.Tags.AddAsync(tag);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Created tag {Tag}", name);
            }

            tags.Add(tag);
        }

        return tags;
    }

    public async Task<List<Tag>> GetAllTagsAsync()
        => await _unitOfWork.Tags.GetAllAsync();

    public async Task<List<Tag>> GetPopularTagsAsync(int count = 10)
        => await _unitOfWork.Tags.GetPopularTagsAsync(count);
}
