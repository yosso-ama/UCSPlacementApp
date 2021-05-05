Namespace UCSPlacementApp

    Public Module GetElevation

        Public Sub GetElevationFromUser(chkVal As String)
            Dim subName As String : subName = "GetElevation"

            Try
                Dim dlgResult As Object

                If Len(chkVal) = 0 Then
                    g_UCSForm.tbUCSElevation.Select()
                    Exit Sub
                End If

                If Val(chkVal) = 0 Then
                    dlgResult = MsgBox("Is the relative elevation " & chkVal & " correct?", vbYesNo, "Verify Input")
                End If

                UCSElevation = Val(chkVal)

                g_UCSForm.btnOriginPoint.Enabled = True
                g_UCSForm.btnOriginPoint.Select()

            Catch
                MsgBox("Not able to extract the origin elevation!", MsgBoxStyle.Critical, "UCS Placement Error")
                Debug.Print(Err.Description)
            End Try

        End Sub
    End Module

End Namespace
