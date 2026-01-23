Imports System
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

        Private Function setName() As String
            Console.WriteLine("Enter Name:")
            Return Console.ReadLine()
        End Function

        Public Function turn() As Integer()
            Console.WriteLine("Enter a row, col in : col,row form")
            Dim xy() As String = Console.ReadLine().Split(","c)
            Dim x As Integer = Integer.Parse(xy(1))
            Dim y As Integer = Integer.Parse(xy(0))
            Return {x, y}
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

    End Class

    Class leaderBoard

    End Class

    Class game
        Private _leaderBoard As leaderBoard
        Private _listOfPlayer As List(Of Player)
        Private _currentBoard As board
        Private _currentPlayer As Player
        Private _listOfSymbols As List(Of String)
        Private _listOfColours As List(Of ConsoleColor)

        Public Sub New()
            _leaderBoard = New leaderBoard
            _listOfPlayer = New List(Of Player)
            _listOfColours = New List(Of ConsoleColor)
            _listOfSymbols = New List(Of String)
            initSymbols()
            initColours()
            _currentBoard = New board(initBoardSize())
            initPlayers()
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
            Dim noOfPlayers As Integer
            Console.WriteLine("How many players would you like?:")
            noOfPlayers = Integer.Parse(Console.ReadLine())

            For i = 0 To noOfPlayers - 1
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

    End Class

    Sub Main(args As String())
        Dim mygame As New game
        mygame.outputBoard()
        Console.ReadLine()
    End Sub

End Module