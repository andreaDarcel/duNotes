using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Models;
using duNotes.Services;
using duNotes.Views;
using System.Collections.ObjectModel;

namespace duNotes.ViewModels;

public partial class AccueilViewModel : BaseViewModel
{
    private readonly DocumentService _documentService;

    [ObservableProperty]
    private ObservableCollection<Document> _recentDocuments = new();

    [ObservableProperty]
    private string _filiereNiveau = "Licence informatique • L1";

    public AccueilViewModel(DocumentService documentService)
    {
        Title = "duNotes - Accueil";
        _documentService = documentService;
        _ = ChargerDocuments();
    }

    [RelayCommand]
    private async Task ChargerDocuments()
    {
        IsBusy = true;
        var docs = await _documentService.GetDocumentsAsync();
        RecentDocuments = new ObservableCollection<Document>(docs);
        IsBusy = false;
    }

    [RelayCommand]
    private Task OuvrirRecherche() => Shell.Current.GoToAsync(nameof(RecherchePage));

    [RelayCommand]
    private async Task OuvrirDocument(Document document)
    {
        if (document is null)
            return;

        await Shell.Current.GoToAsync(nameof(DetailDocumentPage), new Dictionary<string, object>
        {
            ["SelectedDocument"] = document
        });
    }
}