using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task6
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SimpleTest()
        {
            Assert.IsTrue(1 == 1);
        }

        [Test]
        public void SnaredrumConstructorTest()
        {
            Snaredrum SnareTest = new Snaredrum("Wood", 38.6M, "cm", "pinned");
            Assert.IsTrue(SnareTest.Material == "Wood");
            Assert.IsTrue(SnareTest.Diameter == 38.6M);
            Assert.IsTrue(SnareTest.Unit == "cm");
            Assert.IsTrue(SnareTest.Snares == "pinned");
        }

        [Test]
        public void SnaredrumGetDiameterTest()
        {
            Snaredrum SnareTest = new Snaredrum("Wood", 38.6M, "cm", "pinned");
            Assert.IsTrue(SnareTest.GetDiameter("cm") == 38.6M / 2.54M);
        }

        [Test]
        public void SnaredrumToStringCMTest()
        {
            Snaredrum SnareTest = new Snaredrum("Wood", 38.6M, "cm", "pinned");
            Assert.IsTrue(SnareTest.ToString() == "Wood, 15,19685039370078740157480315inch, snares pinned");
        }

        [Test]
        public void SnaredrumToStringInchTest()
        {
            Snaredrum SnareTest = new Snaredrum("Wood", 22M, "inch", "pinned");
            Assert.IsTrue(SnareTest.ToString() == "Wood, 22inch, snares pinned");
        }

        [Test]
        public void UpdateDiameterTest()
        {
            Snaredrum SnareTest = new Snaredrum("Wood", 38.6M, "cm", "pinned");
            SnareTest.UpdateDiameter(22M, "inch");
            Assert.IsTrue(SnareTest.Unit == "inch");
            Assert.IsTrue(SnareTest.Diameter == 22M);
        }

        [Test]
        public void UpdateDiameterNegativeDiameterTest()
        {
            Snaredrum SnareTest = new Snaredrum("Wood", 38.6M, "cm", "pinned");
            //"Diameter must not be negative" is parameter of Exception --> test parameter
            var excpt = Assert.Throws<ArgumentOutOfRangeException>(() => SnareTest.UpdateDiameter(-22M, "inch"));
            Assert.That(excpt.ParamName, Is.EqualTo("Diameter must not be negative"));
        }

        [Test]
        public void UpdateSnaresFalseTest()
        {
            Snaredrum SnareTest = new Snaredrum("Wood", 38.6M, "cm", "pinned");
            //"Snares must be pinned or loosened." is message of Exception --> test message
            var excpt = Assert.Throws<ArgumentException>(() => SnareTest.UpdateSnares("hello"));
            Assert.That(excpt.Message, Is.EqualTo("Snares must be pinned or loosened."));
        }

        [Test]
        public void UpdateSnaresEmptyTest()
        {
            Snaredrum SnareTest = new Snaredrum("Wood", 38.6M, "cm", "pinned");
            var excpt = Assert.Throws<ArgumentException>(() => SnareTest.UpdateSnares(""));
            Assert.That(excpt.Message, Is.EqualTo("Snares must not be empty."));
        }
    }
}
