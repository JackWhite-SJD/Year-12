using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace _3LongestsubstringWithoutRepeats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = LengthOfLongestSubstring("bbbb");

        }

        public static int LengthOfLongestSubstring(string s)
        {
            Dictionary<string, int> characters = new Dictionary<string, int>();
            Dictionary<int,string> strings = new Dictionary<int,string>();
            int count = 0;
            int maxCount = 0;
            string spaces = " ";

            string newstring = "";
            foreach (char c in s) 
            {
                if (!characters.ContainsKey(c.ToString()))
                {
                    newstring += c;
                    count += 1;
                    characters.Add(c.ToString(), 1);
                    spaces += " ";
                }
                else
                {
                    strings.Add(count,newstring + spaces);
                    spaces += " ";
                    if(count > maxCount)
                    {
                        maxCount = count;
                    }
                    count = 0;
                    newstring = "";
                    characters = new Dictionary<string, int>();
                }
                

            }

            foreach (KeyValuePair<int, string> kvp in strings)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }


            return maxCount;
        }
    }
}
