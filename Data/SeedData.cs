using duNotes.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace duNotes.Data;

public static class SeedData
{
    public static async Task InitializeAsync(AppDbContext context)
    {
        var db = context.Database;

        if (await db.Table<Filiere>().CountAsync() > 0) return; // déjà seedé

        // Filières ENSPD
        var geiiL1 = new Filiere { Nom = "Licence GEII", Niveau = "L1" };
        var geiiL2 = new Filiere { Nom = "Licence GEII", Niveau = "L2" };
        var geiiL3 = new Filiere { Nom = "Licence GEII", Niveau = "L3" };
        var ingN3 = new Filiere { Nom = "Cycle Ingénieur Informatique et Génie Logiciel", Niveau = "N3" };
        var ingN4 = new Filiere { Nom = "Cycle Ingénieur Informatique et Génie Logiciel", Niveau = "N4" };
        var ingN5 = new Filiere { Nom = "Cycle Ingénieur Informatique et Génie Logiciel", Niveau = "N5" };

        await db.InsertAllAsync(new[] { geiiL1, geiiL2, geiiL3, ingN3, ingN4, ingN5 });

        // Matières ENSPD
        var matieres = new List<Matiere>
        {
            new() { Nom = "Mathématiques de l'ingénieur", FiliereId = geiiL1.FiliereId },
            new() { Nom = "Systèmes d'exploitation (Linux)", FiliereId = ingN3.FiliereId },
            new() { Nom = "Architecture Cloud & AWS", FiliereId = ingN4.FiliereId },
            new() { Nom = "IA et Machine Learning", FiliereId = ingN5.FiliereId },
            new() { Nom = "Bases de données avancées", FiliereId = ingN4.FiliereId },
            new() { Nom = "Algorithmique avancée", FiliereId = ingN3.FiliereId }
        };
        await db.InsertAllAsync(matieres);

        // Documents seed ENSPD
        var docs = new List<Document>
        {
            new Document {
                Titre = "Annales Cloud AWS 2025 - ENSPD",
                Description = "Annales corrigées Architecture Cloud & AWS - Niveau 4",
                Type = "Annales", Pages = 14, TailleKo = 1350,
                MatiereId = matieres[2].MatiereId, NoteMoyenne = 4.7, NbAvis = 29
            },
            new Document {
                Titre = "Fiche IA/ML - Réseaux de neurones convolutifs",
                Description = "Cours condensé + exercices corrigés IA et Machine Learning - N5",
                Type = "Fiche", Pages = 8, TailleKo = 620,
                MatiereId = matieres[3].MatiereId, NoteMoyenne = 4.9, NbAvis = 41
            },
            new Document {
                Titre = "Annales Linux 2024 - ENSPD",
                Description = "Annales Systèmes d'exploitation Linux - N3",
                Type = "Annales", Pages = 11, TailleKo = 980,
                MatiereId = matieres[1].MatiereId, NoteMoyenne = 4.5, NbAvis = 22
            },
            new Document {
                Titre = "Mathématiques de l'ingénieur - Suites & limites",
                Description = "Fiche complète Mathématiques de l'ingénieur - L1 GEII",
                Type = "Fiche", Pages = 6, TailleKo = 480,
                MatiereId = matieres[0].MatiereId, NoteMoyenne = 4.8, NbAvis = 32
            }
        };
        await db.InsertAllAsync(docs);
    }
}