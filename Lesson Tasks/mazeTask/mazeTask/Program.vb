Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.Security
Imports System.Security.Cryptography

Module Module1
    Const Player As String = "O "
    Const Wall As String = "X "
    Const Prize As String = "."
    Const Endpoint As String = "E"

    Sub Main()
        Dim bounds As Integer = 20

        Dim board(bounds, bounds) As String
        Dim startPos() As Integer, PositionX As Integer, PositionY As Integer, Score As Integer, totalScore As Integer
        totalScore = 0
        Dim YorN As String


        While True

            ' Run the SetupBoard subroutine and initialise the Player's position
            board = generateNewBoard(board)
            startPos = getStartPos()
            Score = 0

            PositionX = getStartPos(0)
            PositionY = getStartPos(1)

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
                        MakeMove(-1, 0, board, Score, PositionX, PositionY, bounds, startPos(0), startPos(1))
                        Exit Select
                    Case "a"
                        Console.Clear()
                        MakeMove(0, -1, board, Score, PositionX, PositionY, bounds, startPos(0), startPos(1))
                        Exit Select
                    Case "s"
                        Console.Clear()
                        MakeMove(1, 0, board, Score, PositionX, PositionY, bounds, startPos(0), startPos(1))
                        Exit Select
                    Case "d"
                        Console.Clear()
                        MakeMove(0, 1, board, Score, PositionX, PositionY, bounds, startPos(0), startPos(1))
                        Exit Select
                    Case "f"
                        Console.WriteLine("Final Score :" & totalScore)
                        End
                    Case "r"
                        Exit While
                    Case Else
                        Console.WriteLine()
                        Console.WriteLine("You inputted:" & input.KeyChar & " that is not a valid input for this program.")
                End Select
                Console.WriteLine("Score :" & Score)
                Console.writeLine("Total Score: " & totalScore)
                console.writeLine("Press r for a new maze, and f to quit.")

            End While
        End While

    End Sub

    Function checkWin(Board(,) As String, winPos() As Integer) As Boolean
        If Board(winPos(0), winPos(1)) = Player Then
            Return True
        End If
        Return False
    End Function

    Function getStartPos(board(,) As String) As Integer(,)
        For i = 0 To 20
            For j = 0 To 20
                If board(i, j) = "S" Then
                    Return (i, j)
                End If
            Next
        Next
    End Function

    ' Make a move on the board
    Sub MakeMove(ByVal XChange, ByVal YChange, ByVal board, ByRef score, ByRef PositionX, ByRef PositionY, ByVal bounds, startX, startY)
        If (board(PositionX + XChange, PositionY + YChange) IsNot Wall) And (PositionX + XChange < bounds) And (PositionY + YChange < bounds) Then
            If board(PositionX + XChange, PositionY + YChange) = Prize Then
                score += 1
            End If
            board(PositionX + XChange, PositionY + YChange) = Player
            board(PositionX, PositionY) = "  "
            printBoard(board, score)
            PositionX = PositionX + XChange
            PositionY = PositionY + YChange
        Else
            board(PositionX, PositionY) = "  "
            PositionX = startX
            PositionY = startY
            board(startX, startY) = Player

            printBoard(board, score)

            Console.WriteLine("You loose.")
        End If
    End Sub

    Function generateNewBoard(board(,) As String) As String(,)
        _initializeBoard(board, visited)
        board = GenerateOriginShiftBoard(board, visited, 0, 0, 0)
        board = placeStartAndEnd(board)
        board = generateOriginShiftWalls(board)
        Return board
    End Function

    Function placeStartAndEnd(board(,) As String) As String(,)
        board(0, 0) = "o"
        board(10, 10) = "x"
        Return board
    End Function

    Function GenerateOriginShiftBoard(board(,) As String, visited(,) As Boolean, x As Integer, y As Integer, count As Integer) As String(,)
        Dim yChange As Integer = 0
        Dim xChange As Integer = 0
        Dim xNewPos As Integer
        Dim yNewPos As Integer
        Static randGen As New Random
        Dim randomNumber As Integer
        Dim temp As (Integer, Integer, String)
        count += 1
        visited(y, x) = True

        Dim directions As (Integer, Integer, String)() = {(-1, 0, "n"), (1, 0, "s"), (0, 1, "e"), (0, -1, "w")}

        For i = 0 To directions.Length - 1
            randomNumber = randGen.Next(i, directions.Length)
            temp = directions(i)
            directions(i) = directions(randomNumber)
            directions(randomNumber) = temp
        Next

        For Each direction In directions
            xChange = direction.Item1
            yChange = direction.Item2

            xNewPos = x + xChange
            yNewPos = y + yChange

            If yNewPos >= 0 And yNewPos <= 10 And xNewPos >= 0 And xNewPos <= 10 Then
                If Not visited(yNewPos, xNewPos) Then
                    board(yNewPos, xNewPos) = direction.Item3
                    GenerateOriginShiftBoard(board, visited, xNewPos, yNewPos, count)
                End If
            End If
        Next

        Return board
    End Function


    Function generateOriginShiftWalls(origBoard(,) As String) As String(,)
        Dim newBoard(20, 20) As String
        Dim currentX As Integer
        Dim currentY As Integer
        Dim randGen As New Random
        Dim RandNum As Integer
        Dim randNum2 As Integer

        For i = 0 To 20
            For j = 0 To 20
                RandNum = randGen.Next(0, 6)
                If i > 1 And i < 19 And j > 1 And j < 19 Then
                    If RandNum = 2 Then
                        newBoard(i, j) = " "
                    Else
                        newBoard(i, j) = "X"
                    End If
                Else
                    newBoard(i, j) = "X"
                End If
            Next
        Next

        For i = 1 To 9
            For j = 1 To 9
                currentX = i * 2
                currentY = j * 2
                newBoard(currentY, currentX) = " "

                Select Case origBoard(i, j)
                    Case "n"
                        newBoard(currentY - 1, currentX) = " "
                    Case "s"
                        newBoard(currentY + 1, currentX) = " "
                    Case "w"
                        newBoard(currentY, currentX - 1) = " "
                    Case "e"
                        newBoard(currentY, currentX + 1) = " "
                End Select
            Next
        Next

        RandNum = randGen.Next(5, 15)
        randNum2 = randGen.Next(5, 15)
        newBoard(RandNum, randNum2) = "S"
        newBoard(RandNum + 1, randNum2) = " "
        newBoard(RandNum, randNum2 - 1) = " "

        'ensures atleast 1 point can be scored per board

        For i = 0 To 5
            RandNum = randGen.Next(1, 19)
            randNum2 = randGen.Next(1, 19)
            newBoard(RandNum, randNum2) = "."
            newBoard(RandNum + 1, randNum2) = " "
            newBoard(RandNum, randNum2 - 1) = " "
        Next
        newBoard(19, 19) = "."
        Return newBoard
    End Function

    ' Output the contents of the board array
    Sub printBoard(baord(,) As String)
        For i = 0 To 20
            For j = 0 To 20
                Console.Write(baord(i, j))
            Next
            Console.WriteLine()
        Next
    End Sub

    ' Setup the board array
    Sub _initializeBoard(ByRef board, ByRef visited)
        For i = 0 To 10
            For j = 0 To 10
                board(i, j) = " "
                visited(i, j) = False
            Next
        Next
    End Sub
End Module