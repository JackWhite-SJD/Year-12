Imports System

Module Program

    Class Player
        Private _name As String
        Private _symbol As String
        Private _score As Integer

        Public Sub New(ByVal name As String, ByVal symbol As String)
            _name = name
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

        Public Function getBoard() As cell(,)
            Return _ArrOfCells
        End Function

    End Class

    Class leaderBoard

    End Class
    Class game
        Private _leaderBoard As leaderBoard
        Private _arrOfPlayers() As Player
        Private _currentBoard As board
        Private _currentPlayer As Player


    End Class

    Sub Main(args As String())
        Console.WriteLine("Hello World!")
    End Sub
End Module