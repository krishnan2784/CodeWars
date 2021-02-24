using NUnit.Framework;

namespace CodeWars.CenturyFromYear
{
    [TestFixture]
    public class CenturyFromYearTests
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(18, Kata.СenturyFromYear(1705));
            Assert.AreEqual(19, Kata.СenturyFromYear(1900));
            Assert.AreEqual(17, Kata.СenturyFromYear(1601));
            Assert.AreEqual(20, Kata.СenturyFromYear(2000));
        }
    }
}