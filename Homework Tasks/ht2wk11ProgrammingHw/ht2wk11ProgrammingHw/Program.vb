'Module Module1

'    Sub Main()
'        Console.WriteLine("How far to count?")
'        Dim HowFar As Integer = Integer.Parse(Console.ReadLine())

'        While HowFar < 1
'            Console.WriteLine("Not a valid number, please try again.")
'            HowFar = Integer.Parse(Console.ReadLine())
'        End While

'        For i = 1 To HowFar
'            If i Mod 3 = 0 And i Mod 5 = 0 Then
'                Console.WriteLine("FizzBuzz")
'            Else
'                If i Mod 3 = 0 Then
'                    Console.WriteLine("Fizz")
'                Else
'                    If i Mod 5 = 0 Then
'                        Console.WriteLine("Buzz")
'                    Else
'                        Console.WriteLine(i)
'                    End If
'                End If
'            End If
'        Next

'    End Sub
'End Module

'Module Module1
'    Sub Main()
'        Dim ISBN(13) As Integer
'        Dim Count As Integer
'        Dim CalculatedDigit As Integer

'        For Count = 1 To 13
'            Console.WriteLine("Please enter next digit of ISBN: ")
'            ISBN(Count) = Integer.Parse(Console.ReadLine())
'        Next

'        CalculatedDigit = 0
'        Count = 1

'        While Count < 13
'            CalculatedDigit = CalculatedDigit + ISBN(Count)
'            Count = Count + 1

'            CalculatedDigit = CalculatedDigit + ISBN(Count) * 3
'            Count = Count + 1
'        End While

'        While CalculatedDigit >= 10
'            CalculatedDigit = CalculatedDigit - 10
'        End While

'        CalculatedDigit = 10 - CalculatedDigit

'        If CalculatedDigit = 10 Then
'            CalculatedDigit = 0
'        End If

'        If CalculatedDigit = ISBN(13) Then
'            Console.WriteLine("Valid ISBN")
'        Else
'            Console.WriteLine("Invalid ISBN")
'        End If

'    End Sub
'End Module

'Module Module1
'    Sub Main()
'        Dim Names(4) As String
'        Dim PlayerName As String
'        Dim Max As Integer
'        Dim Current As Integer
'        Dim Found As Boolean

'        Names(1) = "Ben"
'        Names(2) = "Thor"
'        Names(3) = "Zoe"
'        Names(4) = "Kate"

'        Max = 4
'        Current = 1
'        Found = False

'        Console.WriteLine("What player are you looking for?")
'        PlayerName = Console.ReadLine()

'        While (Found = False) And (Current <= Max)

'            If Names(Current) = PlayerName Then
'                Found = True
'            Else
'                Current = Current + 1
'            End If

'        End While

'        If Found = True Then
'            Console.WriteLine("Yes, they have a top score")
'        Else
'            Console.WriteLine("No, they do not have a top score")
'        End If

'    End Sub
'End Module
