Imports Inventor
Imports System.Windows.Forms
    Imports System.Runtime.InteropServices
    Imports System.Configuration
    Imports Microsoft.Win32

    Public Class ClsSelectPoint

    Public oModelX As Double
    Public oModelY As Double
    Public oModelZ As Double

    Public oPointX, oPointY, oPointZ As Double

    ' Declare the event objects
    Private WithEvents oInteraction As Inventor.InteractionEvents
    Public WithEvents oMouseEvents As Inventor.MouseEvents
    Public Event MouseClick As MouseEventHandler

    ' Declare a Flag that's used to determine when selection stops.
    Private bStillSelecting As Boolean

    Private oSelectedPoint As Inventor.Point2d

    Public Function GetPoint() As Inventor.Point2d
        ' Initialize flag.
        bStillSelecting = True

        If g_DebugOn Then
            MsgBox("In GetPoint Class, trying to get a point.", vbOK, "AMA Debug")
        End If

        ' Create an InteractionEvents object.
        oInteraction = g_InventorApplication.CommandManager.CreateInteractionEvents

        ' Set a reference to the mouse events.
        oMouseEvents = oInteraction.MouseEvents

        ' Disable mouse move since we only need the click.
        oMouseEvents.MouseMoveEnabled = True
        oInteraction.SetCursor(CursorTypeEnum.kCursorBuiltInCrosshair)
        oInteraction.StatusBarText = "Select Point"

        ' The InteractionEvents object.
        oInteraction.Start()
        oInteraction.SelectionActive = True

        ' Loop until a selection is made.
        Do While bStillSelecting
            g_InventorApplication.UserInterfaceManager.DoEvents()
        Loop

        ' Set the return variable with the point.
        GetPoint = oSelectedPoint

        ' Stop the InteractionEvents object.
        oInteraction.Stop()

        ' Clean up.
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.StatusBarText.DefaultIfEmpty
        oMouseEvents = Nothing
        oInteraction = Nothing

    End Function

    Public Sub Findpoint()

        Dim oGetPoint As New ClsSelectPoint
        Dim oCP As Point2d = oGetPoint.GetPoint

    End Sub

    Private Sub oInteraction_OnTerminate()
        '    Private Sub oInteraction_OnTerminate()
        ' Set the flag to indicate we're done.
        bStillSelecting = False
    End Sub

    Private Sub oMouseEvents_OnMouseClick(ByVal Button As MouseButtonEnum, ByVal ShiftKeys As ShiftStateEnum, ByVal ModelPosition As Inventor.Point, ByVal ViewPosition As Point2d, ByVal View As Inventor.View) Handles oMouseEvents.OnMouseClick

        If g_DebugOn Then
            MsgBox("MouseEvents: Getting Point From User", vbOK, "AMA ROUTINE")
        End If

        ' These are in cm
        oPointX = ModelPosition.X
        oPointY = ModelPosition.Y
        oPointZ = ModelPosition.Z

        bStillSelecting = False

        'your code here
        '################

        MsgBox("X: " & oPointX & vbCr & "Y: " & oPointY)
        '#################
    End Sub

End Class
