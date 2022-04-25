Public Class Delete
    Dim passcode_list As New ArrayList
    Dim acc_list As New ArrayList
    Dim acctype_list As New ArrayList
    Dim acc As String
    Dim acclist As New ArrayList
    Public Sub setAcc(ByVal accname As String)
        acc = accname
    End Sub

    Private Sub Delete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim infile As New IO.StreamReader("Manager List.txt")
        Do While infile.EndOfStream = False
            Dim stringcheck As String = infile.ReadLine.ToString
            If (stringcheck.Substring(0, stringcheck.IndexOf(":")) = acc) Then
                acc_list.Add((stringcheck.Substring(stringcheck.IndexOf(":") + 1, (stringcheck.IndexOf(";") - 1) - stringcheck.IndexOf(":"))))
                passcode_list.Add(stringcheck.Substring(stringcheck.IndexOf(";") + 1, (stringcheck.IndexOf("~") - 1) - stringcheck.IndexOf(";")))
                acctype_list.Add(stringcheck.Substring(stringcheck.IndexOf("~") + 1))
            Else
                acclist.Add(infile.ReadLine)
            End If
        Loop
        infile.Close()
        For x = 0 To acc_list.Count - 1
            cb.Items.Add(acctype_list.Item(x) + " | " + acc_list.Item(x), CheckState.Unchecked)
        Next
        Me.Controls.Add(cb)
    End Sub
    Dim indeces As New ArrayList
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim respose = MsgBox("Do you really want to delete the selected account/s", MsgBoxStyle.YesNo)
        If respose = MsgBoxResult.Yes Then
            For x = 0 To cb.Items.Count - 1
                If cb.GetItemCheckState(x) = CheckState.Checked Then
                    indeces.Add(x)
                End If
            Next
            For x = 0 To indeces.Count - 1
                acc_list.Item(indeces(x)) = ""
                passcode_list.Item(indeces(x)) = ""
                acctype_list.Item(indeces(x)) = ""
            Next
            For x = 0 To acc_list.Count - 1
                If Not (acc_list(x).Equals("") And passcode_list(x).Equals("") And acctype_list(x).Equals("")) Then
                    acclist.Add(acc + ":" + acc_list.Item(x) + ";" + passcode_list.Item(x) + "~" + acctype_list.Item(x))
                End If  
            Next
            Dim outfile As New IO.StreamWriter("Manager List.txt")
            For x = 0 To acclist.Count - 1
                outfile.WriteLine(acclist.Item(x))
            Next
            outfile.Close()
            main.setAcc(acc)
            main.Show()
            Me.Close()
        End If
    End Sub
End Class