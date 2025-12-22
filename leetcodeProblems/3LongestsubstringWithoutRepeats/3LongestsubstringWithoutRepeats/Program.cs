using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace _3LongestsubstringWithoutRepeats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = LengthOfLongestSubstring("pwwke");
            Console.WriteLine(max);
        }

        public static int LengthOfLongestSubstring(string s)
        {
            List<string> substringslist = new List<string>();
            int maxLength = 0;
            string longestString = "";
            for (int i = 0; i < s.Length; i++)
            {
                string currentSubstring = "";

                for (int j = i; j < s.Length; j++)
                {
                    if (currentSubstring.Contains(s[j]))
                        break;

                    currentSubstring += s[j];
                    substringslist.Add(currentSubstring);

                    if (currentSubstring.Length > maxLength)
                        maxLength = currentSubstring.Length;
                }
            }

            

            foreach (string substring in substringslist)
            {
                if (substring.Length > maxLength)
                {
                    maxLength = substring.Length;
                    longestString = substring;
                }
            }

            return maxLength;
        }

    }
}
