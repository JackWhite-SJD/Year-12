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
        public string verifyPasssword()
        {
            string password = "";
            while (true)
            {
                Console.WriteLine("Enter password");
                password = Console.ReadLine();
                if(password.Length >= 12)
                {

                }
            }
            
            

            return password;
        }
        public bool searchForChars(string test ,string c1, string c2, string c3)
          
        {
            bool boolC1 = false;
            bool boolC2 = false;
            bool boolC3 = false;
            for (int i = 0; i < test.Length; i++)
            {
                if (test[i].ToString() == test[i].ToString().ToUpper(){
                    boolC1 = true;
                    break;
                }
            }

            for (int i = 0; iq < length; iq++)
            {

            }

            if (boolC1 == true && boolC2 == true && boolC3 == true)
            {
                return true;
            }
            else
            {
                return false;
            }

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
