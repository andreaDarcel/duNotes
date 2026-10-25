using duNotes.Data;
using duNotes.Models;

namespace duNotes.Services;

public class DocumentService
{
    private readonly AppDbContext _dbContext;
    private readonly object _initializationLock = new();
    private Task? _initializationTask;

    public DocumentService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task InitializeAsync()
    {
        lock (_initializationLock)
        {
            return _initializationTask ??= InitializeDatabaseAsync();
        }
    }

    private async Task InitializeDatabaseAsync()
    {
        await _dbContext.InitializeAsync();
        await SeedData.InitializeAsync(_dbContext);
    }

    public async Task<List<Document>> SearchAsync(string? matiere = null, string? type = null, int? tailleMax = null)
    {
        var documents = await GetAllAsync();
        return documents
            .Where(document => string.IsNullOrWhiteSpace(matiere)
                || (document.MatiereNom?.Contains(matiere, StringComparison.OrdinalIgnoreCase) ?? false))
            .Where(document => string.IsNullOrWhiteSpace(type)
                || string.Equals(document.Type, type, StringComparison.OrdinalIgnoreCase))
            .Where(document => !tailleMax.HasValue || document.TailleKo <= tailleMax.Value)
            .ToList();
    }

    public async Task<List<Document>> GetDocumentsAsync(string? searchQuery = null)
    {
        var documents = await GetAllAsync();
        if (string.IsNullOrWhiteSpace(searchQuery))
            return documents;

        return documents
            .Where(document => document.Titre.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)
                || (document.MatiereNom?.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ?? false)
                || document.Description.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public async Task<List<Document>> GetAllAsync()
    {
        await InitializeAsync();
        var documents = await _dbContext.Database.Table<Document>().ToListAsync();
        var subjects = await _dbContext.Database.Table<Matiere>().ToListAsync();
        var programs = await _dbContext.Database.Table<Filiere>().ToListAsync();
        var subjectsById = subjects.ToDictionary(subject => subject.MatiereId);
        var programsById = programs.ToDictionary(program => program.FiliereId);

        foreach (var document in documents)
        {
            if (subjectsById.TryGetValue(document.MatiereId, out var subject))
            {
                document.MatiereNom = subject.Nom;
                if (programsById.TryGetValue(subject.FiliereId, out var program))
                    document.Niveau = program.Niveau;
            }

            document.Auteur = string.IsNullOrWhiteSpace(document.Auteur) ? "Communauté duNotes" : document.Auteur;
        }

        return documents;
    }

    public async Task EnregistrerAvisAsync(Document document, int note, string commentaire)
    {
        await InitializeAsync();
        if (note is < 1 or > 5)
            throw new ArgumentOutOfRangeException(nameof(note), "La note doit être comprise entre 1 et 5.");

        await _dbContext.Database.InsertAsync(new Avis
        {
            DocumentId = document.DocumentId,
            Note = note,
            Commentaire = commentaire.Trim(),
            DateAvis = DateTime.UtcNow
        });

        var totalNotes = document.NbAvis;
        document.NoteMoyenne = ((document.NoteMoyenne * totalNotes) + note) / (totalNotes + 1);
        document.NbAvis++;
        await _dbContext.Database.UpdateAsync(document);
    }

    public async Task PublierDocumentAsync(Document document)
    {
        await InitializeAsync();
        if (string.IsNullOrWhiteSpace(document.Titre))
            throw new ArgumentException("Le titre du document est obligatoire.", nameof(document));

        if (!string.IsNullOrWhiteSpace(document.Matiere))
            document.MatiereNom = document.Matiere.Trim();

        document.DateMiseEnLigne = DateTime.UtcNow;
        await _dbContext.Database.InsertAsync(document);
    }
}