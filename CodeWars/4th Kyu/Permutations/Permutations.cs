using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Permutations
{
    public class Permutations
    {
        public static List<string> SinglePermutations(string s)
        {
            return Permute(s);
        }
        public static List<string> Permute(string list)
        {
            return Permute(list.ToCharArray());
        }
        public static  List<string> Permute(char[] list)
        {
            var permutationList = new List<string>();
            var x = list.Length - 1;
            GetPermutation(list, 0, x, permutationList);
            return permutationList.Distinct().ToList();
        }

        private static void GetPermutation(char[] list, int k, int m, ICollection<string> pL)
        {
            
            if (k == m)
            {
                pL.Add(new string(list));
            }
            else
                for (var i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPermutation(list, k + 1, m, pL);
                    Swap(ref list[k], ref list[i]);
                }
        }
        static void Swap(ref char a, ref char b)
        {
            char tmp;
            tmp = a;
            a = b;
            b = tmp;
        }
    }
}