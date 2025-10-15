<Query Kind="Statements">
  <Connection>
    <ID>8f04375a-4a68-48ae-8015-10bec3dbd593</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="EF7Driver" PublicKeyToken="469b5aa5a4331a8c">EF7Driver.StaticDriver</Driver>
    <CustomAssemblyPathEncoded>&lt;UserProfile&gt;\source\repos\NexaWorksTickets\bin\Debug\net8.0\NexaWorksTickets.dll</CustomAssemblyPathEncoded>
    <CustomTypeName>NexaWorksTickets.Data.ApplicationDbContext</CustomTypeName>
    <CustomCxString>Server=(localdb)\mssqllocaldb;Database=NexaWorksTicketsDB;Trusted_Connection=True;MultipleActiveResultSets=true</CustomCxString>
    <DisplayName>NexaWorksTickets</DisplayName>
    <DriverData>
      <UseDbContextOptions>true</UseDbContextOptions>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

// 1. Obtenir tous les problèmes en cours ou tous les problèmes résolus (tous les produits)
Ticket    
    .Where(t => t.StatusId == 2)
	//.Where(t => t.StatusId == 1) pour avoir les problèmes résolus
	.Select(t => new
    {
        ID = t.Id,
        Produit = t.VersionOs.Version.Product.Name,
        Version = t.VersionOs.Version.Number,
        OS = t.VersionOs.Os.Name,
        DateCreation = t.CreatedDate,
        DateResolution = t.ResolvedDate,
        Probleme = t.Problem,
		Resolution = t.Resolution
    })
    .Dump("Tous les tickets en cours");
	//.Dump("Tous les tickets résolus");
	
// 2. Obtenir tous les problèmes en cours pour un produit, ou tous les problèmes résolus pour un produit (toutes les versions)
Ticket 
	.Where(t => t.StatusId == 2 && t.VersionOs.Version.Product.Id == 1) //En cours
	//.Where(t => t.StatusId == 1 && t.VersionOs.Version.Product.Id == 1) //Résolu
	.Select(t => new
    {
        ID = t.Id,
        Produit = t.VersionOs.Version.Product.Name,
        Version = t.VersionOs.Version.Number,
        OS = t.VersionOs.Os.Name,
        DateCreation = t.CreatedDate,
        DateResolution = t.ResolvedDate,
        Probleme = t.Problem,
		Resolution = t.Resolution
    })
    .Dump("Tickets en cours pour Trader en Herbe");
	//.Dump("Tickets résolus pour Trader en Herbe");
	
// 3. Obtenir tous les problèmes en cours pour un produit, ou tous les problèmes résolus pour un produit (une seule version)
Ticket
	.Where(t => t.VersionOs.Version.Product.Id == 1)
	.Where(t => t.VersionOs.Version.Number == "1.2")
	.Where(t => t.StatusId == 2) //En cours
	//.Where(t => t.StatusId == 1) //Résolu
	.Select(t => new
    {
        ID = t.Id,
        Produit = t.VersionOs.Version.Product.Name,
        Version = t.VersionOs.Version.Number,
        OS = t.VersionOs.Os.Name,
        DateCreation = t.CreatedDate,
        DateResolution = t.ResolvedDate,
        Probleme = t.Problem,
		Resolution = t.Resolution
    })
    .Dump("Tickets en cours pour la version 1.2 de Trader en Herbe");
	//.Dump("Tickets résolus pour la version 1.2 de Trader en Herbe");
	
// 4. Obtenir tous les problèmes rencontrés (ou résolus) au cours d’une période donnée pour un produit (toutes les versions)
DateTime startDate = new DateTime(2025, 2, 5);
DateTime endDate = new DateTime(2025, 7, 24);

Ticket
	.Where(t => t.VersionOs.Version.Product.Id == 2) 
	//.Where(t => startDate <= t.CreatedDate && t.CreatedDate <= endDate) //Rencontrés sur une période
	.Where(t => startDate <= t.ResolvedDate && t.ResolvedDate <= endDate) //Résolus sur une période
	.Select(t => new
    {
        ID = t.Id,
        Produit = t.VersionOs.Version.Product.Name,
        Version = t.VersionOs.Version.Number,
        OS = t.VersionOs.Os.Name,
        DateCreation = t.CreatedDate,
        DateResolution = t.ResolvedDate,
        Probleme = t.Problem,
		Resolution = t.Resolution
    })
    //.Dump("Tickets pour toutes les versions de Maître des Investissements créés entre le 05/02/2025 et le 24/07/2025");
	.Dump("Tickets pour toutes les versions de Maître des Investissements résolus entre le 05/02/2025 et le 24/07/2025");
	
// 5. Obtenir tous les problèmes rencontrés (ou résolus) au cours d’une période donnée pour un produit (une seule version)

DateTime startDate1 = new DateTime(2025, 1, 1);
DateTime endDate1 = new DateTime(2025, 9, 4);

Ticket
	.Where(t => t.VersionOs.Version.Product.Id == 4)
	.Where(t => t.VersionOs.Version.Number == "1.1")
	.Where(t => startDate1 <= t.CreatedDate && t.CreatedDate <= endDate1)
	//.Where(t => startDate1 <= t.ResolvedDate && t.ResolvedDate <= endDate1)
	.Select(t => new
    {
        ID = t.Id,
        Produit = t.VersionOs.Version.Product.Name,
        Version = t.VersionOs.Version.Number,
        OS = t.VersionOs.Os.Name,
        DateCreation = t.CreatedDate,
		DateResolution = t.ResolvedDate,
        Probleme = t.Problem,
		Resolution = t.Resolution
    })
    .Dump("Tickets pour la version 1.1 du Planificateur d’Anxiété Sociale créés entre le 01/01/2025 et le 04/09/2025");
	//.Dump("Tickets pour la version 1.1 du Planificateur d’Anxiété Sociale résolus entre le 01/01/2025 et le 04/09/2025");
	
// 6. Obtenir tous les problèmes en cours (ou résolus) contenant une liste de mots-clés (tous les produits)
string[] keyWords = new [] {"utilisateur", "application"};

Ticket
	.Where(t => t.StatusId == 2)
	//.Where(t => t.StatusId == 1)
	.Where(t => keyWords.Any(k => t.Problem.Contains(k)))
	.Select(t => new
    {
        ID = t.Id,
        Produit = t.VersionOs.Version.Product.Name,
        Version = t.VersionOs.Version.Number,
        OS = t.VersionOs.Os.Name,
        DateCreation = t.CreatedDate,
        DateResolution = t.ResolvedDate,
        Probleme = t.Problem,
		Resolution = t.Resolution
    })
    .Dump("Tickets en cours contenant les mots clés \"utilisateur\" et/ou \"application\"");
	//.Dump("Tickets résolus contenant les mots clés \"utilisateur\" et/ou \"application\"");
	

// 7. Obtenir tous les problèmes en cours (ou résolus) pour un produit contenant une liste de mots-clés (toutes les versions)	
string[] keyWords1 = new [] {"utilisateur", "application"};

Ticket
	.Where(t => t.StatusId == 2)
	//.Where(t => t.StatusId == 1)
	.Where(t => t.VersionOs.Version.Product.Id == 2)
	.Where(t => keyWords1.Any(k => t.Problem.Contains(k)))
	.Select(t => new
    {
        ID = t.Id,
        Produit = t.VersionOs.Version.Product.Name,
        Version = t.VersionOs.Version.Number,
        OS = t.VersionOs.Os.Name,
        DateCreation = t.CreatedDate,
		DateResolution = t.ResolvedDate,
        Probleme = t.Problem,
		Resolution = t.Resolution
    })
    .Dump("Tickets en cours pour Maître des Investissements contenant les mots clés \"utilisateur\" et/ou \"application\"");
	//.Dump("Tickets résolus pour Maître des Investissements contenant les mots clés \"utilisateur\" et/ou \"application\"");
	
// 8. Obtenir tous les problèmes en cours (résolus) pour un produit contenant une liste de mots-clés (une seule version)
string[] keyWords2 = new [] {"utilisateur", "application"};

Ticket
	.Where(t => t.StatusId == 2)
	//.Where(t => t.StatusId == 1)
	.Where(t => t.VersionOs.Version.Product.Id == 1)
	.Where(t => t.VersionOs.Version.Number == "1.2")
	.Where(t => keyWords2.Any(k => t.Problem.Contains(k)))
	.Select(t => new
    {
        ID = t.Id,
        Produit = t.VersionOs.Version.Product.Name,
        Version = t.VersionOs.Version.Number,
        OS = t.VersionOs.Os.Name,
        DateCreation = t.CreatedDate,
		DateResolution = t.ResolvedDate,
        Probleme = t.Problem,
		Resolution = t.Resolution
    })
	.Dump("Tickets en cours pour la version 1.2 de Trader en Herbe contenant les mots clés \"utilisateur\" et/ou \"application\"");
	//.Dump("Tickets résolus pour la version 1.2 de Trader en Herbe contenant les mots clés \"utilisateur\" et/ou \"application\"");

// 9. Obtenir tous les problèmes rencontrés (ou résolus) au cours d’une période donnée pour un produit contenant une liste de mots-clés (toutes les versions)
string[] keyWords3 = new [] {"utilisateur", "application"};

DateTime startDate2 = new DateTime(2025, 1, 1);
DateTime endDate2 = new DateTime(2025, 9, 10);

Ticket
	.Where(t => t.VersionOs.Version.Product.Id == 1)
	.Where(t => keyWords3.Any(k => t.Problem.Contains(k)))
	.Where(t => startDate2 <= t.CreatedDate && t.CreatedDate <= endDate2)
	//.Where(t => startDate2 <= t.ResolvedDate && t.ResolvedDate <= endDate2)
	.Select(t => new
    {
        ID = t.Id,
        Produit = t.VersionOs.Version.Product.Name,
        Version = t.VersionOs.Version.Number,
        OS = t.VersionOs.Os.Name,
        DateCreation = t.CreatedDate,
		DateResolution = t.ResolvedDate,
        Probleme = t.Problem,
		Resolution = t.Resolution
    })
	.Dump("Tickets pour Trader en Herbe créés entre le 01/01/2025 et le 10/09/2025 contenant les mots clés \"utilisateur\" et/ou \"application\"");
	//.Dump("Tickets pour Trader en Herbe résolus entre le 01/01/2025 et le 10/09/2025 contenant les mots clés \"utilisateur\" et/ou \"application\"");
	
// 10. Obtenir tous les problèmes rencontrés (ou résolus) au cours d’une période donnée pour un produit contenant une liste de mots-clés (une seule version)
string[] keyWords4 = new [] {"utilisateur", "application"};

DateTime startDate3 = new DateTime(2025, 1, 1);
DateTime endDate3 = new DateTime(2025, 9, 4);

Ticket
	.Where(t => t.VersionOs.Version.Product.Id == 1)
	.Where(t => t.VersionOs.Version.Number == "1.2")
	.Where(t => keyWords4.Any(k => t.Problem.Contains(k)))
	//.Where(t => startDate3 <= t.CreatedDate && t.CreatedDate <= endDate3)
	.Where(t => startDate3 <= t.ResolvedDate && t.ResolvedDate <= endDate3)
	.Select(t => new
    {
        ID = t.Id,
        Produit = t.VersionOs.Version.Product.Name,
        Version = t.VersionOs.Version.Number,
        OS = t.VersionOs.Os.Name,
        DateCreation = t.CreatedDate,
		DateResolution = t.ResolvedDate,
        Probleme = t.Problem,
		Resolution = t.Resolution
    })
	//.Dump("Tickets pour la version 1.2 de Trader en Herbe créés entre le 01/01/2025 et le 04/09/2025 contenant les mots clés \"utilisateur\" et/ou \"application\"");
	.Dump("Tickets pour la version 1.2 de Trader en Herbe résolus entre le 01/01/2025 et le 04/09/2025 contenant les mots clés \"utilisateur\" et/ou \"application\"");