Imports System
Imports System.ComponentModel.Design

Module Program
    Sub printBoard(board(,) As String)
        Console.WriteLine("   1   2   3")
        For i = 0 To 2
            Console.Write((i + 1) & " ")
            Console.WriteLine(" " & board(i, 0) & " | " & board(i, 1) & " | " & board(i, 2))
            If i < 2 Then
                Console.WriteLine("  ---+---+---")
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
        Console.Clear()
        printBoard(board)

        currentPlayer = "X"

        While True
            Console.WriteLine("It is player " & currentPlayer & " 's turn.")
            board = turn(currentPlayer, board)
            Console.WriteLine()
            Console.Clear()
            printBoard(board)
            If checkWin(currentPlayer, board) Then
                Console.WriteLine("Winner: " & currentPlayer)
                Console.ReadLine()
                Exit While
            ElseIf checkDraw(board) Then
                Console.WriteLine("It's a draw!")
                Exit While
            End If

            currentPlayer = changeTurn(currentPlayer)
        End While

    End Sub

    Sub vsComputer()
        Dim board(,) As String = _initializeBoard()
        Dim currentPlayer As String
        Console.Clear()
        printBoard(board)

        currentPlayer = "X"

        While True
            Console.WriteLine("It is player " & currentPlayer & " 's turn.")
            If currentPlayer = "X" Then
                board = turn(currentPlayer, board)
            Else
                board = computerTurn(currentPlayer, board)
            End If

            Console.WriteLine()
            Console.ReadLine()
            Console.Clear()
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

    Function menu() As Integer
        Dim choice As Integer
        While True
            Console.Clear()
            Console.WriteLine("Welcome to Noughts and Crosses. What would you like to do?")
            Console.WriteLine("1: Player vs Player")
            Console.WriteLine("2: Player vs Computer")
            Console.WriteLine("3: Quit")
            Console.Write("Enter choice (1-3): ")

            If Integer.TryParse(Console.ReadLine(), choice) AndAlso choice >= 1 AndAlso choice <= 3 Then
                If choice = 3 Then
                    End
                End If

                Return choice
            Else
                Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.")
            End If
        End While
    End Function


    Function computerTurn(player As String, board(,) As String) As String(,)
        Dim row As Integer
        Dim col As Integer
        Dim rnd As New Random()

        While True
            row = rnd.Next(0, 3)
            col = rnd.Next(0, 3)
            If validSpace(row, col, board) Then
                Exit While
            End If
        End While

        Console.WriteLine("Computer chooses: " & (row + 1) & "," & (col + 1))
        board(row, col) = player

        Return board
    End Function

    Sub Main(args As String())
        While True
            Dim choice As Integer = menu()
            If choice = 1 Then
                game()
            Else
                vsComputer()
            End If
        End While

        Console.ReadKey()
    End Sub
End Module