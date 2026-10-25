using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Models;
using duNotes.Services;
using duNotes.Views;
using System.Collections.ObjectModel;

namespace duNotes.ViewModels;

public partial class RechercheViewModel : BaseViewModel
{
    private readonly DocumentService _documentService;

    [ObservableProperty]
    private string _searchQuery = "suites";

    [ObservableProperty]
    private ObservableCollection<Document> _searchResults = new();

    public RechercheViewModel(DocumentService documentService)
    {
        Title = "Rechercher";
        _documentService = documentService;
        _ = LancerRecherche();
    }

    [RelayCommand]
    private async Task LancerRecherche()
    {
        var results = await _documentService.GetDocumentsAsync(SearchQuery);
        SearchResults = new ObservableCollection<Document>(results);
    }

    [RelayCommand]
    private async Task OuvrirDocument(Document doc)
    {
        if (doc == null) return;
        var navigationParameter = new Dictionary<string, object>
        {
            { "SelectedDocument", doc }
        };
        await Shell.Current.GoToAsync(nameof(DetailDocumentPage), navigationParameter);
    }
}