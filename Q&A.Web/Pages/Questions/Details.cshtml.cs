using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QA.Domain.Models;
using QA.Application.Interfaces.Services;

namespace QA.Web.Pages.Questions;

public class DetailsModel : PageModel
{
    private readonly IQuestionService _questionService;

    public DetailsModel(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    public Question? Question { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Question = await _questionService.GetQuestionByIdAsync(id);

        if (Question == null)
        {
            return NotFound();
        }

        await _questionService.IncrementViewCountAsync(id);

        return Page();
    }
}
