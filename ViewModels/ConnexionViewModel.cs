using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Services;
using duNotes.Views;

namespace duNotes.ViewModels;

public partial class ConnexionViewModel : BaseViewModel
{
    private readonly AuthService _authService;

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string _motDePasse = string.Empty;

    [ObservableProperty]
    private bool _resterConnecte = true;

    [ObservableProperty]
    private bool _aUneErreur;

    [ObservableProperty]
    private string _messageErreur = string.Empty;

    public ConnexionViewModel(AuthService authService)
    {
        Title = "Connexion";
        _authService = authService;
    }

    [RelayCommand]
    private async Task SeConnecter()
    {
        if (await _authService.ConnexionAsync(Email, MotDePasse))
        {
            await Shell.Current.GoToAsync("//accueil");
            return;
        }

        MessageErreur = "Renseignez votre e-mail et votre mot de passe.";
        AUneErreur = true;
    }

    [RelayCommand]
    private Task OuvrirInscription() => Shell.Current.GoToAsync(nameof(InscriptionPage));
}