Imports System

Module Program
    Sub Main(args As String())
        Dim translatorDict As New Dictionary(Of String, String)
        Dim sentenceToTranslate As String
        Dim englishOrGerman As Boolean
        Dim choice As String
        Dim newSentence As String
        getLangDict(translatorDict)

        Console.WriteLine("Enter sentence to be translated:")
        sentenceToTranslate = LCase(Console.ReadLine())
        Console.WriteLine("English to german (1) or german to english (2)?:")
        choice = Console.ReadLine()
        If choice = "1" Then
            englishOrGerman = True
        Else
            englishOrGerman = False
        End If

        newSentence = getNewSentence(getTranslatedWords(englishOrGerman, getArrayOfWords(sentenceToTranslate, getWordCount(sentenceToTranslate)), translatorDict))
        Console.WriteLine(newSentence)
    End Sub

    Function getNewSentence(words() As String) As String
        Dim newSentence As String
        For i = 0 To words.Length - 1
            newSentence += words(i)
            newSentence += " "
        Next
        Return newSentence
    End Function

    Function getTranslatedWords(ByVal englishOrGerman, ByVal words(), ByRef translatorDict) As String()
        Dim newArray(words.Length) As String
        If englishOrGerman Then
            For i = 0 To words.Length
                If translatorDict.ContainsKey(words(i)) Then
                    newArray(i) = translatorDict(words(i))
                Else
                    Console.WriteLine("word:" & words(i) & " not found, enter a suitable translation for the word as a single word.")
                    translatorDict.add(words(i), LCase(Console.ReadLine()))
                    newArray(i) = translatorDict(words(i))
                End If
            Next
        Else
            For i = 0 To words.Length
                If translatorDict.ContainsValue(words(i)) Then
                    For Each kvp As KeyValuePair(Of String, String) In translatorDict
                        If kvp.Value = words(i) Then
                            newArray(i) = kvp.Key
                        End If
                    Next
                Else
                    Console.WriteLine("word:" & words(i) & " not found, enter a suitable translation for the word as a single word.")
                    translatorDict.add(words(i), LCase(Console.ReadLine()))
                    For Each kvp As KeyValuePair(Of String, String) In translatorDict
                        If kvp.Value = words(i) Then
                            newArray(i) = kvp.Key
                        End If
                    Next
                End If
            Next
        End If
        Return newArray
    End Function

    Function getArrayOfWords(sentence As String, count As Integer) As String()
        Dim arrayOfWords(count) As String
        arrayOfWords = sentence.Replace(".", "").Split(" ")
        Return arrayOfWords
    End Function

    Function getWordCount(sentence As String) As Integer
        Dim count As Integer = 0
        For Each c In sentence
            If c = " " Then
                count += 1
            End If
        Next
        Return count
    End Function

    Sub getLangDict(ByRef englishToGerman)

        englishToGerman.Add("water", "wasser")
        englishToGerman.Add("dog", "hund")
        englishToGerman.Add("house", "haus")
        englishToGerman.Add("vielleicht", "possibly")
        englishToGerman.Add("and", "und")
        englishToGerman.Add("the", "die")
        englishToGerman.Add("there", "gibt")
        englishToGerman.Add("is", "es")

    End Sub
End Module
