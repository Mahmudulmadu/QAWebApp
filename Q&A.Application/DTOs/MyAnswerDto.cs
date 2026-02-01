namespace QA.Application.DTOs;

public class MyAnswerDto
{
    public int Id { get; set; }
    public string Body { get; set; } = string.Empty;
    public bool IsAccepted { get; set; }
    public int VoteCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public int QuestionId { get; set; }
    public string QuestionTitle { get; set; } = string.Empty;

    public bool IsOwner { get; set; }
}
