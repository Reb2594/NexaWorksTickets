# NexaWorksTickets

## Description du projet
Projet 6 de la formation OpenClassrooms "Développeur d'application back-end .NET"

Base de données pour la gestion de tickets (suivi de problèmes) des applications NexaWorks.

## Fonctionnalités
- Suivi des tickets (en cours et résolus)
- Gestion des produits et leurs versions
- Compatibilité avec différents systèmes d'exploitation
- Recherche de tickets par différents critères

## Structure de la base de données
![MCD](https://github.com/Reb2594/NexaWorksTickets/blob/master/Mod%C3%A8le-entit%C3%A9-association.png)

La base de données est constituée des tables principales suivantes :
- Products : Gestion des produits
- ProductVersions : Versions des produits
- Os : Systèmes d'exploitation
- VersionOs : Relations entre versions et OS
- Tickets : Suivi des problèmes
- Status : États des tickets (En cours/Résolu)

## Technologies utilisées
- Entity Framework Core
- SQL Server
- LINQ
- C#
- LINQPad

## Contenu du repository
- Un diagramme décrivant les relations entre les différentes entités. (Voir ci-dessus)
- `DbInitializer.cs` : Code pour l'initialisation de la base de données avec les données des 25 tickets à intégrer
- `ApplicationDbContext.cs` : Configuration de la base de données
- `Tickets.linq` : Fichier contenant les requêtes optimisées pour récupérer les informations des tickets
- Documentation des requêtes (Excel)

## Installation et utilisation
1. Clonez le repository :
```bash
git clone [https://github.com/Reb2594/NexaWorksTickets.git]
```

2. Restaurez les packages NuGet
3. Configurez la chaîne de connexion dans appsettings.json
4. Exécutez les migrations :
```bash
Update-Database
```

## Auteur
Rebecca Bajazet

Formation Développeur backend .NET - OpenClassrooms - Octobre 2025
