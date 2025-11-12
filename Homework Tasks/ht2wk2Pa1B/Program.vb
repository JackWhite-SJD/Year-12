Imports System
Imports System.Runtime.CompilerServices

Module Program
    Sub Main(args As String())
        If turn(3, getOperation) Then
            Console.WriteLine("*************")
        Else
            Console.WriteLine("You loose, womp womp")
        End If

    End Sub

    Function getOperation() As String()
        Dim choice As String
        Dim choiceOfNum As Integer

        While True
            Try

                Console.WriteLine("Player 1 What would you like the target number to be;")
                Console.WriteLine("1 - 50 inclusive:")

                choiceOfNum = Integer.Parse(Console.ReadLine())

                If choiceOfNum <= 50 And choiceOfNum >= 1 Then
                    Exit While
                End If
            Catch ex As Exception
                Console.WriteLine("NaN")
            End Try
        End While

        While True
            Console.WriteLine("Enter operantor, *,+,/,-")
            choice = Console.ReadLine()

            Select Case choice
                Case "*", "x", "+", "-", "/"
                    Exit While
            End Select
            Console.WriteLine("Not an operantor")
        End While

        Return {choice, choiceOfNum.ToString()}
    End Function

    Function getAnswer(num1 As Integer, num2 As Integer, operators As String, target As Integer) As Boolean
        Select Case operators
            Case "*"
                Return num1 * num2 = target
            Case "+"
                Return num1 + num2 = target
            Case "-"
                Return num1 - num2 = target
            Case "/"
                Return Math.Round(num1 / num2, 0) = target
        End Select
    End Function

    Function turn(attempts As Integer, vals As String()) As Boolean
        Dim num1 As Integer
        Dim num2 As Integer

        If attempts = 0 Then
            Return False
        End If

        Console.WriteLine("Player 2 Attempts left:" & attempts)
        Console.WriteLine("Enter num1:")
        num1 = Integer.Parse(Console.ReadLine())
        Console.WriteLine("Enter num2:")
        num2 = Integer.Parse(Console.ReadLine())

        If getAnswer(num1, num2, vals(0), Integer.Parse(vals(1))) Then
            Console.WriteLine("You win in " & 4 - attempts & " attempts, well done.")
            Return True
        Else
            Return turn(attempts - 1, vals)
        End If

    End Function
End Module
