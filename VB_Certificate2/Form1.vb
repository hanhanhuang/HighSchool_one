Public Class Form1
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
        Dim id, name, sex, ec, d(10) As String
        Dim dt As New DataTable '記憶體內資料物件
        dt.Columns.Add("ID_NO")
        dt.Columns.Add("NAME")
        dt.Columns.Add("SEX")
        dt.Columns.Add("ERROR")

        FileOpen(1, "C:\丙檢測試資料\1060306.SM", OpenMode.Input)
        Do While Not EOF(1)
            Input(1, id) : Input(1, name) : Input(1, sex) : ec = " "


            If id Like "[A-Z]#########" Then

                For i = 1 To 9
                    d(i) = Mid(id, i + 1, 1)    'Mid(): 1 as base
                Next
                If d(1) = 1 And sex = "M" Or d(1) = 2 And sex = "F" Then

                    Dim a As String
                    Dim x, x1, x2, y As Integer
                    a = Mid(id, 1, 1)
                    x = InStr("ABCDEFGHJKLMNPQRSTUVXYWZIO", a) + 9
                    x1 = x \ 10 '取整數
                    x2 = x Mod 10
                    y = x1 + 9 * x2
                    For j = 8 To 1 Step -1
                        y = y + j * d(9 - j)
                    Next
                    y = y + d(9)
                    If y Mod 10 = 0 Then
                    Else
                        ec = "CHECK SUM ERROR"
                    End If

                Else
                    ec = "SEX ERROR"
                End If
            Else
                ec = "FORMAT ERROR"
            End If

            dt.Rows.Add(id, name, sex, ec)
        Loop
        FileClose(1)
        DataGridView1.DataSource = dt
        DataGridView1.Sort(DataGridView1.Columns(0), 0)
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
