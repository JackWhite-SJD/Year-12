Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.Security
Imports System.Security.Cryptography

Module Module1
    Const Player As String = "O "
    Const Wall As String = "X "
    Const Prize As String = " "
    Const Endpoint As String = "E"

    Sub Main()
        Dim bounds As Integer = 10
        Dim board(bounds, bounds) As String, PositionX As Integer = 9, PositionY As Integer = 2, Score As Integer = 0
        Dim YorN As String
        Dim winPos() = {9, 8}

        While True

            ' Run the SetupBoard subroutine and initialise the Player's position
            Score = 0
            PositionX = 9
            PositionY = 2
            board = SetupBoard(board)
            board = generateBoard(board, 0, 0, {0, 2})
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

                If checkWin(board, winPos) Then
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

    Function checkWin(Board(,) As String, winPos() As Integer) As Boolean
        If Board(winPos(0), winPos(1)) = Player Then
            Return True
        End If
        Return False
    End Function

    Function GenerateOriginShiftBoard(board(,) As String, count As Integer) As String()
        Dim yChange As Integer
        Dim xChange As Integer
        Dim XcurrentPos As Integer
        Dim yCurrentPos As Integer
        Dim xNewPos As Integer
        Dim yNewPos As Integer
        Dim directionList As New List(Of String)
        Dim randGen As New Random
        Dim newDirection As Integer = randGen.Next(0, 4)
        Dim newDirectionLetter As String

        If count > 100 Then
            Return board
        End If


        dirList.Add("n")
        dirList.Add("e")
        dirList.Add("w")
        dirList.Add("s")



        For i = 0 To 10
            For j = 0 To 10
                If board(i, j) = "o" Then
                    XcurrentPos = i
                    yCurrentPos = j
                End If
            Next
        Next

        Select Case newDirection
            Case 0
                xChange = 1
                yChange = 0

                If XcurrentPos + xChange < 10 Then
                    xNewPos = XcurrentPos + xChange
                    yNewPos = yChange + yCurrentPos
                End If

                newDirectionLetter = "e"

            Case 1
                xChange = -1
                yChange = 0

                If XcurrentPos + xChange > 0 Then
                    xNewPos = XcurrentPos + xChange
                    yNewPos = yChange + yCurrentPos
                End If

                newDirectionLetter = "w"

            Case 2
                xChange = 0
                yChange = 1

                If yCurrentPos + yChange < 10 Then
                    yNewPos = XcurrentPos + xChange
                    yNewPos = yChange + yCurrentPos
                End If

                newDirectionLetter = "s"

            Case 3
                xChange = 0
                yChange = -1

                If yCurrentPos + yChange > 0 Then
                    yNewPos = XcurrentPos + xChange
                    yNewPos = yChange + yCurrentPos
                End If

                newDirectionLetter = "n"

        End Select

        board(XcurrentPos, yCurrentPos) = newDirectionLetter
        board(xNewPos, yNewPos) = "o"

        count += 1

        Return generateBoard(board, count)

    End Function

    Function generateOriginShiftBoardWalls(board(,) As String) As String()
        Dim newBoard(10, 10) As String()
        For i = 0 To 10
            For j = 0 To 10
                If board(i, j) = "e" Or board(i, j) = "w" Then
                    newBoard(i, j) = "-"
                ElseIf board(i, j) = "n" Or board(i, j) = "s" Then
                    newBoard(i, j) = " "
                End If
            Next
        Next
    End Function

    Function generateBoard(board(,) As String, currentDirection As Integer, runCount As Integer, currentPos() As Integer) As String()

        'randomboardGnerator
        Dim vectorArr() As Integer
        Dim randGen As New Random
        Dim xChange As Integer
        Dim yChange As Integer
        Dim length As Integer

        Dim newDirection As Integer
        Dim finalDirection As String
        Dim dirList As New List(Of String)


        dirList.Add("n")
        dirList.Add("e")
        dirList.Add("w")
        dirList.Add("s")

        Dim dupeListArr(3) As String

        Select Case currentDirection
            Case 0
                dupeListArr = {"n", "e", "s"}
            Case 1
                dupeListArr = {"e", "w", "s"}
            Case 2
                dupeListArr = {"n", "w", "s"}
            Case 3
                dupeListArr = {"n", "w", "e"}
        End Select

        newDirection = randGen.Next(0, 3)
        finalDirection = dupeListArr(newDirection)

        Select Case finalDirection
            Case "n"
                If currentPos(1) > 1 Then
                    length = randGen.Next(1, currentPos(1))

                    xChange = 0
                    yChange = -1 * length
                End If

            Case "e"
                If currentPos(0) < 1 Then
                    length = randGen.Next(1, currentPos(0))

                    xChange = -1 * length
                    yChange = 0
                End If
            Case "s"
                If currentPos(1) < 8 Then
                    length = randGen.Next(1, 8 - currentPos(1))

                    xChange = 0
                    yChange = 1
                End If
            Case "w"
                If currentPos(1) < 8 Then
                    length = randGen.Next(1, 8 - currentPos(1))

                    xChange = 1
                    yChange = 0
                End If
        End Select

        currentPos(0) += xChange
        currentPos(1) += yChange

        board(currentPos(0), currentPos(1)) = Prize

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
            board(PositionX, PositionY) = "  "
            PositionX = 9
            PositionY = 2
            board(9, 2) = Player

            PrintBoard(board, score)

            Console.WriteLine("You loose.")
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

        Return board
    End Function

End Module