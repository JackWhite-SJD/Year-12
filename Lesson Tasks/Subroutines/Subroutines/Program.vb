Imports System

Module Program
    Sub Main(args As String())
        Dim numbers(2) As Integer
        Dim total As Decimal = 0.00
        CalculateAverage(getNumbers(numbers), total)
        GetTimeTable(getNumbers(numbers))
    End Sub


    Function getNumbers(ByVal numbers() As Integer) As Integer()
        For count = 0 To 2
            While True
                Try
                    Console.WriteLine("Input number " & count + 1 & ":")
                    numbers(count) = Integer.Parse(Console.ReadLine())
                    Exit While
                Catch ex As Exception
                    Console.WriteLine("nAn")
                End Try
            End While
        Next
        Return numbers
    End Function


    Sub CalculateAverage(ByVal numbers() As Integer, ByRef total As Integer)
        Console.WriteLine(" ")
        total = Math.Round(((numbers(0) + numbers(1) + numbers(2)) / 3), 4)
        Console.WriteLine("Average:" & total)
    End Sub

    Sub GetTimeTable(ByRef numbers() As Integer)
        If numbers(1) < numbers(2) Then
            For i = numbers(1) To numbers(2)
                Console.WriteLine(numbers(0) & " x " & i & " = " & (numbers(0) * i))
            Next
        ElseIf numbers(1) > numbers(2) Then
            For i = numbers(2) To numbers(1)
                Console.WriteLine(numbers(0) & " x " & i & " = " & (numbers(0) * i))
            Next
        Else
            Console.WriteLine(numbers(0) & " x " & numbers(1) & " = " & (numbers(0) * numbers(1)))
        End If
    End Sub

End Module
