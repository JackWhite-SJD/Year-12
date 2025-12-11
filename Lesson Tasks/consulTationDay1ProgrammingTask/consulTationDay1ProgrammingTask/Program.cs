using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.IO;
using System.Runtime.CompilerServices;

namespace consulTationDay1ProgrammingTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> accounts = GetAccounts();

            for (int i = 0; i <3; i++)
            {
                menu(ref accounts);
            }
        }

        public static void updateAccountFile(string username, string password)
        {
            string newText;
            try
            {       
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\file.txt",true);
                newText = username + ":" + password;

                sw.WriteLine(newText);
                sw.Close();
            }
            catch (Exception e) 
            {
                Console.WriteLine($"Error {e.Message}");
                throw;
            }
        }

        public static Dictionary<string,string> GetAccounts()
        {
            Dictionary<string, string> accounts = new Dictionary<string, string>();
            try
            {
                StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\file.txt",true);
                string lines;
                lines = sr.ReadLine();

                while (lines != null)
                {
                    string[] parts = lines.Split(":");
                    accounts[parts[0]] = parts[1].Trim();
                    lines = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error {e.Message}");
                throw;
            }
            return accounts;
        }

        public static string GetUserName(Dictionary<string,string> dict)
        {
            for (int i = 0; i <3; i++)
            {
                Console.WriteLine("Enter a userName:");
                string usrName = Console.ReadLine();
                if(usrName != ""){
                    return usrName;
                }
            }

            Console.WriteLine("User name is null.");
            return null;
        }
        public static bool CheckUsrName(Dictionary<string,string> dict, string usrName)
        {
            if (dict.ContainsKey(usrName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string GetPassord()
        {
            string input;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter a password:");
                input = Console.ReadLine();
                if (input.Length > 12)
                {
                    return input;
                }
            }
            Console.WriteLine("Password too short, press enter to continue.");
            Console.ReadLine();
            return null;
        }

        public static void menu(ref Dictionary<string,string> accounts)
        {
            Console.Clear();
            string choice;
            Console.WriteLine("(1) login.");
            Console.WriteLine("(2) register.");
            Console.WriteLine("(3) quit.");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                login(accounts);
            }
            else if (choice == "2")
            {
                register(ref accounts);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public static void login(Dictionary<string,string> accounts)
        {
            bool accepted = false;
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                string userName = GetUserName(accounts);
                if (!CheckUsrName(accounts, userName.ToLower()))
                {
                    string passsword = GetPassord();
                    if (passsword != null && userName != null)
                    {
                        if (accounts[userName] == passsword)
                        {
                            Console.WriteLine("Acces granted");
                            accepted = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Press enter to try again");
                            Console.ReadLine();
                        }
                    }
                }
            }

            if (!accepted)
            {
                Console.WriteLine("Access denied.");
                Console.ReadLine();
            }
        }

        public static void register(ref Dictionary<string,string> accounts)
        {
            Console.Clear();
            string userName = GetUserName(accounts);
            string password = GetPassord();

            if (userName != null && password != null && CheckUsrName(accounts,userName))
            {
                accounts[userName] = password;
                Console.WriteLine("\nAccount created successfully");
                Console.WriteLine($"\nUser name : {userName} \n \nPassword : {accounts[userName]}");
                updateAccountFile(userName.ToLower(), password);
            }
            else
            {
                Console.WriteLine("User Name, Password or both have not been inputted validly.");
            }
        }
    }
}