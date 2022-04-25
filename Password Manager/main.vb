Public Class main
    Dim acc As String
    Dim passcode_list As New ArrayList
    Dim acc_list As New ArrayList
    Dim acctype_list As New ArrayList
    Public Sub setAcc(ByVal accname As String)
        acc = accname
        Dim infile As New IO.StreamReader("Manager List.txt")
        Do While infile.EndOfStream = False
            Dim stringcheck As String = infile.ReadLine.ToString
            If (stringcheck.Substring(0, stringcheck.IndexOf(":")) = acc) Then
                acc_list.Add((stringcheck.Substring(stringcheck.IndexOf(":") + 1, (stringcheck.IndexOf(";") - 1) - stringcheck.IndexOf(":"))))
                passcode_list.Add(stringcheck.Substring(stringcheck.IndexOf(";") + 1, (stringcheck.IndexOf("~") - 1) - stringcheck.IndexOf(";")))
                acctype_list.Add(stringcheck.Substring(stringcheck.IndexOf("~") + 1))
            End If
        Loop
        infile.Close()
    End Sub
    Public Sub display(ByVal num As Integer)
        Dim inserttype As New Label
        inserttype.Text = acctype_list.Item(num)
        tb.SetColumn(inserttype, 0)
        tb.SetRow(inserttype, num)
        tb.Controls.Add(inserttype)
        Dim insertuser As New Label
        insertuser.Text = acc_list.Item(num)
        tb.SetColumn(insertuser, 1)
        tb.SetRow(insertuser, num)
        tb.Controls.Add(insertuser)
        Dim insertpass As New Label
        insertpass.Text = passcode_list.Item(num)
        tb.SetColumn(insertpass, 2)
        tb.SetRow(insertpass, num)
        tb.Controls.Add(insertpass)
    End Sub

    Public Sub displayselection(ByVal enter As String)
        Dim counter As Integer = 0
        If Not (enter.Equals("")) Then
            For i = 0 To acc_list.Count - 1
                If (acctype_list.Item(i).Equals(enter)) Then
                    counter += 1
                End If
            Next
            tb.RowCount = counter
            For i = 0 To acc_list.Count - 1
                If (acctype_list.Item(i).Equals(enter)) Then
                    display(i)
                End If
            Next
        Else
            tb.RowCount = acc_list.Count
            For i = 0 To acc_list.Count - 1
                display(i)
            Next
        End If
    End Sub
    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        displayselection(TextBox1.Text.ToString.ToUpper)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form3.Show()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tb.Controls.Clear()
        tb.RowStyles.Clear()
        displayselection(TextBox1.Text.ToString.ToUpper)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim form As New pass
        form.getname(acc)
        form.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Delete.setAcc(acc)
        Delete.Show()
        Me.Close()
    End Sub
End Class