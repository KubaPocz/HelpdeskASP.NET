namespace HelpdeskWebAPI.Models;

public class Zgloszenie
{
    public int Id { get; set; }
    public string Tytul { get; set; } = string.Empty;
    public string Opis { get; set; } = string.Empty;
    public DateTime DataUtworzenia { get; set; } = DateTime.Now;
    public int PriorytetId { get; set; }
    public int StatusId { get; set; }
    public int KategoriaId { get; set; }
    public int PracownikId_Zglaszajacy { get; set; }
    public int PracownikId_Naprawiajacy { get; set; }
}
