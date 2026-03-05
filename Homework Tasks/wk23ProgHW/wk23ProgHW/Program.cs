using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        int[] intArray = GetIntArray();
        Output(intArray);
        outputLowest(intArray);
        intArray = RemoveOddNumbers(intArray);
        Output(intArray);
        outputLowest(intArray);
    }

    static void Output(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }

    static void outputLowest(int[] arr)
    {
        int lowerstVal = 1001;
        int higherstVal = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < lowerstVal && arr[i] >=0)
            {
                lowerstVal = arr[i];
            }
            else if (arr[i] > higherstVal)
            {

                higherstVal = arr[i];
            }
        }
        Console.WriteLine("Higherst value:" + higherstVal.ToString());
        Console.WriteLine("Lowerst value:" + lowerstVal.ToString());
    }


    static int[] RemoveOddNumbers(int[] intArr)
    {
        List<int> lst = new List<int>();

        for (int i = 0; i < intArr.Length; i++)
        {
            if (intArr[i] == -1)
                break;

            if (intArr[i] % 2 == 0)
                lst.Add(intArr[i]);
        }

        int[] newArr = new int[lst.Count + 1];

        for (int i = 0; i < lst.Count; i++)
        {
            newArr[i] = lst[i];
        }

        newArr[lst.Count] = -1;

        return newArr;
    }

    static int[] GetIntArray()
    {
        int[] intArray = new int[20];
        Random rnd = new Random();

        for (int i = 0; i < 19; i++)
        {
            intArray[i] = rnd.Next(0, 1000);
        }

        intArray[19] = -1;

        return intArray;
    }
}