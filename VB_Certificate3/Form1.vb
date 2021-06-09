Public Class Form1
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim b, a, y, x, m1, m2 As Integer 'm1輸出分子 m2輸出分母
        Dim op, ans As String
        Dim dt As New DataTable

        dt.Columns.Add("VALUE1")
        dt.Columns.Add("OP")
        dt.Columns.Add("VALUE2")
        dt.Columns.Add("ANSWER")

        FileOpen(1, "C:\丙檢測試資料\1060308.SM", OpenMode.Input)

        Do While Not EOF(1)
            Input(1, b) : Input(1, a) : Input(1, op) : Input(1, y) : Input(1, x) : ans = " "
            Select Case op
                Case "+" '(bx+ay)/ax
                    m1 = b * x + a * y
                    m2 = a * x
                Case "-"
                    m1 = b * x - a * y
                    m2 = a * x
                Case "*"
                    m1 = b * y
                    m2 = a * x
                Case "/"
                    m1 = b * x
                    m2 = a * y
            End Select
            For i = Math.Abs(m2) To 1 Step -1 '絕對值
                If m1 Mod i = 0 And m2 Mod i = 0 Then
                    m1 = m1 / i
                    m2 = m2 / i
                    ans = m1 & "/" & m2
                    If m1 = 0 Then ans = 0
                    If m2 = 1 Then ans = m1
                    dt.Rows.Add(b & "/" & a, op, y & "/" & x, ans)
                    Exit For
                End If
            Next
        Loop
        With DataGridView1
            .DataSource = dt
            .DefaultCellStyle.Alignment = 32
        End With
        FileClose(1)
    End Sub
End Class
