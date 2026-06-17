namespace HelpdeskWebAPI.Models;

public class Pracownik
{
    public int Id { get; set; }
    public string Imie { get; set; } = string.Empty;
    public string Nazwisko { get; set; } = string.Empty;
    public string Email {  get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Haslo { get; set; } = string.Empty;
    public int IdRoli { get; set; }
}
