Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.Drawing

Module Program

    Class Player
        Private _name As String
        Private _symbol As String
        Private _score As Integer
        Private _colour As ConsoleColor
        Public Sub New(ByVal symbol As String, colour As ConsoleColor)
            _name = setName()
            _colour = colour
            _symbol = symbol
            _score = 0
        End Sub

        Public Function getName() As String
            Return _name
        End Function

        Public Function getSymbol() As String
            Return _symbol
        End Function

        Public Function getScore() As Integer
            Return _score
        End Function

        Public Sub incrementScore()
            _score += 1
        End Sub
        Public Function getColour() As ConsoleColor
            Return _colour
        End Function

        Private Function setName() As String
            Console.WriteLine("Enter Name:")
            Return Console.ReadLine()
        End Function

        Public Function turn() As Integer
            Console.WriteLine("Enter a collum")
            Dim x As Integer = Integer.Parse(Console.ReadLine())
            Return x
        End Function

    End Class

    Class cell
        Private _value As String
        Private _colour As ConsoleColor

        Public Sub New()
            _value = " "
            _colour = ConsoleColor.Black
        End Sub

        Public Sub updateCell(value As String, colour As ConsoleColor)
            _value = value
            _colour = colour
        End Sub

        Public Function getColour() As ConsoleColor
            Return _colour
        End Function

        Public Function getCellValue() As String
            Return _value
        End Function
    End Class

    Class board
        Private _size() As Integer
        Private _ArrOfCells(,) As cell

        Public Sub New(size() As Integer)
            _size = size
            _ArrOfCells = generateBaord(_size(1) - 1, _size(0) - 1)
        End Sub

        Public Function generateBaord(ByVal x As Integer, ByVal y As Integer) As cell(,)
            Dim board(y, x) As cell
            For i = 0 To y
                For j = 0 To x
                    Dim newCell As New cell
                    board(i, j) = newCell
                Next
            Next
            Return board
        End Function

        Public Sub ChangeCell(symbol As String, y As Integer, x As Integer, colour As ConsoleColor)
            _ArrOfCells(y - 1, x - 1).updateCell(symbol, colour)
        End Sub

        Public Function getSize() As Integer()
            Return _size
        End Function

        Public Function getBoard() As cell(,)
            Return _ArrOfCells
        End Function

        Public Sub outputBoard()
            Dim cols As Integer = _ArrOfCells.GetLength(1)

            For i = 0 To _ArrOfCells.GetLength(0) - 1
                For k = 0 To cols - 1
                    Console.Write("+---")
                Next
                Console.WriteLine("+")

                For j = 0 To _ArrOfCells.GetLength(1) - 1
                    Console.Write("| ")
                    Console.ForegroundColor = _ArrOfCells(i, j).getColour()
                    Console.Write(_ArrOfCells(i, j).getCellValue())
                    Console.ResetColor()
                    Console.Write(" ")
                Next
                Console.WriteLine("|")
            Next

            For k = 0 To _ArrOfCells.GetLength(1) - 1
                Console.Write("+---")
            Next
            Console.WriteLine("+")
        End Sub

        Public Function checkWin(player As Player, board(,) As cell) As Boolean
            Dim win As Boolean = False

            For l = _ArrOfCells.GetLength(0) - 1 To 0 Step -1
                For c = 0 To _ArrOfCells.GetLength(1) - 1
                    If l >= 4 Then
                        If board(l, c).getCellValue() = player.getSymbol() And board(l - 1, c).getCellValue() = player.getSymbol() And board(l - 2, c).getCellValue() = player.getSymbol() And board(l - 3, c).getCellValue() = player.getSymbol() Then
                            win = True
                            Exit For
                        End If
                    End If

                    If c <= _size(1) - 4 Then
                        If board(l, c).getCellValue() = player.getSymbol() And board(l, c + 1).getCellValue() = player.getSymbol() And board(l, c + 2).getCellValue() = player.getSymbol And board(l, c + 3).getCellValue() = player.getSymbol() Then
                            win = True
                            Exit For
                        End If
                    End If

                    If l >= 4 And c <= _size(1) - 4 Then
                        If board(l, c).getCellValue() = player.getSymbol() And board(l - 1, c + 1).getCellValue() = player.getSymbol() And board(l - 2, c + 2).getCellValue() = player.getSymbol() And board(l - 3, c + 3).getCellValue() = player.getSymbol() Then
                            win = True
                            Exit For
                        End If
                    End If

                    If l >= 4 And c >= 4 Then
                        If board(l, c).getCellValue() = player.getSymbol() And board(l - 1, c - 1).getCellValue() = player.getSymbol() And board(l - 2, c - 2).getCellValue() = player.getSymbol() And board(l - 3, c - 3).getCellValue() = player.getSymbol() Then
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

        Public Function checkDraw(board(,) As cell) As Boolean
            For i = 0 To _size(0)
                For j = 0 To _size(1)
                    If board(i, j).getCellValue() = " " Then
                        Return False
                    End If
                Next
            Next
            Return True
        End Function

        Public Function getYval(ByVal x As Integer) As Integer
            For i = _ArrOfCells.GetLength(0) - 1 To 0
                If _ArrOfCells(i, x).getCellValue() = " " Then
                    Return i
                End If
            Next
            Return False
        End Function

    End Class

    Class leaderBoard

    End Class

    Class game
        Private _leaderBoard As leaderBoard
        Private _listOfPlayer As List(Of Player)
        Private _currentBoard As board
        Private _currentPlayer As Player
        Private _currentPlayerIndex As Integer
        Private _listOfSymbols As List(Of String)
        Private _listOfColours As List(Of ConsoleColor)
        Private _noOfPlayers As Integer

        Public Sub New()
            _leaderBoard = New leaderBoard
            _listOfPlayer = New List(Of Player)
            _listOfColours = New List(Of ConsoleColor)
            _listOfSymbols = New List(Of String)
            initSymbols()
            initColours()
            _currentBoard = New board(initBoardSize())
            initPlayers()
            _currentPlayerIndex = 0
            _currentPlayer = _listOfPlayer(_currentPlayerIndex)
        End Sub

        Private Sub initColours()
            _listOfColours.Add(ConsoleColor.Blue)
            _listOfColours.Add(ConsoleColor.Green)
            _listOfColours.Add(ConsoleColor.Magenta)
            _listOfColours.Add(ConsoleColor.Red)
            _listOfColours.Add(ConsoleColor.Yellow)
        End Sub

        Private Sub initSymbols()
            _listOfSymbols.Add("X")
            _listOfSymbols.Add("O")
            _listOfSymbols.Add("Y")
            _listOfSymbols.Add("G")
            _listOfSymbols.Add("R")
        End Sub

        Private Sub initPlayers()
            Console.WriteLine("How many players would you like?:")
            _noOfPlayers = Integer.Parse(Console.ReadLine()) - 1

            For i = 0 To _noOfPlayers
                Dim nplayer As New Player(_listOfSymbols(i), _listOfColours(i))
                _listOfPlayer.Add(nplayer)
            Next
        End Sub

        Private Function initBoardSize() As Integer()
            Console.WriteLine("Enter a row, col in : row,col form")
            Dim xy() As String = Console.ReadLine().Split(","c)
            Dim x As Integer = Integer.Parse(xy(1))
            Dim y As Integer = Integer.Parse(xy(0))
            Return {x, y}
        End Function

        Public Sub outputBoard()
            _currentBoard.outputBoard()
        End Sub

        Public Function checkWin() As Boolean
            Return _currentBoard.checkWin(_currentPlayer, _currentBoard.getBoard())
        End Function

        Public Function checkDraw() As Boolean
            Return _currentBoard.checkDraw(_currentBoard.getBoard())
        End Function

        Public Sub turn()
            Dim x As Integer = _currentPlayer.turn()
            _currentBoard.ChangeCell(_currentPlayer.getSymbol(), _currentBoard.getYval(x) - 1, x, _currentPlayer.getColour())
            changeTurn()
            outputBoard()
        End Sub

        Public Sub changeTurn()
            If _currentPlayerIndex = -_noOfPlayers Then
                _currentPlayerIndex = 0
            Else
                _currentPlayerIndex += 1
            End If
            _currentPlayer = _listOfPlayer(_currentPlayerIndex)
        End Sub


    End Class

    Sub Main(args As String())
        Dim mygame As New game
        mygame.outputBoard()
        mygame.turn()
        Console.ReadLine()
    End Sub

End Module