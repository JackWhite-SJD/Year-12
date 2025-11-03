Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine(squareOfSum(100, 0) - sumOfSquares(100, 0))
    End Sub

    Function sumOfSquares(maxNum As Integer, total As Integer) As Integer
        If maxNum = 0 Then
            Return total
        Else
            total += (maxNum ^ 2)
            Return sumOfSquares(maxNum - 1, total)
        End If
    End Function

    Function squareOfSum(maxNum As Integer, total As Integer) As Integer
        If maxNum = 0 Then
            total *= tota
            Return total
        Else
            total += maxNum
            Return squareOfSum(maxNum - 1, total)
        End If
    End Function
End Module