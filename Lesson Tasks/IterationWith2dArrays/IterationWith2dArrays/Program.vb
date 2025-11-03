Imports System

Module Program
    Sub Main(args As String())
        menu()
    End Sub

    Function _initializeSeats(ByVal seats) As Boolean(,)
        For column = 0 To 4
            For row = 0 To 5
                seats(column, row) = False
            Next
        Next
        Return seats
    End Function

    Sub displaySeatingPlan(ByVal seats)
        Console.WriteLine(" | 1  2  3  4  5  6 ")
        Console.WriteLine("-|------------------")
        For column = 0 To 4
            Console.Write(column + 1 & "|")
            For row = 0 To 5
                If seats(column, row) Then
                    Console.Write(" X ")
                Else
                    Console.Write(" O ")
                End If
            Next
            Console.WriteLine()
        Next
    End Sub

    Sub bookSeat(row As Integer, col As Integer, seats(,) As Boolean)
        row -= 1
        col -= 1

        If seats(row, col) Then
            Console.WriteLine("Seat already Booked")
        Else
            Console.WriteLine("Seat boooked")
            seats(row, col) = True
        End If
    End Sub

    Sub countAvailableSeats(seats(,) As Boolean)
        Dim count As Integer = 0
        For column = 0 To 4
            For row = 0 To 5
                If seats(column, row) <> True Then
                    count += 1
                End If
            Next
        Next

        Console.WriteLine("Seats available:" & count)
    End Sub

    Sub cancelSeat(row As Integer, col As Integer, seats(,) As Boolean)
        row -= 1
        col -= 1

        If seats(row, col) Then
            seats(row, col) = False
        Else
            Console.WriteLine("Seat not booked.")
        End If
    End Sub

    Sub menu()
        Dim seats(4, 5) As Boolean
        Dim choice As Integer
        Dim row As Integer
        Dim col As Integer

        seats = _initializeSeats(seats)
        seats = randomfill(seats)
        While True
            displaySeatingPlan(seats)

            Console.WriteLine("What would you like to do?:")
            Console.WriteLine("(1) book seat")
            Console.WriteLine("(2) cancel seat")
            Console.WriteLine("(3) display total seats available")
            Console.WriteLine("(4) quit")
            choice = Console.ReadLine()

            Select Case choice
                Case 1
                    Console.WriteLine("Enter a row (1-5):")
                    row = Console.ReadLine()
                    Console.WriteLine("Enter a seat(1-6):")
                    col = Console.ReadLine()
                    bookSeat(row, col, seats)
                Case 2
                    Console.WriteLine("Enter a row (1-5):")
                    row = Console.ReadLine()
                    Console.WriteLine("Enter a seat(1-6):")
                    col = Console.ReadLine()
                    cancelSeat(row, col, seats)
                Case 3
                    displaySeatingPlan(seats)
                Case 4
                    End
            End Select
        End While
    End Sub

    Function randomfill(seats(,) As Boolean) As Boolean(,)
        Dim rand As New Random()
        Dim rand1 As Integer
        Dim rand2 As Integer
        For i = 0 To 15
            rand1 = rand.Next(0, 5)
            rand2 = rand.Next(0, 6)

            If seats(rand1, rand2) = False Then
                seats(rand1, rand2) = True
            End If
        Next

        Return seats
    End Function

End Module