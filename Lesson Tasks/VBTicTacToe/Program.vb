Imports System

'in furture i would:
'use arrays for players
'use an array for win positions and compare
'allow for more players and varied symbols
'allow for varied game sizes

Module Program
    Sub printBoard(board(,) As String)
        For i = 0 To 2
            Console.WriteLine(" " & board(i, 0) & " | " & board(i, 1) & " | " & board(i, 2))
            If i < 2 Then
                Console.WriteLine("---+---+---")
            End If
        Next
    End Sub

    Function _initializeBoard() As String(,)
        Dim board(2, 2) As String
        For row = 0 To 2
            For col = 0 To 2
                board(row, col) = " "
            Next
        Next
        Return board
    End Function

    Function turn(player As String, board(,) As String) As String(,)
        Dim row As Integer = 0
        Dim col As Integer = 0
        Dim input(1) As String

        While True
            While True
                Try
                    Console.WriteLine("Enter row and column in formant: row,column:")
                    input = Split(Console.ReadLine(), ",")
                    row = Integer.Parse(input(0))
                    col = Integer.Parse(input(1))
                    If row >= 1 And row <= 3 And col >= 1 And col <= 3 Then
                        Exit While
                    End If
                Catch ex As Exception
                    Console.WriteLine("nAn")
                End Try
            End While
            If validSpace(row - 1, col - 1, board) Then
                Exit While
            End If
        End While

        board(row - 1, col - 1) = player
        Return board
    End Function

    Function validSpace(row As Integer, col As Integer, board(,) As String) As Boolean
        If board(row, col) = " " Then
            Return True
        Else
            Console.WriteLine("Space not free")
            Return False
        End If
    End Function
    Function changeTurn(player As String) As String
        Dim players(1) As String
        players = {"O", "X"}

        player = players((Array.IndexOf(players, player) + 1) Mod 2)

        Return player
    End Function

    Function checkWin(player As String, board(,) As String) As Boolean
        For i = 0 To 2
            If board(i, 0) = player And board(i, 1) = player And board(i, 2) = player Then
                Return True
            End If
        Next

        For j = 0 To 2
            If board(0, j) = player And board(1, j) = player And board(2, j) = player Then
                Return True
            End If
        Next

        If board(0, 0) = player And board(1, 1) = player And board(2, 2) = player Then
            Return True
        End If

        If board(0, 2) = player And board(1, 1) = player And board(2, 0) = player Then
            Return True
        End If

        Return False
    End Function

    Function checkDraw(board(,) As String) As Boolean
        For i = 0 To 2
            For j = 0 To 2
                If board(i, j) = " " Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Sub game()
        Dim board(,) As String = _initializeBoard()
        Dim currentPlayer As String
        printBoard(board)

        currentPlayer = "X"

        While True
            Console.WriteLine("It is player " & currentPlayer & " 's turn.")
            board = turn(currentPlayer, board)
            Console.WriteLine()
            printBoard(board)
            If checkWin(currentPlayer, board) Then
                Console.WriteLine("Winner: " & currentPlayer)
                Exit While
            ElseIf checkDraw(board) Then
                Console.WriteLine("It's a draw!")
                Exit While
            End If

            currentPlayer = changeTurn(currentPlayer)
        End While

    End Sub
    Sub Main(args As String())
        game()
        Console.ReadKey()
    End Sub

End Module