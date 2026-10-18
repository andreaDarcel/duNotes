using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Models;
using duNotes.Services;

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

    public InscriptionViewModel(AuthService authService)
    {
        Title = "Inscription";
        _authService = authService;
    }

    [RelayCommand]
    private async Task SInscrire()
    {
        var user = new User { Nom = Nom, Email = Email };
        await _authService.InscriptionAsync(user, MotDePasse);
        await Shell.Current.GoToAsync("//AccueilPage");
    }
}