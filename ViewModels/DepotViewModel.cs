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

    [ObservableProperty]
    private string _nomFichier = "Aucun fichier sélectionné";

    [ObservableProperty]
    private string _messageErreur = string.Empty;

    [ObservableProperty]
    private bool _aUneErreur;

    private FileResult? _fichierSelectionne;

    public DepotViewModel(DocumentService documentService)
    {
        Title = "Déposer une note";
        _documentService = documentService;
    }

    [RelayCommand]
    private async Task ChoisirFichier()
    {
        var fichier = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Choisir un document PDF",
            FileTypes = FilePickerFileType.Pdf
        });

        if (fichier is null)
            return;

        _fichierSelectionne = fichier;
        NomFichier = fichier.FileName;
        AUneErreur = false;
    }

    [RelayCommand]
    private async Task Publier()
    {
        if (string.IsNullOrWhiteSpace(Titre) || string.IsNullOrWhiteSpace(Matiere))
        {
            MessageErreur = "Le titre et la matière sont obligatoires.";
            AUneErreur = true;
            return;
        }

        if (_fichierSelectionne is null)
        {
            MessageErreur = "Sélectionnez le fichier PDF à déposer.";
            AUneErreur = true;
            return;
        }

        var cheminFichier = Path.Combine(FileSystem.AppDataDirectory, $"{Guid.NewGuid():N}{Path.GetExtension(_fichierSelectionne.FileName)}");
        await using (var source = await _fichierSelectionne.OpenReadAsync())
        await using (var destination = File.Create(cheminFichier))
            await source.CopyToAsync(destination);

        var doc = new Document
        {
            Titre = Titre,
            Description = Description,
            Matiere = Matiere,
            Niveau = Niveau,
            Auteur = "Utilisateur Actuel",
            CheminFichier = cheminFichier,
            TailleKo = (int)Math.Ceiling(new FileInfo(cheminFichier).Length / 1024d)
        };

        await _documentService.PublierDocumentAsync(doc);
        Titre = string.Empty;
        Description = string.Empty;
        _fichierSelectionne = null;
        NomFichier = "Aucun fichier sélectionné";
        await Shell.Current.DisplayAlert("Succès", "Votre document a été publié avec succès !", "OK");
    }
}