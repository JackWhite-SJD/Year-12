Imports System
Imports System.IO

Module Program
    Sub Main(args As String())
        Dim time1 As DateTime
        Dim tim2 As DateTime
        Dim difference As TimeSpan
        Dim seconds As Double
        Dim speed As Double

        Console.WriteLine("Enter time of cam1 in (hh:mm:ss):")
        time1 = DateTime.Parse(Console.ReadLine())

        Console.WriteLine("Enter time of cam2 in (hh:mm:ss):")
        tim2 = DateTime.Parse(Console.ReadLine())

        difference = tim2 - time1
        seconds = difference.TotalSeconds
        speed = (1.0 / seconds) * 3600

        Console.WriteLine("Avg speed:" & speed & "mph")

    End Sub
End Module
