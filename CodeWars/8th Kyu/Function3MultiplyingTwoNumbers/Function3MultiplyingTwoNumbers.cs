using NUnit.Framework;

namespace CodeWars.Function3MultiplyingTwoNumbers
{
    [TestFixture]
    public class Function3MultiplyingTwoNumbers
    {
        private static object[] testCases = new object[]
        {
            new object[] {2, 2, 4},
            new object[] {4, 3, 12},
            new object[] {10, 10, 100},
            new object[] {20, 10, 200},
            new object[] {-10, -10, 100},
            new object[] {-10, 10, -100},
            new object[] {10, -10, -100},
        };
  
        [Test, TestCaseSource("testCases")]
        public void SampleTest(int a, int b, int expected)
        {
            Assert.AreEqual(expected, Kata.Multiply(a, b));
        }
    }
}