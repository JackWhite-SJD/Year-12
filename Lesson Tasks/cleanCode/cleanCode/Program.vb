Imports System
Imports System.Threading.Channels

Module Program
    Sub Main(args As String())
        Dim sentence() As String = {"The", "cat", "in", "the", "hat", "sat", "on", "the", "mat"}
        Console.WriteLine(GetSentenceVowellCount(sentence))
    End Sub

    Function GetSentenceVowellCount(sentence() As String) As Integer
        Dim count As Integer = 0

        For Each word As String In sentence
            count += GetWordVowellCount(word)
        Next

        Return count
    End Function

    Function GetWordVowellCount(word As String) As Integer
        Dim count As Integer = 0

        For Each c As Char In word
            If IsVowel(c) Then
                count += 1
            End If
        Next

        Return count
    End Function

    Function IsVowel(ByVal c As Char) As Boolean
        Dim vowels() As String = {"a", "e", "i", "o", "u"}

        If vowels.Contains(c.ToString().ToLower()) Then
            Return True
        End If

        Return False
    End Function
End Module