Imports System
Imports System.Threading

Module Program
    Sub Main(args As String())
        Dim board(10, 10) As String
        Dim visited(10, 10) As Boolean
        _initializeBoard(board, visited)
        board = GenerateOriginShiftBoard(board, visited, 0, 0, 0)
        board = placeStartAndEnd(board)
        board = generateOriginShiftWalls(board)
        printBoard(board)
    End Sub

    Sub _initializeBoard(ByRef board, ByRef visited)
        For i = 0 To 10
            For j = 0 To 10
                board(i, j) = " "
                visited(i, j) = False
            Next
        Next
    End Sub

    Sub printBoard(baord(,) As String)
        For i = 0 To 20
            For j = 0 To 20
                Console.Write(baord(i, j))
            Next
            Console.WriteLine()
        Next
    End Sub

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

End Module