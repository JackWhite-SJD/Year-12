Imports System

Module Program
    Sub Main(args As String())
        Dim name As String
        Console.WriteLine("Enter word")
        name = Console.ReadLine()

        If palindromeChecker(name) Then
            Console.WriteLine(name & " is a palindrome")
        Else
            Console.WriteLine(name & " is not a palindrome")
        End If
    End Sub

    Function palindromeChecker(ByVal name As String) As Boolean
        If StrReverse(name) = name Then
            Return True
        Else
            Return False
        End If

    End Function
End Module
