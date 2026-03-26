'Skeleton Program code for the AQA A Level Paper 1 Summer 2024 examination
'this code should be used in conjunction with the Preliminary Material
'written by the AQA Programmer Team
'developed in the Visual Studio Community Edition programming environment

Imports System.IO
Imports Microsoft.Win32

Module Module1

    Dim Rng As New Random

    Sub Main()
        Dim Again As String = "y"
        Dim Score As Integer
        While Again = "y"
            Console.WriteLine("(1) two player")
            Console.WriteLine("(2) single player")
            Dim c As String = Console.ReadLine()
            If c = "1" Then
                Console.WriteLine("Player 1 symbol = Q, enter player 1 Name:")
                c = Console.ReadLine()
                Dim player1 As Player = New Player(c, "Q")

                Console.WriteLine("Player 2 symbol = X, enter player 2 Name:")
                c = Console.ReadLine()
                Dim player2 As Player = New Player(c, "Q")

                Dim puzzle As TwoPlayerPuzzle = New TwoPlayerPuzzle(8, Int(8 * 8 * 0.6), player1, player2)
                puzzle.AttemptPuzzle()

            Else
                Console.Write("Press Enter to start a standard puzzle or enter name of file to load: ")
                Dim Filename As String = Console.ReadLine()
                Dim MyPuzzle As Puzzle
                If Filename.Length > 0 Then
                    MyPuzzle = New Puzzle(Filename & ".txt")
                Else
                    MyPuzzle = New Puzzle(8, Int(8 * 8 * 0.6))
                End If
                Score = MyPuzzle.AttemptPuzzle()
                Console.WriteLine("Puzzle finished. Your score was: " & Score)
            End If

            Console.Write("Do another puzzle? ")
            Again = Console.ReadLine().ToLower()
        End While
        Console.ReadLine()
    End Sub

    Class TwoPlayerPuzzle
        Inherits Puzzle
        Private _player1 As Player
        Private _player2 As Player
        Private _currentPlayer As Player
        Sub New(ByVal Size As Integer, ByVal StartSymbols As Integer, ByVal player1 As Player, ByVal player2 As Player)
            MyBase.New(Size, StartSymbols)
            _player1 = player1
            _player2 = player2
        End Sub

        Public Overrides Function AttemptPuzzle() As Integer
            Dim Finished As Boolean = False
            changeTurn()
            While Not Finished
                changeTurn()
                DisplayPuzzle()
                Dim Valid As Boolean = False
                Dim Row As Integer = -1
                While Not Valid
                    Console.WriteLine(_currentPlayer.getName() + " 's turn.")
                    Console.Write("Enter row number: ")
                    Try
                        Row = Console.ReadLine()
                        Valid = True
                    Catch
                    End Try
                End While
                Dim Column As Integer = -1
                Valid = False
                While Not Valid
                    Console.Write("Enter column number: ")
                    Try
                        Column = Console.ReadLine()
                        Valid = True
                    Catch
                    End Try
                End While
                Dim Symbol As String = GetSymbolFromUser()
                SymbolsLeft -= 1
                Dim CurrentCell As Cell = GetCell(Row, Column)
                If Symbol = "B" And CurrentCell.CheckSymbolAllowed("@") = False Then
                    Dim celly As Integer = GetIndexOfCell(Row, Column)
                    MyBase.Grid(celly) = New Cell()
                ElseIf CurrentCell.CheckSymbolAllowed(Symbol) Then
                    CurrentCell.ChangeSymbolInCell(Symbol)
                    Dim AmountToAddToScore As Integer = CheckForMatchWithPattern(Row, Column)
                    If AmountToAddToScore > 0 Then
                        _currentPlayer.incrementScore(AmountToAddToScore)
                    End If
                End If
                If SymbolsLeft = 0 Then
                    Finished = True
                End If
            End While
            Console.WriteLine()
            DisplayPuzzle()
            If _player1.getScore() > _player2.getScore() Then
                _currentPlayer = _player1
            ElseIf _player1.getScore() < _player2.getScore() Then
                _currentPlayer = _player2
            Else
                Return 0
            End If
            Console.WriteLine("Winner:" + _currentPlayer.getName())
            Return _currentPlayer.getScore()
        End Function

        Sub changeTurn()
            If _currentPlayer.getSymbol() = "Q" Then
                _currentPlayer = _player2
            Else
                _currentPlayer = _player1
            End If
        End Sub
    End Class

    Class Puzzle
        Private Score As Integer
        Protected SymbolsLeft As Integer
        Private GridSize As Integer
        Protected Grid As List(Of Cell)
        Private AllowedPatterns As List(Of Pattern)
        Private AllowedSymbols As List(Of String)

        Sub New(ByVal Filename As String)
            Grid = New List(Of Cell)
            AllowedPatterns = New List(Of Pattern)
            AllowedSymbols = New List(Of String)
            AllowedSymbols.Add("B")
            LoadPuzzle(Filename)
        End Sub

        Sub New(ByVal Size As Integer, ByVal StartSymbols As Integer)
            Score = 0
            SymbolsLeft = StartSymbols
            GridSize = Size
            Grid = New List(Of Cell)
            For Count = 1 To GridSize * GridSize
                Dim C As Cell
                If Rng.Next(1, 101) < 90 Then
                    C = New Cell()
                Else
                    C = New BlockedCell()
                End If
                Grid.Add(C)
            Next
            AllowedPatterns = New List(Of Pattern)
            AllowedSymbols = New List(Of String)
            Dim QPattern As Pattern = New Pattern("Q", "QQ**Q**QQ")
            AllowedPatterns.Add(QPattern)
            AllowedSymbols.Add("Q")
            Dim XPattern As Pattern = New Pattern("X", "X*X*X*X*X")
            AllowedPatterns.Add(XPattern)
            AllowedSymbols.Add("X")
            Dim TPattern As Pattern = New Pattern("T", "TTT**T**T")
            AllowedPatterns.Add(TPattern)
            AllowedSymbols.Add("T")
            AllowedSymbols.Add("B")
        End Sub


        Protected Function GetIndexOfCell(ByVal Row As Integer, ByVal Column As Integer) As Integer
            Return ((GridSize - Row) * GridSize + Column - 1)
        End Function

        Private Sub LoadPuzzle(ByVal Filename As String)
            Try
                Using MyStream As New StreamReader(Filename)
                    Dim NoOfSymbols As Integer = MyStream.ReadLine()
                    For Count = 1 To NoOfSymbols
                        AllowedSymbols.Add(MyStream.ReadLine())
                    Next
                    Dim NoOfPatterns As Integer = MyStream.ReadLine()
                    For Count = 1 To NoOfPatterns
                        Dim Items As List(Of String) = MyStream.ReadLine().Split(",").ToList()
                        Dim P As Pattern = New Pattern(Items(0), Items(1))
                        AllowedPatterns.Add(P)
                    Next
                    GridSize = Convert.ToInt32(MyStream.ReadLine())
                    For Count = 1 To GridSize * GridSize
                        Dim C As Cell
                        Dim Items As List(Of String) = MyStream.ReadLine().Split(",").ToList()
                        If Items(0) = "@" Then
                            C = New BlockedCell()
                        Else
                            C = New Cell()
                            C.ChangeSymbolInCell(Items(0))
                            For CurrentSymbol = 1 To Items.Count - 1
                                C.AddToNotAllowedSymbols(Items(CurrentSymbol))
                            Next
                        End If
                        Grid.Add(C)
                    Next
                    Score = MyStream.ReadLine()
                    SymbolsLeft = MyStream.ReadLine()
                End Using
            Catch
                Console.WriteLine("Puzzle not loaded")
            End Try
        End Sub

        Public Overridable Function AttemptPuzzle() As Integer
            Dim Finished As Boolean = False
            While Not Finished
                DisplayPuzzle()
                Console.WriteLine("Current score: " & Score)
                Dim Valid As Boolean = False
                Dim Row As Integer = -1
                While Not Valid
                    Console.Write("Enter row number: ")
                    Try
                        Row = Console.ReadLine()
                        Valid = True
                    Catch
                    End Try
                End While
                Dim Column As Integer = -1
                Valid = False
                While Not Valid
                    Console.Write("Enter column number: ")
                    Try
                        Column = Console.ReadLine()
                        Valid = True
                    Catch
                    End Try
                End While
                Dim Symbol As String = GetSymbolFromUser()
                SymbolsLeft -= 1
                Dim CurrentCell As Cell = GetCell(Row, Column)
                If Symbol = "B" And CurrentCell.CheckSymbolAllowed("@") = False Then
                    Dim celly As Integer = GetIndexOfCell(Row, Column)
                    Grid(celly) = New Cell()
                ElseIf CurrentCell.CheckSymbolAllowed(Symbol) Then
                    CurrentCell.ChangeSymbolInCell(Symbol)
                    Dim AmountToAddToScore As Integer = CheckForMatchWithPattern(Row, Column)
                    If AmountToAddToScore > 0 Then
                        Score += AmountToAddToScore
                    End If
                End If
                If SymbolsLeft = 0 Then
                    Finished = True
                End If
            End While
            Console.WriteLine()
            DisplayPuzzle()
            Console.WriteLine()
            Return Score
        End Function

        Protected Overridable Function GetCell(ByVal Row As Integer, ByVal Column As Integer) As Cell
            Return Grid((GridSize - Row) * GridSize + Column - 1)
        End Function

        Public Overridable Function CheckForMatchWithPattern(ByVal Row As Integer, ByVal Column As Integer) As Integer
            For StartRow = Row + 2 To Row Step -1
                For StartColumn = Column - 2 To Column
                    Try
                        Dim PatternString As String = ""
                        PatternString &= GetCell(StartRow, StartColumn).GetSymbol()
                        PatternString &= GetCell(StartRow, StartColumn + 1).GetSymbol()
                        PatternString &= GetCell(StartRow, StartColumn + 2).GetSymbol()
                        PatternString &= GetCell(StartRow - 1, StartColumn + 2).GetSymbol()
                        PatternString &= GetCell(StartRow - 2, StartColumn + 2).GetSymbol()
                        PatternString &= GetCell(StartRow - 2, StartColumn + 1).GetSymbol()
                        PatternString &= GetCell(StartRow - 2, StartColumn).GetSymbol()
                        PatternString &= GetCell(StartRow - 1, StartColumn).GetSymbol()
                        PatternString &= GetCell(StartRow - 1, StartColumn + 1).GetSymbol()
                        For Each P In AllowedPatterns
                            Dim CurrentSymbol As String = GetCell(Row, Column).GetSymbol()
                            If P.MatchesPattern(PatternString, CurrentSymbol) Then
                                GetCell(StartRow, StartColumn).AddToNotAllowedSymbols(CurrentSymbol)
                                GetCell(StartRow, StartColumn + 1).AddToNotAllowedSymbols(CurrentSymbol)
                                GetCell(StartRow, StartColumn + 2).AddToNotAllowedSymbols(CurrentSymbol)
                                GetCell(StartRow - 1, StartColumn + 2).AddToNotAllowedSymbols(CurrentSymbol)
                                GetCell(StartRow - 2, StartColumn + 2).AddToNotAllowedSymbols(CurrentSymbol)
                                GetCell(StartRow - 2, StartColumn + 1).AddToNotAllowedSymbols(CurrentSymbol)
                                GetCell(StartRow - 2, StartColumn).AddToNotAllowedSymbols(CurrentSymbol)
                                GetCell(StartRow - 1, StartColumn).AddToNotAllowedSymbols(CurrentSymbol)
                                GetCell(StartRow - 1, StartColumn + 1).AddToNotAllowedSymbols(CurrentSymbol)
                                Return 10
                            End If
                        Next
                    Catch
                    End Try
                Next
            Next
            Return 0
        End Function

        Protected Overridable Function GetSymbolFromUser() As String
            Dim Symbol As String = ""
            While Not AllowedSymbols.Contains(Symbol)
                Console.Write("Enter symbol: ")
                Symbol = Console.ReadLine()
            End While
            Return Symbol
        End Function

        Private Function CreateHorizontalLine() As String
            Dim Line As String = "  "
            For Count = 1 To GridSize * 2 + 1
                Line = Line & "-"
            Next
            Return Line
        End Function

        Public Overridable Sub DisplayPuzzle()
            Console.WriteLine()
            If GridSize < 10 Then
                Console.Write("  ")
                For Count = 1 To GridSize
                    Console.Write(" " & Count)
                Next
            End If
            Console.WriteLine()
            Console.WriteLine(CreateHorizontalLine())
            For Count = 0 To Grid.Count() - 1
                If Count Mod GridSize = 0 And GridSize < 10 Then
                    Console.Write((GridSize - ((Count + 1) \ GridSize)) & " ")
                End If
                Console.Write("|" & Grid(Count).GetSymbol())
                If (Count + 1) Mod GridSize = 0 Then
                    Console.WriteLine("|")
                    Console.WriteLine(CreateHorizontalLine())
                End If
            Next
        End Sub
    End Class

    Class Pattern
        Private Symbol As String
        Private PatternSequence As String

        Sub New(ByVal SymbolToUse As String, ByVal PatternString As String)
            Symbol = SymbolToUse
            PatternSequence = PatternString
        End Sub

        Public Overridable Function MatchesPattern(ByVal PatternString As String, ByVal SymbolPlaced As String) As Boolean
            If SymbolPlaced <> Symbol Then
                Return False
            End If
            For Count = 0 To PatternSequence.Length - 1
                If PatternSequence(Count) = Symbol And PatternString(Count) <> Symbol Then
                    Return False
                End If
            Next
            Return True
        End Function

        Public Overridable Function GetPatternSequence() As String
            Return PatternSequence
        End Function
    End Class

    Class Cell
        Protected Symbol As String
        Private SymbolsNotAllowed As List(Of String)

        Sub New()
            Symbol = ""
            SymbolsNotAllowed = New List(Of String)
        End Sub

        Public Overridable Function GetSymbol() As String
            If IsEmpty() Then
                Return "-"
            Else
                Return Symbol
            End If
        End Function

        Public Function IsEmpty() As Boolean
            If Symbol.Length = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub ChangeSymbolInCell(ByVal NewSymbol As String)
            Symbol = NewSymbol
        End Sub

        Public Overridable Function CheckSymbolAllowed(ByVal SymbolToCheck As String) As Boolean
            For Each Item In SymbolsNotAllowed
                If Item = SymbolToCheck Then
                    Return False
                End If
            Next
            Return True
        End Function

        Public Overridable Sub AddToNotAllowedSymbols(ByVal SymbolToAdd As String)
            SymbolsNotAllowed.Add(SymbolToAdd)
        End Sub

        Public Overridable Sub UpdateCell()
        End Sub
    End Class

    Class BlockedCell
        Inherits Cell

        Sub New()
            MyBase.New()
            Symbol = "@"
        End Sub

        Public Overrides Function CheckSymbolAllowed(ByVal SymbolToCheck As String) As Boolean
            Return False
        End Function
    End Class

    Class Player
        Private _name As String
        Private _score As Integer
        Private _symbol As String

        Public Sub New(n As String, s As String)
            _score = 0
            _name = n
            _symbol = s
        End Sub

        Public Function getName() As String
            Return _name
        End Function

        Public Function getScore() As Integer
            Return _score
        End Function

        Public Function getSymbol() As String
            Return _symbol
        End Function
        Public Sub incrementScore(n As Integer)
            _score += n
        End Sub
    End Class
End Module