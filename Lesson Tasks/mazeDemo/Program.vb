Imports System

Module Program
    Sub Main(args As String())
        Dim board(10, 10) As String
        Dim visited(10, 10) As Boolean
        Dim randgen As New Random

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
                Console.Write(baord(i, j))
            Next
            Console.WriteLine()
        Next
    End Sub
    Function GenerateOriginShiftBoard(board(,) As String, visited(,) As Boolean, x As Integer, y As Integer) As String(,)
        Dim yChange As Integer = 0
        Dim xChange As Integer = 0
        Dim xNewPos As Integer
        Dim yNewPos As Integer
        Static randGen As New Random
        Dim randomNumber As Integer
        Dim temp As (Integer, Integer, String)


        Dim newDirection As Integer
        Dim newDirectionLetter As String
        Dim validMove As Boolean = False

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
                If Not visited(xNewPos, yNewPos) Then
                    board(xNewPos, yNewPos) = direction.Item3
                    Return GenerateOriginShiftBoard(board, visited, xNewPos, yNewPos)
                End If
            End If
        Next


        Do While Not validMove
            newDirection = randGen.Next(0, 4)
            Select Case newDirection
                Case 0
                    newDirectionLetter = "e"
                Case 1
                    newDirectionLetter = "w"
                Case 2
                    newDirectionLetter = "s"
                Case 3
                    newDirectionLetter = "n"
            End Select

            If lastDirection = "n" And newDirectionLetter = "s" Then
                Continue Do
            ElseIf lastDirection = "s" And newDirectionLetter = "n" Then
                Continue Do
            ElseIf lastDirection = "e" And newDirectionLetter = "w" Then
                Continue Do
            ElseIf lastDirection = "w" And newDirectionLetter = "e" Then
                Continue Do
            End If

            Select Case newDirection
                Case 0
                    xChange = 1
                    yChange = 0
                Case 1
                    xChange = -1
                    yChange = 0
                Case 2
                    xChange = 0
                    yChange = 1
                Case 3
                    xChange = 0
                    yChange = -1
            End Select

            xNewPos = XcurrentPos + xChange
            yNewPos = yCurrentPos + yChange

            If newDirectionLetter = "s" And yCurrentPos = 10 Then
                Continue Do
            ElseIf newDirectionLetter = "n" And yCurrentPos = 0 Then
                Continue Do
            ElseIf newDirectionLetter = "w" And XcurrentPos = 0 Then
                Continue Do
            ElseIf newDirectionLetter = "e" And XcurrentPos = 10 Then
                Continue Do
            End If

            If xNewPos >= 0 And xNewPos <= 10 And yNewPos >= 0 And yNewPos <= 10 Then
                validMove = True
            End If
        Loop

        board(XcurrentPos, yCurrentPos) = newDirectionLetter
        board(xNewPos, yNewPos) = "o"

        Return GenerateOriginShiftBoard(board, count + 1, newDirectionLetter)
    End Function

    Function generateOriginShiftBoardWalls(board(,) As String) As String(,)
        Dim newBoard(10, 10) As String
        For i = 0 To 10
            For j = 0 To 10
                If board(i, j) = "e" Or board(i, j) = "w" Then
                    newBoard(i, j) = "-"
                ElseIf board(i, j) = "n" Or board(i, j) = "s" Then
                    newBoard(i, j) = "!"
                Else
                    newBoard(i, j) = " "
                End If
            Next
        Next
        Return newBoard
    End Function

    End Module