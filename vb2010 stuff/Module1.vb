Imports System.Runtime.Remoting.Services
Imports ConsoleApplication1.Module1

Module Module1

    Sub Main()
        studentDb()
    End Sub

    Sub studentDb()
        Dim rsponce As Char
        Dim rply As Char
        Dim student0 As New studnet

        While rsponce <> "q"
            Console.WriteLine("Student database")
            Console.WriteLine()
            Console.WriteLine("Add studend,  (A)")
            Console.WriteLine("view student data , (B)")
            Console.WriteLine("Compute student data, (C)")
            Console.WriteLine("Quit, (Q)")

            rsponce = Console.ReadLine().ToLower()

            If rsponce = "a" Then
                Console.WriteLine("Enter the forename:")
                student0.forename = Console.ReadLine()
                Console.WriteLine("Enter the surname:")
                student0.surname = Console.ReadLine()
                Console.WriteLine("Enter GPA:")
                student0.gpa = Double.Parse(Console.ReadLine())

                Console.WriteLine("Student data complete")
                Console.ReadLine()
                Console.Clear()
            ElseIf rsponce = "b" Then
                Console.WriteLine("Student Firstname:" & student0.forename)
                Console.WriteLine("Student Surname:" & student0.surname)
                Console.WriteLine("Student GPA:" & student0.gpa)

                Console.WriteLine("Student data output complete")
                Console.ReadLine()
                Console.Clear()
            ElseIf rsponce = "c" Then
                student0.ComputeGrade()
                Console.ReadLine()
                Console.Clear()
            End If

        End While
    End Sub

    Sub circele()
        Dim mycrickle As New Circle
        Dim mycilinder As New cylinder

        Console.WriteLine("Enter a Radius")
        mycrickle.radius = Console.ReadLine()

        mycilinder.radius = mycrickle.radius

        Console.WriteLine("Enter a Height")
        mycilinder.Height = Console.ReadLine()

        Console.Write("Area of Circle " & Format(mycrickle.Area(), "0.00"))
        Console.WriteLine(" metres squared.")
        Console.WriteLine()
        Console.Write("Volume of the cylinder " & Format(mycilinder.Area(), "0.00"))
        Console.WriteLine(" metres cubed")
        Console.Read()
    End Sub

    Class Circle
        Protected _radius As Integer

        Public Property radius
            Get
                Return _radius
            End Get
            Set(ByVal value)
                _radius = value
            End Set
        End Property

        Public Sub New(Optional Radius As Integer = 1)
            _radius = Radius
        End Sub


        Public Function Area() As Double
            Return (_radius ^ 2) * Math.PI
        End Function
        Public Function Circumference() As Double
            Return Math.PI * (_radius * 2)
        End Function


    End Class

    Class box
        Private _width, _height, _length As Double
        Sub New(Optional width As Double = 1, Optional height As Double = 1, Optional length As Double = 1)
            _width = width
            _height = height
            _length = length
        End Sub

        Public Function Volume() As Double
            Return _width * _height * _length
        End Function

        Public Function surfaceArea() As Double
            Return 2 * ((_length * _width) + (_height * _width) + (_length * _height))
        End Function

    End Class

    Class cylinder
        Inherits Circle

        Protected _height As Integer

        Public Sub New(Optional height As Integer = 1)
            MyBase.New()
            _height = height
        End Sub

        Public Property Height As Integer
            Set(Value As Integer)
                _height = Value
            End Set
            Get
                Return _height
            End Get
        End Property

        Public Overloads Function Area() As Double
            Return (radius() ^ 2) * Math.PI * Height()
        End Function

    End Class

    Class studnet
        Protected _forename As String
        Protected _surname As String
        Protected _gpa As Double

        Public Property forename As String
            Set(value As String)
                _forename = value
            End Set
            Get
                Return _forename
            End Get
        End Property

        Public Property surname As String
            Get
                Return _surname
            End Get
            Set(value As String)
                _surname = value
            End Set
        End Property

        Public Property gpa As Double
            Get
                Return _gpa
            End Get
            Set(value As Double)
                _gpa = value
            End Set
        End Property

        Public Sub New(Optional forename As String = "", Optional surname As String = "", Optional gpa As Double = 0)
            _forename = forename
            _surname = surname
            _gpa = gpa
        End Sub

        Public Overridable Sub ComputeGrade()
            If _gpa > 50 Then
                Console.WriteLine("You are Entry Level")
                Console.WriteLine("Congratulations you have passed")
            Else
                Console.WriteLine("You are Entry Level")
                Console.WriteLine("Commiserations you have failed")
            End If
        End Sub

    End Class

    Class graduate
        Inherits studnet

        Public Overrides Sub ComputeGrade()
            If gpa > 75 Then
                Console.WriteLine("You are indeed a graduate")
                Console.WriteLine("Well in you have passed.")
            End If
        End Sub
    End Class

End Module