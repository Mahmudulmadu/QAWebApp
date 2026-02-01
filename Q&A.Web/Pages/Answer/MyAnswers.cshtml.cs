using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QA.Application.DTOs;
using QA.Application.Interfaces.Services;
using System.Security.Claims;

namespace QA.Web.Pages.Answer
{
    
    public class MyAnswersModel : PageModel
    {
        private readonly IAnswerService _answerService;

        public MyAnswersModel(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        public List<MyAnswerDto> Answers { get; set; } = new();

        
        public async Task OnGetAsync()
        {
            var userIdClaim =
                User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? User.FindFirst("id")?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                throw new UnauthorizedAccessException("User ID claim missing");

            int userId = int.Parse(userIdClaim);

            Answers = await _answerService.GetMyAnswersAsync(userId);
        }


    }
}
