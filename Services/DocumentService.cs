using duNotes.Models;

namespace duNotes.Services;

public class DocumentService
{
    private readonly List<Document> _documents = MockData.GetDocumentsMock();

    public async Task<List<Document>> GetDocumentsAsync(string? recherche = null, string? matiere = null)
    {
        await Task.Delay(300);
        var result = _documents.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(recherche))
        {
            result = result.Where(d => d.Titre.Contains(recherche, StringComparison.OrdinalIgnoreCase) ||
                                       d.Matiere.Contains(recherche, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(matiere) && matiere != "Toutes")
        {
            result = result.Where(d => d.Matiere.Equals(matiere, StringComparison.OrdinalIgnoreCase));
        }

        return result.ToList();
    }

    public async Task PublierDocumentAsync(Document doc)
    {
        await Task.Delay(400);
        _documents.Insert(0, doc);
    }
}