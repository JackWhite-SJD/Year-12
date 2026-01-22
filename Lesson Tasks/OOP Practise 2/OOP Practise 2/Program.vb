Imports System

Module Program

    Class Player
        Private _name As String
        Private _symbol As String
        Private _score As Integer
        Private _colour As ConsoleColor

        Public Sub New(ByVal symbol As String, ByVal colour As ConsoleColor)
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

        Private Function setName()
            Console.WriteLine("Enter Name:")
            Return Console.ReadLine()
        End Function

        Public Function turn() As Integer()
            Console.WriteLine("Enter a row, col in : row,col form")
            Dim xy() As String = Console.ReadLine().Split(",")
            Dim x As Integer = xy(1)
            Dim y As Integer = xy(0)
            Return {x, y}
        End Function

    End Class

    Class cell
        Private _value As String
        Public Sub New()
            _value = " "
        End Sub

        Public Sub updateCell(value)
            _value = value
        End Sub

        Public Function getCellValue() As String
            Return _value
        End Function
    End Class

    Class board
        Private _size() As Integer
        Private _ArrOfCells(,) As cell

        Public Sub New(size() As Integer)
            _size = size
            _ArrOfCells = generateBaord(_size(1), _size(0))

        End Sub

        Public Function generateBaord(ByVal x As Integer, ByVal y As Integer) As cell(,)
            Dim board(y, x) As cell
            For i = 0 To y
                For j = 0 To x
                    Dim newCell As New cell
                    board(y, x) = newCell
                Next
            Next
            Return board
        End Function


        Public Sub ChangeCell(symbol As String, y As Integer, x As Integer)
            _ArrOfCells(y - 1, x - 1).updateCell(symbol)
        End Sub
        Public Function getBoard() As cell(,)
            Return _ArrOfCells
        End Function

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
            _currentBoard = New board(initBoardSize)
            initSymbols()
            initColours()
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

        Public Sub initPlayers()
            Dim noOfPlayers As Integer
            Console.WriteLine("How many players would you like?:")
            noOfPlayers = Integer.Parse(Console.ReadLine())

            For i = 0 To noOfPlayers
                Dim nplayer As New Player(_listOfSymbols(i), _listOfColours(i))
                _listOfPlayer.Add(nplayer)
            Next
        End Sub

        Private Function initBoardSize()
            Console.WriteLine("Enter a row, col in : row,col form")
            Dim xy() As String = Console.ReadLine().Split(",")
            Dim x As Integer = xy(1)
            Dim y As Integer = xy(0)
            Return {x, y}
        End Function

    End Class

    Sub Main(args As String())
        Console.WriteLine("Hello World!")
    End Sub
End Module