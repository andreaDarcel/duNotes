using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace duNotes.ViewModels;

public partial class NotationViewModel : BaseViewModel
{
    [ObservableProperty]
    private int _note = 5;

    [ObservableProperty]
    private string _commentaire = string.Empty;

    public NotationViewModel()
    {
        Title = "Evaluer un document";
    }

    [RelayCommand]
    private async Task SoumettreAvis()
    {
        await Shell.Current.DisplayAlert("Merci", "Votre avis a bien été pris en compte.", "OK");
        await Shell.Current.GoToAsync("..");
    }
}