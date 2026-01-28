using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QA.Domain.Models;
using QA.Application.Interfaces.Services;

namespace QA.Web.Pages.Questions;

public class QuestionsIndexModel : PageModel
{
    private readonly IQuestionService _questionService;

    public QuestionsIndexModel(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    public List<Question> Questions { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? SearchTerm { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SelectedTag { get; set; }

    public async Task OnGetAsync(string? search, string? tag)
    {
        SearchTerm = search;
        SelectedTag = tag;
        Questions = await _questionService.GetAllQuestionsAsync(search, tag);
    }
}
