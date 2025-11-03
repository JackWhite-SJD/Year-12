Imports System
Imports System.ComponentModel.Design

Module Program
    Sub Main(args As String())
        Dim name() As String
        Dim fname As String
        Dim lname As String
        Dim concatName As String
        Dim initChar As String

        While Len(fname) > 15 And Len(lname) > 15
            Console.WriteLine("What is your name?:")
            name = Split(Console.ReadLine(), " ")
            fname = name(0).Substring(0, 3)
            lname = name(1).Substring(0, 3)
            concatName = LCase(fname + lname)

            If Len(fname) > 15 And Len(lname) > 15 Then
                Console.WriteLine("Thats too long of a name")
            Else
                Exit
            End If

        End While

        initChar = UCase(concatName.Substring(0, 1))
        initChar += concatName.Substring(1, Len(concatName) - 1)




        Console.WriteLine(initChar)
    End Sub
End Module
