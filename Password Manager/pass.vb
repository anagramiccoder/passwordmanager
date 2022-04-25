Public Class pass
    Dim acc As String
    Dim acc_list As New ArrayList
    Public Sub getname(ByVal accname As String)
        acc = accname
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim outfile As New IO.StreamWriter("Manager List.txt")
        For x = 0 To acc_list.Count - 1
            outfile.WriteLine(acc_list.Item(x))
        Next
        outfile.Close()
        main.setAcc(acc)
        main.Show()
        Me.Close()
    End Sub

    Private Sub pass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim infile As New IO.StreamReader("Manager List.txt")
        Do While infile.EndOfStream = False
            acc_list.Add(infile.ReadLine)
        Loop
        infile.Close()
    End Sub
    Private Function isAlphaNum(ByVal str As String) As Boolean
        Return (System.Text.RegularExpressions.Regex.IsMatch(str, "^[a-zA-Z0-9@]+$"))
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not (isAlphaNum(TextBox1.Text)) Or Not (isAlphaNum(TextBox2.Text)) Or Not (isAlphaNum(TextBox3.Text)) Then
            MessageBox.Show("Please enter a valid answer")
        Else
            Dim newacc As String = acc + ":" + TextBox2.Text + ";" + TextBox3.Text + "~" + TextBox1.Text.ToUpper
            Dim counter As Integer = 0
            For x = 0 To acc_list.Count - 1
                If (acc_list.Item(x).Equals(newacc)) Then
                    counter = 1
                End If
            Next
            If counter = 1 Then
                MessageBox.Show("Account already saved")
            Else
                acc_list.Add(newacc)

                Dim response = MsgBox("Do you want to continue?", MsgBoxStyle.YesNo)
                If response = MsgBoxResult.Yes Then
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                Else
                    Dim outfile As New IO.StreamWriter("Manager List.txt")
                    Dim count = 0
                    Do While count < acc_list.Count
                        outfile.WriteLine(acc_list.Item(count))
                        count += 1
                    Loop
                    outfile.Close()
                    main.setAcc(acc)
                    main.Show()
                    Me.Close()
                End If
            End If
        End If
    End Sub
End Class