Imports System

Module Program
    '   -----------------------------------------------------------------
    '  | abstraction by generalisation:                                  |  
    '  |    grouping common characteristics to arrive at a hierarchical  |
    '  |    relationship of the "is a kind of" type                      |
    '   -----------------------------------------------------------------
    Class Animal
        Private _strName As String
        Private _intAge As Integer

        Public Sub setName(ByVal value As String)
            _strName = value
        End Sub

        Public Function getName()
            Return _strName
        End Function

        Public Overridable Sub makeNoise()
            Console.WriteLine("The animal has made a noise")
        End Sub

    End Class

    Class Penguin
        Inherits Animal ' child class of Animal, can access properties and methds of Animal.

        Public Overrides Sub makeNoise() 'process called polymorphism.
            Console.WriteLine("Noot Noot")
        End Sub

    End Class


    Sub Main(args As String())
        Dim penguin As New Penguin
        penguin.setName("Pingu")
    End Sub
End Module
