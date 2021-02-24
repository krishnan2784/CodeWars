using System.Text;

namespace CodeWars.Stringy
{
    //8th Kyu
    public static partial class Kata
    {
        public static string Stringy(int size)
        {
            var label=new StringBuilder();

            for (var i = 1; i <= size; i++)
            {
                label.Append(i % 2 != 0 ? "1" : "0");
            }

            return label.ToString();
        }
    }
}