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
        For i = 0 To 10
            For j = 0 To 10
                Console.Write(baord(i, j) + ".")
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
        visited(x, y) = True

        Dim directions As (Integer, Integer, String)() = {(0, -1, "n"), (0, 1, "s"), (1, 0, "e"), (-1, 0, "w")}

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
                If Not visited(xNewPos, yNewPos) Or count <= 50 Then
                    board(xNewPos, yNewPos) = direction.Item3
                    Return GenerateOriginShiftBoard(board, visited, xNewPos, yNewPos, count)
                Else
                    Return board
                End If
            End If

        Next
    End Function

    Function generateOriginShiftWalls(origBoard(,) As String) As String(,)
        Dim newBoard(10, 10) As String
        For i = 0 To 10
            For j = 0 To 10
                Select Case origBoard(i, j)
                    Case "n", "s"
                        newBoard(i, j) = "."
                    Case "e", "w"
                        newBoard(i, j) = "."
                    Case "o", "x"
                        newBoard(i, j) = origBoard(i, j)
                    Case Else
                        newBoard(i, j) = "@"
                End Select
            Next
        Next
        Return newBoard
    End Function

End Module