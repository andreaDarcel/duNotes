namespace duNotes.Models;

public static class MockData
{
    public static List<Document> GetDocumentsMock()
    {
        return new List<Document>
        {
            new Document { Titre = "Cours complet Algorithmique & C++", Matiere = "Informatique", Niveau = "Licence 1", Auteur = "Dr. Kameni", NoteMoyenne = 4.8, NbAvis = 24, TailleKo = 2458 },
            new Document { Titre = "Fiche de révision Mathématiques Signal", Matiere = "Mathématiques", Niveau = "Licence 2", Auteur = "Prof. Obama", NoteMoyenne = 4.5, NbAvis = 18, TailleKo = 1126 },
            new Document { Titre = "Résumé Architecture des Réseaux CISCO", Matiere = "Réseaux", Niveau = "Ingénieur 3", Auteur = "Darcel A.", NoteMoyenne = 4.9, NbAvis = 35, TailleKo = 3891 },
            new Document { Titre = "Annales & Corrigés Électronique Numérique", Matiere = "Électronique", Niveau = "Licence 2", Auteur = "Poly-Tech Club", NoteMoyenne = 4.2, NbAvis = 12, TailleKo = 5120 }
        };
    }
}