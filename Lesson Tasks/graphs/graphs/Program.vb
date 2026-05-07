Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")
    End Sub
End Module

Public Class graph
    Dim _matrix(,) As Integer

    Sub New(row As Integer, col As Integer)
        setupMatrix(row, col)
    End Sub
    Sub setupMatrix(row, col)
        ReDim _matrix(row, col)
    End Sub

    Sub addConnection()

End Class
