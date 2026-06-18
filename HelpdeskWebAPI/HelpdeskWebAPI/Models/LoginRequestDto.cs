namespace HelpdeskWebAPI.Models;

public class LoginRequestDto
{
    public string Login { get; set; } = string.Empty;
    public string Haslo { get; set; } = string.Empty;
}
