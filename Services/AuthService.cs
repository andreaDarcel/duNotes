using duNotes.Models;

namespace duNotes.Services;

public class AuthService
{
    public User? CurrentUser { get; private set; }
    public bool IsAuthenticated => CurrentUser != null;

    public async Task<bool> ConnexionAsync(string email, string password)
    {
        await Task.Delay(500);
        if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
        {
            CurrentUser = new User
            {
                Id = "usr_001",
                Nom = "Étudiant Test",
                Email = email,
                Etablissement = "ENSPD Douala"
            };
            return true;
        }
        return false;
    }

    public async Task InscriptionAsync(User user, string password)
    {
        await Task.Delay(500);
        CurrentUser = user;
    }

    public void Deconnexion()
    {
        CurrentUser = null;
    }
}