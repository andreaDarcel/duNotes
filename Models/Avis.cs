using SQLite;

namespace duNotes.Models;

public class Avis
{
    [PrimaryKey, AutoIncrement]
    public int AvisId { get; set; }
    public int DocumentId { get; set; }
    public int UtilisateurId { get; set; }
    public int Note { get; set; }
    public string? Commentaire { get; set; }
    public DateTime DateAvis { get; set; } = DateTime.UtcNow;
}