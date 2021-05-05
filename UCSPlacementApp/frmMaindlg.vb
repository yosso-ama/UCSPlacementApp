Imports System.Windows.Forms
Imports UCSPlacementApp.UCSPlacementApp

Public Class frmMaindlg
    Private m_InventorDoc As Inventor.Document = Nothing

    Public Property InventorDocument() As Inventor.Document
        Get
            Return m_InventorDoc
        End Get
        Set(ByVal value As Inventor.Document)
            m_InventorDoc = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim i As Integer
        ' Load the list box
        For i = 90 To -90 Step -1
            'Debug.Print i
            Me.lbAngleInput.Items.Add(Trim(CStr(i)))
        Next i

        Me.lbAngleInput.SelectedItem = lbAngleInput.Items.Count / 2

        ' Setup the dialog controls
        Me.tbUCSElevation.Enabled = False
        Me.lbAngleInput.Visible = False
        Me.tbOriginElevation.Text = CStr(g_OriginElevation)
        Me.tbOriginElevation.Enabled = False
        Me.btnAddUCS.Enabled = False
        Me.btnOriginPoint.Enabled = False

    End Sub

    Private Sub btnOriginPoint_Click(sender As Object, e As EventArgs) Handles btnOriginPoint.Click

        'Me.Hide()
        Dim tempPoint As Inventor.Point = Nothing

        g_InventorApplication.ScreenUpdating = True

        Try
            tempPoint = SelectPoint.SelectPoint
            Globals.g_OriginPoint = tempPoint
        Catch
            If tempPoint Is Nothing Then
                Me.Show()
            End If
        Finally
            Me.Show()
        End Try

    End Sub

    Private Sub tbUCSName_Validated(sender As Object, e As EventArgs) Handles tbUCSName.Validated
        Dim t As TextBox = sender
        If t.Text <> "" Then
            Call InputUCSName(t.Text)
            Me.tbUCSElevation.Enabled = True
            Me.tbUCSElevation.Select()
        End If
    End Sub

    Private Sub tbUCSElevation_Validated(sender As Object, e As EventArgs) Handles tbUCSElevation.Validated
        Dim t As TextBox = sender

        If t.Text <> "" Then
            Call GetElevationFromUser(t.Text)
        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        Exit Sub
    End Sub
End Class