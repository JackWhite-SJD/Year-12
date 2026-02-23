Class Member

    Private _Username As String

    Public Property MemberUsername As String

        Get

            Return _Username

        End Get

        Set(ByVal value As String)

            _Username = value

        End Set

    End Property

    Private _Password As String

    Public Property MemberPassword As String

        Get

            Return _Password

        End Get

        Set(ByVal value As String)

            _Password = value

        End Set

    End Property

    Protected _UniqueID As String

    Public ReadOnly Property MemberUniqueID As String

        Get

            Return _UniqueID

        End Get

    End Property


    Public Overridable Sub Entry(ByVal Lanyard As Lanyard)

        Console.WriteLine("Welcome to the building " & _Username)

    End Sub


    Public Sub New(ByVal MemberNumber As Integer)

        Console.WriteLine("What is their Username?")

        _Username = Console.ReadLine()

        Console.WriteLine("what is their Password?")

        _Password = Console.ReadLine()

        _UniqueID = MemberNumber

    End Sub

End Class


Class Lanyard

    Private _Owner As Member

    Private _MemberID As String

    Public Sub New(ByVal Member As Member)

        _Owner = Member

        _MemberID = Member.MemberUniqueID

    End Sub

End Class


Class Adult

    Private DBS As Boolean = True

End Class


Class Child

    Private _MinimumGradeRequirement As Boolean = True

    Private _Allergies As New List(Of String)

    Public Sub New()

        AddAllergies()

    End Sub

    Public Sub AddAllergies()

        Console.WriteLine("Does this child have any allergies?")

        Dim allergy As String = Console.ReadLine()

        If allergy.ToLower = "yes" Then

            Dim done As Boolean = False

            Do Until done = True

                Console.WriteLine("Please enter the allergy and press enter to submit")

                allergy = Console.ReadLine()

                _Allergies.Add(allergy)

                Console.WriteLine("Any more?")

                Dim response As String = Console.ReadLine()

                If response.ToLower = "no" Then

                    done = True

                End If

            Loop

        Else

            Console.WriteLine("Lucky you!")

        End If

    End Sub

End Class


Class Student 'Composite of Member and Child

    Private _StudentMember As Member 'Member contains information about student's username, password, uniqueID

    Public ReadOnly Property StudentUsername As String

        Get

            Return _StudentMember.MemberUsername

        End Get

    End Property

    Private _StudentChild As Child 'Child contains information about student's allergies

    Private _Subjects(3) As String

    Public ReadOnly Property StudentSubjects() As String

        Get

            For i As Integer = 1 To 3

                Console.WriteLine(_Subjects(i))

            Next

        End Get

    End Property

    Public Sub New(ByVal MemberNumber As Integer)

        _StudentMember = New Member(MemberNumber) 'Member and Child both CREATED inside Student --> Composition

        _StudentChild = New Child() 'Member and Child both CREATED inside Student --> Composition

        Console.WriteLine("Please enter " & Me._StudentMember.MemberUsername & "'s three subjects one by one.")

        _Subjects(1) = Console.ReadLine()

        _Subjects(2) = Console.ReadLine()

        _Subjects(3) = Console.ReadLine()

        Console.WriteLine(Me._StudentMember.MemberUsername & " has been successfully added. Welcome to Sir John Deane's!")

        DisplayDetails()

    End Sub

    Public Sub DisplayDetails()

        Console.WriteLine("Username: " & Me._StudentMember.MemberUsername)

        Console.WriteLine("Password: PROTECTED")

        Console.WriteLine("UniqueID: " & Me._StudentMember.MemberUniqueID)

        For i As Integer = 1 To 3

            Console.WriteLine("Subject" & i & ": " & _Subjects(i))

        Next

    End Sub

End Class

Class Teacher
    Private _TeacherMember As Member
    Private _TeacherAdult As Adult
    Private _Department As String
    Protected _Salary As Integer
    Private _YearsOfExperience As Integer

    Private ClassA As List(Of Student)
    Private ClassB As List(Of Student)
    Private ClassC As List(Of Student)
    Private ClassD As List(Of Student)

    Public Sub New(ByVal _MemberID)
        _TeacherMember = New Member(_MemberID)
        _TeacherAdult = New Adult()
        Console.WriteLine("Enter years of experience:")
        _YearsOfExperience = Integer.Parse(Console.ReadLine())
        _Salary = 30000 + (_YearsOfExperience * 1000)
        Console.WriteLine("Enter department")
        _Department = Console.ReadLine()
        DisplayDetails()
    End Sub

    Public Sub DisplayDetails()
        Console.WriteLine(_TeacherMember.MemberUsername)
        Console.WriteLine("Password PROTECTED")
        Console.WriteLine(_Department)
        Console.WriteLine(_YearsOfExperience)
        Console.WriteLine(_Salary)
    End Sub

    Sub AddStudent(ByVal StudentToAdd As Student)
        Dim choice As String
        Console.WriteLine("Enter a class to add the student to (A,B,C or D)")
        choice = Console.ReadLine()
        Select Case choice
            Case "A"
                ClassA.Add(StudentToAdd)
            Case "B"
                ClassB.Add(StudentToAdd)
            Case "C"
                ClassC.Add(StudentToAdd)
            Case "D"
                ClassD.Add(StudentToAdd)
        End Select

        Console.WriteLine(StudentToAdd.StudentUsername + " has successfully been added to Class" + choice)
    End Sub

End Class

Class SeniorLeader
    Inherits Teacher

    Private _Role As String
    Private _Team As List(Of Teacher)
    Public Sub New(ByVal _MemberID)
        MyBase.New(_MemberID)
        Console.WriteLine("Enter role")
        _Role = Console.ReadLine()
        Select Case _Role
            Case "Principle"
                Me._Salary *= 3
            Case "Deputy Principle"
                Me._Salary *= 2
            Case "Principle"
                Me._Salary = Math.Round(Double.Parse(Me._Salary) * 1.5)
        End Select
    End Sub

    Public Function AddTeamMember(TeacherToAdd As Teacher) As Boolean
        If _Team.Count < 5 Then
            _Team.Add(TeacherToAdd)
            Return True
        Else
            Console.WriteLine("Team is full I'm afraid")
            Return False
        End If

    End Function

End Class

Module Module1

    Sub Main()

        Dim Students(2000) As Student

        Dim Teachers(70) As Teacher

        Console.WriteLine("Welcome to the SJD Community Program")

        Dim finished As Boolean = False

        Dim studentCount As Integer = 0

        Dim teacherCount As Integer = 0

        Do Until finished = True

            Console.WriteLine("Do you wish to add a Teacher or Student?")

            Dim choice As String = Console.ReadLine()

            If choice.ToLower = "student" Then

                Dim NewStudent As New Student(studentCount)

                studentCount += 1

                Students(studentCount) = NewStudent 'Saves student into the correct array index

            Else
                Console.WriteLine("Teacher or Senior Leader?:")
                Dim c As String = Console.ReadLine()
                If c.ToLower = "teacher" Then
                    Dim NewTeacher As New Teacher(teacherCount)
                    Teachers.Append(NewTeacher)
                Else
                    Dim NewLeader As New SeniorLeader(teacherCount)
                    Teachers.Append(NewLeader)
                End If
            End If
            Console.WriteLine("Do you wish to add another member?")

            Dim response As String = Console.ReadLine()

            If response.ToLower = "no" Then

                Console.WriteLine("OK thank you for using the SJD Community Program")

                finished = True

                System.Threading.Thread.Sleep(1000)

            End If

        Loop

    End Sub


End Module