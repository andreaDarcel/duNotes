using SQLite;

namespace duNotes.Models;

public class Filiere
{
    [PrimaryKey, AutoIncrement]
    public int FiliereId { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Niveau { get; set; } = string.Empty;
}