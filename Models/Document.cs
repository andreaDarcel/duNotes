using SQLite;

namespace duNotes.Models;

public class Document
{
    [PrimaryKey, AutoIncrement]
    public int DocumentId { get; set; }
    public string Titre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // "Fiche" ou "Annales"
    public int Pages { get; set; }
    public int TailleKo { get; set; }
    public string? CheminFichier { get; set; }
    public DateTime DateMiseEnLigne { get; set; } = DateTime.UtcNow;
    public int MatiereId { get; set; }
    public int UtilisateurId { get; set; }
    public double NoteMoyenne { get; set; }
    public int NbAvis { get; set; }

    public string? MatiereNom { get; set; }

    [Ignore]
    public string Matiere
    {
        get => MatiereNom ?? string.Empty;
        set => MatiereNom = value;
    }

    [Ignore]
    public string Niveau { get; set; } = string.Empty;

    [Ignore]
    public string Auteur { get; set; } = string.Empty;

    [Ignore]
    public int NombreEvaluations
    {
        get => NbAvis;
        set => NbAvis = value;
    }

    [Ignore]
    public string TailleFichier => TailleKo >= 1024
        ? $"{TailleKo / 1024.0:0.#} Mo"
        : $"{TailleKo} Ko";

    [Ignore]
    public bool EstTelecharge { get; set; }
}