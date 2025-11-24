Imports System

Module Program
    Dim Globalwidth As Integer
    Dim Globalheight As Integer
    Sub Main(args As String())
        Globalheight = 5
        Globalwidth = 5
        printBoard(setupBoard())
    End Sub

    Sub game()

    Function setupBoard() As String(,)
        Dim board(Globalwidth, Globalheight) As String
        For i = 0 To Globalwidth
            For j = 0 To Globalheight
                board(Globalwidth, Globalheight) = " "
            Next
        Next
        Return board
    End Function

    Sub printBoard(board(,) As String)
        For i = 0 To Globalwidth
            For l = 0 To Globalwidth
                Console.Write("--+")
            Next
            Console.WriteLine()
            For j = 0 To Globalheight

                Console.Write(board(i, j) + "  |")
            Next
            Console.WriteLine()
        Next
    End Sub

    Function turn(player As String, board(,) As String) As String(,)
        Dim row As Integer = 0
        Dim col As Integer = 0
        Dim input(1) As String

        While True
            While True
                Try
                    Console.WriteLine("Enter column in formant: column:")
                    col = Integer.Parse(Console.ReadLine())
                    If col <= Globalwidth And col >= 0 Then
                        Exit While
                    End If
                Catch ex As Exception
                    Console.WriteLine("nAn")
                End Try
            End While
            If validSpace(col - 1, board) Then
                Exit While
            End If
        End While

        For i = Globalheight To 0 Step -1
            If board(i, col - 1) = " " Then
                board(i, col - 1) = player
            End If
        Next
        Return board
    End Function


    Function validSpace(col As Integer, board(,) As String) As Boolean
        For i = 0 To Globalheight
            If board(i, col) = " " Then
                Return True
            Else
                Console.WriteLine("Space not free")
                Return False
            End If
        Next

    End Function

    Function changeTurn(player As String) As String
        Dim players(1) As String
        players = {"O", "X"}

        player = players((Array.IndexOf(players, player) + 1) Mod 2)

        Return player
    End Function

    Function checkDraw(board(,) As String) As Boolean
        For i = 0 To Globalwidth
            For j = 0 To Globalheight
                If board(i, j) = " " Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

End Module
