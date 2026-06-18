namespace HelpdeskZgloszenia.Models;

public class LoginResponse
{
    [System.Text.Json.Serialization.JsonPropertyName("wiadomosc")]
    public string Wiadomosc { get; set; } = string.Empty;

    [System.Text.Json.Serialization.JsonPropertyName("imie")]
    public string Imie { get; set; } = string.Empty;

    [System.Text.Json.Serialization.JsonPropertyName("nazwisko")]
    public string Nazwisko { get; set; } = string.Empty;

    [System.Text.Json.Serialization.JsonPropertyName("rola")]
    public string Rola { get; set; } = string.Empty;
}
