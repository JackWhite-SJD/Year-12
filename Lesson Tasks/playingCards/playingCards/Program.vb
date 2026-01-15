Imports System
Imports System.Globalization

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

        Public Sub New(S As Integer, iv As Integer)
            _intSuit = S
            _intValue = iv
            _strSuit = assaignSuit(S)
            _strValue = assaignCard(iv)
        End Sub

        Public Function assaignCard(card As Integer) As String
            Select Case card
                Case 11
                    Return "Jack"
                Case 12
                    Return "Queen"
                Case 13
                    Return "King"
                Case 1
                    Return "Ace"
                Case Else
                    Return card.ToString()
            End Select
        End Function

        Public Function assaignSuit(suit As Integer) As String
            Select Case suit
                Case 1
                    Return "Diamonds"
                Case 2
                    Return "Hearts"
                Case 3
                    Return "Spades"
                Case 4
                    Return "Clubs"
            End Select
        End Function

    End Class

    Class deck
        Private _remainingCards As List(Of playingCard)
        Private _decks As Integer

        Public Sub New(noDecks As Integer)
            _decks = noDecks
            createDeck(_decks)
        End Sub

        Public Sub createDeck(decks As Integer)
            For d = 1 To decks
                For i As Integer = 1 To 4
                    For j As Integer = 1 To 13
                        If j = 11 Then
                            _remainingCards.Add(New playingCard(i, j))
                        ElseIf j = 12 Then
                            _remainingCards.Add(New playingCard(i, j))
                        ElseIf j = 13 Then
                            _remainingCards.Add(New playingCard(i, j))
                        ElseIf j = 1 Then
                            _remainingCards.Add(New playingCard(i, j))
                        Else
                            _remainingCards.Add(New playingCard(i, j))
                        End If
                    Next
                Next
            Next

            _remainingCards = New List(Of playingCard)
        End Sub

        Private Function generateCard() As playingCard
            Dim rnd As Random = New Random
            Dim pos As Integer = rnd.Next(rnd.Next(0, Len(_remainingCards) - 1))
            Dim card As playingCard = _remainingCards(rnd.Next(pos))
            _remainingCards = removeElm(_remainingCards, pos, Len(_remainingCards) - 1)
            Return card
        End Function

        Private Function removeElm(lst As List(Of playingCard), elm As Integer, lengthOflist As Integer) As List(Of playingCard)
            Dim newlst As List(Of playingCard) = New List(Of playingCard)

            For i = 0 To lengthOflist
                If i <> elm Then
                    newlst.Add(_remainingCards(i))
                End If
            Next
            Return newlst
        End Function

        Public Function getDeck() As playingCard()
            Return {generateCard(), generateCard()}
        End Function

        Public Function hit() As playingCard
            Return generateCard()
        End Function

    End Class

    Class player
        Private _name As String
        Private _score As String
        Private _deck As List(Of playingCard)


        Public Sub New(noDecks As Integer, name As String)
            _deck = New List(Of playingCard)
            _name = name
            _score = 0
        End Sub

        Public Function getScore() As String
            Return _score
        End Function

        Public Sub incrementScore()
            _score += 1
        End Sub

        Public Sub setScore(score As Integer)
            _score = score
        End Sub

        Public Function getName() As String
            Return _name
        End Function

        Public Sub resetDeck()
            _deck = New List(Of playingCard)
        End Sub

        Public Sub newDeck(playingCardArr() As playingCard)
            _deck.Add(playingCardArr(0))
            _deck.Add(playingCardArr(1))
        End Sub

        Public Sub addCard(card As playingCard)
            _deck.Add(card)
        End Sub

    End Class

    Class game
        Private _players As List(Of player)
        Private _deck As deck
        Private _noOfPlayers As Integer
        Private _currentPlayer As Integer

        Public Sub New(noOfPlayers As Integer, noOfDecks As Integer)
            _deck = New deck(noOfDecks)
            _players = New List(Of player)
            _noOfPlayers = noOfPlayers - 1
            _currentPlayer = 0
        End Sub



    End Class

    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        Dim cards As List(Of playingCard) = New List(Of playingCard)
        Dim suits() As String = {"diamonds", "hearts", "spades", "clubs"}

        For i As Integer = 1 To 4
            For j As Integer = 1 To 13
                If j = 11 Then
                    cards.Add(New playingCard(i, j))
                ElseIf j = 12 Then
                    cards.Add(New playingCard(i, j))
                ElseIf j = 13 Then
                    cards.Add(New playingCard(i, j))
                ElseIf j = 1 Then
                    cards.Add(New playingCard(i, j))
                Else
                    cards.Add(New playingCard(i, j))
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
