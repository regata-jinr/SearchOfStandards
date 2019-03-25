Public Class Main

    Public List_Of_Files(), Elements_In_Standards(,) As String

    Public DefaultElements(), StandartElements(), AllElements() As String

    Public Dimension_i, Dimension_j As Integer
    Public FSI() As IO.FileSystemInfo
    Public Info As IO.FileSystemInfo

    Public Sub ElmntInStndrtsInit()
        Dim DI As IO.DirectoryInfo
        Dim Dir_Name As String

        Dir_Name = "C:\WORKPROG\REF"

        DI = New IO.DirectoryInfo(Dir_Name)
        FSI = DI.GetFileSystemInfos("*.ref") ' все *.ref

        Dim i As Integer = 0 'Подсчет количества *.ref
        StandartElements = Split(My.MySettings.Default.StandartElement, ",")
        Dimension_i = FSI.Count()
        Dimension_j = Me.StandartElements.Count() * 3 + 1 '67*3+1=202 ''так и не понял зачем *3
        ReDim List_Of_Files(Dimension_i - 1)
        ReDim Elements_In_Standards(Dimension_i - 1, Dimension_j - 1)
        Dim k As Integer = 1

        For i = 0 To Dimension_i - 1
            For j = 0 To Dimension_j - 1
                Elements_In_Standards(i, j) = ""
            Next
            For Each elem In Me.StandartElements
                Elements_In_Standards(i, k) = elem
                k += 3
            Next
            k = 1
        Next

        ListBox_REF.Items.Clear()

        i = 0
        For Each Me.Info In Me.FSI
            List_Of_Files(i) = Me.Info.Name
            Elements_In_Standards(i, 0) = Info.Name
            Work_With_File_Of_Standards(Me.Info.Name, i, Dimension_j)
            ListBox_REF.Items.Add(Me.Info.Name)
            i = i + 1
        Next

        MaskedTextBox_Error.Text = "30.00"

    End Sub

    Private Sub Main_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            Me.Text = "Поиск стандартов - " & Application.ProductVersion
            Me.CheckedListBox_Separate_Elements.Items.AddRange(Split(My.MySettings.Default.StandartElement, ","))
            Me.ElmntInStndrtsInit()

            'For Each Me.Info In Me.FSI
            'Work_With_File_Of_Standards(Me.Info.Name, i, Dimension_j)
            '  Next

            'MaskedTextBox_Error.Text = "30.00"

        Catch ex As System.IO.DirectoryNotFoundException
            MsgBox(ex.Message & " || Операция была отменена (ошибка в Main_Shown; возможно, директория C:\WORKPROG\REF не существует)!", MsgBoxStyle.Critical, Me.Text)
            Application.Exit()
        End Try
    End Sub

    Private Sub Work_With_File_Of_Standards(ByVal File_Name_p As String, ByVal i_p As Integer, ByVal Dimension_j_p As Integer)
        Try
            Dim currentRow_p, IZ, PPM, ERR, File_Name_Full_p As String
            File_Name_Full_p = "C:\WORKPROG\REF\" + File_Name_p

            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(File_Name_Full_p, System.Text.Encoding.Default)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(" ")
                While Not MyReader.EndOfData
                    currentRow_p = MyReader.ReadLine

                    currentRow_p = currentRow_p.Trim 'удаляем пробелы в начале и конце строки, если они есть
                    While InStr(currentRow_p, "--") > 0
                        currentRow_p = Replace(currentRow_p, "--", "-") ' заменяем все двойные тире одинарными
                    End While
                    If currentRow_p = "-" Then
                        currentRow_p = MyReader.ReadLine
                        currentRow_p = currentRow_p.Trim 'удаляем пробелы в начале и конце строки, если они есть
                        While InStr(currentRow_p, "  ") > 0
                            currentRow_p = Replace(currentRow_p, "  ", " ") ' заменяем все двойные пробелы одинарными
                        End While
                        If currentRow_p.StartsWith("IZ PPM ERR.,%") Then
                            currentRow_p = MyReader.ReadLine
                            currentRow_p = currentRow_p.Trim 'удаляем пробелы в начале и конце строки, если они есть
                            While InStr(currentRow_p, "--") > 0
                                currentRow_p = Replace(currentRow_p, "--", "-") ' заменяем все двойные пробелы одинарными
                            End While
                            ' msgbox("Похоже, правильный формат файла сертифицированных концентраций!", MsgBoxStyle.Exclamation, Me.Text)
                            currentRow_p = MyReader.ReadLine
                            IZ = ""
                            PPM = ""
                            ERR = ""
                            ' Debug.WriteLine(File_Name_Full_p)
a:                          data_ident_REF(currentRow_p, IZ, PPM, ERR)

                            For j = 0 To Dimension_j_p - 1
                                If Elements_In_Standards(i_p, j).ToUpper = IZ.ToUpper Then
                                    Elements_In_Standards(i_p, j + 1) = PPM
                                    Elements_In_Standards(i_p, j + 2) = ERR
                                End If
                            Next

                            currentRow_p = MyReader.ReadLine
                            If currentRow_p.Length > 1 Then GoTo a
                        End If
                    End If
                End While
            End Using
            ' Catch nex As NullReferenceException

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End Try
    End Sub

    Private Sub data_ident_REF(ByVal currentRow_p As String, ByRef nuclide_p As String, ByRef PPM_p As String, ByRef ERR_p As String)
        Try
            currentRow_p = currentRow_p.Trim 'удаляем пробелы в начале и конце строки, если они есть
            While InStr(currentRow_p, "  ") > 0
                currentRow_p = Replace(currentRow_p, "  ", " ") ' заменяем все двойные пробелы одинарными
            End While
            currentRow_p = currentRow_p + " " 'добавляем пробел в конец строки
            nuclide_p = Mid(currentRow_p, 1, InStr(1, currentRow_p, " ") - 1) 'нуклид-первое слово до пробела
            currentRow_p = Replace(currentRow_p, nuclide_p + " ", "", 1, 1)
            '  Debug.WriteLine(currentRow_p & "  " & currentRow_p.Length())
            If (currentRow_p.Length() < 4) Then Exit Sub
            PPM_p = Val(Mid(currentRow_p, 1, InStr(1, currentRow_p, " ") - 1))
            'только русские рег. параметры PPM_p = CDbl(Replace(Mid(currentRow_p, 1, InStr(1, currentRow_p, " ") - 1), ".", ",", 1, 1))
            currentRow_p = Replace(currentRow_p, Mid(currentRow_p, 1, InStr(1, currentRow_p, " ") - 1) + " ", "", 1, 1)
            ERR_p = Val(Mid(currentRow_p, 1, InStr(1, currentRow_p, " ") - 1))
            'только русские рег. параметры ERR_p = CDbl(Replace(Mid(currentRow_p, 1, InStr(1, currentRow_p, " ") - 1), ".", ",", 1, 1))
        Catch ex As Exception
            'If language = "russian" Then
            MsgBox(ex.ToString, MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End Try
    End Sub

    Private Sub Button_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Search.Click
        Try
            'Me.ElmntInStndrtsInit()
            Dim At_Least_One_Cheked As Boolean
            Dim All_Elements_Present As Boolean

            At_Least_One_Cheked = False
            All_Elements_Present = True

            For i = 0 To CheckedListBox_Separate_Elements.Items.Count - 1
                If CheckedListBox_Separate_Elements.GetItemChecked(i) = True Then
                    At_Least_One_Cheked = True
                    Exit For
                End If
            Next

            If At_Least_One_Cheked = False Then
                MsgBox("Ни один элемент не выбран!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If

            If MaskedTextBox_Error.Text = "  ," Then
                MsgBox("Введите значение ошибки!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If

            DataGridView_Appropriate_Standards.Rows.Clear()
            DataGridView_Appropriate_Standards.Columns.Clear()
            DataGridView_Appropriate_Standards.Columns.Add("File_Name", "Имя файла")

            Dim g As Graphics = DataGridView_Appropriate_Standards.CreateGraphics()
            Dim offset As Integer = Convert.ToInt32(Math.Ceiling(g.MeasureString("  ", DataGridView_Appropriate_Standards.Font).Width))


            For i = 0 To CheckedListBox_Separate_Elements.Items.Count - 1
                If CheckedListBox_Separate_Elements.GetItemChecked(i) = True Then
                    DataGridView_Appropriate_Standards.Columns.Add(CheckedListBox_Separate_Elements.Items(i).ToString.ToUpper + "_PPM", CheckedListBox_Separate_Elements.Items(i).ToString.ToUpper + " PPM")
                    DataGridView_Appropriate_Standards.Columns(DataGridView_Appropriate_Standards.Columns.Count - 1).Width = Convert.ToInt32(Math.Ceiling(g.MeasureString("ERR.,%", DataGridView_Appropriate_Standards.Font).Width)) + offset

                    DataGridView_Appropriate_Standards.Columns.Add(CheckedListBox_Separate_Elements.Items(i).ToString.ToUpper + "_ERR", CheckedListBox_Separate_Elements.Items(i).ToString.ToUpper + " ERR.,%")
                    DataGridView_Appropriate_Standards.Columns(DataGridView_Appropriate_Standards.Columns.Count - 1).Width = Convert.ToInt32(Math.Ceiling(g.MeasureString("ERR.,%", DataGridView_Appropriate_Standards.Font).Width)) + offset
                End If
            Next

            Dim DGV_AS_Rows_Count As Integer
            DGV_AS_Rows_Count = 1

            For i_EIS = 0 To Dimension_i - 1 ' строка - файлы REF
                ' проверка на существование всех отмеченных элементов в текущей строчке таблицы элементов по стандартам
                For j_EIS = 1 To Dimension_j - 1 Step 3 ' столб - элементы
                    For i_CLB_SE = 0 To CheckedListBox_Separate_Elements.Items.Count - 1
                        If CheckedListBox_Separate_Elements.GetItemChecked(i_CLB_SE) = True Then
                            If CheckedListBox_Separate_Elements.Items(i_CLB_SE).ToString.ToUpper = Elements_In_Standards(i_EIS, j_EIS).ToUpper Then
                                If Elements_In_Standards(i_EIS, j_EIS + 1) = "" And Elements_In_Standards(i_EIS, j_EIS + 2) = "" Then
                                    'MsgBox("значение пустое!", MsgBoxStyle.Exclamation, Me.Text)
                                    All_Elements_Present = False
                                ElseIf Elements_In_Standards(i_EIS, j_EIS + 1) <> "" And Elements_In_Standards(i_EIS, j_EIS + 2) <> "" Then
                                    If CDbl(Elements_In_Standards(i_EIS, j_EIS + 2)) > CDbl(MaskedTextBox_Error.Text) Then
                                        All_Elements_Present = False
                                    Else
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next

                ' если все отмеченные элементы есть в текущей строчке таблицы элементов по стандартам, надо занести данные из таблицы элементов по стандартам в DataGridView
                If All_Elements_Present = True Then
                    'If DataGridView_Appropriate_Standards.Rows.Item(0).Cells.Item(0).Value <> "" Then DataGridView_Appropriate_Standards.Rows.Add()
                    DataGridView_Appropriate_Standards.Rows.Add()

                    ' заносим имя файла REF в первую ячейку строки DataGridView
                    DataGridView_Appropriate_Standards.Rows.Item(DGV_AS_Rows_Count - 1).Cells.Item(0).Value = Elements_In_Standards(i_EIS, 0)
                    For j_EIS = 1 To Dimension_j - 1 Step 3 ' столб - элементы
                        For i_CLB_SE = 0 To CheckedListBox_Separate_Elements.Items.Count - 1
                            If CheckedListBox_Separate_Elements.GetItemChecked(i_CLB_SE) = True Then
                                If CheckedListBox_Separate_Elements.Items(i_CLB_SE).ToString.ToUpper = Elements_In_Standards(i_EIS, j_EIS).ToUpper Then
                                    If Elements_In_Standards(i_EIS, j_EIS + 1) = "" And Elements_In_Standards(i_EIS, j_EIS + 2) = "" Then
                                        'MsgBox("значение пустое!", MsgBoxStyle.Exclamation, Me.Text)
                                        'All_Elements_Present = False
                                    ElseIf Elements_In_Standards(i_EIS, j_EIS + 1) <> "" And Elements_In_Standards(i_EIS, j_EIS + 2) <> "" Then
                                        If CDbl(Elements_In_Standards(i_EIS, j_EIS + 2)) > CDbl(MaskedTextBox_Error.Text) Then
                                            'All_Elements_Present = False
                                        Else
                                            For j_DGV_AS = 1 To DataGridView_Appropriate_Standards.Columns.Count - 1 Step 2
                                                If Mid(DataGridView_Appropriate_Standards.Columns.Item(j_DGV_AS).Name, 1, InStr(1, DataGridView_Appropriate_Standards.Columns.Item(j_DGV_AS).Name, "_") - 1).ToUpper = Elements_In_Standards(i_EIS, j_EIS).ToUpper Then
                                                    DataGridView_Appropriate_Standards.Rows.Item(DGV_AS_Rows_Count - 1).Cells.Item(j_DGV_AS).Value = Elements_In_Standards(i_EIS, j_EIS + 1)
                                                    DataGridView_Appropriate_Standards.Rows.Item(DGV_AS_Rows_Count - 1).Cells.Item(j_DGV_AS + 1).Value = Elements_In_Standards(i_EIS, j_EIS + 2)
                                                End If
                                            Next
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Next
                    DGV_AS_Rows_Count = DGV_AS_Rows_Count + 1
                End If
                All_Elements_Present = True
            Next
            For i = 0 To DataGridView_Appropriate_Standards.Rows.Count - 1
                DataGridView_Appropriate_Standards.Rows.Item(i).Selected = False
            Next
        Catch ex As Exception
            MsgBox("Операция была отменена (ошибка в Button_Search_Click)!", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End Try
    End Sub


    Private Sub Button_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Delete.Click
        Try
            Dim At_Least_One_Row_Selected As Boolean
            At_Least_One_Row_Selected = False
            For i = 0 To DataGridView_Appropriate_Standards.Rows.Count - 1
                If DataGridView_Appropriate_Standards.Rows.Item(i).Selected = True Then
                    At_Least_One_Row_Selected = True
                End If
            Next
            If At_Least_One_Row_Selected = False Then
                MsgBox("Выберите строку!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            DataGridView_Appropriate_Standards.Rows.RemoveAt(DataGridView_Appropriate_Standards.SelectedRows.Item(0).Index)
        Catch ex As Exception
            MsgBox("Операция была отменена (ошибка в Button_Delete_Click)!", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End Try
    End Sub

    Private Sub Button_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Save.Click
        Try
            If DataGridView_Appropriate_Standards.Rows.Count = 0 Then
                MsgBox("Таблица пустая!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If

            SaveFileDialog_Standards.InitialDirectory = "C:\GENIE2K\REF"
            SaveFileDialog_Standards.FileName = "Standards.xlsx"
            If SaveFileDialog_Standards.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then ' Эта строчка открывает диалог и сравнивает результат с cancel 
                Exit Sub
            ElseIf System.Windows.Forms.DialogResult.OK Then ' Эта строчка только сравнивает результат с OK 
                Dim s As String
                Dim oExcel As Object
                Dim oBook As Object
                Dim oSheet As Object
                'Открыть новую книгу Excel
                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add
                oSheet = oBook.Worksheets(1)
                '    oSheet.Rows("3").WrapText = True

                oSheet.columns("A").WrapText = True ' Переносить по словам
                oSheet.columns("B").WrapText = True ' Переносить по словам

                oSheet.columns("A").ColumnWidth = 12

                If CheckedListBox_Separate_Elements.CheckedItems.Count <> 0 Then
                    oSheet.Range("A1").value = "Выбранные элементы:"
                    oSheet.Range("A1").HorizontalAlignment = -4108
                    oSheet.Range("A1").VerticalAlignment = -4108
                    s = ""
                    For i = 0 To CheckedListBox_Separate_Elements.CheckedItems.Count - 1
                        If i = 0 Then
                            s = CheckedListBox_Separate_Elements.CheckedItems.Item(i)
                        Else
                            s = s + ", " + CheckedListBox_Separate_Elements.CheckedItems.Item(i)
                        End If
                    Next

                    oSheet.Range("B1").value = s
                    oSheet.Range("B1").HorizontalAlignment = -4108
                    oSheet.Range("B1").VerticalAlignment = -4108

                    oSheet.Range("A2").value = "Ошибка меньше, %:"
                    oSheet.Range("A2").HorizontalAlignment = -4108
                    oSheet.Range("A2").VerticalAlignment = -4108

                    oSheet.Range("B2").value = MaskedTextBox_Error.Text
                    oSheet.Range("B2").HorizontalAlignment = -4108
                    oSheet.Range("B2").VerticalAlignment = -4108
                End If

                Dim current_string As String
                Dim IZ As String

                For j = 0 To DataGridView_Appropriate_Standards.ColumnCount - 1
                    If j = 0 Then
                        ' назание "Имя файла"
                        s = column_letters(j + 1) + CStr(4)
                        oSheet.Range(s).HorizontalAlignment = -4108
                        oSheet.Range(s).VerticalAlignment = -4108
                        oSheet.Range(s).Value = DataGridView_Appropriate_Standards.Columns.Item(j).HeaderText
                    ElseIf j > 0 Then

                        s = column_letters(j + 1)
                        oSheet.columns(s).ColumnWidth = 10

                        ' строка с названиями элементов
                        s = column_letters(j + 1) + CStr(3)
                        oSheet.Range(s).HorizontalAlignment = -4108
                        oSheet.Range(s).VerticalAlignment = -4108

                        current_string = DataGridView_Appropriate_Standards.Columns.Item(j).HeaderText

                        IZ = Mid(current_string, 1, InStr(1, current_string, " ") - 1)
                        oSheet.Range(s).Value = IZ

                        current_string = Replace(current_string, IZ + " ", "", 1, 1)

                        ' строка с названиями "PPM ERR.,%"
                        s = column_letters(j + 1) + CStr(4)
                        oSheet.Range(s).HorizontalAlignment = -4108
                        oSheet.Range(s).VerticalAlignment = -4108
                        oSheet.Range(s).Value = current_string

                        If DataGridView_Appropriate_Standards.Columns.Item(j).Visible = False Then
                            oSheet.Columns(column_letters(j + 1)).Hidden = True
                        End If

                    End If

                    For i = 0 To DataGridView_Appropriate_Standards.RowCount - 1
                        s = column_letters(j + 1) + CStr(i + 5)
                        oSheet.Range(s).Value = DataGridView_Appropriate_Standards.Rows.Item(i).Cells.Item(j).Value
                        oSheet.Range(s).HorizontalAlignment = -4108 ' выравнивание по центру
                        oSheet.Range(s).VerticalAlignment = -4108 ' выравнивание по центру

                    Next
                Next

                oBook.SaveAs(SaveFileDialog_Standards.FileName)
                oExcel.Quit()

            End If
        Catch ex As Exception
            MsgBox("Операция была отменена (ошибка в Button_Save_Click; возможно, не закрыт файл *.xlsx)!", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End Try
    End Sub

    Function column_letters(ByVal column_number_p As Integer) As String
        column_letters = 0
        Try
            ' Col_Letters = номер колонки

            If column_number_p > 26 Then
                column_letters = Chr(64 + Int((column_number_p - 1) / 26)) & Chr(65 + ((column_number_p - 1) Mod 26))
            Else
                column_letters = Chr(64 + column_number_p)
            End If
        Catch ex As Exception
            MsgBox("Операция была отменена (ошибка в column_letters)!", MsgBoxStyle.Critical, Me.Text)
            Exit Function
        End Try
    End Function

    Sub groupSet(ByVal DefaultGroup As String, ByVal UserGroup As String)
        Dim i, j As Integer

        If UserGroup = "" Then
            UserGroup = DefaultGroup
        End If
        For i = 0 To CheckedListBox_Separate_Elements.Items.Count - 1
            CheckedListBox_Separate_Elements.SetItemChecked(i, False)
        Next

        For i = 0 To CheckedListBox_Separate_Elements.Items.Count() - 1

            For j = 0 To UserGroup.Split(",").Count() - 1
                If UserGroup.Split(",")(j) = CheckedListBox_Separate_Elements.Items(i) Then
                    CheckedListBox_Separate_Elements.SetItemChecked(i, True)
                End If
            Next
        Next

    End Sub

    Private Sub CheckedListBox_Group_Of_Elements_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CheckedListBox_Group_Of_Elements.MouseUp
        Try
            Dim i As Integer

            For i = 0 To CheckedListBox_Separate_Elements.Items.Count - 1
                CheckedListBox_Separate_Elements.SetItemChecked(i, False)
            Next

            If CheckedListBox_Group_Of_Elements.GetItemChecked(0) = True Then
                groupSet(My.MySettings.Default.DefaultGroupsHlgn, My.MySettings.Default.UserGroupsHlgn)
            End If

            If CheckedListBox_Group_Of_Elements.GetItemChecked(1) = True Then
                groupSet(My.MySettings.Default.DefaultGroupsSL, My.MySettings.Default.UserGroupsSL)
            End If

            If CheckedListBox_Group_Of_Elements.GetItemChecked(2) = True Then
                groupSet(My.MySettings.Default.DefaultGroupsLL1, My.MySettings.Default.UserGroupsLL1)
            End If

            If CheckedListBox_Group_Of_Elements.GetItemChecked(3) = True Then
                groupSet(My.MySettings.Default.DefaultGroupsLL2, My.MySettings.Default.UserGroupsLL2)
            End If

            CheckedListBox_Separate_Elements_SelectedIndexChanged(sender, e)

        Catch ex As Exception
            MsgBox("Операция была отменена (ошибка в CheckedListBox_Group_Of_Elements_SelectedValueChanged)!", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End Try
    End Sub

    Private Sub ListBox_REF_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox_REF.SelectedIndexChanged
        Try
            If ListBox_REF.SelectedItems.Count > 0 Then

                'CheckedListBox_Separate_Elements.ClearSelected()

                For i = 0 To CheckedListBox_Separate_Elements.Items.Count - 1
                    CheckedListBox_Separate_Elements.SetItemChecked(i, False)
                    'CheckedListBox_Separate_Elements.SetSelected(i, False)
                Next

                For i = 0 To CheckedListBox_Group_Of_Elements.Items.Count - 1
                    CheckedListBox_Group_Of_Elements.SetItemChecked(i, False)
                Next

                DataGridView_Appropriate_Standards.Rows.Clear()
                DataGridView_Appropriate_Standards.Columns.Clear()
                DataGridView_Appropriate_Standards.Columns.Add("File_Name", "Имя файла")

                Dim g As Graphics = DataGridView_Appropriate_Standards.CreateGraphics()
                Dim offset As Integer = Convert.ToInt32(Math.Ceiling(g.MeasureString("  ", DataGridView_Appropriate_Standards.Font).Width))

                For i = 0 To CheckedListBox_Separate_Elements.Items.Count - 1
                    DataGridView_Appropriate_Standards.Columns.Add(CheckedListBox_Separate_Elements.Items(i).ToUpper + "_PPM", CheckedListBox_Separate_Elements.Items(i).ToUpper + " PPM")
                    DataGridView_Appropriate_Standards.Columns(DataGridView_Appropriate_Standards.Columns.Count - 1).Width = Convert.ToInt32(Math.Ceiling(g.MeasureString("ERR.,%", DataGridView_Appropriate_Standards.Font).Width)) + offset

                    DataGridView_Appropriate_Standards.Columns.Add(CheckedListBox_Separate_Elements.Items(i).ToUpper + "_ERR", CheckedListBox_Separate_Elements.Items(i).ToUpper + " ERR.,%")
                    DataGridView_Appropriate_Standards.Columns(DataGridView_Appropriate_Standards.Columns.Count - 1).Width = Convert.ToInt32(Math.Ceiling(g.MeasureString("ERR.,%", DataGridView_Appropriate_Standards.Font).Width)) + offset
                Next

                ' цикл по всем строкам в листбоксе рефов
                For i_LB_REF = 0 To ListBox_REF.Items.Count - 1
                    ' если реф в листбоксе выделен
                    If ListBox_REF.GetSelected(i_LB_REF) = True Then
                        ' цикл по всему массиву элементов в стандартах
                        For i_EIS = 0 To Dimension_i - 1 ' строка - файлы REF
                            ' находим совпадающие имена файлов рефов
                            If ListBox_REF.Items.Item(i_LB_REF) = Elements_In_Standards(i_EIS, 0) Then
                                ' если нашли, добавляем строку в таблицу подходящих стандартов
                                DataGridView_Appropriate_Standards.Rows.Add()
                                ' ищем номер добавленной строки
                                Dim Added_String_Number As Integer
                                For i_DG_A_S = 0 To DataGridView_Appropriate_Standards.Rows.Count - 1
                                    If DataGridView_Appropriate_Standards.Rows.Item(i_DG_A_S).Cells(0).Value = "" Then
                                        Added_String_Number = i_DG_A_S
                                    End If
                                Next
                                ' записываем в нулевую ячейку добавленной строки имя файла REF
                                DataGridView_Appropriate_Standards.Rows.Item(Added_String_Number).Cells(0).Value = Elements_In_Standards(i_EIS, 0)
                                For j_EIS = 1 To Dimension_j - 1 Step 3 ' столб - элементы в массиве элементов в стандартах
                                    For j_DG_A_S = 1 To DataGridView_Appropriate_Standards.ColumnCount - 1 Step 2 ' столб - элементы в гриде
                                        Dim Current_Izotop As String
                                        Current_Izotop = Mid(DataGridView_Appropriate_Standards.Columns.Item(j_DG_A_S).HeaderText, 1, InStr(1, DataGridView_Appropriate_Standards.Columns.Item(j_DG_A_S).HeaderText, " ") - 1)
                                        ' ищем совпадающие элементы
                                        If Elements_In_Standards(i_EIS, j_EIS).ToUpper = Current_Izotop.ToUpper Then
                                            ' если нашли, записываем данные в грид
                                            DataGridView_Appropriate_Standards.Rows.Item(Added_String_Number).Cells(j_DG_A_S).Value = Elements_In_Standards(i_EIS, j_EIS + 1)
                                            DataGridView_Appropriate_Standards.Rows.Item(Added_String_Number).Cells(j_DG_A_S + 1).Value = Elements_In_Standards(i_EIS, j_EIS + 2)
                                        End If
                                    Next
                                Next
                            End If
                        Next
                    End If
                Next

                Dim All_Cells_Empty As String
                All_Cells_Empty = True
                For j_DG_A_S = 1 To DataGridView_Appropriate_Standards.ColumnCount - 1 Step 2
                    For i_DG_A_S = 0 To DataGridView_Appropriate_Standards.RowCount - 1
                        If DataGridView_Appropriate_Standards.Rows.Item(i_DG_A_S).Cells.Item(j_DG_A_S).Value <> "" Then
                            All_Cells_Empty = False
                        End If
                        If DataGridView_Appropriate_Standards.Rows.Item(i_DG_A_S).Cells.Item(j_DG_A_S + 1).Value <> "" Then
                            All_Cells_Empty = False
                        End If
                    Next
                    If All_Cells_Empty = True Then
                        DataGridView_Appropriate_Standards.Columns.Item(j_DG_A_S).Visible = False
                        DataGridView_Appropriate_Standards.Columns.Item(j_DG_A_S + 1).Visible = False
                    Else
                        All_Cells_Empty = True
                    End If
                Next

                For i = 0 To DataGridView_Appropriate_Standards.Rows.Count - 1
                    DataGridView_Appropriate_Standards.Rows.Item(i).Selected = False
                Next
            End If

        Catch ex As Exception
            MsgBox("Операция была отменена (ошибка в ListBox_REF_SelectedIndexChanged)!", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End Try
    End Sub

    Private Sub CheckedListBox_Separate_Elements_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox_Separate_Elements.SelectedIndexChanged
        DataGridView_Appropriate_Standards.Rows.Clear()
        DataGridView_Appropriate_Standards.Columns.Clear()
        For i = 0 To ListBox_REF.Items.Count - 1
            ListBox_REF.ClearSelected()
        Next
    End Sub

    Private Sub AddElem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddElem.Click
        periodic.Visible = True
        Me.Visible = False

        StandartElements = Split(My.MySettings.Default.StandartElement, ",")

        For i = 0 To StandartElements.GetLength(0) - 1 'getLength 0 дает размерность первого измерения
            For j = 0 To periodic.CheckedListBoxPeriodic.Items.Count - 1
                If periodic.CheckedListBoxPeriodic.Items(j) = StandartElements(i) Then
                    periodic.CheckedListBoxPeriodic.SetItemChecked(j, True)
                    Exit For
                End If
            Next
        Next

    End Sub

    Private Sub ChangeGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeGroup.Click
        SetGroupOfElements.Visible = True
        Me.Visible = False
    End Sub

End Class

