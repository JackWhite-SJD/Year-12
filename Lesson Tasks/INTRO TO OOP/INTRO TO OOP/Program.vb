Imports System
Imports INTRO_TO_OOP.Program

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

    Class Owner
        Private Animals As List(Of Animal)

        Public Sub AddAnimal()
            Dim finished As Boolean = False

            Do Until finished = True
                Console.WriteLine("What kind of animal would you like to add?")
                Console.WriteLine("1. Dog")
                Console.WriteLine("2. Cat")
                Console.WriteLine("3. Penguin")

                Dim response As String = Console.ReadLine()

                If response = "1" Then
                    Dim Dog As New Dog
                    Animals.Add(Dog)
                ElseIf response = "2" Then
                    Dim Cat As New Cat
                    Animals.Add(Cat)
                Else
                    Dim penguin As New Penguin
                    Animals.Add(penguin)
                End If


                Console.WriteLine("Would you like to add another animal?")
                response = Console.ReadLine()

                If response.ToLower = "no" Then
                    finished = True
                End If
            Loop
        End Sub
    End Class

    Class Penguin
        Inherits Animal ' child class of Animal, can access properties and methds of Animal.

        Public Overrides Sub makeNoise() 'process called polymorphism.
            Console.WriteLine("Noot Noot")
        End Sub

    End Class

    Class Dog
        Inherits Animal ' child class of Animal, can access properties and methds of Animal.

        Public Overrides Sub makeNoise() 'process called polymorphism.
            Console.WriteLine("Bark")
        End Sub
    End Class

    Class Cat
        Inherits Animal ' child class of Animal, can access properties and methds of Animal.

        Public Overrides Sub makeNoise() 'process called polymorphism.
            Console.WriteLine("Meow")
        End Sub
    End Class
    Sub Main(args As String())
        Dim penguin As New Owner
        penguin.AddAnimal()
    End Sub
End Module
