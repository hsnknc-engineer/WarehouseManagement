using WMSBackend.Models;


namespace WMSBackend.UnitTest
{
    [TestFixture]
    public class ArticleTests
    {
        [TestCase("ValidName", TestName = "Gültiger Artikel: Name=ValidName")]
        [TestCase("AnotherValidName", TestName = "Gültiger Artikel: Name=AnotherValidName")]
        [TestCase("Name123", TestName = "Gültiger Artikel: Name=Name123")]
        public void Should_Create_Article_When_Valid_Name(string name)
        {
            // Act
            var article = new Article { Name = name }; // Nutzt den Objekt-Initializer

            // Assert
            Assert.That(article.Name, Is.EqualTo(name), "Der Name wurde nicht korrekt gesetzt.");
        }

        [TestCase("", TestName = "Ungültiger Name: leer")]
        [TestCase("ab", TestName = "Ungültiger Name: weniger als 3 Zeichen")]
        [TestCase("  ", TestName = "Ungültiger Name: nur Leerzeichen")] // Anstatt null
        public void Should_Throw_Exception_When_Name_Is_Invalid(string name)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Article { Name = name });

            // Überprüfen der Fehlermeldung
            Assert.That(ex.Message, Does.Contain("Name must be at least 3 characters long"));
        }
    }
}