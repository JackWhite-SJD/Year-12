Public Class Form1

    Dim changeColourButton As New Button
    Dim myPictureBox As New PictureBox
    Dim colourChanged As Boolean
    Dim gridScf As Integer
    Dim upButton As New Button
    Dim downButton As New Button
    Dim leftButton As New Button
    Dim rightButton As New Button


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'set size
        changeColourButton.Height = 50 'pixels
        changeColourButton.Width = 50
        colourChanged = False

        gridScf = 20
        'set location
        changeColourButton.Left = 10
        changeColourButton.Top = 10

        AddHandler changeColourButton.Click, AddressOf changeColourButton_Click
        'put on form
        Me.Controls.Add(changeColourButton)

        With myPictureBox
            .Height = 20
            .Width = 50
            .Left = gridScf * 10
            .Top = gridScf * 10
            .BackColor = Color.Black
        End With

        buttonSetup(upButton)
        upButton.Top = 30

        buttonSetup(leftButton)
        leftButton.Top = 60

        buttonSetup(rightButton)
        rigtButton.Top = 90

        buttonSetup(upButton)
        upButton.Top = 120
        Me.Controls.Add(myPictureBox)
    End Sub

    Public Sub buttonSetup(button As Button)
        button.Width = 20
        button.Height = 20
        button.Left = 20
    End Sub
    Private Sub changeColourButton_Click()

        If colourChanged Then
            myPictureBox.BackColor = Color.Red
            colourChanged = False
        Else
            myPictureBox.BackColor = Color.Blue
            colourChanged = True
        End If

    End Sub

End Class
