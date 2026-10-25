using duNotes.Models;

namespace duNotes.Services;

public class OfflineService
{
    private readonly List<Document> _documentsHorsLigne = new();

    public async Task<List<Document>> GetDocumentsHorsLigneAsync()
    {
        await Task.Delay(200);
        return _documentsHorsLigne;
    }

    public async Task SauvegarderDocumentAsync(Document doc)
    {
        await Task.Delay(300);
        if (!_documentsHorsLigne.Any(document => document.DocumentId == doc.DocumentId))
        {
            doc.EstTelecharge = true;
            _documentsHorsLigne.Add(doc);
        }
    }

    public async Task SupprimerDocumentAsync(string documentId)
    {
        await Task.Delay(200);
        if (!int.TryParse(documentId, out var parsedDocumentId))
            return;

        var doc = _documentsHorsLigne.FirstOrDefault(document => document.DocumentId == parsedDocumentId);
        if (doc != null)
        {
            doc.EstTelecharge = false;
            _documentsHorsLigne.Remove(doc);
        }
    }
}