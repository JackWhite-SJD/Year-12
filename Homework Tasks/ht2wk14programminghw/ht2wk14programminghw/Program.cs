using System.Numerics;

namespace ht2wk14programminghw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input num1:");
            Int64 num1 = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Input num2:");
            Int64 num2 = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
            Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");

        }
    }
}
