Imports System
Module Program
    Sub Main()
        Dim costPrice As Double
        Dim customerType As String
        Dim retailPrice As Double

        Console.Write("Enter cost price: ")
        If Not Double.TryParse(Console.ReadLine(), costPrice) OrElse costPrice < 0 Then
            Console.WriteLine("Error: Invalid cost price.")
            Return
        End If

        Console.Write("Enter customer type (A for Adult, C for Child): ")
        customerType = Console.ReadLine().ToUpper()

        If customerType = "A" Then
            retailPrice = costPrice * 1.175
            Console.WriteLine("Retail price: £" & retailPrice.ToString("0.00"))
        ElseIf customerType = "C" Then
            retailPrice = costPrice
            Console.WriteLine("Retail price: £" & retailPrice.ToString("0.00"))
        Else
            Console.WriteLine("Error: Invalid customer type.")
        End If
    End Sub
End Module