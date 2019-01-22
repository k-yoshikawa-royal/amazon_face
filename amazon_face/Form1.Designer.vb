<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label0 = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Cf_Button1 = New System.Windows.Forms.Button()
        Me.Cf_TextBox1 = New System.Windows.Forms.TextBox()
        Me.Cf_Label1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(308, 375)
        Me.TabControl1.TabIndex = 181
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.Label0)
        Me.TabPage1.Controls.Add(Me.Button9)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.TextBox2)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(300, 349)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "メイン"
        '
        'Label0
        '
        Me.Label0.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label0.Location = New System.Drawing.Point(12, 31)
        Me.Label0.Name = "Label0"
        Me.Label0.Size = New System.Drawing.Size(263, 19)
        Me.Label0.TabIndex = 64
        Me.Label0.Text = "アマゾンデータ取込"
        Me.Label0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(213, 320)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 63
        Me.Button9.Text = "閉じる"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button4.Location = New System.Drawing.Point(211, 147)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(71, 23)
        Me.Button4.TabIndex = 50
        Me.Button4.Text = "ファイル選択"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(13, 147)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(192, 19)
        Me.TextBox2.TabIndex = 49
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(263, 19)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "出品レポート"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(269, 83)
        Me.Label2.TabIndex = 47
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 193)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(269, 23)
        Me.Button1.TabIndex = 46
        Me.Button1.Text = "テキストファイル取り込み"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button2.Location = New System.Drawing.Point(213, 99)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 23)
        Me.Button2.TabIndex = 45
        Me.Button2.Text = "ファイル選択"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(15, 99)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(192, 19)
        Me.TextBox1.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(263, 19)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "出品詳細レポート"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LightYellow
        Me.TabPage2.Controls.Add(Me.Cf_Button1)
        Me.TabPage2.Controls.Add(Me.Cf_TextBox1)
        Me.TabPage2.Controls.Add(Me.Cf_Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(300, 349)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "設定"
        '
        'Cf_Button1
        '
        Me.Cf_Button1.Location = New System.Drawing.Point(207, 168)
        Me.Cf_Button1.Name = "Cf_Button1"
        Me.Cf_Button1.Size = New System.Drawing.Size(74, 23)
        Me.Cf_Button1.TabIndex = 24
        Me.Cf_Button1.Text = "設定保存"
        Me.Cf_Button1.UseVisualStyleBackColor = True
        '
        'Cf_TextBox1
        '
        Me.Cf_TextBox1.Location = New System.Drawing.Point(15, 42)
        Me.Cf_TextBox1.Name = "Cf_TextBox1"
        Me.Cf_TextBox1.Size = New System.Drawing.Size(253, 19)
        Me.Cf_TextBox1.TabIndex = 16
        '
        'Cf_Label1
        '
        Me.Cf_Label1.Location = New System.Drawing.Point(13, 20)
        Me.Cf_Label1.Name = "Cf_Label1"
        Me.Cf_Label1.Size = New System.Drawing.Size(218, 19)
        Me.Cf_Label1.TabIndex = 17
        Me.Cf_Label1.Text = "CSVファイル保存場所"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 397)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "出品レポートを読み込む"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label0 As Label
    Friend WithEvents Button9 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Cf_Button1 As Button
    Friend WithEvents Cf_TextBox1 As TextBox
    Friend WithEvents Cf_Label1 As Label
    Friend WithEvents Button1 As Button
End Class
