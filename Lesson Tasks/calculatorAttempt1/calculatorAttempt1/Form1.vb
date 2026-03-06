Public Class Form1

    Dim operatorPlus As New Button
    Dim operatorMinus As New Button
    Dim operatorTimes As New Button
    Dim operatorDivide As New Button
    Dim operatorEquals As New Button
    Dim operatorDecimal As New Button
    Dim boxEqn As New TextBox

    Dim listOfButtons As List(Of Button)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        placeButton(operatorPlus, 30, 50, "+")
        placeButton(operatorMinus, 120, 50, "-")
        placeButton(operatorTimes, 30, 100, "*")
        placeButton(operatorDivide, 120, 100, "÷")
        placeButton(operatorEquals, 210, 150, "=")

    End Sub


    Public Sub placeButton(btn As Button, left As Integer, top As Integer, text As String)
        With btn
            .Left = left
            .Top = top
            .Text = text
        End With
        AddHandler btn.Click, AddressOf Button_Click
        Me.Controls.Add(btn)
    End Sub

    Public Sub Button_Click(sender As Object, e As EventArgs)
        Dim btn As Button = sender
        Dim symbol As String = btn.Text
    End Sub

    Public Function _initializeButtons() As Button(,)
        Dim btn0 As New Button
        Dim btn1 As New Button
        Dim btn2 As New Button
        Dim btn3 As New Button
        Dim btn4 As New Button
        Dim btn5 As New Button
        Dim btn6 As New Button
        Dim btn7 As New Button
        Dim btn8 As New Button
        Dim btn9 As New Button


        Return {{btn1, btn2, btn3, operatorPlus}, {btn4, btn5, btn6, operatorMinus}, {btn7, btn8, btn9, operatorTimes}, {btn0, operatorDecimal, operatorEquals}}
    End Function

End Class
