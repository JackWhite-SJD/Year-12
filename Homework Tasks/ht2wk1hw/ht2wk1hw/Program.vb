Imports System

Module Program
    Sub Main(args As String())

    End Sub

    Function sumOfSquares(maxNum As Integer, total As Integer) As Integer
        If maxNum = 0 Then
            Return total
        Else
            total += (maxNum ^ 2)
            Return sumOfSquares(maxNum - 1, total)
        End If
    End Function
End Module
