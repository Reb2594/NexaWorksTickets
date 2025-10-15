using NexaWorksTickets.Data;
using NexaWorksTickets.Models.Entities;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Ticket.Any())
            return;

        var versionOsDict = context.VersionOs
            .ToDictionary(
                vo => (vo.VersionId, vo.OsId),
                vo => vo.Id
            );

        var tickets = new[]
        {
            // Ticket 1
            new Ticket
            {
                VersionOsId = versionOsDict[(2,2)], // Trader en Herbe v1.1 MacOS
                StatusId = 1,
                CreatedDate = new DateTime(2025,1,10),
                ResolvedDate = new DateTime(2025,1,18),
                Problem = "Lors de l’ouverture du portefeuille, certains utilisateurs voient leur solde affiché à zéro alors que leurs transactions sont bien présentes. Le problème survient uniquement après une mise à jour de l’application.",
                Resolution = "La mise à jour n’actualisait pas la table des soldes au premier lancement. Ajout d’une requête de recalcul automatique du solde après installation d’une mise à jour."
            },
            // Ticket 2
            new Ticket
            {
                VersionOsId = versionOsDict[(4,3)], // Trader en Herbe v1.3 Windows
                StatusId = 2,
                CreatedDate = new DateTime(2025,1,22),
                Problem = "Le graphique cesse de se mettre à jour après environ une heure d’utilisation continue. Les utilisateurs doivent redémarrer l’application pour relancer le flux."
            },
            // Ticket 3
            new Ticket
            {
                VersionOsId = versionOsDict[(1,1)], // Trader en Herbe v1.0 Linux
                StatusId = 1,
                CreatedDate = new DateTime(2025,2,3),
                ResolvedDate = new DateTime(2025,2,9),
                Problem = "Lorsqu’un utilisateur vend partiellement une position (par ex. 5 actions sur 10), le nombre restant s’affiche incorrectement (souvent doublé).",
                Resolution = "Le champ \"quantité restante\" utilisait la valeur brute au lieu de la valeur calculée. Correction du calcul et ajout de tests unitaires."
            },
            // Ticket 4
            new Ticket
            {
                VersionOsId = versionOsDict[(4,5)], // Trader en Herbe v1.3 iOS
                StatusId = 2,
                CreatedDate = new DateTime(2025,2,15),
                Problem = "Les notifications d’alerte de prix arrivent avec plusieurs heures de retard pour certains utilisateurs européens."
            },
            // Ticket 5
            new Ticket
            {
                VersionOsId = versionOsDict[(3,6)], // Trader en Herbe v1.2 Windows Mobile
                StatusId = 1,
                CreatedDate = new DateTime(2025,3,1),
                ResolvedDate = new DateTime(2025,3,6),
                Problem = "Impossible d’ajouter un compte bancaire dans une devise autre que l’euro, ce qui bloque les utilisateurs internationaux.",
                Resolution = "Le champ devise de la table des comptes n’acceptait pas les devises étrangères. Ajout d’un support multi-devises et mise à jour de l’API de validation."
            },
            // Ticket 6
            new Ticket
            {
                VersionOsId = versionOsDict[(5,2)], // Maître des Investissements v1.0 MacOS
                StatusId = 2,
                CreatedDate = new DateTime(2025,1,10),
                Problem = "Lorsqu’un utilisateur consulte son tableau de bord sur plusieurs appareils, les données ne sont pas toujours cohérentes (différence dans les courbes de rendement)."
            },
            // Ticket 7
            new Ticket
            {
                VersionOsId = versionOsDict[(6,4)], // Maître des Investissements v2.0 Android
                StatusId = 1,
                CreatedDate = new DateTime(2025,3,5),
                ResolvedDate = new DateTime(2025,3,10),
                Problem = "Les rapports exportés en PDF n’affichent pas les graphiques, seulement les tableaux chiffrés.",
                Resolution = "Le module PDF ne gérait pas l’export d’images SVG. Conversion des graphiques en PNG avant génération."
            },
            // Ticket 8
            new Ticket
            {
                VersionOsId = versionOsDict[(7,5)], // Maître des Investissements v2.1 iOS
                StatusId = 2,
                CreatedDate = new DateTime(2025,4,23),
                Problem = "Les filtres par secteur (banque, énergie, santé…) ne renvoient aucun résultat même quand des données existent."
            },
            // Ticket 9
            new Ticket
            {
                VersionOsId = versionOsDict[(6,2)], // Maître des Investissements v2.0 MacOS
                StatusId = 1,
                CreatedDate = new DateTime(2025,6,20),
                ResolvedDate = new DateTime(2025,6,30),
                Problem = "Dans le calcul des dividendes, certains montants apparaissent doublés, ce qui gonfle artificiellement le rendement.",
                Resolution = "Bug identifié dans la jointure SQL qui doublait certaines lignes. Correction apportée et base recalculée."
            },
            // Ticket 10
            new Ticket
            {
                VersionOsId = versionOsDict[(5,5)], // Maître des Investissements v1.0 iOS
                StatusId = 2,
                CreatedDate = new DateTime(2025,5,3),
                Problem = "L’application déconnecte automatiquement l’utilisateur au bout de 5 minutes d’inactivité, ce qui est trop court pour une analyse."
            },
            // Ticket 11
            new Ticket
            {
                VersionOsId = versionOsDict[(9,4)], // Planificateur d'Entraînement v1.1 Android
                StatusId = 2,
                CreatedDate = new DateTime(2025,3,4),
                Problem = "Les séances planifiées disparaissent lorsqu’on redémarre l’application, surtout sur certains modèles de téléphones."
            },
            // Ticket 12
            new Ticket
            {
                VersionOsId = versionOsDict[(8,1)], // Planificateur d'Entraînement v1.0 Linux
                StatusId = 1,
                CreatedDate = new DateTime(2025,1,18),
                ResolvedDate = new DateTime(2025,1,25),
                Problem = "Les utilisateurs ne peuvent pas ajouter de nouveaux exercices personnalisés, l’application affiche un message d’erreur vide.",
                Resolution = "Correction d’une clé manquante dans la table \"exercices\"."
            },
            // Ticket 13
            new Ticket
            {
                VersionOsId = versionOsDict[(10,3)], // Planificateur d'Entraînement v2.0 Windows
                StatusId = 2,
                CreatedDate = new DateTime(2025,7,5),
                Problem = "Le compteur de calories brûlées affiche toujours zéro pour les activités de cardio."
            },
            // Ticket 14
            new Ticket
            {
                VersionOsId = versionOsDict[(9,4)], // Planificateur d'Entraînement v1.1 Android
                StatusId = 1,
                CreatedDate = new DateTime(2025,5,15),
                ResolvedDate = new DateTime(2025,5,20),
                Problem = "Les notifications d’entraînement programmées ne s’affichent pas sur certains appareils Android.",
                Resolution = "Mise à jour du système de notification pour supporter Android 13."
            },
            // Ticket 15
            new Ticket
            {
                VersionOsId = versionOsDict[(9,5)], // Planificateur d'Entraînement v1.1 iOS
                StatusId = 2,
                CreatedDate = new DateTime(2025,2,28),
                Problem = "Les vidéos d’exercices intégrées ne se chargent pas en 4G, seulement en Wi-Fi."
            },
            // Ticket 16
            new Ticket
            {
                VersionOsId = versionOsDict[(11,3)], // Planificateur d'Anxiété Sociale v1.0 Windows
                StatusId = 1,
                CreatedDate = new DateTime(2025,3,10),
                ResolvedDate = new DateTime(2025,3,20),
                Problem = "Les entrées du journal de progression ne se sauvegardaient pas si l’application était fermée brutalement.",
                Resolution = "Ajout d’une sauvegarde automatique à chaque validation d’entrée."
            },
            // Ticket 17
            new Ticket
            {
                VersionOsId = versionOsDict[(12,4)], // Planificateur d'Anxiété Sociale v1.1 Android
                StatusId = 2,
                CreatedDate = new DateTime(2025,1,22),
                Problem = "Les exercices de respiration guidée s’interrompent après 30 secondes au lieu de 3 minutes."
            },
            // Ticket 18
            new Ticket
            {
                VersionOsId = versionOsDict[(11,5)], // Planificateur d'Anxiété Sociale v1.0 iOS
                StatusId = 1,
                CreatedDate = new DateTime(2025,2,2),
                ResolvedDate = new DateTime(2025,2,8),
                Problem = "Le mode sombre ne s’appliquait pas à la section \"Paramètres\".",
                Resolution = "Ajout des feuilles de style manquantes."
            },
            // Ticket 19
            new Ticket
            {
                VersionOsId = versionOsDict[(12,3)], // Planificateur d'Anxiété Sociale v1.1 Windows
                StatusId = 2,
                CreatedDate = new DateTime(2025,6,15),
                Problem = "Les rappels quotidiens ne se déclenchent pas si l’application n’a pas été ouverte depuis plus de 72 heures."
            },
            // Ticket 20
            new Ticket
            {
                VersionOsId = versionOsDict[(11,2)], // Planificateur d'Anxiété Sociale v1.0 MacOS
                StatusId = 1,
                CreatedDate = new DateTime(2025,3,1),
                ResolvedDate = new DateTime(2025,3,10),
                Problem = "L’export du rapport de progression par email échoue avec une erreur \"fichier introuvable\".",
                Resolution = "Correction du chemin temporaire utilisé pour générer le fichier PDF."
            },
            // Ticket 21
            new Ticket
            {
                VersionOsId = versionOsDict[(4,4)], // Trader en Herbe v1.3 Android
                StatusId = 2,
                CreatedDate = new DateTime(2025,3,10),
                Problem = "Les alertes de prix s’affichent même si l’utilisateur les a désactivées."
            },
            // Ticket 22
            new Ticket
            {
                VersionOsId = versionOsDict[(7,5)], // Maître des Investissements v2.1 iOS
                StatusId = 1,
                CreatedDate = new DateTime(2025,4,15),
                ResolvedDate = new DateTime(2025,4,22),
                Problem = "Dans le simulateur de crédit, les taux d’intérêt étaient arrondis à l’entier le plus proche.",
                Resolution = "Mise à jour du calcul pour afficher les décimales avec précision au centième."
            },
            // Ticket 23
            new Ticket
            {
                VersionOsId = versionOsDict[(9,1)], // Planificateur d'Entraînement v1.1 Linux
                StatusId = 2,
                CreatedDate = new DateTime(2025,6,20),
                Problem = "Lorsqu’on planifie plusieurs séances le même jour, seule la première est enregistrée."
            },
            // Ticket 24
            new Ticket
            {
                VersionOsId = versionOsDict[(12,4)], // Planificateur d'Anxiété Sociale v1.1 Android
                StatusId = 1,
                CreatedDate = new DateTime(2025,3,25),
                ResolvedDate = new DateTime(2025,3,30),
                Problem = "Les sons de méditation ne se lançaient pas si le téléphone était en mode silencieux.",
                Resolution = "Modification du lecteur audio pour ignorer le mode silencieux."
            },
            // Ticket 25
            new Ticket
            {
                VersionOsId = versionOsDict[(3,6)], // Trader en Herbe v1.2 Windows Mobile
                StatusId = 2,
                CreatedDate = new DateTime(2025,4,5),
                Problem = "Le graphique d’évolution du portefeuille reste vide après la dernière mise à jour de l’application."
            }
        };

        context.Ticket.AddRange(tickets);
        context.SaveChanges();
    }
}