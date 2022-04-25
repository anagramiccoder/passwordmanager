Public Class Form2
    Dim Account As New ArrayList
    Dim Password As New ArrayList
    Dim accountname As String
    Dim passcode As String
    Public Sub Re()
        Account.Clear()
        Password.Clear()
        Try
            Dim accfile As New IO.StreamReader("Name.txt")
            Do While accfile.EndOfStream = False
                Account.Add(accfile.ReadLine)
            Loop
            accfile.Close()
            Dim Passfile As New IO.StreamReader("Password.txt")
            Do While Passfile.EndOfStream = False
                Password.Add((Passfile.ReadLine).ToString)
            Loop
            Passfile.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Re()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        passcode = (TextBox2.Text).ToString
        accountname = (TextBox1.Text).ToString
        Dim counter As Integer = 0
        For x = 0 To Account.Count - 1
            If Account.Item(x).Equals(accountname) Then
                If (Password.Item(x).Equals(passcode)) Then
                    counter = 1
                    MessageBox.Show("Account name found")
                Else
                    counter = 2
                End If
            End If
        Next
        If counter = 0 Then
            MessageBox.Show("Account name not found")
        ElseIf counter = 1 Then
            Dim a As main = New main
            a.setAcc(accountname)
            a.Show()
            Me.Close()
        ElseIf counter = 2 Then
            MessageBox.Show("Wrong Password")
        End If
    End Sub
End Class