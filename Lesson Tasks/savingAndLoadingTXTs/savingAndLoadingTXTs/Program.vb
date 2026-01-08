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

        ' chl4 = chl1(reindeerPath

    End Sub

	@@ -74,31 +73,51 @@ Module Program
    Function bubbleSort(arr() As Integer)

    End Function

    Sub dataWriteToFileForStudentData()
        Dim currentStudentKey As Integer = 0
        Dim path As String = Directory.GetCurrentDirectory() + "\\file.txt"

    End Sub

    Function getData(ByRef currentStudentKey As Integer, ByVal path As String) As (Integer, String, String, Integer)()

        Dim allLines() As String = File.ReadAllLines(path)
        Dim currentStudentData() As String
        Dim studentData(allLines.Length) As (Integer, String, String, Integer)

        For i = 0 To allLines.Length()
            currentStudentData = allLines(i).Split(":")
            studentData(i).Item1 = Integer.Parse(currentStudentData(0))
            studentData(i).Item2 = currentStudentData(1)
            studentData(i).Item3 = currentStudentData(2)
            studentData(i).Item4 = Integer.Parse(currentStudentData(3))

        Next
        Return studentData

    End Function

    Sub createStudent(ByRef currentStudentKey As Integer, ByRef path As String)
        Console.WriteLine("Enter student first name:")
        Dim fname As String = Console.ReadLine()

        Console.WriteLine("Enter student las")


    End Sub

    Sub addData(ByRef currentStudentKey As Integer, ByVal fname As String, ByVal lname As String, ByVal mtg As Integer, ByVal path As String)
        Dim newData As String = currentStudentKey.ToString() & ":" & fname & ":" & lname & ":" & mtg.ToString()
        Dim sw As New StreamWriter(path, True)

        sw.WriteLine(newData)
        sw.Close()
        currentStudentKey += 1

    End Sub

End Module
