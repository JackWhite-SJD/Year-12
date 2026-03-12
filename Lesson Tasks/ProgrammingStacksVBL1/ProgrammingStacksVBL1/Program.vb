Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        Dim stack As Stack = New Stack(5)
        stack.Push(1)
        stack.Push(2)
        stack.Push(3)
        stack.Push(4)

        Console.WriteLine(stack.Peek().ToString())


        stack.POP()

        Console.WriteLine(stack.Peek().ToString())
    End Sub

    Class Stack
        Private _Array() As Integer
        Private _Pointer As Integer = -1
        Private _PointerMax As Integer

        Public Sub New(len As Integer)
            ReDim _PointerMax = len
            ReDim _Array(len)
        End Sub

        Public Sub POP()
            If _Pointer > -1 Then
                _Pointer -= 1
            Else
                Console.Writeline("UnderFlow Error")
            End If
        End Sub

        Public Sub Peek()
            Return _Array(_Pointer)
        End Sub

        Public Sub Push(item As Integer)
            If _Pointer < _PointerMax - 1 Then
                _Pointer += 1
                _Array(_Pointer) = item
            Else
                Console.WriteLine("Overflow error")
            End If
        End Sub

    End Class

End Module
