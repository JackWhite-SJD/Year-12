Imports System
Imports System.Net.Http.Headers

Module Program
    Sub Main(args As String())
        Dim name As String
        Dim player1 As player
        Dim player2 As player
        Dim board As New Board
        Dim currentPlayer As player

        Console.WriteLine("Enter player 1's name:")
        name = Console.ReadLine()
        player1 = New player(name, "O")

        Console.WriteLine("Enter player 2's name:")
        name = Console.ReadLine()
        player2 = New player(name, "X")

        currentPlayer = player1

        While True
            If board.checkWin(currentPlayer) Then

            End If
        End While
    End Sub
    Class Board
        Private _Board(,) As cell

        Sub New()
            _initializeBoard()
        End Sub

        Private Sub _initializeBoard()
            For i = 0 To 2
                For j = 0 To 2
                    _Board(i, j) = New cell(" ", 0)
                Next
            Next
        End Sub

        Public Sub updateCell(i As Integer, j As Integer, p As player)
            If checkValidCell(i, j) Then
                _Board(i, j).updateCell(p.getName(), p.getSymbol)
            End If
        End Sub

        Public Function checkValidCell(i As Integer, j As Integer)
            If _Board(i, j).getValue() = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function checkWin(p As player) As Boolean
            For i = 0 To 2
                If _Board(i, 0).getSymbol = p.getName() And _Board(i, 1).getSymbol = p.getName() And _Board(i, 2).getSymbol = p.getName() Then
                    Return True
                ElseIf _Board(0, i).getSymbol = p.getName() And _Board(1, i).getSymbol = p.getName() And _Board(2, i).getSymbol = p.getName() Then
                    Return True
                End If
            Next

            If _Board(0, 0).getSymbol = p.getName() And _Board(1, 1).getSymbol = p.getName() And _Board(2, 2).getSymbol = p.getName() Then
                Return True
            End If
            If _Board(0, 2).getSymbol = p.getName() And _Board(1, 1).getSymbol = p.getName() And _Board(2, 0).getSymbol = p.getName() Then
                Return True
            End If

            Return False
        End Function

    End Class


    Class player
        Private _Name As String
        Private _Symbol As String
        Public Sub New(name As String, symbol As String)
            _Name = name
            _Symbol = symbol
        End Sub

        Public Function getName()
            Return _Name
        End Function

        Public Function getSymbol()
            Return _Symbol
        End Function

        Public Function turn() As Integer()
            Console.WriteLine("Enter x coord:")
            Dim x As Integer = Integer.Parse(Console.ReadLine())
            Console.WriteLine("Enter y coord:")
            Dim y As Integer = Integer.Parse(Console.ReadLine())

            Return {x, y}
        End Function

    End Class

    Class cell
        Private _value As String
        Private _symbol As Integer
        Sub New(v As String, s As Integer)
            _value = v
            _symbol = s
        End Sub

        Public Sub updateCell(v As String, s As Integer)
            _value = v
            _symbol = s
        End Sub

        Public Function getSymbol()
            Return _symbol
        End Function

        Public Function getValue()
            Return _value
        End Function
    End Class

End Module
