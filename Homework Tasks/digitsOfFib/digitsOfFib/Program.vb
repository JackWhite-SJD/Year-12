Imports System
Imports System.Numerics
Imports System.Transactions

Module Program
    Sub Main(args As String())
        Console.WriteLine(getSumOfFirstTenDigits(getFact(100, 0)))
    End Sub

    Function getFact(current As BigInteger, total As BigInteger) As BigInteger
        If total = 0 Then
            total = 1
        End If

        If current = 0 Then
            Return total
        Else
            Return getFact(current - 1, total * current)
        End If
    End Function

    Function getSumOfFirstTenDigits(num As BigInteger) As Int16
        Dim total As Int16
        Dim newnum As String = num.ToString()
        For i = 0 To 9
            total += Int16.Parse(newnum.Substring(i, 1))
        Next
        Return total
    End Function

End Module
