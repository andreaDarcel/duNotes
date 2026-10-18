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
    private ObservableCollection<Document> _documentsSaved = new();

    public HorsLigneViewModel(OfflineService offlineService)
    {
        Title = "Documents Hors-ligne";
        _offlineService = offlineService;
    }

    [RelayCommand]
    private async Task ChargerHorsLigne()
    {
        var list = await _offlineService.GetDocumentsHorsLigneAsync();
        DocumentsSaved = new ObservableCollection<Document>(list);
    }
}