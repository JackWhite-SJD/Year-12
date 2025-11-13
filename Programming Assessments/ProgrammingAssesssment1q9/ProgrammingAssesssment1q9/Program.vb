Imports System.ComponentModel
Imports System.Net.Sockets

Module Module1
    Const Player As String = "O "
    Const Wall As String = "X "
    Const Prize As String = ". "

    Sub Main()
        Dim bounds As Integer = 10
        Dim board(bounds, bounds) As String, PositionX As Integer = 9, PositionY As Integer = 2, Score As Integer = 0
        Dim YorN As String

        While True

            ' Run the SetupBoard subroutine and initialise the Player's position
            Score = 0
            PositionX = 9
            PositionY = 2
            board = SetupBoard(board)
            board(PositionX, PositionY) = Player
            PrintBoard(board, Score)

            ' Continued game play
            While True
                Dim input As ConsoleKeyInfo
                input = Console.ReadKey

                ' Actions dependent upon characters pressed
                Select Case input.KeyChar
                    Case "w"
                        Console.Clear()
                        MakeMove(-1, 0, board, Score, PositionX, PositionY, bounds)
                        Exit Select
                    Case "a"
                        Console.Clear()
                        MakeMove(0, -1, board, Score, PositionX, PositionY, bounds)
                        Exit Select
                    Case "s"
                        Console.Clear()
                        MakeMove(1, 0, board, Score, PositionX, PositionY, bounds)
                        Exit Select
                    Case "d"
                        Console.Clear()
                        MakeMove(0, 1, board, Score, PositionX, PositionY, bounds)
                        Exit Select
                    Case Else
                        Console.WriteLine()
                        Console.WriteLine("You inputted:" & input.KeyChar & " that is not a valid input for this program.")
                End Select

                If checkWin(board) Then
                    Exit While
                End If

            End While

            Console.WriteLine("You win")
            Console.WriteLine("Woul you like to play again?:")
            YorN = Console.ReadLine().ToLower().Substring(0, 1)

            Console.WriteLine()
            Console.WriteLine("Final board:")
            PrintBoard(board, Score)
            Console.WriteLine()
            Console.WriteLine()

            If YorN = "y" Then
                Continue While
            Else
                Exit While
            End If

        End While

    End Sub

    Function checkWin(Board(,) As String) As Boolean
        For row As Integer = 0 To 9
            For column As Integer = 0 To 9
                If Board(row, column) = Prize Then
                    Return False
                End If
            Next
        Next

        Return True
    End Function

    ' Make a move on the board
    Sub MakeMove(ByVal XChange, ByVal YChange, ByVal board, ByRef score, ByRef PositionX, ByRef PositionY, ByVal bounds)
        If (board(PositionX + XChange, PositionY + YChange) IsNot Wall) And (PositionX + XChange < bounds) And (PositionY + YChange < bounds) Then
            If board(PositionX + XChange, PositionY + YChange) = Prize Then
                score += 1
            End If
            board(PositionX + XChange, PositionY + YChange) = Player
            board(PositionX, PositionY) = "  "
            PrintBoard(board, score)
            PositionX = PositionX + XChange
            PositionY = PositionY + YChange
        Else
            PrintBoard(board, score)
        End If


    End Sub

    ' Output the contents of the board array
    Sub PrintBoard(ByVal board, ByVal score)
        Console.WriteLine("   1 2 3 4 5 6 7 8 9 10")

        For row As Integer = 0 To 9
            If row = 9 Then
                Console.Write(row + 1 & " ")
            Else
                Console.Write(row + 1 & "  ")
            End If

            For column As Integer = 0 To 9
                Console.Write(board(row, column))
            Next
            Console.WriteLine()
        Next
        Console.WriteLine()
        Console.WriteLine("Your current score: " & score)
    End Sub

    ' Setup the board array
    Function SetupBoard(ByVal board)
        For row As Integer = 0 To 9
            For column As Integer = 0 To 9
                board(row, column) = Wall
            Next
        Next

        For row As Integer = 2 To 9
            board(row, 2) = Prize
        Next

        For row As Integer = 2 To 9
            board(row, 7) = Prize
        Next

        For column As Integer = 2 To 7
            board(2, column) = Prize
        Next

        Return board
    End Function

End Module
