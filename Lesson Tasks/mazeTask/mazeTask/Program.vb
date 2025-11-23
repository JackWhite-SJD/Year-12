Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.Security
Imports System.Security.Cryptography

Module Module1
    Const Player As String = "O"
    Const Wall As String = "X"
    Const Prize As String = "."
    Const prize2 As String = "*"
    Const Endpoint As String = "E"
    Const bomb As String = "#"
    Const bounds As Integer = 30
    Sub Main()


        Dim board(bounds, bounds) As String
        Dim startPos() As Integer, PositionX As Integer, PositionY As Integer, Score As Integer, totalScore As Integer = 0, livees As Integer, livesUsed As Integer = 0, ratio As Integer = 0
        totalScore = 0


        While True

            ' Run the SetupBoard subroutine and initialise the Player's position
            Console.Clear()
            livees = 3
            board = generateNewBoard(board)
            startPos = getStartPos(board)
            Score = 0

            ResetToStart(board, PositionX, PositionY, startPos)
            printBoard(board)

            ' Continued game play
            While True
                If livees <= 0 Then
                    Console.WriteLine("Out of lives for this maze, generating new maze.")
                    Exit While
                End If

                Dim input As ConsoleKeyInfo
                input = Console.ReadKey

                ' Actions dependent upon characters pressed
                Select Case input.KeyChar
                    Case "w"
                        Console.Clear()
                        MakeMove(-1, 0, board, Score, PositionX, PositionY, bounds, startPos, totalScore, livees, livesUsed)
                        Exit Select
                    Case "a"
                        Console.Clear()
                        MakeMove(0, -1, board, Score, PositionX, PositionY, bounds, startPos, totalScore, livees, livesUsed)
                        Exit Select
                    Case "s"
                        Console.Clear()
                        MakeMove(1, 0, board, Score, PositionX, PositionY, bounds, startPos, totalScore, livees, livesUsed)
                        Exit Select
                    Case "d"
                        Console.Clear()
                        MakeMove(0, 1, board, Score, PositionX, PositionY, bounds, startPos, totalScore, livees, livesUsed)
                        Exit Select
                    Case "f"
                        Console.WriteLine("Final Score :" & totalScore)
                        End
                    Case "r"
                        Exit While
                    Case "q"
                        totalScore = 0
                        livesUsed = 0
                        Exit While
                    Case Else
                        Console.WriteLine()
                        Console.WriteLine("You inputted:" & input.KeyChar & " that is not a valid input for this program.")
                End Select
                Console.WriteLine()
                Console.WriteLine("Score :" & Score)
                Console.WriteLine("Total Score: " & totalScore)
                If livesUsed >= 1 And totalScore >= 1 Then
                    Console.WriteLine("Lives:total score :" & Math.Round((totalScore / livesUsed), 2))
                End If

                Console.WriteLine("Press r for a new maze, q to reset scores and f to quit.")

            End While
        End While

    End Sub

    Function checkWin(Board(,) As String, winPos() As Integer) As Boolean
        If Board(winPos(0), winPos(1)) = Player Then
            Return True
        End If
        Return False
    End Function

    Function getStartPos(board(,) As String) As Integer()
        For i = 0 To bounds
            For j = 0 To bounds
                If board(i, j) = "S" Then
                    Return {i, j}
                End If
            Next
        Next
    End Function

    ' Make a move on the board
    Sub MakeMove(ByVal XChange, ByVal YChange, ByVal board, ByRef score, ByRef PositionX, ByRef PositionY, ByVal bounds, ByVal startPos, ByRef totalScore, ByRef Lives, ByRef livesUsed)


        If (board(PositionX + XChange, PositionY + YChange) IsNot Wall) And (PositionX + XChange < bounds) And (PositionY + YChange < bounds) Then
            If board(PositionX + XChange, PositionY + YChange) = Prize Then
                score += 1
                totalScore += 1
            ElseIf board(PositionX + XChange, PositionY + YChange) = prize2 Then
                score += 3
                totalScore += 3
            ElseIf board(PositionX + XChange, PositionY + YChange) = bomb Then
                score -= 2
                totalScore -= 2
            End If
            board(PositionX + XChange, PositionY + YChange) = Player
            board(PositionX, PositionY) = " "
            printBoard(board)
            PositionX = PositionX + XChange
            PositionY = PositionY + YChange
        Else
            Lives -= 1
            livesUsed += 1
            board(PositionX, PositionY) = " "
            PositionX = startPos(0)
            PositionY = startPos(1)
            board(startPos(0), startPos(1)) = Player

            printBoard(board)

            Console.WriteLine("Reset Position, lives for map left:" & Lives)
        End If
    End Sub

    Function generateNewBoard(board(,) As String) As String(,)
        Dim visited(bounds / 2, bounds / 2) As Boolean
        _initializeBoard(board, visited)
        board = GenerateOriginShiftBoard(board, visited, 0, 0, 0)
        board = placeStartAndEnd(board)
        board = generateOriginShiftWalls(board)
        Return board
    End Function

    Function placeStartAndEnd(board(,) As String) As String(,)
        board(0, 0) = "o"
        board(bounds / 2, bounds / 2) = "x"
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

            If yNewPos >= 0 And yNewPos <= bounds / 2 And xNewPos >= 0 And xNewPos <= bounds / 2 Then
                If Not visited(yNewPos, xNewPos) Then
                    board(yNewPos, xNewPos) = direction.Item3
                    GenerateOriginShiftBoard(board, visited, xNewPos, yNewPos, count)
                End If
            End If
        Next

        Return board
    End Function

    Sub ResetToStart(ByRef board(,) As String, ByRef posX As Integer, ByRef posY As Integer, startPos() As Integer)
        board(posX, posY) = " "
        posX = startPos(0)
        posY = startPos(1)
        board(posX, posY) = "O"
    End Sub


    Function generateOriginShiftWalls(origBoard(,) As String) As String(,)
        Dim newBoard(bounds, bounds) As String
        Dim currentX As Integer
        Dim currentY As Integer
        Dim randGen As New Random
        Dim RandNum As Integer
        Dim randNum2 As Integer

        For i = 0 To bounds
            For j = 0 To bounds
                RandNum = randGen.Next(0, 6)
                If i > 1 And i < bounds - 1 And j > 1 And j < bounds - 1 Then
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

        For i = 1 To (bounds / 2) - 1
            For j = 1 To (bounds / 2) - 1
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

        For i = 0 To Math.Round(bounds * 0.35)
            RandNum = randGen.Next(1, bounds - 1)
            randNum2 = randGen.Next(1, bounds - 1)
            newBoard(RandNum, randNum2) = "."
            newBoard(RandNum + 1, randNum2) = " "
            newBoard(RandNum, randNum2 - 1) = " "
        Next

        For i = 0 To Math.Round(bounds * 0.2)
            RandNum = randGen.Next(1, bounds - 1)
            randNum2 = randGen.Next(1, bounds - 1)
            newBoard(RandNum, randNum2) = "*"
            newBoard(RandNum + 1, randNum2) = " "
            newBoard(RandNum, randNum2 - 1) = " "
        Next

        For i = 0 To Math.Round(bounds * 0.24)
            RandNum = randGen.Next(1, bounds - 1)
            randNum2 = randGen.Next(1, bounds - 1)
            newBoard(RandNum, randNum2) = "#"
            newBoard(RandNum + 1, randNum2) = " "
            newBoard(RandNum, randNum2 - 1) = " "
        Next
        newBoard(bounds - 1, bounds - 1) = "."

        RandNum = randGen.Next(Math.Round((bounds * 0.25), 0), Math.Round(bounds * 0.75))
        randNum2 = randGen.Next(Math.Round((bounds * 0.25), 0), Math.Round(bounds * 0.75))
        newBoard(RandNum, randNum2) = "S"
        newBoard(RandNum + 1, randNum2) = " "
        newBoard(RandNum, randNum2 - 1) = " "

        Return newBoard
    End Function

    Sub printBoard(baord(,) As String)
        For i = 0 To bounds
            For j = 0 To bounds
                Console.Write(baord(i, j))
            Next
            Console.WriteLine()
        Next
    End Sub

    ' Setup the board array
    Sub _initializeBoard(ByRef board, ByRef visited)
        For i = 0 To Math.Round(bounds / 2)
            For j = 0 To Math.Round(bounds / 2)
                board(i, j) = " "
                visited(i, j) = False
            Next
        Next
    End Sub
End Module