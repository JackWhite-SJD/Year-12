Imports System

Module Program
    Sub Main()
        Console.WriteLine("Enter number of integers:")
        Dim n As Integer = Integer.Parse(Console.ReadLine())
        Dim nums(n - 1) As Integer

        For i = 0 To n - 1
            Console.WriteLine("Enter integer " + (i + 1).ToString() + ":")
            nums(i) = Integer.Parse(Console.ReadLine())
        Next

        Array.Sort(nums)

        Console.WriteLine()
        For i = 0 To n - 1
            Console.WriteLine(nums(i))
        Next
    End Sub
End Module