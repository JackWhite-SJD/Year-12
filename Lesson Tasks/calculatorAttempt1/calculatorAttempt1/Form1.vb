Imports System.Net.NetworkInformation
Imports System.Threading

Public Class Form1
    Dim boxEqn As New TextBox
    Dim isOperatorUsed As Boolean = False
    Dim arrOfButtons(,) As Button
    Dim arrOfOperators() As Button
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        arrOfButtons = _initializeButtons()
        arrOfOperators = getOperatorButtons(arrOfButtons)
        placeButtons(arrOfButtons)
        Me.Controls.Add(boxEqn)
    End Sub


    Public Sub Button_Click(sender As Object, e As EventArgs)
        Dim btn As Button = sender
        boxEqn.Text += btn.Text

    End Sub

    Public Sub Operator_Click(sender As Object, e As EventArgs)
        Dim btn As Button = sender
        'switchOperatorEnabled()
    End Sub

    Public Sub Equals_Click(sender As Object, e As EventArgs)
        Dim equation As String = boxEqn.Text
        Dim operatorSelected As Boolean = False
        Dim strOperator As String
        Dim strNum1 As String
        Dim strNum2 As String
        Dim intNum1 As Integer
        Dim intNum2 As Integer
        Dim result As Decimal


        For Each s As String In equation
            Try
                Integer.Parse(s)
                If operatorSelected = False Then
                    strNum1 += s
                Else
                    strNum2 += s
                End If

            Catch ex As Exception
                operatorSelected = True
                strOperator = s
            End Try
        Next

        intNum1 = Integer.Parse(strNum1)
        intNum2 = Integer.Parse(strNum2)

        Select Case strOperator
            Case "+"
                result = intNum1 + intNum2
            Case "-"
                result = intNum1 - intNum2
            Case "x"
                result = intNum1 * intNum2
            Case "÷"
                result = Math.Round(intNum1 / intNum2, 2)
            Case Else
                result = intNum1
        End Select
        boxEqn.Text = result.ToString()
        arrOfButtons(3, 1).Text = result.ToString
        boxEqn.Text = ""

    End Sub

    'Public Sub switchOperatorEnabled()
    '    If operatorUsed = False Then
    '        operatorUsed = True
    '    Else
    '        operatorUsed = False
    '    End If
    '    For i = 0 To arrOfOperators(i)
    '        If arrOfOperators(i).Text = "=" Or arrOfOperators(i).Text = "AC" Or arrOfOperators(i).Text = "." Then
    '            Continue For
    '        End If
    '        arrOfOperators(i).Enabled = operatorUsed
    '    Next
    'End Sub

    Public Sub AC_Click(sender As Object, e As EventArgs)
        boxEqn.Text = ""
    End Sub

    Public Sub Decimal_click(sender As Object, e As EventArgs)
        Dim btn As Button = sender
        boxEqn.Text += btn.Text
    End Sub

    Public Function getOperatorButtons(btnArr(,) As Button) As Button()
        Dim newArr(6) As Button
        For i = 0 To 3
            For j = 0 To 3
                Try
                    Integer.Parse(btnArr(i, j).Text)
                Catch ex As Exception
                    newArr.Append(btnArr(i, j))
                End Try
            Next
        Next
        Return newArr
    End Function

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
        operatorPlus.Text = "+"
        AddHandler operatorPlus.Click, AddressOf Operator_Click

        Dim operatorMinus As New Button
        operatorMinus.Text = "-"
        AddHandler operatorMinus.Click, AddressOf Operator_Click

        Dim operatorTimes As New Button
        operatorTimes.Text = "x"
        AddHandler operatorTimes.Click, AddressOf Operator_Click

        Dim operatorDivide As New Button
        operatorDivide.Text = "÷"
        AddHandler operatorDivide.Click, AddressOf Operator_Click

        Dim operatorEquals As New Button
        operatorEquals.Text = "="
        AddHandler operatorEquals.Click, AddressOf Equals_Click

        Dim operatorDecimal As New Button
        operatorDecimal.Text = "."
        AddHandler operatorDecimal.Click, AddressOf Decimal_click

        Dim operatorAC As New Button
        operatorAC.Text = "AC"
        AddHandler operatorAC.Click, AddressOf AC_Click

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
                If btnArr(i, j).Text = "AC" Or btnArr(i, j).Text = "=" Then
                    Continue For
                Else
                    AddHandler btnArr(i, j).Click, AddressOf Button_Click
                End If
            Next
        Next
    End Sub

End Class
