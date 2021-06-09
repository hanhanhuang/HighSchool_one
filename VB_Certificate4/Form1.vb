Public Class Form1
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim n1, num, pp, bp, count, s As Integer
        'n1 讀第一筆資料看玩家玩幾局 num 撲克牌編號1-51
        'pp 玩家點數 bp 莊家點數
        's 序號 count 計數發牌次數
        s = 1
        Dim player, banker, result As String
        Dim suit(4) As String '花色
        Dim n2 As Double '從第二筆開始的隨機數
        Dim card As New ArrayList '已抽牌的陣列

        Dim ba1() As Byte = {226, 153, 160}
        Dim ba2() As Byte = {226, 153, 165}
        Dim ba3() As Byte = {226, 153, 166}
        Dim ba4() As Byte = {226, 153, 163}
        suit(0) = System.Text.Encoding.UTF8.GetString(ba1) '黑桃
        suit(1) = System.Text.Encoding.UTF8.GetString(ba2)
        suit(2) = System.Text.Encoding.UTF8.GetString(ba3)
        suit(3) = System.Text.Encoding.UTF8.GetString(ba4)

        dt.Columns.Add("序號")
        dt.Columns.Add("玩家")
        dt.Columns.Add("莊家")
        dt.Columns.Add("結果")
        FileOpen(1, "C:\丙檢測試資料\1060307.SM", OpenMode.Input)
        Input(1, n1) '讀第一筆資料看要玩幾局

        Do Until EOF(1)
            Input(1, n2)
            num = Int(n2 * 52) '算出隨機數*52且捨棄小數的值
            If card.IndexOf(num) = -1 Then '尋找已抽牌陣列有沒有一樣的牌
                '都沒有 回傳-1
                card.Add(num) '加入已抽牌陣列
                count = count + 1
                If count = n1 * 2 Then Exit Do '當發牌次數=局數*2 結束發牌
            End If
        Loop
        FileClose(1)

        For i = 0 To n1 * 2 - 1 Step 2 '陣列從0開始計數 i從0開始 而每一局發兩張牌所以step2
            Dim disp = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"} '題目要求0-12 為A-K
            pp = card(i) Mod 13
            bp = card(i + 1) Mod 13
            player = suit(card(i) \ 13) & disp(pp) '\13 取整數找出花色,再搭配點數數値
            banker = suit(card(i + 1) \ 13) & disp(bp)
            If pp = 0 Then pp = 99
            If bp = 0 Then bp = 99
            If pp > bp Then result = "玩家贏"
            If pp < bp Then result = "莊家贏"
            If pp = bp Then result = "平手"

            dt.Rows.Add(s, player, banker, result)
            s += 1
        Next
        DataGridView1.DataSource = dt




    End Sub
End Class
