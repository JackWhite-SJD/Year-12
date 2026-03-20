using System.IO;
namespace savingAndLoadingCSVs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            csvWriter();
            csvReader();
        }

        public static void csvWriter()
        {
            StreamWriter fileWriter = new StreamWriter("test.csv",true);
            fileWriter.WriteLine("Adam,Cheese,26");
            string filePath = Path.GetFullPath("test.csv");
            Console.WriteLine(filePath);
            fileWriter.Close();
        }

        public static void csvReader()
        {
            string currentline = "";
            try
            {
                StreamReader fileReader = new StreamReader("test.csv");
                while (fileReader.Peek() != -1)
                {
                    currentline = fileReader.ReadLine();
                    string[] currentRecord = currentline.Split(",");
                    Console.WriteLine(currentRecord[0]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
