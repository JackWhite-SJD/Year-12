Imports System
Imports System.Runtime.InteropServices
Imports System.Runtime.Versioning
Imports System.Threading.Tasks.Sources

Module Program
    Sub Main(args As String())
        Dim score As Integer = 0
        Dim games As Integer = 0
        Dim win As Boolean
        Dim maxNum As Integer
        Dim difficulty As String
        Dim choices As Integer

        While True
            Console.WriteLine("Select difficulty: easy medium or hard?:")
            difficulty = LCase(Console.ReadLine()).Substring(0, 1)
            If difficulty = "e" Then
                maxNum = 100
                Exit While
            ElseIf difficulty = "m" Then
                maxNum = 200
                Exit While
            ElseIf difficulty = "h" Then
                maxNum = 300
                Exit While
            End If
        End While

        Console.WriteLine("Do you like to gamble?:")
        difficulty = LCase(Console.ReadLine()).Substring(0, 1)
        If difficulty = "y" Then
            choices = getLog(maxNum) - 2
        Else
            choices = getLog(maxNum) + 1
        End If

        While True
            games += 1
            win = game(maxNum, choices)
            If win Then
                score += 1
            End If
            win = False
            Console.WriteLine("Would you like to play again?:")
            Dim choice As String = Console.ReadLine()
            If LCase(choice).Substring(0, 1) = "y" Then
                Continue While
            Else
                Exit While
            End If
        End While
        Console.WriteLine("Total score: " & score & " out of " & games & " games")

    End Sub

    Function game(max As Integer, guessesss As Integer) As Boolean
        Dim rnd As New Random()
        Dim secretNum As Integer = rnd.Next(1, 100)
        Dim guess As Integer = 0
        Dim guesses As Integer = guessesss
        Dim MaxGuess As Integer = 100
        Dim LowGuess As Integer = 0
        Dim guessest As Integer = 0

        While guesses <> 0
            While True
                Try
                    Console.WriteLine("Enter a guess between the numbers: " & LowGuess & " and " & MaxGuess)
                    guess = Integer.Parse(Console.ReadLine())

                    If guess <= MaxGuess And guess > LowGuess Then
                        Exit While
                    Else
                        Console.WriteLine("Number not in range, try again, remaining guesses left:" & guesses)
                    End If

                Catch ex As Exception
                    Console.WriteLine("nAn")
                End Try

            End While
            guesses -= 1
            If guess = secretNum Then
                guessest = 5 - guesses
                Console.WriteLine("You win, guesses taken: " & guessest)
                Return True
            ElseIf guess < secretNum Then
                LowGuess = guess
                Console.WriteLine("Too low")
            ElseIf guess > secretNum Then
                Console.WriteLine("Too high")
                MaxGuess = guess
            Else

                Console.WriteLine("Incorrect, guesses remaining: " & guesses)
            End If

            Console.WriteLine("Guesses left:" & guesses)
        End While
        Console.WriteLine("Ha u got it wrong, secretnumber = :" & secretNum)
        Return False
    End Function

    Function getLog(num) As Integer
        Dim number As Integer = 1
        Dim count As Integer = 0
        While number < num
            number *= 2
            count += 1
        End While
        count -= 1
        Return count
    End Function
End Module
