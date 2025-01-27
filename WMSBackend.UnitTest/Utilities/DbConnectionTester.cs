using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WMSBackend.Data;

namespace WMSBackend.UnitTest.Utilities
{
    [TestFixture]
    public class DbConnectionTester
    {
        private const string ConnectionString = "Server=DESKTOP-HE4ULMV;Database=WMSDatabase;User Id=TestUser;Password=Passwort123;TrustServerCertificate=True;Encrypt=False";

        [Test]
        public void TestDatabaseConnection_ShouldSucceed()
        {
            // Arrange: Konfiguriere DbContext mit Connection String
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            // Act & Assert: Überprüfe die Verbindung
            using (var context = new AppDbContext(options))
            {
                Assert.That(() => context.Database.CanConnect(), Is.True, "Die Verbindung zur Datenbank konnte nicht hergestellt werden.");
            }
        }
    }
}
