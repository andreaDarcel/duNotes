using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Models;
using duNotes.Services;
using duNotes.Views;

namespace duNotes.ViewModels;

[QueryProperty(nameof(SelectedDocument), "SelectedDocument")]
public partial class DetailDocumentViewModel : BaseViewModel
{
    private readonly OfflineService _offlineService;

    [ObservableProperty]
    private Document _selectedDocument = new();

    public DetailDocumentViewModel(OfflineService offlineService)
    {
        Title = "Détail du document";
        _offlineService = offlineService;
    }

    [RelayCommand]
    private async Task TelechargerHorsLigne()
    {
        await _offlineService.SauvegarderDocumentAsync(SelectedDocument);
        await Shell.Current.DisplayAlert("Hors-ligne", "Document sauvegardé pour la consultation hors-ligne !", "OK");
    }

    [RelayCommand]
    private Task Telecharger() => TelechargerHorsLigne();

    [RelayCommand]
    private Task VoirApercu() => Shell.Current.GoToAsync(nameof(ApercuPage), new Dictionary<string, object>
    {
        ["SelectedDocument"] = SelectedDocument
    });

    [RelayCommand]
    private Task OuvrirNotation() => Shell.Current.GoToAsync(nameof(NotationPage), new Dictionary<string, object>
    {
        ["SelectedDocument"] = SelectedDocument
    });
}