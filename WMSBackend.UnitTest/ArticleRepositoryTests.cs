using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMSBackend.Models;
using WMSBackend.Repositories;

namespace WMSBackend.UnitTest.Repositories
{
    [TestFixture] // Markiert diese Klasse als Testklasse
    public class ArticleRepositoryTests
    {
        private ArticleRepository _repository; // Repository-Instanz für die Tests

        [SetUp] // Setup-Methode wird vor jedem Test ausgeführt
        public void Setup()
        {
            _repository = new ArticleRepository(); // Repository initialisieren
        }

        


        [Test] // Test für das Hinzufügen eines Artikels
        public void AddArticle_ShouldAddArticle_WhenValid()
        {
            // Arrange
            var newArticle = new Article(4, "Artikel D");

            // Act
            _repository.AddArticle(newArticle);

            // Assert
            var addedArticle = _repository.SearchArticleById(4);
            Assert.That(addedArticle, Is.Not.Null, "Der Artikel wurde nicht hinzugefügt.");
            Assert.That(addedArticle.Name, Is.EqualTo("Artikel D"), "Der Artikelname wurde nicht korrekt gespeichert.");
        }

        [Test] // Test für Suchen von Artikel
        public void SearchArticleById_ShouldReturnArticle_WhenIdExists()
        {
            // Arrange
            int searchedID = 3;

            // Act
            var article = _repository.SearchArticleById(searchedID);

            // Assert
            // Überprüft, ob ein Artikel mit der gesuchten ID gefunden wurde (stellt sicher, dass kein null zurückgegeben wurde).
            Assert.That(article, Is.Not.Null); // Überprüft, ob ein Artikel gefunden wurde.


            // Stellt sicher, dass die gefundene Artikel-ID tatsächlich mit der gesuchten ID übereinstimmt
            // (doppelte Überprüfung für Genauigkeit).
            Assert.That(article.Id, Is.EqualTo(searchedID));
        }


        [Test] // Test für Löschen eines nicht existierenden Artikels
        public void DeleteArticle_ShouldReturnFalse_WhenIdDoesNotExist()
        {
            // Arrange
            int nonExistingId = 999;

            // Act
            var result = _repository.DeleteArticle(nonExistingId);

            // Assert
            Assert.That(result, Is.False, "Die Methode sollte false zurückgeben, wenn der Artikel nicht existiert.");
        }

        [Test] // Test für ungültige ID
        public void DeleteArticle_ShouldThrowException_WhenIdIsInvalid()
        {
            // Arrange
            int invalidId = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _repository.DeleteArticle(invalidId),
                "Die Methode sollte eine Ausnahme auslösen, wenn die ID ungültig ist.");
        }
    }
}