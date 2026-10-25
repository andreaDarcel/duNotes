using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Models;
using duNotes.Services;
using duNotes.Views;

namespace duNotes.ViewModels;

public partial class InscriptionViewModel : BaseViewModel
{
    private readonly AuthService _authService;

    [ObservableProperty]
    private string _nom = string.Empty;

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string _motDePasse = string.Empty;

    [ObservableProperty]
    private string _confirmationMotDePasse = string.Empty;

    [ObservableProperty]
    private bool _aUneErreur;

    [ObservableProperty]
    private string _messageErreur = string.Empty;

    public InscriptionViewModel(AuthService authService)
    {
        Title = "Inscription";
        _authService = authService;
    }

    [RelayCommand]
    private async Task SInscrire()
    {
        if (string.IsNullOrWhiteSpace(Nom) || string.IsNullOrWhiteSpace(Email) || MotDePasse.Length < 8)
        {
            MessageErreur = "Complétez les champs et choisissez un mot de passe de 8 caractères minimum.";
            AUneErreur = true;
            return;
        }

        if (!string.Equals(MotDePasse, ConfirmationMotDePasse, StringComparison.Ordinal))
        {
            MessageErreur = "Les mots de passe ne correspondent pas.";
            AUneErreur = true;
            return;
        }

        var user = new User { Nom = Nom, Email = Email };
        await _authService.InscriptionAsync(user, MotDePasse);
        await Shell.Current.GoToAsync("//accueil");
    }

    [RelayCommand]
    private Task RetourConnexion() => Shell.Current.GoToAsync("//connexion");
}