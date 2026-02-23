Imports System

Module Program
    Sub Main(args As String())
        Dim str As String
        Dim count As Integer = 0

        Console.Write("Type a string: ")
        str = Console.ReadLine()

        For Each c As Char In str
            If c = "c" Then
                count += 1
            End If
        Next

        Console.WriteLine()
        Console.WriteLine("The letter c appears " & count & " time/s in a string.")
    End Sub
End Module
