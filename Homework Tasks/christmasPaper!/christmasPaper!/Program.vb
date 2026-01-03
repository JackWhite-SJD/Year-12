Imports System

Module Program
    Sub Main(args As String())
        Dim PlayerOneScore As Integer = 0
        Dim PlayerTwoScore As Integer = 0
        Console.WriteLine("How many games?")
        Dim NoOfGamesInMatch As Integer = Console.ReadLine()
        For NoOfGamesPlayed = 1 To NoOfGamesInMatch
            Console.WriteLine("Did Player One win the game (enter Y or N)?")
            Dim PlayerOneWinsGame As String = Console.ReadLine()
            If PlayerOneWinsGame = "Y" Then
                PlayerOneScore = PlayerOneScore + 1
            Else
                PlayerTwoScore = PlayerTwoScore + 1
            End If
        Next
        Console.WriteLine(PlayerOneScore)
        Console.WriteLine(PlayerTwoScore)
    End Sub
End Module
