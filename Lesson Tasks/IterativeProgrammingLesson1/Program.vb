Imports System

Module Program
    Sub Main(args As String())
        Dim answer As Integer = 0
        Dim bit As Integer = 2
        Console.WriteLine("Number of bits:")
        Dim column As Integer = 2 ^ (Integer.Parse(Console.ReadLine()) - 1)


        While column >= 1
            While True
                While True
                    Try
                        Console.WriteLine("Enter bit value of column " & column & ":")
                        bit = Integer.Parse(Console.ReadLine())
                        If IsNumeric(bit) Then
                            Exit While
                        End If
                    Catch e As Exception
                        Console.WriteLine("Using a number, enter bit value of column " & column & ":")
                        bit = Integer.Parse(Console.ReadLine())
                    End Try
                End While
                If bit = 1 Or bit = 0 Then
                    Exit While
                End If
        End While
            answer += (column * bit)
            column /= 2
        End While
        Console.WriteLine(answer)
    End Sub
End Module
