using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WMSBackend.UnitTest
{
    [TestFixture]
    public class FailingTest
    {
        [Test]
        public void ThisTestWillFail()
        {
            // Arrange
            int expected = 5;
            int actual = 3;


            // Act & Assert: Absichtlich Falsch
            Assert.That(actual, Is.EqualTo(expected), "Dieser Test schlägt fehl, weil 5 != 3.");
        }
    }
}
