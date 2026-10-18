using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Models;
using duNotes.Services;

namespace duNotes.ViewModels;

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
}