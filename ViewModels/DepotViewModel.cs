using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Models;
using duNotes.Services;

namespace duNotes.ViewModels;

public partial class DepotViewModel : BaseViewModel
{
    private readonly DocumentService _documentService;

    [ObservableProperty]
    private string _titre = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    [ObservableProperty]
    private string _matiere = string.Empty;

    [ObservableProperty]
    private string _niveau = string.Empty;

    public DepotViewModel(DocumentService documentService)
    {
        Title = "Déposer une note";
        _documentService = documentService;
    }

    [RelayCommand]
    private async Task Publier()
    {
        var doc = new Document
        {
            Titre = Titre,
            Description = Description,
            Matiere = Matiere,
            Niveau = Niveau,
            Auteur = "Utilisateur Actuel"
        };

        await _documentService.PublierDocumentAsync(doc);
        Titre = string.Empty;
        Description = string.Empty;
        await Shell.Current.DisplayAlert("Succès", "Votre document a été publié avec succès !", "OK");
    }
}