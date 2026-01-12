Imports System

Public MustInherit Class Animal
    Public _name As String
    Public Sub New(name As String)
        Me._name = name
    End Sub
    Public MustOverride Function Speak() As String

End Class

Public Class Dog
    Inherits Animal

    Public Sub New(ByVal name As String)
        MyBase.New(name)
    End Sub

    Public Overrides Function Speak() As String
        Return "Woof"
    End Function

End Class

Public Class Owner
    Private _Name As String
    Private _EmailAddress As String
    Private _ContactNumber As Integer
    Private _Animals As List(Of Animal)

    Public Sub New(usrName As String, emailAddy As String, numberr As Integer)
        Me._Name = usrName
        Me._EmailAddress = emailAddy
        Me._ContactNumber = numberr
    End Sub

    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property

    Public Property EmailAddress As String
        Get
            Return _EmailAddress
        End Get
        Set(value As String)
            _EmailAddress = value
        End Set
    End Property

    Public Property ContactNumber As Integer
        Get
            Return _ContactNumber
        End Get
        Set(value As Integer)
            _ContactNumber = value
        End Set
    End Property

    Public Property Animals As List(Of Animal)
        Get
            Return _Animals
        End Get
        Set(value As List(Of Animal))
            _Animals = value
        End Set
    End Property


End Class

Module Program
    Sub Main(args As String())
        Dim myDog As New Dog()
        Dim pets As New List(Of Animal) From {myDog}

        Dim owner As New Owner(
            "John",
            "john@example.com",
            123456789,
            pets
        )

        Console.WriteLine(owner.Name & " owns " & owner.Animals.Count & " animal(s).")
    End Sub
End Module
