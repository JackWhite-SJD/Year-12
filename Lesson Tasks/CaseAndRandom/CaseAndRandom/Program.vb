Module Program
    Sub Main(args As String())

        Dim countOne As Integer = 0
        Dim indexer As Integer = 0
        While indexer < 10000000
            If game() Then
                countOne += 1
            End If
            indexer += 1
        End While
        Console.WriteLine("  ")
        Console.WriteLine(countOne)
    End Sub

    Function game() As Boolean
        Dim money As Decimal = 1
        Dim rnd As New Random
        Dim choice As String
        Dim roll As Integer
        Dim debt As Decimal

        Dim indexer As Integer = 1



        While indexer < 1000
            'Console.WriteLine("Would you like to role the dice?:")
            'choice = LCase(Console.ReadLine()).Substring(0, 1)
            'If choice = "n" Then
            '    Exit While
            'End If

            If money > 1000000000 Or debt > 10000000000 Then
                Exit While
            End If

            roll = rnd.Next(1, 6)
            'Console.WriteLine("You rolled a " & roll)

            Select Case roll
                Case 1
                    money = 0
                    'Console.WriteLine("You have lost all of your money, would you like a loan of £1?:")
                    'choice = LCase(Console.ReadLine()).Substring(0, 1)
                    'If choice = "n" Then
                    '    Exit While
                    'End If
                    debt += 1
                    money += 1
                    'Console.WriteLine("debt:" & debt)
                Case 2
                    money /= 10
                    money *= 13
                Case 3
                    money *= 10
                    money /= 13
                Case 4
                    money += (Math.Round(debt * 1.5, 2) / money)
                Case 5, 6
                    money *= 2
            End Select
            debt = Math.Round(debt * 1.5, 2)
            money = Math.Round(money, 2)
            'Console.WriteLine("debt:" & debt)
            'Console.WriteLine("money:" & money)

        End While

        'Console.WriteLine("Winnings:£" & money - debt)

        If money - debt = 1.0 Then
            Return True
        End If
    End Function
End Module

