
Imports Inventor

'' https://forums.autodesk.com/t5/inventor-customization/selecting-a-point2d-with-your-mouse-on-a-drawing-sheet/td-p/3739407/page/2

Namespace UCSPlacementApp

    Public Module SelectPoint
        Private WithEvents m_intereaction As Inventor.InteractionEvents
        Private WithEvents m_mouse As Inventor.MouseEvents

        Public Function SelectPoint() As Point

            Dim MyPointSelection As ClsSelectPoint
            MyPointSelection = New ClsSelectPoint

            If g_DebugOn Then
                MsgBox("Getting Point From User", vbOK, "AMA ROUTINE")
            End If

            'm_intereaction = g_InventorApplication.CommandManager.CreateInteractionEvents
            'm_mouse = m_intereaction.MouseEvents

            'm_intereaction.Start()

            Dim tempPoint As Point

            Try
                'tempPoint = MyPointSelection.GetPoint

                'myPoint = g_InventorApplication.CommandManager.Pick(SelectionFilterEnum.kSketchPointFilter, "Select UCS origin point.")
                myPoint = MyPointSelection.GetPoint

                If myPoint Is Nothing Then
                    Return Nothing
                End If

                'If g_DebugOn Then
                '    Debug.Print("myPoint selected")
                '    'Call PrintXYZ(myPoint)
                'End If

            Catch ex As Exception
                MsgBox("Error get origin point!" & vbCr & vbCr & ex.Message, vbOK, g_AMA_error_title)
                ' CatchErrorcatch:
                Debug.Print(ex.Message)
            End Try


            Dim oSketch As PlanarSketch = myPoint.Parent
            Dim my2DPoint As Point2d = myPoint.Geometry
            Dim my3DPoint As Point = oSketch.SketchToModelSpace(my2DPoint)

            tempPoint = oSketch.SketchToModelSpace(my2DPoint)

            If g_DebugOn Then
                PrintXYZ(tempPoint)
            End If
            m_intereaction.Stop()

            ' ENABLE THE LISTBOX FOR THE ANGLE
            g_UCSForm.lbAngleInput.Enabled = True
            g_UCSForm.lbAngleInput.Visible = True
            g_UCSForm.lbAngleInput.SelectedItem = ((g_UCSForm.lbAngleInput.Items.Count - 1) / 2) + 1
            'myForm.lbAngleInput.ListIndex = ((myForm.lbAngleInput.ListCount - 1) / 2) + 1

            Return tempPoint

        End Function

        Private Sub PrintXYZ(my As Point)

            ' Units are centimeters!
            Debug.Print("Point Selected")
            Debug.Print(my.X, my.Y, my.Z)

        End Sub

    End Module

    Public Class GetMouseInput
        Private WithEvents m_interaction As Inventor.InteractionEvents
        Private WithEvents m_mouse As Inventor.MouseEvents

        Public Sub Create()
            m_interaction = g_InventorApplication.CommandManager.CreateInteractionEvents
            m_mouse = m_interaction.MouseEvents
            m_interaction.StatusBarText = "Select a sketch point."
            m_interaction.Start()

        End Sub

    End Class

End Namespace
