using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Models;
using duNotes.Services;

namespace duNotes.ViewModels;

[QueryProperty(nameof(SelectedDocument), "SelectedDocument")]
public partial class ApercuViewModel : BaseViewModel
{
    private readonly OfflineService _offlineService;

    [ObservableProperty]
    private Document _selectedDocument = new();

    public ApercuViewModel(OfflineService offlineService)
    {
        Title = "Aperçu léger";
        _offlineService = offlineService;
    }

    [RelayCommand]
    private async Task TelechargerPdf()
    {
        await _offlineService.SauvegarderDocumentAsync(SelectedDocument);
        await Shell.Current.DisplayAlert("Téléchargement", "Le PDF complet de " + SelectedDocument.TailleFichier + " a été téléchargé.", "OK");
    }
}