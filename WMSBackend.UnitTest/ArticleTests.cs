using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMSBackend.Models;

namespace WMSBackend.UnitTest
{
    [TestFixture] // Markiert diese Klasse als eine Testklasse
    public class ArticleTests
    {
        [TestCase(1, "ValidName", TestName = "Gültiger Artikel: ID=1, Name=ValidName")]
        [TestCase(100, "AnotherValidName", TestName = "Gültiger Artikel: ID=100, Name=AnotherValidName")]
        [TestCase(999, "Name123", TestName = "Gültiger Artikel: ID=999, Name=Name123")]
        public void Should_Create_Article_When_Valid_Inputs(int id, string name)
        {
            // Act
            var article = new Article(id, name);

            // Assert
            Assert.That(article.Id, Is.EqualTo(id), "Die ID wurde nicht korrekt gesetzt.");
            Assert.That(article.Name, Is.EqualTo(name), "Der Name wurde nicht korrekt gesetzt.");
        }


        [TestCase(0, "ValidName", TestName = "Ungültige ID: 0")]
        [TestCase(-1, "ValidName", TestName = "Ungültige ID: negativ")]
        [TestCase(1, "", TestName = "Ungültiger Name: leer")]
        [TestCase(1, "ab", TestName = "Ungültiger Name: weniger als 3 Zeichen")]
        public void Article_InvalidInputs_ShouldThrowArgumentException(int id, string name)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Article(id, name));

            // Optional: Überprüfen der Fehlermeldung
            if (id <= 0)
            {
                Assert.That(ex.Message, Does.Contain("Id must be greater than 0"));
            }
            else if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                Assert.That(ex.Message, Does.Contain("Name must be at least 3 characters long"));
            }
        }


    }
}