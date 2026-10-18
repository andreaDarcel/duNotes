namespace duNotes.Models;

public class Document
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Titre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Matiere { get; set; } = string.Empty;
    public string Niveau { get; set; } = string.Empty;
    public string Auteur { get; set; } = string.Empty;
    public DateTime DateDepot { get; set; } = DateTime.Now;
    public double NoteMoyenne { get; set; }
    public int NombreEvaluations { get; set; }
    public string TailleFichier { get; set; } = "1.2 MB";
    public bool EstTelecharge { get; set; }
    public string FilePath { get; set; } = string.Empty;
}