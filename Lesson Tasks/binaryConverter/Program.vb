Imports System

Module Program
    Sub Main(args As String())
        Dim number As Integer = 210
        Console.WriteLine(ToBinary(number))
    End Sub
    Function toBinary(number As Integer) As String
        Dim binary As String = ""
        Dim remainder As Integer
        If number = 0 Then
            Return "0"
        End If

        While number > 0
            remainder = number Mod 2
            binary = remainder.ToString() & binary
            number = number \ 2
        End While

        Return binary
    End Function
End Module