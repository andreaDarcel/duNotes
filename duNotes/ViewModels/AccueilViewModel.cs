using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Models;
using duNotes.Services;
using System.Collections.ObjectModel;

namespace duNotes.ViewModels;

public partial class AccueilViewModel : BaseViewModel
{
    private readonly DocumentService _documentService;

    [ObservableProperty]
    private ObservableCollection<Document> _recentDocuments = new();

    public AccueilViewModel(DocumentService documentService)
    {
        Title = "duNotes - Accueil";
        _documentService = documentService;
        Task.Run(ChargerDocuments);
    }

    [RelayCommand]
    private async Task ChargerDocuments()
    {
        IsBusy = true;
        var docs = await _documentService.GetDocumentsAsync();
        RecentDocuments = new ObservableCollection<Document>(docs);
        IsBusy = false;
    }
}