Imports System

Module Program

    Class playingCard

        Private _intSuit As Integer
        Private _intValue As Integer
        Private _strSuit As String
        Private _strValue As String

        Public Function getIntSuit()
            Return Me._intSuit
        End Function
        Public Function getIntValue()
            Return Me._intValue
        End Function
        Public Function getStrSuit()
            Return Me._strSuit
        End Function
        Public Function getStrValue()
            Return Me._strValue
        End Function

        Public Sub New(S As Integer, iv As Integer, sS As String, sV As String)
            _intSuit = S
            _intValue = iv
            _strSuit = sS
            _strValue = sV
        End Sub


    End Class

    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        Dim cards As List(Of playingCard) = New List(Of playingCard)
        Dim suits() As String = {"diamonds", "hearts", "spades", "clubs"}

        For i As Integer = 1 To 4
            For j As Integer = 1 To 13
                If j = 11 Then
                    cards.Add(New playingCard(i, j, suits(i - 1), "Jack"))
                ElseIf j = 12 Then
                    cards.Add(New playingCard(i, j, suits(i - 1), "Queen"))
                ElseIf j = 13 Then
                    cards.Add(New playingCard(i, j, suits(i - 1), "King"))
                ElseIf j = 1 Then
                    cards.Add(New playingCard(i, j, suits(i - 1), "Ace"))
                Else
                    cards.Add(New playingCard(i, j, suits(i - 1), j.ToString()))
                End If
            Next
        Next

        For i = 0 To 51
            Console.WriteLine(cards(i).getIntSuit())
            Console.WriteLine(cards(i).getIntValue())
            Console.WriteLine(cards(i).getStrSuit())
            Console.WriteLine(cards(i).getStrValue())
            Console.WriteLine()
        Next


    End Sub
End Module
