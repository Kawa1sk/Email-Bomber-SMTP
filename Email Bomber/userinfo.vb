Public Class userinfo

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HT_CAPTION As Integer = &H2

    ' Önemli: Aşağıdaki satır, user32.dll'deki SendMessage fonksiyonunu dışa aktarır.
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    ' Önemli: Aşağıdaki satır, user32.dll'deki ReleaseCapture fonksiyonunu dışa aktarır.
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Form1.ListView1.Items.Count = 5 Then
            MessageBox.Show("Public versions are only allowed 5 users!" + vbNewLine + vbNewLine + "You have reached the mamimum ammount of users!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If TextBox1.Text.Contains("@") = False Then
            MessageBox.Show("You did not enter a valid Email address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Text = ""
            Exit Sub
        ElseIf TextBox2.Text.Count <= 0 Then
            MessageBox.Show("You did not enter password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Text = ""
            Exit Sub
        End If
        Dim str(2) As String
        Dim itm As ListViewItem
        str(0) = TextBox1.Text
        str(1) = TextBox2.Text
        itm = New ListViewItem(str)
        Form1.ListView1.Items.Add(itm)
        Me.Close()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            If e.Clicks = 1 AndAlso e.Y <= Me.Height AndAlso e.Y >= 0 Then
                ReleaseCapture()
                SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        End If
    End Sub

    Private Sub Label4_MouseDown(sender As Object, e As MouseEventArgs) Handles Label4.MouseDown
        If e.Button = MouseButtons.Left Then
            If e.Clicks = 1 AndAlso e.Y <= Me.Height AndAlso e.Y >= 0 Then
                ReleaseCapture()
                SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        End If
    End Sub
End Class