Imports System

Module Program
    Sub Main(args As String())
        hArryTest()
    End Sub
    Public Sub hArryTest()
        Dim s As intStack = New intStack(3)
        s.Push(1)
        s.Push(50)
        s.Push(12)
        s.Push(90)
        s.Push(100)
        Console.WriteLine(s.Peek())
        s.POP()
        Console.WriteLine(s.Peek)
        s.POP()
        s.POP()
        s.POP()
        s.POP()
        Console.WriteLine(s.Peek)
        Console.ReadKey()
    End Sub

    Class intStack
        Private _Array() As Integer
        Private _Pointer As Integer = -1
        Private _PointerMax As Integer

        Public Sub New(len As Integer)
            _PointerMax = len
            ReDim _Array(len)
        End Sub

        Public Sub POP()
            If _Pointer > -1 Then
                _Pointer -= 1
            Else
                Console.WriteLine("CANNOT POP AND EMPTY STACK")
            End If
        End Sub

        Public Function Peek()
            If _Pointer > -1 Then
                Return _Array(_Pointer)
            Else
                Console.WriteLine("CANNOT PEEK AN EMPTY STACK")
                Return Nothing
            End If
        End Function

        Public Sub Push(item As Integer)
            If _Pointer < _PointerMax Then
                _Pointer += 1
                _Array(_Pointer) = item
            Else
                Console.WriteLine("CANNOT PUSH TO A FULL STACK")
            End If
        End Sub

        Public Sub clear()
            _Pointer = -1
        End Sub

    End Class

End Module
