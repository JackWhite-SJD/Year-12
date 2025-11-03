Imports System

Module Program
    Sub Main(args As String())
        Dim chioces(,) As String = getStrings()
        Dim guesses As Integer = 3

        If turn(chioces, guesses) Then
            Console.WriteLine("Win")
        Else
            Console.WriteLine("Loss")
        End If



    End Sub

    Function getStrings() As String(,)
        Dim rnd As New Random
        Dim randomPos As Integer = rnd.Next(0, 11)
        Dim choices(1, 12) As String

        'assigns the word tomato to a random position in choices
        'fills non tomato position with not a tomato
        For i = 0 To 12
            If i = randomPos Then
                choices(0, i) = "tomato"
            Else
                choices(0, i) = "not a tomato"
            End If

            choices(1, i) = " "
        Next

        choices(1, 0) = randomPos.ToString()

        Return choices
    End Function

    Function turn(choices(,) As String, guesses As Integer) As Boolean
        Dim choice As Integer = 0
        Dim pos As Integer = Integer.Parse(choices(1, 0))
        Dim newChoices(1, 12) As String
        Dim checker As Boolean
        newChoices(1, 0) = choices(1, 0)

        Console.WriteLine("What position in the array is the tomato, array length: " & (choices.Length() / 2))
        choice = Integer.Parse(Console.ReadLine())

        If guesses = 0 Then
            Return False
        ElseIf choice = pos Then
            Return True
        End If

        Select Case choice
            Case choice > pos
                For i = 0 To choice
                    newChoices(0, i) = choices(0, i)
                Next
                Console.WriteLine("Too high")
                guesses -= 1
                checker = turn(newChoices, guesses)
            Case choice < pos
                For i = choice + 1 To 12
                    newChoices(0, i) = choices(0, i)
                Next
                Console.WriteLine("Too low")
                guesses -= 1
                checker = turn(newChoices, guesses)
        End Select

    End Function
End Module
