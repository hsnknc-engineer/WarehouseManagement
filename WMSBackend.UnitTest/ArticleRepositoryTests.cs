using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WMSBackend.Data;
using WMSBackend.Models;
using WMSBackend.Repositories;

namespace WMSBackend.UnitTest
{
    [TestFixture]
    public class ArticleRepositoryTests
    {
        private AppDbContext _context; // Datenbankkontext
        private ArticleRepository _repository; // Artikel-Repository

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("DataSource=:memory:") // Nutze SQLite In-Memory-Datenbank
                .Options;

            _context = new AppDbContext(options);
            _context.Database.OpenConnection(); // Verbindung öffnen
            _context.Database.EnsureCreated(); // Datenbank erstellen

            _repository = new ArticleRepository(_context);
        }


        [Test]
        public void AddArticle_ShouldAddArticleToDatabase()
        {
            // Arrange
            var newArticle = new Article { Name = "Artikel A" };

            // Act
            _repository.AddArticle(newArticle);

            // Assert
            var addedArticle = _repository.SearchArticleById(newArticle.Id);
            Assert.That(addedArticle, Is.Not.Null);
            Assert.That(addedArticle.Name, Is.EqualTo("Artikel A"));
        }

        [Test]
        public void GetAllArticles_ShouldReturnExistingArticles()
        {
            // Arrange
            _repository.AddArticle(new Article { Name = "Artikel A" });
            _repository.AddArticle(new Article { Name = "Artikel B" });

            // Act
            var articles = _repository.GetAllArticles();

            // Assert
            Assert.That(articles.Count, Is.EqualTo(2));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose(); // Ressourcen freigeben
        }
    }
}
