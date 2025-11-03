Imports System
Imports System.ComponentModel.Design
Imports System.Linq.Expressions
Imports System.Reflection.Metadata.Ecma335
Imports System.Runtime.Serialization.Formatters

Module Program
    Sub Main(args As String())
        Dim name As String
        Dim subjects(3) As String
        Dim targetGrade As String
        Dim checkAge As Boolean
        Dim age As Integer
        Dim checkAgeChoice As String


        ' checks name
        While True
            Console.WriteLine("Enter your name:")
            name = Console.ReadLine()
            If Len(name) >= 1 And Len(name) < 15 And checkForNumbers(name) = True Then
                Console.WriteLine("Name is perfect length, continue.")
                Exit While
            Else
                Console.WriteLine("Name is too long, or invalid, try again.")
            End If
        End While


        'inputs 3 subjects
        For index = 0 To 2
            Console.WriteLine("Enter subject " & index + 1 & ":")
            If checkForNumbers(UCase(Console.ReadLine())) Then
                subjects(index) = UCase(Console.ReadLine())
            End If
        Next


        'inputs target grade
        While True
            Console.WriteLine("Enter Target grade:")
            targetGrade = Console.ReadLine()
            If targetGrade.Length() <> 1 Or targetGrade <> "A" Or targetGrade <> "B" Or targetGrade <> "C" Or targetGrade <> "D" Then
                Console.WriteLine("Not a grade")
            Else
                Char.Parse(UCase(targetGrade))
                Exit While
            End If
        End While


        'inputs if user is over 18
        While True
            Console.WriteLine("Are you over 18, yes or no?:")
            checkAgeChoice = UCase(Console.ReadLine().Substring(0, 1))
            If checkAgeChoice = "Y" Then
                checkAge = True
                Exit While
            Else
                checkAge = False
                Exit While
            End If
        End While


        'inputs age is between set values
        While True
            Try
                Console.WriteLine("How old are you?:")
                age = Integer.Parse(Console.ReadLine())

                If age >= 10 And age <= 100 Then
                    Console.WriteLine("valid age, continue")
                    Exit While
                Else
                    Console.WriteLine("No way Jose.")
                End If

            Catch ex As Exception
                Console.WriteLine("nAn try again.")
            End Try
        End While
    End Sub

    Function checkForNumbers(StringtoCheck As String) As Boolean
        Dim num As Integer = 0
        Dim count As Integer = 0
        Dim characters() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

        'Checksy type of each character
        For Each character As Char In StringtoCheck
            Try
                num = Integer.Parse(character)
                Return False
            Catch ex As Exception

            End Try
        Next


        'Ensures only valid characters are inputted
        For Each character2 As Char In StringtoCheck

            character2 = UCase(character2)
            For index = 0 To 25
                If character2 = characters(index) Or character2 = " " Then
                    Continue For
                Else
                    Return False
                End If
            Next
        Next

        Return True
    End Function

End Module
