Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.AccessControl
Imports System.Threading

Module Program
    Sub Main(args As String())

        Dim reindeerPath As String = "reindeerscores.txt"
        Dim carolPath As String = "christmascarol.txt"


        'chl1(carolPath)
        'chl2(carolPath)
        'chl3(carolPath)

        ' chl4 = chl1(reindeerPath)

    End Sub

    Sub chl1(path As String)
        Dim text As String
        Using sr As New System.IO.StreamReader(path)
            'read whole file
            text = sr.ReadToEnd()
        End Using
        Console.WriteLine(text)
    End Sub
    Sub chl2(path As String)
        Dim count As Integer
        Using sr As New System.IO.StreamReader(path)
            While sr.Peek() >= 0
                Dim line As String = sr.ReadLine()
                count += 1
            End While

        End Using

        Console.WriteLine(count)
    End Sub

    Sub chl3(path As String)
        Dim count As Integer = 0
        Using sr As New System.IO.StreamReader(path)
            While sr.Peek() >= 0
                Dim line As String = sr.ReadLine()
                count += 1
                If count >= 3275 And count <= 3278 Then
                    Console.WriteLine(line)
                End If
            End While
        End Using
    End Sub

    Sub chl5(path As String)
        Dim scores() As Integer
        Dim added As Boolean
        Dim count As Integer = 1
        Dim number As Integer
        Dim lines() As String
        Using sr As New System.IO.StreamReader(path)
            scores(0) = 22456
            While sr.Peek() >= 0
                Dim line As String = sr.ReadLine()
                lines(count) = line
                scores(count) = Integer.Parse(line.Substring(0, 5))
                count += 1
            End While

        End Using
    End Sub

    Function bubbleSort(arr() As Integer)

    End Function
End Module


Sub dataWriteToFileForStudentData()
    Dim currentStudentKey As Integer = 0

End Sub

Function getData(ref currentStudentKey As Integer)

    Dim path As String = Directory.GetCurrentDirectory() + "\\file.txt"
    Dim allLines() As String = File.ReadAllLines(path, True)
    Dim currentStudentData() As String
    Dim studentData() As (Integer, String, String, Integer)
    Dim student As String

    For i = 0 To allLines.Length()
        currentStudentData(i) = allLines(i).split(":")


    Next

End Function


Sub addData(ref currentStudentKey As Integer)

End Sub
