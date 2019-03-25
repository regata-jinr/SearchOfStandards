Public Class SetGroupOfElements

    Private Sub SetGroupOfElements_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Me.StandartElemCheckListBox.Items.AddRange(Split(My.MySettings.Default.StandartElement, ","))

        If My.MySettings.Default.UserGroupsHlgn = "" Then
            Me.CheckedListBoxHalogens.Items.AddRange(Split(My.MySettings.Default.DefaultGroupsHlgn, ","))
        Else
            Me.CheckedListBoxHalogens.Items.AddRange(Split(My.MySettings.Default.UserGroupsHlgn, ","))
        End If

        If My.MySettings.Default.UserGroupsSL = "" Then
            Me.CheckedListBoxSL.Items.AddRange(Split(My.MySettings.Default.DefaultGroupsSL, ","))
        Else
            Me.CheckedListBoxSL.Items.AddRange(Split(My.MySettings.Default.UserGroupsSL, ","))
        End If

        If My.MySettings.Default.UserGroupsLL1 = "" Then
            Me.CheckedListBoxLL1.Items.AddRange(Split(My.MySettings.Default.DefaultGroupsLL1, ","))
        Else
            Me.CheckedListBoxLL1.Items.AddRange(Split(My.MySettings.Default.UserGroupsLL1, ","))
        End If

        If My.MySettings.Default.UserGroupsLL2 = "" Then
            Me.CheckedListBoxLL2.Items.AddRange(Split(My.MySettings.Default.DefaultGroupsLL2, ","))
        Else
            Me.CheckedListBoxLL2.Items.AddRange(Split(My.MySettings.Default.UserGroupsLL2, ","))
        End If

    End Sub

    Private Sub SetGroupOfElementsClosing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Visible = False
        Main.Visible = True
    End Sub

    Function groupChng(ByVal UserGroup As String, ByVal CheckListBoxGroup As CheckedListBox) As String

        Dim i As Integer = 0
        Dim elem As String
        Dim UserGroupAr() As String
        UserGroupAr = {}

        Array.Resize(UserGroupAr, CheckListBoxGroup.Items.Count())

        For i = 0 To CheckListBoxGroup.Items.Count() - 1
            UserGroupAr(i) = CheckListBoxGroup.Items(i)
        Next

        UserGroup = ""
        i = 0
        For Each elem In UserGroupAr
            If i = UserGroupAr.Count() - 1 Then
                UserGroup = UserGroup & elem
            Else
                UserGroup = UserGroup & elem & ","
            End If
            i += 1
        Next

        Return UserGroup
    End Function

    Private Sub ButtonAppl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAppl.Click

        My.MySettings.Default.UserGroupsHlgn = groupChng(My.MySettings.Default.UserGroupsHlgn, CheckedListBoxHalogens)
        My.MySettings.Default.UserGroupsSL = groupChng(My.MySettings.Default.UserGroupsSL, CheckedListBoxSL)
        My.MySettings.Default.UserGroupsLL1 = groupChng(My.MySettings.Default.UserGroupsLL1, CheckedListBoxLL1)
        My.MySettings.Default.UserGroupsLL2 = groupChng(My.MySettings.Default.UserGroupsLL2, CheckedListBoxLL2)

        Main.Visible = True
        Me.Visible = False

    End Sub

    Private Sub ButtonDflt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDflt.Click

        Me.CheckedListBoxHalogens.Items.Clear()
        Me.CheckedListBoxSL.Items.Clear()
        Me.CheckedListBoxLL1.Items.Clear()
        Me.CheckedListBoxLL2.Items.Clear()

        My.MySettings.Default.UserGroupsHlgn = My.MySettings.Default.DefaultGroupsHlgn
        My.MySettings.Default.UserGroupsSL = My.MySettings.Default.DefaultGroupsSL
        My.MySettings.Default.UserGroupsLL1 = My.MySettings.Default.DefaultGroupsLL1
        My.MySettings.Default.UserGroupsLL2 = My.MySettings.Default.DefaultGroupsLL2

        Me.CheckedListBoxHalogens.Items.AddRange(My.MySettings.Default.UserGroupsHlgn.Split(","))
        Me.CheckedListBoxSL.Items.AddRange(My.MySettings.Default.UserGroupsSL.Split(","))
        Me.CheckedListBoxLL1.Items.AddRange(My.MySettings.Default.UserGroupsLL1.Split(","))
        Me.CheckedListBoxLL2.Items.AddRange(My.MySettings.Default.UserGroupsLL2.Split(","))

    End Sub

    Sub EllAddToGroup(ByVal CheckListBoxGroup As CheckedListBox)

        Dim elem As String

        For Each elem In Me.StandartElemCheckListBox.CheckedItems
            CheckListBoxGroup.Items.Add(elem)
        Next

    End Sub

    Sub EllDelFromGroup(ByVal CheckListBoxGroup As CheckedListBox)

        For checked As Integer = CheckListBoxGroup.CheckedItems.Count - 1 To 0 Step -1
            CheckListBoxGroup.Items.Remove(CheckListBoxGroup.CheckedItems(checked))
        Next

    End Sub

    Private Sub HalButtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HalButtAdd.Click
        EllAddToGroup(Me.CheckedListBoxHalogens)
    End Sub

    Private Sub HalButtDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HalButtDel.Click
       EllDelFromGroup(Me.CheckedListBoxHalogens)
    End Sub

   
    Private Sub SlButtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlButtAdd.Click
        EllAddToGroup(Me.CheckedListBoxSL)
    End Sub

    Private Sub SLButtDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLButtDel.Click
        EllDelFromGroup(Me.CheckedListBoxSL)
    End Sub

    Private Sub Button8Cncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8Cncl.Click
        Me.Visible = False
        Main.Visible = True
    End Sub

    Private Sub LL1ButtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LL1ButtAdd.Click
        EllAddToGroup(Me.CheckedListBoxLL1)
    End Sub

    Private Sub LL1ButtDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LL1ButtDel.Click
        EllDelFromGroup(Me.CheckedListBoxLL1)
    End Sub

    Private Sub LL2ButtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LL2ButtAdd.Click
        EllAddToGroup(Me.CheckedListBoxLL2)
    End Sub

    Private Sub LL2ButtDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LL2ButtDel.Click
        EllDelFromGroup(Me.CheckedListBoxLL2)
    End Sub
End Class