using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace consultationProgrammingTask2SdntScores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //createPeople();
            List<Dictionary<string, double[,]>> allStudents= getStudents(getNames());
            outputData(allStudents);
        }

        public static void createPeople()
        {
            int people = 0;

            Console.WriteLine("How many people to create:");
            people = int.Parse(Console.ReadLine());

            for (int i = 0; i < people; i++)
            {
                Console.Clear();
                createAPerson();
            }
        }

        public static void outputData(List<Dictionary<string, double[,]>> allStudents)
        {
            string currentName;
            Console.Clear();
            foreach (Dictionary<string, double[,]> name in allStudents)
            {
                currentName = name.Keys.First();
                Console.WriteLine(currentName + ":");
                Console.WriteLine($"Average: {name[currentName][1, 0]}");
                Console.WriteLine($"Min:     {name[currentName][1, 1]}");
                Console.WriteLine($"Max:     {name[currentName][1, 2]}");
                Console.WriteLine("\n \n");
            }
        }
        public static string[] getNames()
        {
            List<string> names = new List<string>();
            int totalNames = 0;
            int count = 0;

            Console.WriteLine("How many names:");
            totalNames = int.Parse(Console.ReadLine());
            
            while (count < totalNames)
            {
                Console.Clear();
                Console.WriteLine($"Enter name {count + 1}");
                names.Add(Console.ReadLine());
                count++;
            }

            return names.ToArray();
        }
        public static void createAPerson()
        {
            Dictionary<string, double[,]> scores = new Dictionary<string, double[,]>();
            string name;
            int tests;

            Console.WriteLine("Enter name:");
            name = Console.ReadLine();

            Console.WriteLine("Enter tests.");
            tests = int.Parse(Console.ReadLine());

            newScores(ref scores, name, tests);

            Console.WriteLine($"{scores[name][1, 0]} , {scores[name][1, 1]} , {scores[name][1, 2]}");

            newStudentFile(name, scores, tests);
        }

        public static List<Dictionary<string, double[,]>> getStudents(string[] names)
        {
            List<Dictionary<string, double[,]>> studentFiles = new List<Dictionary<string, double[,]>>();
            foreach (string name in names)
            {
                try
                {
                    studentFiles.Add(getStudentFromFile(name + "_scores.txt"));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Welldone, you either havent inputted a valid name or carnt spel well done!");
                    throw;
                }
                
            }
            return studentFiles;
        }

        public static void newScores(ref Dictionary<string, double[,]> scores, string user, int tests)
        {
            double score;
            double[,] inputtedScores = new double[2, tests + 3];

            int count = 0;
            double total = 0;
            double min = 0;
            double max = 0;

            while (count < tests)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter score:");
                        score = double.Parse(Console.ReadLine());
                        score = Math.Round(score, 4);

                        if (score >= 0 && score <= 100)
                        {
                            Console.WriteLine("score accepted");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Score must be between 0 and 100");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid score");
                    }
                }

                inputtedScores[0, count] = score;
                total += score;

                if (count == 0)
                {
                    min = score;
                    max = score;
                }
                else
                {
                    if (score < min) min = score;
                    if (score > max) max = score;
                }

                count++;
            }

            double average = Math.Round(total / tests, 4);

            inputtedScores[1, 0] = average;
            inputtedScores[1, 1] = min;
            inputtedScores[1, 2] = max;

            scores.Add(user, inputtedScores);
        }

        public static void newStudentFile(string name ,Dictionary<string, double[,]> scores, int tests)
        {
            string filename = $"{name}_scores.txt";

            StreamWriter sw  = new StreamWriter(filename);

            sw.WriteLine($"Student: {name}");
            sw.WriteLine($"Number of tests: {tests}");
            sw.WriteLine();

            sw.WriteLine("Scores:");
            for (int i = 0; i < tests; i++)
            {
                sw.WriteLine($"Test {i + 1}: {scores[name][0, i]}");
            }

            sw.WriteLine();
            sw.WriteLine($"Average: {scores[name][1, 0]}");
            sw.WriteLine($"Min:     {scores[name][1, 1]}");
            sw.WriteLine($"Max:     {scores[name][1, 2]}");
            sw.Close();
        }

        public static Dictionary<string, double[,]> getStudentFromFile(string filename)
        {
            Dictionary<string, double[,]> scores = new Dictionary<string, double[,]>();

            string[] lines = File.ReadAllLines(filename);

            string name = "";
            int tests = 0;

            List<double> testScores = new List<double>();

            double average = 0;
            double min = 0;
            double max = 0;

            foreach (string line in lines)
            {
                if (line.StartsWith("Student:"))
                {
                    name = line.Replace("Student:", "").Trim();
                }
                else if (line.StartsWith("Number of tests:"))
                {
                    tests = int.Parse(line.Replace("Number of tests:", "").Trim());
                }
                else if (line.StartsWith("Test"))
                {
                    string value = line.Split(':')[1].Trim();
                    testScores.Add(double.Parse(value));
                }
                else if (line.StartsWith("Average:"))
                {
                    average = double.Parse(line.Replace("Average:", "").Trim());
                }
                else if (line.StartsWith("Min:"))
                {
                    min = double.Parse(line.Replace("Min:", "").Trim());
                }
                else if (line.StartsWith("Max:"))
                {
                    max = double.Parse(line.Replace("Max:", "").Trim());
                }
            }
            double[,] array = new double[2, tests + 3];

            for (int i = 0; i < tests; i++)
            {
                array[0, i] = testScores[i];
            }
            array[1, 0] = average;
            array[1, 1] = min;
            array[1, 2] = max;

            scores[name] = array;

            return scores;
        }
    }
}