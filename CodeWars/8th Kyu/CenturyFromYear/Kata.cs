namespace CodeWars.CenturyFromYear
{
    //8th Kyu
    public static partial class Kata
    {
        public static int СenturyFromYear(int year)
        {
            return (int)(year / 100) + ((year % 100 == 0) ? 0 : 1);
        }
    }
}