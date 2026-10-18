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
        if (!_documentsHorsLigne.Any(d => d.Id == doc.Id))
        {
            doc.EstTelecharge = true;
            _documentsHorsLigne.Add(doc);
        }
    }

    public async Task SupprimerDocumentAsync(string docId)
    {
        await Task.Delay(200);
        var doc = _documentsHorsLigne.FirstOrDefault(d => d.Id == docId);
        if (doc != null)
        {
            doc.EstTelecharge = false;
            _documentsHorsLigne.Remove(doc);
        }
    }
}