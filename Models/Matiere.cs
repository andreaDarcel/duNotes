using SQLite;

namespace duNotes.Models;

public class Matiere
{
    [PrimaryKey, AutoIncrement]
    public int MatiereId { get; set; }
    public string Nom { get; set; } = string.Empty;
    public int FiliereId { get; set; }
}