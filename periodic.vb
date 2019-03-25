Public Class periodic

    Private Sub SaveNewElementsBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveNewElementsBut.Click

        Dim itemChecked As Object
        Dim i As Integer = 0
        Dim elem As String

        Array.Resize(Main.StandartElements, CheckedListBoxPeriodic.CheckedItems.Count)

        For Each itemChecked In CheckedListBoxPeriodic.CheckedItems
            Main.StandartElements(i) = itemChecked
            i += 1

        Next

        Main.CheckedListBox_Separate_Elements.Items.Clear()
        Main.CheckedListBox_Separate_Elements.Items.AddRange(Main.StandartElements)

        My.MySettings.Default.StandartElement = ""
        i = 0
        For Each elem In Main.StandartElements
            If i = Main.StandartElements.Count() - 1 Then
                My.MySettings.Default.StandartElement = My.MySettings.Default.StandartElement & elem
            Else
                My.MySettings.Default.StandartElement = My.MySettings.Default.StandartElement & elem & ","
            End If
            i += 1
        Next

        Main.ElmntInStndrtsInit()

        Main.Visible = True
        Me.Visible = False
    End Sub

    Private Sub SetDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetDefault.Click

        Me.CheckedListBoxPeriodic.Items.Clear()
        Me.CheckedListBoxPeriodic.Items.AddRange(Split(My.MySettings.Default.AllElement, ","))

        Main.DefaultElements = Split(My.MySettings.Default.DefaultElements, ",")

        For i = 0 To Main.DefaultElements.GetLength(0) - 1 'getLength 0 дает размерность первого измерения
            For j = 0 To Me.CheckedListBoxPeriodic.Items.Count - 1
                If Me.CheckedListBoxPeriodic.Items(j) = Main.DefaultElements(i) Then
                    Me.CheckedListBoxPeriodic.SetItemChecked(j, True)
                    Exit For
                End If
            Next
        Next

        Main.StandartElements = Main.DefaultElements

    End Sub

    Private Sub DelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelAll.Click
        For j = 0 To Me.CheckedListBoxPeriodic.Items.Count - 1
            If Me.CheckedListBoxPeriodic.GetItemCheckState(j) = CheckState.Checked Then
                Me.CheckedListBoxPeriodic.SetItemChecked(j, False)
            End If
        Next
    End Sub

    Private Sub SetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetAll.Click
        For j = 0 To Me.CheckedListBoxPeriodic.Items.Count - 1
            If Me.CheckedListBoxPeriodic.GetItemCheckState(j) = CheckState.Unchecked Then
                Me.CheckedListBoxPeriodic.SetItemChecked(j, True)
            End If
        Next
    End Sub

    Private Sub periodic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CheckedListBoxPeriodic.Items.AddRange(Split(My.MySettings.Default.AllElement, ","))
    End Sub

    Private Sub PeriodicClosing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Visible = False
        Main.Visible = True
    End Sub
End Class