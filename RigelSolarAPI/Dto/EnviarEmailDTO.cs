namespace RigelSolarAPI.Dto;

public class EnviarEmailDTO
{
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
