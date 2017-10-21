' Program Name: Flooring Cost Calculator Application
' Author:       Tu Tong
' Date:         Oct 20, 2017
' Purpose:      This windows applicaiton computes the estimated cost
'               of flooring based on the number of square feet and
'               the following cost per square foot: 
'               Tile - $4.99 per square foot;
'               Carpet - $4.99 per square foot;
'               Hardwood - $7.49 per square foot.

' Prevent automatic conversion of values
Option Strict On

Public Class frmFlooring
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        ' The btnCalculate event handler calculates the estimated cost of
        ' flooring based on the square footage and the flooring type.

        ' Declare constants
        Const cdecTileCost As Decimal = 4.99D
        Const cdecCarpetCost As Decimal = 4.99D
        Const cdecHardwoodCost As Decimal = 7.49D

        ' Declare variables
        Dim decFootage As Decimal
        Dim decCostPerSquareFoot As Decimal
        Dim decCostEstimate As Decimal

        ' Did user enter a numeric value?
        If IsNumeric(txtFootage.Text) Then

            ' convert entered footage text to decimal
            decFootage = Convert.ToDecimal(txtFootage.Text)

            ' Is square footage greater than zero?
            If decFootage > 0 Then

                ' Determine cost per square foot
                If radTile.Checked Then
                    decCostPerSquareFoot = cdecTileCost
                ElseIf radCarpet.Checked Then
                    decCostPerSquareFoot = cdecCarpetCost
                ElseIf radHardwood.Checked Then
                    decCostPerSquareFoot = cdecHardwoodCost
                End If

                ' calculate and display the cost estimate
                decCostEstimate = decFootage * decCostPerSquareFoot
                lblCostEstimate.Text = decCostEstimate.ToString("C")
            Else

                'Display error message if user entered a negative value
                MsgBox("You entered " & decFootage.ToString() & ". Enter a Positive Number", MsgBoxStyle.Exclamation, "Input Error")
                txtFootage.Clear()
                txtFootage.Focus()
            End If
        Else
            ' Display error message if user entered a nonnumeric value
            MsgBox("Enter the Square Footage of Flooring", MsgBoxStyle.Critical, "Input Error")
            txtFootage.Clear()
            txtFootage.Focus()
        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' Clear button click event handler clear the Square Footage Textbox,
        ' Cost Estimate label, reset the radios button with Tile selected,
        ' and set the focus to the Square Footage Textbox.

        txtFootage.Clear()
        lblCostEstimate.Text = ""
        radTile.Checked = True
        radCarpet.Checked = False
        radHardwood.Checked = False
        txtFootage.Focus()

    End Sub

    Private Sub frmFlooring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' This event handler is executed when the form is loaded at the start of
        ' the program. It sets the focus to the square footage text box and
        ' clears the cost estimate label.

        txtFootage.Focus()
        lblCostEstimate.Text = ""

    End Sub
End Class
