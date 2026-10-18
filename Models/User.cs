namespace duNotes.Models;

public class User
{
    public string Id { get; set; } = string.Empty;
    public string Nom { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = "Etudiant";
    public string Etablissement { get; set; } = string.Empty;
}