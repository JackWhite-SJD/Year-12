Imports System
Imports System.Numerics 'allows for type of bigInteger which allows for a maximum factorial of 4357!
Module Program
    Sub Main(args As String())
        For i = 0 To 3
            Console.WriteLine("What number do you want to find the factorial of?:")
            Dim num As BigInteger = BigInteger.Parse(Console.ReadLine())
            Console.WriteLine(getFactorial(num, 1))
        Next

    End Sub

    Function getFactorial(num As BigInteger, total As BigInteger) As BigInteger
        Dim newNum As BigInteger

        If num = 0 Then
            Return 1
        End If

        newNum = num * total
        If num <> 1 Then
            num -= 1
            Return getFactorial(num, newNum)
        Else
            Return total
        End If

    End Function
End Module