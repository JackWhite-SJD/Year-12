Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine("How many digits are you going to be inputting?:")
        Dim n As Integer = Integer.Parse(Console.ReadLine())

        Dim ndict As New Dictionary(Of Integer, Integer)
        Dim mode As Integer = 0
        Dim mode2 As Integer = 0
        Dim t As Integer

        For i As Integer = 0 To n - 1
            Console.WriteLine($"Enter digit {i + 1}:")
            t = Integer.Parse(Console.ReadLine())
            If ndict.ContainsKey(t) Then
                ndict(t) += 1
            Else
                ndict.Add(t, 1)
            End If
        Next

        For Each v As Integer In ndict.Values
            If v > mode Then
                mode = v
            ElseIf v = mode Then
                mode2 = v
            End If
        Next

        Console.WriteLine()

        If mode > mode2 Then
            Console.WriteLine($"Mode frequency:{mode}")
        Else
            Console.WriteLine("Data was multimodal")
        End If
    End Sub
End Module