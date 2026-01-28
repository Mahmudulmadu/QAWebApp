using System.ComponentModel.DataAnnotations;
using QA.Domain.Models;

namespace QA.Application.DTOs;

public class VoteDto
{
    [Required]
    public VoteType Type { get; set; }

    public int? QuestionId { get; set; }

    public int? AnswerId { get; set; }
}
