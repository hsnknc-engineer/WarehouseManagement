using Microsoft.EntityFrameworkCore;
using WMSBackend.Data;
using WMSBackend.Models;
using WMSBackend.Repositories;


namespace WMSBackend.UnitTest
{
    [TestFixture]
    public class ArticleRepositoryTests
    {
        private static AppDbContext _context; // Gemeinsamer Datenbankkontext
        private static ArticleRepository _repository; // Gemeinsames Repository

        [OneTimeSetUp] // Wird nur einmal vor allen Tests ausgeführt
        public void OneTimeSetup()
        {
            // Konfiguration für die Verbindung zur Datenbank
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=DESKTOP-HE4ULMV;Database=WMSDatabase;User Id=TestUser;Password=Passwort123;TrustServerCertificate=True;Encrypt=False")
                .Options;

            // Initialisierung von DbContext und Repository
            _context = new AppDbContext(options);
            _repository = new ArticleRepository(_context);
        }

        [Test]
        public void AddArticle_ShouldAddArticleToDatabase()
        {
            // Arrange: Erstelle einen neuen Artikel
            var newArticle = new Article { Name = "Artikel B" }; // ID wird automatisch generiert

            // Act: Füge den Artikel hinzu
            _repository.AddArticle(newArticle);

            // Assert: Überprüfe, ob der Artikel korrekt hinzugefügt wurde
            var addedArticle = _repository.SearchArticleById(newArticle.Id); // Automatisch generierte ID
            Assert.That(addedArticle, Is.Not.Null, "Der Artikel wurde nicht in die Datenbank eingefügt.");
            Assert.That(addedArticle.Name, Is.EqualTo("Artikel B"), "Der Artikelname wurde nicht korrekt gespeichert.");
        }

        [Test]
        public void GetAllArticles_ShouldReturnExistingArticlesInDatabase()
        {
            // Act: Rufe alle vorhandenen Artikel aus der Datenbank ab
            var articles = _repository.GetAllArticles();

            // Assert: Überprüfe, ob Artikel in der Datenbank vorhanden sind
            Assert.That(articles, Is.Not.Null, "Die Artikel-Liste ist null.");
            Assert.That(articles.Count, Is.GreaterThan(0), "Es wurden keine Artikel gefunden.");

            // Optional: Gib die Artikel in der Konsole aus
            foreach (var article in articles)
            {
                Console.WriteLine($"ID: {article.Id}, Name: {article.Name}");
            }
        }

        [OneTimeTearDown] // Wird nur einmal nach allen Tests ausgeführt
        public void OneTimeTearDown()
        {
            // Ressourcen nach allen Tests freigeben
            _context.Dispose();
        }
    }
}