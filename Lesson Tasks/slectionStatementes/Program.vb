Imports System

Module Program
    Sub Main(args As String())
        Dim choice As String
        Dim inputTemp As Decimal

        While True
            While True
                Console.WriteLine("Convert to celcius or fahrenheit, or would you like to exit:")
                choice = UCase(Console.ReadLine().Substring(0, 1))

                If choice = "E" Or choice = "Q" Then
                    End
                End If

                Console.WriteLine("Input temperature to convert:")
                inputTemp = Convert.ToDecimal(Console.ReadLine())

                If choice = "C" Or choice = "F" Then
                    Exit While
                End If
            End While

            If choice = "C" Then
                Console.WriteLine(inputTemp & "F in celcius is:" & Math.Round(((5 / 9) * (inputTemp - 32)), 2))
            Else
                Console.WriteLine(inputTemp & "C in fahrenheit is:" & Math.Round(((9 * inputTemp) / 5) + 32, 2))
            End If

        End While
    End Sub
End Module
