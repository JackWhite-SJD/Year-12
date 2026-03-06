Public Class Form1
    Dim boxEqn As New TextBox


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        placeButtons(_initializeButtons)
    End Sub


    Public Sub Button_Click(sender As Object, e As EventArgs)
        Dim btn As Button = sender
        btn.Text = "a"
    End Sub

    Public Function _initializeButtons() As Button(,)
        Dim btn0 As New Button
        btn0.Text = "0"

        Dim btn1 As New Button
        btn1.Text = "1"

        Dim btn2 As New Button
        btn2.Text = "2"

        Dim btn3 As New Button
        btn3.Text = "3"

        Dim btn4 As New Button
        btn4.Text = "4"

        Dim btn5 As New Button
        btn5.Text = "5"

        Dim btn6 As New Button
        btn6.Text = "6"
        Dim btn7 As New Button
        btn7.Text = "7"
        Dim btn8 As New Button
        btn8.Text = "8"
        Dim btn9 As New Button
        btn9.Text = "9"

        Dim operatorPlus As New Button
        Dim operatorMinus As New Button
        Dim operatorTimes As New Button
        Dim operatorDivide As New Button
        Dim operatorEquals As New Button
        Dim operatorDecimal As New Button
        Dim operatorAC As New Button


        Return {{btn1, btn2, btn3, operatorPlus}, {btn4, btn5, btn6, operatorMinus}, {btn7, btn8, btn9, operatorTimes}, {btn0, operatorDecimal, operatorEquals, operatorAC}}
    End Function

    Public Sub placeButtons(btnArr As Button(,))
        Dim posX As Integer = 30
        Dim posY As Integer = 50
        Dim posXIncrement As Integer = 90
        Dim posYIncrement As Integer = 50

        For i = 0 To 3
            For j = 0 To 3
                With btnArr(i, j)
                    .Left = posX + (posXIncrement * j)
                    .Top = posY + (posYIncrement * i)
                End With
                Me.Controls.Add(btnArr(i, j))
                AddHandler btnArr(i, j).Click, AddressOf Button_Click
            Next
        Next
    End Sub

End Class
