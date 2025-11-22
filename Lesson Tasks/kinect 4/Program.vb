Imports System
Module Program
    Dim globalHeight As Integer
    Dim globalWidth As Integer
    Sub printBoard(board(,) As String)
        Console.Clear()
        Dim gridXrows As String = ""

        For i = 0 To globalWidth
            gridXrows += "---|"
        Next

        For i = 0 To globalHeight
            For j = 0 To globalWidth
                Console.Write(" " & board(i, j) & " |")
            Next
            Console.WriteLine()
            Console.WriteLine(gridXrows)
            Console.WriteLine()
        Next
    End Sub


    Function _initializeBoard() As String(,)
        Dim board(globalHeight, globalWidth) As String
        For row = 0 To globalHeight
            For col = 0 To globalWidth
                board(row, col) = " "
            Next
        Next
        Return board
    End Function

    Function turn(player As String, board(,) As String) As String(,)
        Dim col As Integer = 0
        Dim row As Integer = 0
        While True
            While True
                Try
                    Console.WriteLine("Enter a Column in formant: column:")
                    col = Integer.Parse(Console.ReadLine())
                    If col >= 1 And col <= globalWidth + 1 Then
                        Exit While
                    End If
                Catch ex As Exception
                    Console.WriteLine("nAn")
                End Try
            End While
            If validSpace(col - 1, board) <> 999999 Then
                Exit While
            End If
        End While

        board(validSpace(col - 1, board), col - 1) = player
        Return board
    End Function

    Function validSpace(col As Integer, board(,) As String) As Integer
        For i = globalHeight To 0 Step -1
            If board(i, col) = " " Then
                Return i
            End If
        Next
        Return 999999
    End Function

    Function changeTurn(player As String) As String
        Dim players(1) As String
        players = {"O", "X"}

        player = players((Array.IndexOf(players, player) + 1) Mod 2)

        Return player
    End Function

    Function checkWin(player As String, board(,) As String) As Boolean
        Dim win As Boolean = False

        For l = globalHeight To 0 Step -1
            For c = 0 To globalWidth
                If l >= 3 Then
                    If board(l, c) = player And board(l - 1, c) = player And board(l - 2, c) = player And board(l - 3, c) = player Then
                        win = True
                        Exit For
                    End If
                End If

                If c <= globalWidth - 3 Then
                    If board(l, c) = player And board(l, c + 1) = player And board(l, c + 2) = player And board(l, c + 3) = player Then
                        win = True
                        Exit For
                    End If
                End If

                If l >= 3 And c <= globalWidth - 3 Then
                    If board(l, c) = player And board(l - 1, c + 1) = player And board(l - 2, c + 2) = player And board(l - 3, c + 3) = player Then
                        win = True
                        Exit For
                    End If
                End If

                If l >= 3 And c >= 3 Then
                    If board(l, c) = player And board(l - 1, c - 1) = player And board(l - 2, c - 2) = player And board(l - 3, c - 3) = player Then
                        win = True
                        Exit For
                    End If
                End If
            Next

            If win Then
                Exit For
            End If
        Next

        Return win
    End Function


    Function checkDraw(board(,) As String) As Boolean
        For i = 0 To globalHeight
            For j = 0 To globalWidth
                If board(i, j) = " " Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Function getGrid() As Integer()
        Dim input(1) As String
        Dim row As Integer
        Dim col As Integer


        While True
            Try
                Console.WriteLine("Enter grid size in format: row,col:")
                Input = Split(Console.ReadLine(), ",")
                row = Integer.Parse(Input(0))
                col = Integer.Parse(input(1))
                If row > 4 And col > 4 Then
                    Exit While
                End If
            Catch ex As Exception
                Console.WriteLine("Wrong format and or nAn.")
            End Try
        End While

        Return {row - 1, col - 1}
    End Function

    Sub game()
        Dim gottenGridzize = getGrid()
        globalWidth = gottenGridzize(1)
        globalHeight = gottenGridzize(0)
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