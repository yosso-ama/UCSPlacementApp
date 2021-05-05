Imports Inventor
Imports Inventor.DocumentTypeEnum

Namespace UCSPlacementApp

    Public Module Main

        ' Setup global variables
        'Public myForm As frmMain = New frmMain

        ' UCS elevation and existing origin elevation
        Public UCSElevation As Double = 0#
        'Public OriginElevation As Double

        ' The point of it all!
        Public myPoint As Point

        ' The document in which we are adding
        ' in the new UCS
        Public MyPartDoc As PartDocument

        ' The 3D sketch which will be utilized to define the UCS
        Public My3DSketch As Sketch3D

        ' Pie, or rather PI
        Public dPi As Double

        '' Notes on VB.net
        '' https://stackoverflow.com/questions/881570/classes-vs-modules-in-vb-net

        Public Sub UCSPlacementStart()

            Try
                ' Is a document open?
                If g_InventorApplication.ActiveDocument Is Nothing Then
                    NoFileOpenError()
                    Exit Sub
                    ' Is the document a part document?
                ElseIf g_InventorApplication.ActiveDocumentType <> kPartDocumentObject Then
                    NoFileOpenError()
                    Exit Sub
                End If

                ' Make some pie!
                dPi = Math.Atan(1) * 4.0#

                'Obtain the active document
                Dim myPartDoc As PartDocument
                myPartDoc = g_InventorApplication.ActiveDocument

                If g_DebugOn Then
                    MsgBox("Part file name =" & myPartDoc.File.FullFileName,
                            vbOK, "AMA ROUTINE")
                End If

                ' Get the origin elevation from the name of the XY plane
                g_OriginElevation = GetOriginElevation(myPartDoc)

                If g_DebugOn Then
                    MsgBox("Origin elevation=" & CStr(g_OriginElevation), vbOK, "AMA ROUTINE")
                End If

                g_UCSForm = New frmMaindlg()

                g_UCSForm.InventorDocument = myPartDoc

                If Not (g_UCSForm Is Nothing) Then
                    g_UCSForm.Activate()
                    g_UCSForm.Top = True
                    g_UCSForm.ShowInTaskbar = True
                    g_UCSForm.Activate()
                End If

                ' Bring up the dialog
                g_UCSForm.ShowDialog()

            Catch ex As Exception

                MsgBox("Error starting routine!" & vbCr & vbCr & ex.Message, vbOK, g_AMA_error_title)
                ' CatchErrorcatch:
                Debug.Print(ex.Message)

            End Try

        End Sub

        Private Sub NoFileOpenError()
            MsgBox("Please open a part document file and try again.", MsgBoxStyle.Information, "CRITICAL ERROR")
        End Sub

        Private Function GetOriginElevation(d As PartDocument) As Double

            Dim oPlane As WorkPlane
            Dim oPlanes As WorkPlanes
            Dim XYPlane As Integer = 3
            Dim oPlaneName As String

            oPlanes = d.ComponentDefinition.WorkPlanes

            oPlane = oPlanes.Item(XYPlane)
            oPlaneName = oPlane.Name

            If Val(oPlaneName) = 0 Then
                If g_DebugOn Then
                    MsgBox("Getting origin elevation from XY plane" & oPlaneName, vbOK, "AMA ROUTINE")
                    Debug.Print(Val(oPlaneName))
                End If

                GetOriginElevation = 0
                Exit Function
            Else
                GetOriginElevation = Val(oPlaneName)
            End If

        End Function
    End Module
End Namespace
