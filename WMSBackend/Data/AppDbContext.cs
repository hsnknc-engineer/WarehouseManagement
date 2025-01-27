using Microsoft.EntityFrameworkCore;
using WMSBackend.Models;

namespace WMSBackend.Data
{
    // Diese Klasse stellt die Verbindung zwischen deinem Code und der Datenbank her
    public class AppDbContext : DbContext 
    {
        // Konstruktor: Übergibt die Konfigurationsoptionen an die Basis-Klasse
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet repräsentiert eine Tabelle in der Datenbank.
        // "SqlArticles" ist der Name der Tabelle, die Artikel enthält.
        // Artikel-Daten basieren auf dem "Article"-Modell (z. B. mit den Feldern Id und Name).
        public DbSet<Article> SqlArticles { get; set; }
    }
}
