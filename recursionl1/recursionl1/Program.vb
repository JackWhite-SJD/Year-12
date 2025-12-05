Imports System
Imports System.Numerics
Imports System.Reflection.Emit

Module Program
    Sub Main(args As String())
        Dim nth As Int16
        While True
            Try
                Console.WriteLine("Enter fibonnaic position:")
                nth = Integer.Parse(Console.ReadLine())
                If nth > 0 And nth < 7411 Then
                    Exit While
                Else
                    Console.WriteLine("Needs to be a positive integer number and less than 7411, try again.")
                End If
            Catch ex As Exception
                Console.WriteLine("nAn try again.")
            End Try
        End While

        Dim startTime As Long = Stopwatch.GetTimestamp()
        Console.WriteLine("Fibonacci at positon " & nth & " : " & Convert.ToString(finbonacci(0, nth - 3, {0, 1, 1})))
        Dim elapsedTime As TimeSpan = Stopwatch.GetElapsedTime(startTime)
        Console.WriteLine(elapsedTime)
    End Sub

    Function finbonacci(current As Int16, final As Int16, nums() As BigInteger) As BigInteger
        If current = final Then
            Return nums(2)
        Else
            nums(0) = nums(1)
            nums(1) = nums(2)
            nums(2) = nums(0) + nums(1)
            Return finbonacci(current + 1, final, nums)
        End If
    End Function
End Module