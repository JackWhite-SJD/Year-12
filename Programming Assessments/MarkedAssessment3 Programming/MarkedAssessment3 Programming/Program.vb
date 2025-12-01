Imports System

Module Program
    Sub Main(args As String())
        Dim input As String
        Dim choice() As String
        Dim num1 As String
        Dim num2 As String
        Dim total As Decimal

        Console.WriteLine("Enter inputted unsigned binary.")
        input = Console.ReadLine()
        choice = input.Split(".")
        num1 = StrReverse(choice(0))
        num2 = choice(1)

        For i = 3 To 0 Step -1
            If num1(i) = "1" Then
                total += (2 ^ (i))
            End If
            If num2(i) = "1" Then
                total += 1 / ((2 ^ (i + 1)))
            End If
        Next

        Console.WriteLine(total)
    End Sub
End Module
