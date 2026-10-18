using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Services;

namespace duNotes.ViewModels;

public partial class ConnexionViewModel : BaseViewModel
{
    private readonly AuthService _authService;

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string _motDePasse = string.Empty;

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
            await Shell.Current.GoToAsync("//AccueilPage");
        }
    }
}