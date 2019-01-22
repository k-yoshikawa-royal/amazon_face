Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''INIファイルを読み込む。
        Dim dbini As IO.StreamReader
        Dim stCurrentDir As String = System.IO.Directory.GetCurrentDirectory()
        CuDr = stCurrentDir

        If IO.File.Exists(CuDr & "\config.ini") = True Then
            dbini = New IO.StreamReader(CuDr & "\config.ini", System.Text.Encoding.Default)

            For lp1 As Integer = 1 To 1
                Dim tbxn1 As String = "Cf_TextBox" & lp1.ToString

                Dim cs As Control() = Me.Controls.Find(tbxn1, True)
                If cs.Length > 0 Then
                    CType(cs(0), TextBox).Text = dbini.ReadLine
                End If
            Next

            ''メイン作業タブへ
            Me.TabControl1.SelectedTab = TabPage1

            dbini.Close()
            dbini.Dispose()
        Else
            MessageBox.Show("設定ファイルが見つからないか壊れています。", "通知")
            Me.TabControl1.SelectedTab = TabPage2
        End If
    End Sub

    Private Sub Cf_Button1_Click(sender As Object, e As EventArgs) Handles Cf_Button1.Click
        close_save()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '出品詳細レポートをファイル選択するボタン
        Dim ofd As New OpenFileDialog()
        ofd.FileName = "出品詳細レポート+*.txt"
        ofd.InitialDirectory = Cf_TextBox1.Text
        ofd.Filter = "TXTファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*"
        ofd.FilterIndex = 1
        ofd.Title = "Amazonの出品詳細レポートを選択してください。"
        ofd.RestoreDirectory = True
        ofd.CheckFileExists = True
        ofd.CheckPathExists = True

        If ofd.ShowDialog() = DialogResult.OK Then
            ''ファイルがあった場合の処理
            Me.TextBox1.Text = ofd.FileName
        Else
            MessageBox.Show("キャンセルされました", "通知")
        End If

        Me.Button1.Enabled = True
        Me.Refresh()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '出品レポートをファイル選択するボタン
        Dim ofd As New OpenFileDialog()
        ofd.FileName = "出品レポート+*.txt"
        ofd.InitialDirectory = Cf_TextBox1.Text
        ofd.Filter = "TXTファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*"
        ofd.FilterIndex = 1
        ofd.Title = "Amazonの出品レポートを選択してください。"
        ofd.RestoreDirectory = True
        ofd.CheckFileExists = True
        ofd.CheckPathExists = True

        If ofd.ShowDialog() = DialogResult.OK Then
            ''ファイルがあった場合の処理
            Me.TextBox2.Text = ofd.FileName
        Else
            MessageBox.Show("キャンセルされました", "通知")
        End If

        Me.Button1.Enabled = True
        Me.Refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call bu1c()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Dispose()
    End Sub
End Class
