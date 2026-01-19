Imports System

Module Program
    Class vegetable
        Private _name As String

        Public Sub New(name As String)
            _name = name
        End Sub

        Public Function getName()
            Return _name
        End Function

    End Class

    Class box
        Private _capacity As Integer
        Private _currentNumber As Integer
        Private _vegieList As List(Of vegetable)
        Private _name As String

        Public Sub New(ByVal capacity As Integer, ByVal name As String)
            _capacity = capacity
            _currentNumber = 0
            _vegieList = New List(Of vegetable)
            _name = name
        End Sub

        Public Function getCapacity()
            Return _capacity
        End Function

        Public Sub addVegetable(ByVal value As vegetable)
            If _currentNumber < _capacity Then
                _currentNumber += 1
                _vegieList.Add(value)
            Else
                Console.WriteLine("capacity reached")
            End If
        End Sub

        Public Sub printVegetableList()
            For Each v As vegetable In _vegieList
                Console.WriteLine(v.getName())
            Next

        End Sub

        Public Function getName()
            Return _name
        End Function

    End Class


    Public Class crate
        Private _boxes As List(Of box)
        Private _capacity As Integer
        Private _currentNumber As Integer

        Public Sub New(ByVal value As Integer)
            _boxes = New List(Of box)
            _capacity = value
            _currentNumber = 0
        End Sub

        Public Sub addBox(ByVal value As box)
            If _currentNumber < _capacity Then
                _currentNumber += 1
                _boxes.Add(value)
            Else
                Console.WriteLine("capacity reached")
            End If
        End Sub

        Public Sub printVegetableList()
            For Each v As box In _boxes
                Console.WriteLine(v.getName())
            Next

        End Sub

    End Class

    Sub Main(args As String())
        Dim parsnip1 As vegetable = New vegetable("parsnip1")
        Dim parsnip2 As vegetable = New vegetable("parsnip2")
        Dim parsnip3 As vegetable = New vegetable("parsnip3")
        Dim parsnip4 As vegetable = New vegetable("parsnip4")
        Dim parsnip5 As vegetable = New vegetable("parsnip5")
        Dim parsnip6 As vegetable = New vegetable("parsnip6")

        Dim newBox As box = New box(5, "parsnips")
        newBox.addVegetable(parsnip1)
        newBox.addVegetable(parsnip2)
        newBox.addVegetable(parsnip3)
        newBox.addVegetable(parsnip4)
        newBox.addVegetable(parsnip5)
        newBox.addVegetable(parsnip6)

        Console.WriteLine(newBox.getCapacity())
        newBox.printVegetableList()

        Dim carrot1 As vegetable = New vegetable("carrot1")
        Dim carrot2 As vegetable = New vegetable("carrot2")
        Dim carrot3 As vegetable = New vegetable("carrot3")
        Dim carrot4 As vegetable = New vegetable("carrot4")
        Dim carrot5 As vegetable = New vegetable("carrot5")
        Dim carrot6 As vegetable = New vegetable("carrot6")

        Dim newBoxCarrot As box = New box(5, "carrots")
        newBoxCarrot.addVegetable(carrot1)
        newBoxCarrot.addVegetable(carrot2)
        newBoxCarrot.addVegetable(carrot3)
        newBoxCarrot.addVegetable(carrot4)
        newBoxCarrot.addVegetable(carrot5)
        newBoxCarrot.addVegetable(carrot6)

        Console.WriteLine(newBoxCarrot.getCapacity())
        newBoxCarrot.printVegetableList()

        Console.WriteLine()

        Dim c As crate = New crate(10)
        c.addBox(newBoxCarrot)
        c.addBox(newBox)
        c.printVegetableList()
    End Sub
End Module
