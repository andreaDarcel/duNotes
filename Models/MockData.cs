namespace duNotes.Models;

public static class MockData
{
    public static List<Document> GetDocumentsMock()
    {
        return new List<Document>
        {
            new Document { Id = "1", Titre = "Cours complet Algorithmique & C++", Matiere = "Informatique", Niveau = "Licence 1", Auteur = "Dr. Kameni", NoteMoyenne = 4.8, NombreEvaluations = 24, TailleFichier = "2.4 MB" },
            new Document { Id = "2", Titre = "Fiche de révision Mathématiques Signal", Matiere = "Mathématiques", Niveau = "Licence 2", Auteur = "Prof. Obama", NoteMoyenne = 4.5, NombreEvaluations = 18, TailleFichier = "1.1 MB" },
            new Document { Id = "3", Titre = "Résumé Architecture des Réseaux CISCO", Matiere = "Réseaux", Niveau = "Ingénieur 3", Auteur = "Darcel A.", NoteMoyenne = 4.9, NombreEvaluations = 35, TailleFichier = "3.8 MB" },
            new Document { Id = "4", Titre = "Annales & Corrigés Électronique Numérique", Matiere = "Électronique", Niveau = "Licence 2", Auteur = "Poly-Tech Club", NoteMoyenne = 4.2, NombreEvaluations = 12, TailleFichier = "5.0 MB" }
        };
    }
}