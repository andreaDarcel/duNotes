using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Models;
using duNotes.Services;
using System.Collections.ObjectModel;

namespace duNotes.ViewModels;

public partial class ExplorerViewModel : BaseViewModel
{
    private readonly DocumentService _documentService;

    [ObservableProperty]
    private string _searchQuery = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Document> _searchResults = new();

    public ExplorerViewModel(DocumentService documentService)
    {
        Title = "Explorer les cours";
        _documentService = documentService;
    }

    [RelayCommand]
    private async Task Rechercher()
    {
        IsBusy = true;
        var results = await _documentService.GetDocumentsAsync(SearchQuery);
        SearchResults = new ObservableCollection<Document>(results);
        IsBusy = false;
    }
}