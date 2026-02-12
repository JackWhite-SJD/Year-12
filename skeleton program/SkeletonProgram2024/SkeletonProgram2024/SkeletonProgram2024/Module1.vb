'Skeleton Program code for the AQA A Level Paper 1 Summer 2024 examination
'this code should be used in conjunction with the Preliminary Material
'written by the AQA Programmer Team
'developed in the Visual Studio Community Edition programming environment

Imports System.IO

Module Module1

    Dim Rng As New Random

    Sub Main()
        Dim Again As String = "y"
        Dim Score As Integer
        Dim MyPuzzle As Puzzle
        While Again = "y"
            Console.Write("Press Enter to start a standard puzzle, enter name of file to load or enter a numeric digit: ")
            Dim Filename As String = Console.ReadLine()
            Try
                Filename = Integer.Parse(Filename)
                MyPuzzle = New Puzzle(Filename, Int(Filename * Filename * 0.6))
            Catch ex As Exception
                If Filename.Length > 0 Then
                    MyPuzzle = New Puzzle(Filename & ".txt")
                Else
                    MyPuzzle = New Puzzle(8, Int(8 * 8 * 0.6))
                End If
            End Try

            Score = MyPuzzle.AttemptPuzzle()
            Console.WriteLine("Puzzle finished. Your score was: " & Score)
            Console.Write("Do another puzzle? ")
            Again = Console.ReadLine().ToLower()
        End While
        Console.ReadLine()
    End Sub

    Class Puzzle
        Private Score As Integer
        Private SymbolsLeft As Integer
        Private GridSize As Integer
        Private Grid As List(Of Cell)
        Private AllowedPatterns As List(Of Pattern)
        Private AllowedSymbols As List(Of String)



        'having multiple constructors is called overloading - same method name, different parameter lists.
        'enables different functionality by varing inputs/parameters
        'to overload regular subroutines, you must have an overloads keyword
        'overloading functionality is already built into the New sub
        Sub New(ByVal Filename As String)
            Grid = New List(Of Cell)
            AllowedPatterns = New List(Of Pattern)
            AllowedSymbols = New List(Of String)
            LoadPuzzle(Filename)
        End Sub

        Sub New(ByVal Size As Integer, ByVal StartSymbols As Integer)
            Score = 0
            SymbolsLeft = StartSymbols
            GridSize = Size
            Grid = New List(Of Cell)
            Dim difficulty As Integer = 1
            While True
                Console.WriteLine("Enter difficulty between 1 and 3 inclusive:")
                difficulty = Console.ReadLine()
                If difficulty > 0 And difficulty < 4 Then
                    Exit While
                End If
                Console.WriteLine("Invalid numeric input, please try again.")
            End While


            Select Case difficulty
                Case 1
                    difficulty = 90
                Case 2
                    difficulty = 75
                Case 3
                    difficulty = 60
            End Select

            For Count = 1 To GridSize * GridSize
                Dim C As Cell
                If Rng.Next(1, 101) < difficulty Then
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

            Dim HPattern As Pattern = New Pattern("H", "H*HHH*HHH")
            AllowedPatterns.Add(HPattern)
            AllowedSymbols.Add("H")
        End Sub

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
                        If Row > 0 And Row < 9 Then
                            Valid = True
                        End If

                    Catch
                    End Try
                End While
                Dim Column As Integer = -1
                Valid = False
                While Not Valid
                    Console.Write("Enter column number: ")
                    Try
                        Column = Console.ReadLine()
                        If Column < 9 And Column > 0 Then
                            Valid = True
                        End If
                    Catch
                    End Try
                End While
                Dim Symbol As String = GetSymbolFromUser()
                SymbolsLeft -= 1
                Dim CurrentCell As Cell = GetCell(Row, Column)
                If CurrentCell.CheckSymbolAllowed(Symbol) Then
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

        Private Function GetCell(ByVal Row As Integer, ByVal Column As Integer) As Cell
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
                                If CurrentSymbol = "H" Then
                                    Return 20
                                Else
                                    Return 10
                                End If
                            End If
                        Next
                    Catch
                    End Try
                Next
            Next
            Return 0
        End Function

        Private Function GetSymbolFromUser() As String
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
End Module