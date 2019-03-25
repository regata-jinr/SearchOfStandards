<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class periodic
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(periodic))
        Me.CheckedListBoxPeriodic = New System.Windows.Forms.CheckedListBox()
        Me.SaveNewElementsBut = New System.Windows.Forms.Button()
        Me.SetDefault = New System.Windows.Forms.Button()
        Me.DelAll = New System.Windows.Forms.Button()
        Me.SetAll = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CheckedListBoxPeriodic
        '
        Me.CheckedListBoxPeriodic.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.CheckedListBoxPeriodic.FormattingEnabled = True
        Me.CheckedListBoxPeriodic.Location = New System.Drawing.Point(24, 34)
        Me.CheckedListBoxPeriodic.MultiColumn = True
        Me.CheckedListBoxPeriodic.Name = "CheckedListBoxPeriodic"
        Me.CheckedListBoxPeriodic.Size = New System.Drawing.Size(504, 544)
        Me.CheckedListBoxPeriodic.TabIndex = 5
        '
        'SaveNewElementsBut
        '
        Me.SaveNewElementsBut.Location = New System.Drawing.Point(534, 202)
        Me.SaveNewElementsBut.Name = "SaveNewElementsBut"
        Me.SaveNewElementsBut.Size = New System.Drawing.Size(100, 50)
        Me.SaveNewElementsBut.TabIndex = 6
        Me.SaveNewElementsBut.Text = "Сохранить добавленные элементы"
        Me.SaveNewElementsBut.UseVisualStyleBackColor = True
        '
        'SetDefault
        '
        Me.SetDefault.Location = New System.Drawing.Point(534, 146)
        Me.SetDefault.Name = "SetDefault"
        Me.SetDefault.Size = New System.Drawing.Size(100, 50)
        Me.SetDefault.TabIndex = 7
        Me.SetDefault.Text = "Восстановить элементы по умолчанию"
        Me.SetDefault.UseVisualStyleBackColor = True
        '
        'DelAll
        '
        Me.DelAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DelAll.Location = New System.Drawing.Point(534, 34)
        Me.DelAll.Name = "DelAll"
        Me.DelAll.Size = New System.Drawing.Size(100, 50)
        Me.DelAll.TabIndex = 8
        Me.DelAll.Text = "Снять все"
        Me.DelAll.UseVisualStyleBackColor = True
        '
        'SetAll
        '
        Me.SetAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.SetAll.Location = New System.Drawing.Point(534, 90)
        Me.SetAll.Name = "SetAll"
        Me.SetAll.Size = New System.Drawing.Size(100, 50)
        Me.SetAll.TabIndex = 9
        Me.SetAll.Text = "Выделить все"
        Me.SetAll.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(20, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(501, 20)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Отметьте элементы, которые хотите добавить в список поиска."
        '
        'periodic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 590)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SetAll)
        Me.Controls.Add(Me.DelAll)
        Me.Controls.Add(Me.SetDefault)
        Me.Controls.Add(Me.SaveNewElementsBut)
        Me.Controls.Add(Me.CheckedListBoxPeriodic)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "periodic"
        Me.Text = "Добавление новых элементов"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckedListBoxPeriodic As System.Windows.Forms.CheckedListBox
    Friend WithEvents SaveNewElementsBut As System.Windows.Forms.Button
    Friend WithEvents SetDefault As System.Windows.Forms.Button
    Friend WithEvents DelAll As System.Windows.Forms.Button
    Friend WithEvents SetAll As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
