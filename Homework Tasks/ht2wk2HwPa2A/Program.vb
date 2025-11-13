Imports System
Imports System.Security.Cryptography

Module Program
    Sub Main(args As String())
        Dim grades() As Integer = getStudents()
        Console.WriteLine("Enter Passmark:")
        Dim PassMark = Integer.Parse(Console.ReadLine())
        Console.WriteLine("Average grade:" & getAvg(grades))
        outputPass(grades, PassMark)

    End Sub

    Function getStudents() As Integer()
        Dim numStudents As Integer
        Dim grade As Integer

        Console.WriteLine("Hown many students in the class?:")
        numStudents = Integer.Parse(Console.ReadLine())

        Dim grades(numStudents - 1) As Integer

        For i = 0 To numStudents - 1
            While True
                Console.WriteLine("Enter grade of student  " & i + 1 & ":")
                grade = Integer.Parse(Console.ReadLine)

                If grade < 0 Or grade > 100 Then
                    Console.WriteLine("Grade not in range, try again.")
                    Continue While
                Else
                    Exit While
                End If
            End While
            grades(i) = grade
        Next

        Return grades

    End Function

    Function getAvg(grades() As Integer) As Integer
        Dim TotalMark As Integer

        For i = 0 To grades.Length() - 1
            TotalMark += grades(i)
        Next

        Return Integer.Parse(Math.Round(TotalMark / 5, 0))
    End Function

    Sub outputPass(grades() As Integer, passMark As Integer)
        Dim retateStudents As Integer

        For i = 0 To grades.Length() - 1
            If grades(i) < passMark Then
                retateStudents += 1
                Console.WriteLine("Student " & i + 1 & " fails.")
            Else
                Console.WriteLine("Student " & i + 1 & " passess.")
            End If
        Next

        Console.WriteLine("Number of students needed to retake: " & retateStudents)

    End Sub

End Module
