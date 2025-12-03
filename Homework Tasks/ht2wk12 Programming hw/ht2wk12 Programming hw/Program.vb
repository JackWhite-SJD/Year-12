Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine(getSumOfdigits(10))
    End Sub
    Function getSumOfdigits(powerOf2 As Integer) As Integer
        Dim num As Integer = 2 ^ powerOf2
        Dim numAsString As String = num.ToString()
        Dim total As Integer = 0

        For i = 0 To numAsString.Length - 1
            total += Integer.Parse(numAsString(i))
        Next
        Return total
    End Function
End Module
