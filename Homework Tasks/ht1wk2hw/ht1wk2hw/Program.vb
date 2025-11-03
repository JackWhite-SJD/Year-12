Imports System
Imports System.Runtime.InteropServices

Module Program
    Sub Main(args As String())
        Dim num1 As Integer = 2
        Dim num2 As Integer = 2
        Dim num3 As Integer = 2
        Dim maxNum As Integer = 0

        While True
            Try
                Console.WriteLine("What number do you want as max?:")
                maxNum = Integer.Parse(Console.ReadLine())
                If maxNum Mod 2 = 0 Then
                    Exit While
                Else
                    Console.Write("Not divisible by 2")
                End If
            Catch ex As Exception
                Console.WriteLine("nAn, try again.")
            End Try
        End While

        For index = 1 To maxNum
            If index Mod 3 = 0 Then
                num3 += index
            End If
            If index Mod 2 = 0 Then
                num2 += index
            End If
        Next

        Console.WriteLine("Sum of numbers divisible by 2 = " & num2)
        Console.WriteLine("Sum of numbers divisible by 3 = " & num3)

    End Sub
End Module
