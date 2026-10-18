namespace duNotes.Models;

public class Avis
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string DocumentId { get; set; } = string.Empty;
    public string UtilisateurNom { get; set; } = string.Empty;
    public int Note { get; set; }
    public string Commentaire { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
}