using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using duNotes.Models;
using duNotes.Services;

namespace duNotes.ViewModels;

[QueryProperty(nameof(SelectedDocument), "SelectedDocument")]
public partial class NotationViewModel : BaseViewModel
{
    private readonly DocumentService _documentService;

    [ObservableProperty]
    private Document _selectedDocument = new();

    [ObservableProperty]
    private int _note = 5;

    [ObservableProperty]
    private string _commentaire = string.Empty;

    [ObservableProperty]
    private string _messageErreur = string.Empty;

    [ObservableProperty]
    private bool _aUneErreur;

    public NotationViewModel(DocumentService documentService)
    {
        Title = "Evaluer un document";
        _documentService = documentService;
    }

    [RelayCommand]
    private async Task SoumettreAvis()
    {
        if (SelectedDocument.DocumentId <= 0)
            return;

        if (string.IsNullOrWhiteSpace(Commentaire))
        {
            MessageErreur = "Ajoutez un commentaire avant d'envoyer votre avis.";
            AUneErreur = true;
            return;
        }

        await _documentService.EnregistrerAvisAsync(SelectedDocument, Note, Commentaire);
        await Shell.Current.DisplayAlert("Merci", "Votre avis a bien été pris en compte.", "OK");
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private void ChoisirNote(string note)
    {
        if (int.TryParse(note, out var valeur) && valeur is >= 1 and <= 5)
            Note = valeur;
    }
}