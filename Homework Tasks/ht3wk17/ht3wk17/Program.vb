Imports System

Module Program
    Sub Main()
        Dim s As String
        Dim n As Integer

        Console.Write("Enter a string: ")
        s = Console.ReadLine()

        Console.Write("Enter position n: ")
        n = Integer.Parse(Console.ReadLine())

        If n < 1 Or n > s.Length Then
            Console.WriteLine("Invalid position.")
        Else
            Dim fromStart As Char = s(n - 1)
            Dim fromEnd As Char = s(s.Length - n)

            Console.WriteLine("Character at position " & n & " from start: " & fromStart)
            Console.WriteLine("Character at position " & n & " from end: " & fromEnd)
        End If

        Console.ReadLine()

    End Sub
End Module