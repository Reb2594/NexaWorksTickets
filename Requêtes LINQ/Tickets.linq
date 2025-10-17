<Query Kind="Statements">
  <Connection>
    <ID>8f7ceeaa-44f3-4d9a-af8b-aa75337b17bf</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>NexaWorksTicketsDB</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
  <Reference Relative="..\Code\bin\Debug\net8.0\Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.dll">&lt;UserProfile&gt;\source\repos\NexaWorksTickets\Code\bin\Debug\net8.0\Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.dll</Reference>
  <Reference Relative="..\Code\bin\Debug\net8.0\Microsoft.AspNetCore.Identity.EntityFrameworkCore.dll">&lt;UserProfile&gt;\source\repos\NexaWorksTickets\Code\bin\Debug\net8.0\Microsoft.AspNetCore.Identity.EntityFrameworkCore.dll</Reference>
  <Reference Relative="..\Code\bin\Debug\net8.0\Microsoft.EntityFrameworkCore.Abstractions.dll">&lt;UserProfile&gt;\source\repos\NexaWorksTickets\Code\bin\Debug\net8.0\Microsoft.EntityFrameworkCore.Abstractions.dll</Reference>
  <Reference Relative="..\Code\bin\Debug\net8.0\Microsoft.EntityFrameworkCore.Design.dll">&lt;UserProfile&gt;\source\repos\NexaWorksTickets\Code\bin\Debug\net8.0\Microsoft.EntityFrameworkCore.Design.dll</Reference>
  <Reference Relative="..\Code\bin\Debug\net8.0\Microsoft.EntityFrameworkCore.dll">&lt;UserProfile&gt;\source\repos\NexaWorksTickets\Code\bin\Debug\net8.0\Microsoft.EntityFrameworkCore.dll</Reference>
  <Reference Relative="..\Code\bin\Debug\net8.0\Microsoft.EntityFrameworkCore.Relational.dll">&lt;UserProfile&gt;\source\repos\NexaWorksTickets\Code\bin\Debug\net8.0\Microsoft.EntityFrameworkCore.Relational.dll</Reference>
  <Reference Relative="..\Code\bin\Debug\net8.0\Microsoft.EntityFrameworkCore.SqlServer.dll">&lt;UserProfile&gt;\source\repos\NexaWorksTickets\Code\bin\Debug\net8.0\Microsoft.EntityFrameworkCore.SqlServer.dll</Reference>
  <Reference Relative="..\Code\bin\Debug\net8.0\NexaWorksTickets.dll">&lt;UserProfile&gt;\source\repos\NexaWorksTickets\Code\bin\Debug\net8.0\NexaWorksTickets.dll</Reference>
  <Namespace>Microsoft.EntityFrameworkCore</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.Metadata</Namespace>
  <Namespace>NexaWorksTickets.Code.Data</Namespace>
  <Namespace>NexaWorksTickets.Code.Models.Entities</Namespace>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

// Paramètres à modifier en fonction du résultat escompté
int? productId = null;                 // ex: 1 = Trader en Herbe, 2 = Maître des Investissements, 3 = Planificateur d'Entraînement, 4 = Planificateur d'Anxiété Sociale
string? versionNumber = null;          // ex: "1.2"
int? statusId = 2;                     // 2 = en cours, 1 = résolu
DateTime? startDate = null;            // ex: new DateTime(2025, 1, 1)
DateTime? endDate = null;              // ex: new DateTime(2025, 9, 4)
string[] keyWords = null;			   //new [] { "utilisateur", "application" };

// Requête de base
var query = Tickets.AsQueryable();

// Filtres optionnels
if (statusId != null)
    query = query.Where(t => t.StatusId == statusId);

if (productId != null)
    query = query.Where(t => t.VersionOs.Version.Product.Id == productId);

if (versionNumber != null)
    query = query.Where(t => t.VersionOs.Version.Number == versionNumber);

if (startDate != null && endDate != null)
{    
    //query = query.Where(t => t.CreatedDate >= startDate && t.CreatedDate <= endDate);
	query = query.Where(t => t.ResolvedDate >= startDate && t.ResolvedDate <= endDate);
}

// Gestion affichage
var result = query
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
	.AsEnumerable()
        .Where(t => keyWords == null || keyWords.Length == 0 || 
               keyWords.Any(k => t.Probleme.Contains(k)))
	.ToList();

// Affichage final
result.Dump("Résultat de la requête paramétrée");
