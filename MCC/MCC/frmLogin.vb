' Project Name: Oracle Project
' Purpose:      To Leanr how to use Oracle database with Oracle 11G XE and dotConnect
' Change log:   K. Rashford 9/16/2015


Public Class frmLogin

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' declare 2 objects
        'Dim LoginAdapter As New MCC_DEPTDataSetTableAdapters.LOGINTableAdapter
        Dim LoginAdapter As New MCC_DEPTDataSetTableAdapters.LOGINTableAdapter

        ' clean up the Login table before filling up
        LoginAdapter.ClearBeforeFill = True
        ' call the method we modified to pass user input
        LoginAdapter.FillByUsernamePassword(MCC_DEPTDataSet.LOGIN, txtUsername.Text, txtPassword.Text)

        ' check if input match our data
        If MCC_DEPTDataSet.LOGIN.Count = 0 Then
            MessageBox.Show("No Matching data found.", "Login Failure")
            Exit Sub
        End If
        SelForm.Show()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CSE_DEPTDataSet.LOGIN' table. You can move, or remove it, as needed.
        Me.LOGINTableAdapter.Fill(Me.MCC_DEPTDataSet.LOGIN)

    End Sub

    Private Sub btnReadLogin_Click(sender As Object, e As EventArgs) Handles btnReadLogIn.Click
        'declare a table adapter and 2 strings
        Dim LoginAdapter As New MCC_DEPTDataSetTableAdapters.LOGINTableAdapter
        Dim strPswd, strResult As String

        ' clean up the Login table before filling up
        LoginAdapter.ClearBeforeFill = True

        strPswd = LoginAdapter.PasswordQuery(txtUsername.Text)

        ' check the result
        If strPswd = String.Empty Then
            MessageBox.Show("No matching user name found!", "Password Query")
            Exit Sub
        End If

        'Display the result
        strResult = "the password is " & strPswd
        MessageBox.Show(strResult)
    End Sub
End Class