Imports MySql.Data.MySqlClient

Module Module1

    Public CuDr As String       ''exeの動くカレントディレクトリを格納
    Public mysqlCon As New MySqlConnection
    Public sqlCommand As New MySqlCommand

    Sub sql_st()
        ''データベースに接続

        Dim Builder = New MySqlConnectionStringBuilder()
        ' データベースに接続するために必要な情報をBuilderに与える。データベース情報はGitに乗せないこと。
        Builder.Server = ""
        Builder.Port =
        Builder.UserID = ""
        Builder.Password = ""
        Builder.Database = ""
        Dim ConStr = Builder.ToString()

        mysqlCon.ConnectionString = ConStr
        mysqlCon.Open()

    End Sub

    Sub sql_cl()
        ' データベースの切断
        mysqlCon.Close()
    End Sub

    Function sql_result_return(ByVal query As String) As DataTable
        ''データセットを返すSELECT系のSQLを処理するコード

        Dim dt As New DataTable()

        Try
            ' 4.データ取得のためのアダプタの設定
            Dim Adapter = New MySqlDataAdapter(query, mysqlCon)

            ' 5.データを取得
            Dim Ds As New DataSet
            Adapter.Fill(dt)

            Return dt
        Catch ex As Exception

            Return dt
        End Try

    End Function

    Function sql_result_no(ByVal query As String)
        ''データセットを返さない、DELETE、UPDATE、INSERT系のSQLを処理するコード

        System.Threading.Thread.Sleep(500)

        Try
            sqlCommand.Connection = mysqlCon
            sqlCommand.CommandText = query
            sqlCommand.ExecuteNonQuery()

            Return "Complete"
        Catch ex As Exception

            Return ex.Message
        End Try

    End Function

    Sub close_save()
        ''設定用ファイルの保存

        Dim dtx1 As String = ""

        For lp1 As Integer = 1 To 1
            Dim tbxn1 As String = "Cf_TextBox" & lp1.ToString

            Dim cs As Control() = Form1.Controls.Find(tbxn1, True)
            If cs.Length > 0 Then
                dtx1 &= CType(cs(0), TextBox).Text
                dtx1 &= vbCrLf
            End If
        Next


        Dim stCurrentDir As String = System.IO.Directory.GetCurrentDirectory()
        CuDr = stCurrentDir

        Dim excsv1 As IO.StreamWriter
        excsv1 = New IO.StreamWriter(CuDr & "\config.ini", False, System.Text.Encoding.GetEncoding("shift_jis"))
        excsv1.Write(dtx1)
        excsv1.Close()
        excsv1.Dispose()

    End Sub

    Sub bu1c()

        ''処理3⇒ダウンロードファイルをデータベースに取り込み

        Dim lfn01 = Form1.TextBox1.Text
        Dim lfn02 = Form1.TextBox2.Text

        ''データベースと接続
        Call sql_st()

        Dim arrCsvData As New System.Collections.ArrayList()

        ''ファイル1の日時を確保
        Dim fts1 As DateTime = System.IO.File.GetLastWriteTime(lfn01)

        ''同じ時間のファイルが既に読み込まれていないかチェック
        Dim sql1 As New System.Text.StringBuilder()
        Dim fldl1 As New System.Text.StringBuilder()
        Dim fldl2 As New System.Text.StringBuilder()
        Dim sqlh As New System.Text.StringBuilder()

        sql1.Clear()
        sql1.Append("SELECT * FROM file_date_time WHERE table_name = 'amazon_details_exhibition' AND inp_datetime = '")
        sql1.Append(fts1.ToString)
        sql1.Append("';")

        Dim dTb1 As DataTable = sql_result_return(sql1.ToString)

        If dTb1.Rows.Count = 0 Then
            ''データが見つからない⇒登録作業

            ''ファイル1を読み込み(SJIS)
            Dim swText1 As New FileIO.TextFieldParser(lfn01, System.Text.Encoding.GetEncoding(932))

            swText1.TextFieldType = FileIO.FieldType.Delimited
            swText1.Delimiters = New String() {vbTab}

            swText1.HasFieldsEnclosedInQuotes = True
            swText1.TrimWhiteSpace = True


            While Not swText1.EndOfData

                Dim fields As String() = swText1.ReadFields()
                arrCsvData.Add(fields)

            End While

            Dim lpce As Integer = arrCsvData.Count

            'ファイルを解放します。
            swText1.Close()

            'newestテーブルを削除
            sql1.Clear()
            sql1.Append("DELETE FROM amazon_details_exhibition_newest;")
            Dim rst As String = sql_result_no(sql1.ToString)
            If rst <> "Complete" Then
                MsgBox("SQLが正常に反映されませんでした", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "警告")
                Debug.Print(sql1.ToString)
            End If

            '読み込んだ要素をSQLに合成
            Dim ln As Integer = 0
            Dim lpc1 As Integer = 0
            sql1.Clear()
            sqlh.Clear()
            fldl1.Clear()

            sqlh.Append("INSERT INTO amazon_details_exhibition_newest (")

            For Each arr As String() In arrCsvData
                sql1.Append("(")

                ''読み取った行を要素に分解
                For i As Integer = 0 To (arr.Length - 1)

                    If ln < 1 Then
                        ''カウンタが0＝これはヘッダ
                        fldl1.Append("`")
                        fldl1.Append(CType(arr(i), String))
                        fldl1.Append("`")


                        If i < (arr.Length - 1) Then
                            fldl1.Append(",")
                        Else
                            sqlh.Append(fldl1)
                            sqlh.Append(") VALUES ")
                        End If

                        sql1.Clear()

                    Else
                        ''カウンタが0以上＝データのブロック
                        Select Case i
                            Case 0, 1, 2, 3, 4, 9, 13, 15, 28, 29, 30, 32
                                If arr(i) = "" Then
                                    sql1.Append("NULL")
                                Else
                                    Dim txtelement As String = arr(i).ToString

                                    txtelement = txtelement.Replace("\", "\\")
                                    txtelement = txtelement.Replace("'", "\'")


                                    sql1.Append("'")
                                    sql1.Append(txtelement)
                                    sql1.Append("'")
                                End If


                            Case 5, 6, 8, 10, 11, 12, 14, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 31
                                If arr(i) = "" Then
                                    sql1.Append("NULL")
                                Else
                                    sql1.Append(arr(i))
                                End If

                            Case 7
                                Dim ts As DateTime = arr(i).Replace(" JST", "")
                                Dim dbts As String = ""
                                dbts &= ts.Year.ToString("0000")
                                dbts &= "-"
                                dbts &= ts.Month.ToString("00")
                                dbts &= "-"
                                dbts &= ts.Day.ToString("00")
                                dbts &= " "
                                dbts &= ts.Hour.ToString("00")
                                dbts &= ":"
                                dbts &= ts.Minute.ToString("00")
                                dbts &= ":"
                                dbts &= ts.Second.ToString("00")

                                sql1.Append("'")
                                sql1.Append(dbts)
                                sql1.Append("'")

                            Case Else
                        End Select

                        If i < (arr.Length - 1) Then
                            sql1.Append(",")
                        Else
                            sql1.Append("),")

                        End If
                    End If
                Next
                ln = ln + 1


                Dim chn1 As Integer = Math.Floor(ln / 100)
                Dim chn2 As Integer = Math.Ceiling(ln / 100)

                If chn1 = chn2 Then
                    Form1.Label2.Text = lfn01 & " の" & ln & "行目を読み込み中"
                    Form1.Label2.Refresh()

                    Dim sql0 As String = sqlh.ToString
                    sql0 &= sql1.ToString()
                    Dim ln1 As Long = sql0.Length
                    sql0 = sql0.Substring(0, ln1 - 1)
                    sql0 &= ";"
                    rst = sql_result_no(sql0)
                    If rst <> "Complete" Then
                        MsgBox("SQLが正常に反映されませんでした", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "警告")
                        Debug.Print(sql0)
                    End If

                    sql1.Clear()

                End If
            Next

            If sql1.Length > 0 Then
                Dim sql0 As String = sqlh.ToString
                sql0 &= sql1.ToString()
                Dim ln1 As Long = sql0.Length
                sql0 = sql0.Substring(0, ln1 - 1)
                sql0 &= ";"
                rst = sql_result_no(sql0)
                If rst <> "Complete" Then
                    MsgBox("SQLが正常に反映されませんでした", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "警告")
                    Debug.Print(sql0)
                End If

                sql1.Clear()

            End If

            Form1.Label2.Text = lfn01 & " の" & ln & "行読み込み完了"
            Form1.Label2.Refresh()

            ''ファイル日付を登録
            sql1.Clear()
            sql1.Append("INSERT INTO file_date_time (inp_datetime,table_name)  VALUES ('")
            sql1.Append(fts1.ToString)
            sql1.Append("','amazon_details_exhibition');")
            rst = sql_result_no(sql1.ToString)
            If rst <> "Complete" Then
                MsgBox("SQLが正常に反映されませんでした", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "警告")
                Debug.Print(sql1.ToString)
            End If
        Else
            MsgBox(fts1.ToString & "のdl-item***.csvファイルは既に登録されています", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "通知")
            Debug.Print("")

        End If

        arrCsvData.Clear()

        ''ファイル2の日時を確保
        Dim fts2 As DateTime = System.IO.File.GetLastWriteTime(lfn02)

        ''同じ時間のファイルが既に読み込まれていないかチェック
        sql1.Clear()
        sql1.Append("SELECT * FROM file_date_time WHERE table_name = 'amazon_exhibition' AND inp_datetime = '")
        sql1.Append(fts2.ToString)
        sql1.Append("';")

        Dim dTb2 As DataTable = sql_result_return(sql1.ToString)

        If dTb2.Rows.Count = 0 Then
            ''データが見つからない⇒登録作業

            ''ファイル1を読み込み(SJIS)
            Dim swText2 As New FileIO.TextFieldParser(lfn02, System.Text.Encoding.GetEncoding(932))

            swText2.TextFieldType = FileIO.FieldType.Delimited
            swText2.Delimiters = New String() {vbTab}

            swText2.HasFieldsEnclosedInQuotes = True
            swText2.TrimWhiteSpace = True


            While Not swText2.EndOfData

                Dim fields As String() = swText2.ReadFields()
                arrCsvData.Add(fields)

            End While

            Dim lpce As Integer = arrCsvData.Count

            'ファイルを解放します。
            swText2.Close()

            'newestテーブルを削除
            sql1.Clear()
            sql1.Append("DELETE FROM amazon_exhibition_newest;")
            Dim rst As String = sql_result_no(sql1.ToString)
            If rst <> "Complete" Then
                MsgBox("SQLが正常に反映されませんでした", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "警告")
                Debug.Print(sql1.ToString)
            End If


            '読み込んだ要素をSQLに合成
            Dim ln As Integer = 0
            Dim lpc1 As Integer = 0
            sql1.Clear()
            sqlh.Clear()
            fldl2.Clear()
            sqlh.Append("INSERT INTO amazon_exhibition_newest (")

            For Each arr As String() In arrCsvData
                sql1.Append("(")

                ''読み取った行を要素に分解
                For i As Integer = 0 To (arr.Length - 1)

                    If ln < 1 Then
                        ''カウンタが0＝これはヘッダ
                        fldl2.Append("`")
                        fldl2.Append(CType(arr(i), String))
                        fldl2.Append("`")

                        If i < (arr.Length - 1) Then
                            fldl2.Append(",")
                        Else
                            sqlh.Append(fldl2)
                            sqlh.Append(") VALUES ")
                        End If

                        sql1.Clear()

                    Else
                        ''カウンタが0以上＝データのブロック
                        Select Case i
                            Case 0, 1
                                If arr(i) = "" Then
                                    sql1.Append("NULL")
                                Else
                                    sql1.Append("'")
                                    sql1.Append(arr(i).Replace("'", "\'"))
                                    sql1.Append("'")
                                End If


                            Case 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
                                If arr(i) = "" Then
                                    sql1.Append("NULL")
                                Else
                                    sql1.Append(arr(i))
                                End If

                            Case Else
                        End Select

                        If i < (arr.Length - 1) Then
                            sql1.Append(",")
                        Else
                            If ln < lpce Then
                                sql1.Append("),")
                            Else
                                sql1.Append("),")
                            End If

                        End If
                    End If
                Next
                ln = ln + 1

                Dim chn1 As Integer = Math.Floor(ln / 100)
                Dim chn2 As Integer = Math.Ceiling(ln / 100)

                If chn1 = chn2 Then
                    Form1.Label2.Text = lfn02 & " の" & ln & "行目を読み込み中"
                    Form1.Label2.Refresh()

                    Dim sql0 As String = sqlh.ToString
                    sql0 &= sql1.ToString()
                    Dim ln1 As Long = sql0.Length
                    sql0 = sql0.Substring(0, ln1 - 1)
                    sql0 &= ";"
                    rst = sql_result_no(sql0)
                    If rst <> "Complete" Then
                        MsgBox("SQLが正常に反映されませんでした", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "警告")
                        Debug.Print(sql0)
                    End If

                    sql1.Clear()

                End If

            Next

            If sql1.Length > 0 Then
                Dim sql0 As String = sqlh.ToString
                sql0 &= sql1.ToString()
                Dim ln1 As Long = sql0.Length
                sql0 = sql0.Substring(0, ln1 - 1)
                sql0 &= ";"
                rst = sql_result_no(sql0)
                If rst <> "Complete" Then
                    MsgBox("SQLが正常に反映されませんでした", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "警告")
                    Debug.Print(sql0)
                End If

                sql1.Clear()

            End If

            Form1.Label2.Text = lfn02 & " の" & ln & "行読み込み完了"
            Form1.Label2.Refresh()

            sql1.Clear()
            sql1.Append("INSERT INTO file_date_time (inp_datetime,table_name)  VALUES ('")
            sql1.Append(fts2.ToString)
            sql1.Append("','amazon_exhibition');")
            rst = sql_result_no(sql1.ToString)
            If rst <> "Complete" Then
                MsgBox("SQLが正常に反映されませんでした", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "警告")
                Debug.Print(sql1.ToString)
            End If

            ''product-idをASINコードに変換。
            Dim sql2 As String = "UPDATE `amazon_details_exhibition_newest`,`amazon_exhibition_newest`"
            sql2 &= " SET `amazon_details_exhibition_newest`.`商品ID` = `amazon_exhibition_newest`.`asin`"
            sql2 &= " WHERE `amazon_details_exhibition_newest`.`出品者SKU` = `amazon_exhibition_newest`.`出品者SKU`"
            sql2 &= ";"

            rst = sql_result_no(sql2)
            If rst <> "Complete" Then
                MsgBox("SQLが正常に反映されませんでした", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "警告")
                Debug.Print(sql2)
            End If


            'newestテーブルを累積テーブルへINSERT
            sql1.Clear()
            sql1.Append("INSERT INTO amazon_details_exhibition (`CSV作成日時`,")
            sql1.Append(fldl1)
            sql1.Append(") SELECT '")
            sql1.Append(fts1.ToString)
            sql1.Append("' AS `CSV作成日時`,")
            sql1.Append(fldl1)
            sql1.Append(" FROM amazon_details_exhibition_newest")
            sql1.Append(";")

            rst = sql_result_no(sql1.ToString)
            If rst <> "Complete" Then
                MsgBox("SQLが正常に反映されませんでした", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "警告")
                Debug.Print(sql1.ToString)
            End If


            'newestテーブルを累積テーブルへINSERT
            sql1.Clear()
            sql1.Append("INSERT INTO amazon_exhibition (`CSV作成日時`,")
            sql1.Append(fldl2)
            sql1.Append(") SELECT '")
            sql1.Append(fts2.ToString)
            sql1.Append("' AS `CSV作成日時`,")
            sql1.Append(fldl2)
            sql1.Append(" FROM amazon_exhibition_newest")
            sql1.Append(";")

            rst = sql_result_no(sql1.ToString)
            If rst <> "Complete" Then
                MsgBox("SQLが正常に反映されませんでした", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "警告")
                Debug.Print(sql1.ToString)
            End If

            Form1.Label2.Text = "読み込み完了"
            Form1.Label2.Refresh()

        Else
            MsgBox(fts2.ToString & "のdl-select***.csvファイルは既に登録されています", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "通知")
        End If


        ''データベースを切断
        Call sql_cl()

    End Sub

End Module
