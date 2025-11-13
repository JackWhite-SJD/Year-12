Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine("Player 1 input a number for Player 2 to guess.")
        Dim target As Integer = getRealNum()

        If player2Turn(5, target) Then
            Console.WriteLine("Player Two Wins")
        Else
            Console.WriteLine("Player One Wins")
        End If
    End Sub

    Function getRealNum() As Integer
        Dim number As Integer

        While True
            Try
                Console.WriteLine("Enter a number between 1 and 10:")
                number = Integer.Parse(Console.ReadLine)
                If number < 11 And number > 0 Then
                    Return number
                Else
                    Console.WriteLine("Error, number not in range, try again.")
                End If
            Catch ex As Exception
                Console.WriteLine("Please input a valid number")
            End Try
        End While
    End Function

    Function player2Turn(attempts As Integer, target As Integer) As Boolean
        Dim choice As Integer

        If attempts = 0 Then
            Return False
        End If

        Console.WriteLine("Player 2 guess " & 6 - attempts & " :")
        choice = getRealNum()

        If choice = target Then
            Return True
        Else
            Return player2Turn(attempts - 1, target)
        End If

    End Function

End Module