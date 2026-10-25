using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Models;
using duNotes.Services;
using System.Collections.ObjectModel;

namespace duNotes.ViewModels;

public partial class HorsLigneViewModel : BaseViewModel
{
    private readonly OfflineService _offlineService;

    [ObservableProperty]
    private ObservableCollection<Document> _documentsHorsLigne = new();

    public HorsLigneViewModel(OfflineService offlineService)
    {
        Title = "Documents Hors-ligne";
        _offlineService = offlineService;
        _ = ChargerHorsLigne();
    }

    [RelayCommand]
    private async Task ChargerHorsLigne()
    {
        var list = await _offlineService.GetDocumentsHorsLigneAsync();
        DocumentsHorsLigne = new ObservableCollection<Document>(list);
    }

    [RelayCommand]
    private async Task SupprimerCopies()
    {
        foreach (var document in DocumentsHorsLigne.ToList())
            await _offlineService.SupprimerDocumentAsync(document.DocumentId.ToString());

        DocumentsHorsLigne.Clear();
    }
}