Imports System

Module Program
    Sub Main(args As String())

        Console.WriteLine("Emter a string:")
        Dim s As String = Console.ReadLine()

        Dim firstCharacter As String = s(0)
        Dim middleCharacter As String = s(s.Length / 2)
        Dim lastCharacter As String = s(s.Length - 1)

        Console.WriteLine(firstCharacter)
        Console.WriteLine(middleCharacter)
        Console.WriteLine(lastCharacter)

    End Sub
End Module
