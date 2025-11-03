Imports System
Imports System.Diagnostics.CodeAnalysis
Imports System.Runtime.CompilerServices

Module Program
    Sub Main(args As String())
        'initialize all variables'



        'main program'


    End Sub

    Sub mainProg()
        Dim name As String
        Dim dates() As String
        Dim subject As String
        Console.WriteLine("What is your name?:")
        name = Console.ReadLine()
        Console.WriteLine("What is your birthday in the dd/mm/yyyy format with prefixed 0s removed from dd/mm:")
        dates = Split(Console.ReadLine(), "/")


        Console.WriteLine("What subject have your chosen?:")
        subject = Console.ReadLine()
        Console.WriteLine("Hello " + name + Environment.NewLine + "You have chosen  " + subject + Environment.NewLine + "And you are " + Convert.ToString(age) + " years old.")
    End Sub

    Sub convertToDays(dates() As String)
        Dim day As Int16
        Dim month As Int16
        Dim year As Int16
        Dim thisDate As Date
        thisDate = Today


        day = Convert.ToInt16(dates(0))
        month = Convert.ToInt16(dates(1))
        year = Convert.ToInt16(dates(2))



    End Sub
End Module
