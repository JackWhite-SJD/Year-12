Imports System

Module Program
    Sub Main(args As String())
        Dim intArray() As Integer = getIntArray()
        output(intArray)
        intArray = rmvOddNumbers(intArray)
        output(intArray)
    End Sub

    Sub output(arr() As Integer)
        For i = 0 To arr.Length - 1
            Console.WriteLine(arr(i))
        Next
    End Sub

    Function rmvOddNumbers(intArr() As Integer) As Integer()
        Dim lst As New List(Of Integer)

        For i = 0 To intArr.Length - 1
            If intArr(i) = -1 Then
                Exit For
            End If

            If intArr(i) Mod 2 = 0 Then
                lst.Add(intArr(i))
            End If
        Next

        Dim newArr(lst.Count) As Integer

        For i = 0 To lst.Count - 1
            newArr(i) = lst(i)
        Next

        newArr(lst.Count) = -1

        Return newArr
    End Function

    Function getIntArray() As Integer()
        Dim intArray(19) As Integer
        Dim rnd As New Random

        For i = 0 To 18
            intArray(i) = rnd.Next(0, 1000)
        Next

        intArray(19) = -1
        Return intArray
    End Function
End Module