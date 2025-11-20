Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")
        Dim board(,) As String = {{"e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "s"}, {"e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "s"}, {"e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "s"}, {"e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "s"}, {"e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "s"}, {"e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "s"}, {"e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "s"}, {"e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "s"}, {"e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "s"}, {"e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "s"}, {"e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "o"}}
        Dim newBoard(,) As String = GenerateOriginShiftBoard(board, 1, 0)
        newBoard = generateOriginShiftBoardWalls(newBoard)
        printBoard(newBoard)
    End Sub

    Sub printBoard(baord(,) As String)
        For i = 0 To 10
            For j = 0 To 10
                Console.Write(baord(i, j))
            Next
            Console.WriteLine()
        Next
    End Sub
    Function GenerateOriginShiftBoard(board(,) As String, count As Integer, lastDirection As String) As String(,)
        Dim yChange As Integer = 0
        Dim xChange As Integer = 0
        Dim XcurrentPos As Integer = -1
        Dim yCurrentPos As Integer = -1
        Dim xNewPos As Integer
        Dim yNewPos As Integer
        Static randGen As New Random
        Dim newDirection As Integer
        Dim newDirectionLetter As String
        Dim validMove As Boolean = False

        If count > 1000 Then
            Return board
        End If

        For i = 0 To 10
            For j = 0 To 10
                If board(i, j) = "o" Then
                    XcurrentPos = i
                    yCurrentPos = j
                End If
            Next
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