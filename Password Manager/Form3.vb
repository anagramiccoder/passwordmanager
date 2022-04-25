Public Class Form3
    Dim acc As String
    Dim Account As New ArrayList
    Dim Password As New ArrayList
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim counter As Integer = 0
        Dim accfile As New IO.StreamWriter("Name.txt")
        For x = 0 To Account.Count - 1
            accfile.WriteLine(Account.Item(x))
        Next
        Dim passfile As New IO.StreamWriter("Password.txt")
        For x = 0 To Account.Count - 1
            passfile.WriteLine(Password.Item(x))
        Next
        Dim breaker As Boolean = False
        For x = 0 To Account.Count - 1
            If Account.Item(x).Equals(TextBox1.Text) Then
                breaker = True
            End If
        Next
        If breaker Then
            MessageBox.Show("The user is already taken")
        Else
            accfile.WriteLine(TextBox1.Text)
            passfile.WriteLine(TextBox2.Text)
            accfile.Close()
            passfile.Close()
            MessageBox.Show("Thanks, please login")
            Dim a As New Form2
            a.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim response = MsgBox("Do you really want to exit?", MsgBoxStyle.YesNo)
        If response = MsgBoxResult.Yes Then
            Form2.Show()
            Me.Close()
        End If
    End Sub
End Class