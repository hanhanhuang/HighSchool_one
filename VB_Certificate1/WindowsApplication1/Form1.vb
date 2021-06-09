Public Class Form1
    '*******************************
    '* 11900-1060301 Program Start *
    '*******************************
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim m0, m1, m2, m3, m4 As Integer '宣告 m0,m1,m2,m3,m4 是整數格式
        FileOpen(1, "C:\丙檢測試資料\1060301.SM", OpenMode.Input)
        '設定為讀取模式
        '設定成output檔案會被清空
        Input(1, m0) '讀取檔案編號1的檔案中並將讀取資料存入m0
        FileClose(1) '關閉一號檔案

        m1 = m0
        For i = 1 To 9
            m2 = m1 \ 10
            m3 = m1 Mod 10
            m4 = m4 & m3
            If m2 = 0 Then
                Exit For
            Else
                m1 = m2
            End If

        Next



        If m0 = m4 Then
            TextBox1.Text = "第一題結果：" & m0 & " is a palidrome"
        Else
            TextBox1.Text = "第一題結果：" & m0 & " is not a palidrome"
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    '*******************************
    '* 11900-1060302 Program Start *
    '*******************************
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim m0 As Integer '宣告 m0 是整數格式
        Dim s As String
        FileOpen(1, "C:\丙檢測試資料\1060302.SM", OpenMode.Input)
        Input(1, m0)
        FileClose(1)

        For j = 1 To m0
            For i = 1 To j
                s = s & i
            Next
            s = s & vbNewLine
        Next
        TextBox2.Text = "第二題結果：" & vbNewLine & s

    End Sub
    '*******************************
    '* 11900-1060303 Program Start *
    '*******************************
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim m0, m1, m2 As Integer

        FileOpen(1, "C:\丙檢測試資料\1060303.SM", OpenMode.Input)
        Input(1, m0)
        FileClose(1)

        m1 = m0

        For j = 1 To m1
            If m1 Mod j = 0 Then
                m2 = m2 + 1
            End If
        Next
        If m2 = 2 Then
            TextBox3.Text = "第三題結果：" & m1 & " is a prime number"
        Else
            TextBox3.Text = "第三題結果：" & m1 & " is not a prime number"
        End If


    End Sub
    '*******************************
    '* 11900-1060304 Program Start *
    '*******************************
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim h(3), w(3), bmi(3), min As Integer

        FileOpen(1, "C:\丙檢測試資料\1060304.SM", OpenMode.Input)

        For i = 1 To 3
            Input(1, h(i)) : Input(1, w(i))
            bmi(i) = w(i) / (h(i) / 100) ^ 2
        Next
        FileClose(1)
        min = bmi(1)
        For i = 1 To 3
            If bmi(i) < min Then
                min = bmi(i)
            End If
        Next

        Dim min45 As Integer = min

        If min45 < 20 Or min > 25 Then
            TextBox4.Text = "第四題結果：BMI最小值為=" & min45 & "，不正常"
        Else
            TextBox4.Text = "第四題結果：BMI最小值為=" & min45 & "，正常"
        End If

    End Sub
    '*******************************
    '* 11900-1060305 Program Start *
    '*******************************
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim a(2, 2), b(2, 2), c(2, 2) As Integer
        FileOpen(1, "C:\丙檢測試資料\1060305.SM", OpenMode.Input)
        Input(1, a(1, 1)) : Input(1, a(1, 2))
        Input(1, a(2, 1)) : Input(1, a(2, 2))
        Input(1, b(1, 1)) : Input(1, b(1, 2))
        Input(1, b(2, 1)) : Input(1, b(2, 2))
        FileClose(1)

        For i = 1 To 2
            For j = 1 To 2
                c(i, j) = a(i, j) + b(i, j)
            Next
        Next

        'do while loop
        'Dim i = 1
        'Do While i <= 2
        '    Dim j = 1
        '    Do While j <= 2
        '        c(i, j) = a(i, j) + b(i, j)
        '    Loop
        'Loop
        Dim m1 As String
        m1 = m1 & "[" & c(1, 1) & "        " & c(1, 2) & "]" & vbNewLine
        m1 = m1 & "[" & c(2, 1) & "     " & c(2, 2) & "]"

        TextBox5.Text = "第五題結果：" & vbNewLine & m1

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim data As String
        Dim vn = vbNewLine
        data = data & "姓名：[黃韋翰]     術科測試編號：[000000000]" & vn
        data = data & "座號：[29]              日期[2019/06/04]" & vn & vn

        data = data & TextBox1.Text & vn & vn
        data = data & TextBox2.Text & vn & vn
        data = data & TextBox3.Text & vn & vn
        data = data & TextBox4.Text & vn & vn
        data = data & TextBox5.Text & vn & vn

        e.Graphics.DrawString(data, Me.Font, Brushes.Black, 100, 100)
        'e 是指printDocument1 這個物件; Graphics-畫圖; Drawstring-畫出字串
        '(要印的資料,字型,顏色,列印起始坐標)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call PrintDocument1.Print()
    End Sub
End Class
