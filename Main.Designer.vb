<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.CheckedListBox_Separate_Elements = New System.Windows.Forms.CheckedListBox()
        Me.Button_Search = New System.Windows.Forms.Button()
        Me.DataGridView_Appropriate_Standards = New System.Windows.Forms.DataGridView()
        Me.L_Name_Error = New System.Windows.Forms.Label()
        Me.MaskedTextBox_Error = New System.Windows.Forms.MaskedTextBox()
        Me.L_Name_Group_Of_Elements = New System.Windows.Forms.Label()
        Me.CheckedListBox_Group_Of_Elements = New System.Windows.Forms.CheckedListBox()
        Me.Button_Delete = New System.Windows.Forms.Button()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.SaveFileDialog_Standards = New System.Windows.Forms.SaveFileDialog()
        Me.ListBox_REF = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AddElem = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChangeGroup = New System.Windows.Forms.Button()
        CType(Me.DataGridView_Appropriate_Standards, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckedListBox_Separate_Elements
        '
        Me.CheckedListBox_Separate_Elements.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckedListBox_Separate_Elements.CheckOnClick = True
        Me.CheckedListBox_Separate_Elements.ColumnWidth = 70
        Me.CheckedListBox_Separate_Elements.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CheckedListBox_Separate_Elements.FormattingEnabled = True
        Me.CheckedListBox_Separate_Elements.Location = New System.Drawing.Point(228, 27)
        Me.CheckedListBox_Separate_Elements.MultiColumn = True
        Me.CheckedListBox_Separate_Elements.Name = "CheckedListBox_Separate_Elements"
        Me.CheckedListBox_Separate_Elements.Size = New System.Drawing.Size(457, 220)
        Me.CheckedListBox_Separate_Elements.TabIndex = 105
        '
        'Button_Search
        '
        Me.Button_Search.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button_Search.Location = New System.Drawing.Point(300, 400)
        Me.Button_Search.Name = "Button_Search"
        Me.Button_Search.Size = New System.Drawing.Size(140, 25)
        Me.Button_Search.TabIndex = 106
        Me.Button_Search.Text = "Поиск"
        Me.Button_Search.UseVisualStyleBackColor = True
        '
        'DataGridView_Appropriate_Standards
        '
        Me.DataGridView_Appropriate_Standards.AllowUserToAddRows = False
        Me.DataGridView_Appropriate_Standards.AllowUserToResizeRows = False
        Me.DataGridView_Appropriate_Standards.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_Appropriate_Standards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_Appropriate_Standards.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView_Appropriate_Standards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView_Appropriate_Standards.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView_Appropriate_Standards.Location = New System.Drawing.Point(12, 260)
        Me.DataGridView_Appropriate_Standards.MultiSelect = False
        Me.DataGridView_Appropriate_Standards.Name = "DataGridView_Appropriate_Standards"
        Me.DataGridView_Appropriate_Standards.RowHeadersVisible = False
        Me.DataGridView_Appropriate_Standards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView_Appropriate_Standards.Size = New System.Drawing.Size(673, 135)
        Me.DataGridView_Appropriate_Standards.TabIndex = 107
        '
        'L_Name_Error
        '
        Me.L_Name_Error.AutoSize = True
        Me.L_Name_Error.Location = New System.Drawing.Point(118, 109)
        Me.L_Name_Error.Name = "L_Name_Error"
        Me.L_Name_Error.Size = New System.Drawing.Size(104, 13)
        Me.L_Name_Error.TabIndex = 108
        Me.L_Name_Error.Text = "Ошибка меньше, %"
        '
        'MaskedTextBox_Error
        '
        Me.MaskedTextBox_Error.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MaskedTextBox_Error.Location = New System.Drawing.Point(121, 125)
        Me.MaskedTextBox_Error.Mask = "90.09"
        Me.MaskedTextBox_Error.Name = "MaskedTextBox_Error"
        Me.MaskedTextBox_Error.Size = New System.Drawing.Size(53, 23)
        Me.MaskedTextBox_Error.TabIndex = 109
        '
        'L_Name_Group_Of_Elements
        '
        Me.L_Name_Group_Of_Elements.AutoSize = True
        Me.L_Name_Group_Of_Elements.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.L_Name_Group_Of_Elements.Location = New System.Drawing.Point(113, 9)
        Me.L_Name_Group_Of_Elements.Name = "L_Name_Group_Of_Elements"
        Me.L_Name_Group_Of_Elements.Size = New System.Drawing.Size(114, 15)
        Me.L_Name_Group_Of_Elements.TabIndex = 111
        Me.L_Name_Group_Of_Elements.Text = "Группа элементов"
        '
        'CheckedListBox_Group_Of_Elements
        '
        Me.CheckedListBox_Group_Of_Elements.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CheckedListBox_Group_Of_Elements.FormattingEnabled = True
        Me.CheckedListBox_Group_Of_Elements.Items.AddRange(New Object() {"галогены", "КЖИ", "ДЖИ-1", "ДЖИ-2"})
        Me.CheckedListBox_Group_Of_Elements.Location = New System.Drawing.Point(121, 27)
        Me.CheckedListBox_Group_Of_Elements.Name = "CheckedListBox_Group_Of_Elements"
        Me.CheckedListBox_Group_Of_Elements.Size = New System.Drawing.Size(101, 76)
        Me.CheckedListBox_Group_Of_Elements.TabIndex = 110
        '
        'Button_Delete
        '
        Me.Button_Delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button_Delete.Location = New System.Drawing.Point(154, 400)
        Me.Button_Delete.Name = "Button_Delete"
        Me.Button_Delete.Size = New System.Drawing.Size(140, 25)
        Me.Button_Delete.TabIndex = 112
        Me.Button_Delete.Text = "Удалить строку"
        Me.Button_Delete.UseVisualStyleBackColor = True
        '
        'Button_Save
        '
        Me.Button_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button_Save.Location = New System.Drawing.Point(446, 400)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(140, 25)
        Me.Button_Save.TabIndex = 113
        Me.Button_Save.Text = "Сохранить в файл"
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'SaveFileDialog_Standards
        '
        Me.SaveFileDialog_Standards.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        '
        'ListBox_REF
        '
        Me.ListBox_REF.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ListBox_REF.FormattingEnabled = True
        Me.ListBox_REF.ItemHeight = 16
        Me.ListBox_REF.Location = New System.Drawing.Point(9, 27)
        Me.ListBox_REF.Name = "ListBox_REF"
        Me.ListBox_REF.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox_REF.Size = New System.Drawing.Size(106, 212)
        Me.ListBox_REF.TabIndex = 114
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 26)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Список" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "файлов-паспортов"
        '
        'AddElem
        '
        Me.AddElem.Location = New System.Drawing.Point(121, 151)
        Me.AddElem.Name = "AddElem"
        Me.AddElem.Size = New System.Drawing.Size(100, 40)
        Me.AddElem.TabIndex = 116
        Me.AddElem.Text = "Добавить элемент"
        Me.AddElem.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(269, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(343, 20)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Выберите элементы, которые хотите найти"
        '
        'ChangeGroup
        '
        Me.ChangeGroup.Location = New System.Drawing.Point(121, 194)
        Me.ChangeGroup.Name = "ChangeGroup"
        Me.ChangeGroup.Size = New System.Drawing.Size(100, 40)
        Me.ChangeGroup.TabIndex = 118
        Me.ChangeGroup.Text = "Изменить группировку"
        Me.ChangeGroup.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 430)
        Me.Controls.Add(Me.ChangeGroup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.AddElem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox_REF)
        Me.Controls.Add(Me.Button_Save)
        Me.Controls.Add(Me.Button_Delete)
        Me.Controls.Add(Me.L_Name_Group_Of_Elements)
        Me.Controls.Add(Me.CheckedListBox_Group_Of_Elements)
        Me.Controls.Add(Me.MaskedTextBox_Error)
        Me.Controls.Add(Me.L_Name_Error)
        Me.Controls.Add(Me.DataGridView_Appropriate_Standards)
        Me.Controls.Add(Me.Button_Search)
        Me.Controls.Add(Me.CheckedListBox_Separate_Elements)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Поиск стандартов"
        CType(Me.DataGridView_Appropriate_Standards, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckedListBox_Separate_Elements As System.Windows.Forms.CheckedListBox
    Friend WithEvents Button_Search As System.Windows.Forms.Button
    Friend WithEvents DataGridView_Appropriate_Standards As System.Windows.Forms.DataGridView
    Friend WithEvents L_Name_Error As System.Windows.Forms.Label
    Friend WithEvents MaskedTextBox_Error As System.Windows.Forms.MaskedTextBox
    Friend WithEvents L_Name_Group_Of_Elements As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox_Group_Of_Elements As System.Windows.Forms.CheckedListBox
    Friend WithEvents Button_Delete As System.Windows.Forms.Button
    Friend WithEvents Button_Save As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog_Standards As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ListBox_REF As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AddElem As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChangeGroup As System.Windows.Forms.Button

End Class
