using NUnit.Framework;

namespace CodeWars.SumStringsAsNumbers
{
    [TestFixture]
    public class SumStringsAsNumbers
    {
        [Test]
        public void Given123And456Returns579()
        {
            Assert.AreEqual("579",Kata.SumStrings("123","456"));
        }
    }
}