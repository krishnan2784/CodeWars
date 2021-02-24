using System.Numerics;

namespace CodeWars.SumStringsAsNumbers
{
    
    //4th Kyu
    public static partial class Kata
    {
        public static string SumStrings(string a, string b)
        {
            var aIsNumber = BigInteger.TryParse(a, out var numberA);
            var bIsNumber = BigInteger.TryParse(b, out var numberB);
            return (numberA + numberB).ToString("G");        
        }
    }
}