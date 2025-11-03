Imports System
Imports System.Data.SqlTypes

Module Program
    Sub Main(args As String())
        Dim money As Integer = 0
        Dim answer As String = " "



        Console.WriteLine("Q1:Who created the muppets?:")
        answer = LCase(Console.ReadLine())
        If answer = "jim henson" Then




    End Sub

    Function getQuetionsAndAnswers() As String(,)
        Dim questionPool() As String = {"Who created the muppets?:", "What is the chemical symbol for iron?:", "What year was the city of Constantinople renamed?:", "Who succeeded neville chamberlaind as prime minister?:"}
        Dim answerPool() As String = {"jim henson", "fe", "1923", "winston churchil"}
        Dim mcqPool() As String = {"How many times to the clockhands overlap each day?:", "What is the smallest prime number greater than 10?:", "In what year did the berlin wall fall?:", "What do plants many produce through photosynthesis?:"}
        Dim mcqAnswer() As String = {"22", "11", "23", "21", "11", "12", "13", "23", "1989", "1987", "1984", "1986", "glucose", "Water", "oxygen", "carbon dioxide"}


        Randomize()
        Dim questions(,) As String
        Dim q1 As Integer = Int((3 * Rnd()) + 0)
        questions(0, 1) = questionPool(q1)
        questionPool.

    End Function

End Module
