Imports Inventor
Namespace UCSPlacementApp

    Module CreateUCS

        Public Sub CreateUCS()

            Dim oUCSDef As UserCoordinateSystemDefinition = MyPartDoc.
                                                            ComponentDefinition.UserCoordinateSystems.CreateDefinition
            Dim DeltaZCentimeters As Double
            Dim DeltaZFeet As Double
            Dim oUCS As UserCoordinateSystem

            DeltaZFeet = UCSElevation - g_OriginElevation
            DeltaZCentimeters = ConvertFT_CM(DeltaZFeet)

            ' Create the 3D Sketch from the given data, deltaZ and origin point
            Create3DSketch(g_UCSName, g_MyPoints, DeltaZCentimeters)

            ' Create the UCS Definition from the 3D Sketch
            CreateNewUCSDef(oUCSDef, My3DSketch)

            ' Create the new UCS from the UCS Definition
            oUCS = MyPartDoc.ComponentDefinition.UserCoordinateSystems.Add(oUCSDef)

        End Sub

        ' Create the 3D sketch which will be utilized to place the UCS
        Public Sub Create3DSketch(name As String, mp() As Point, deltaZ As Double)

            Dim XOffset As Double = Math.Round(12.0# * 2.5397, 4)
            Dim YOffset As Double = Math.Round(12.0# * 2.5397, 4)

            Dim oCompDef As PartComponentDefinition = MyPartDoc.ComponentDefinition

            Dim RotateAngleDeg As Double
            RotateAngleDeg = Val(g_UCSForm.lbAngleInput.SelectedItem.ToString)

            If g_DebugOn Then
                Debug.Print("Angle selected : " & CStr(RotateAngleDeg))
            End If

            Dim RotateAngleRadian As Double = ConvertAngleToRad(RotateAngleDeg)

            'Dim oSketch3D As Sketch3D
            My3DSketch = oCompDef.Sketches3D.Add

            Dim oTG As TransientGeometry = g_InventorApplication.TransientGeometry

            Dim oLineA As SketchLine3D
            Dim oLineB As SketchLine3D
            Dim oLineC As SketchLine3D

            '' 10/29/30 fix  for zero deltaZ
            If deltaZ = 0 Then
                deltaZ = 0.001 ' centimeters, so 1 micron
            End If

            oLineA = My3DSketch.SketchLines3D.AddByTwoPoints(myPoint, oTG.CreatePoint(myPoint.Geometry.X, myPoint.Geometry.Y, deltaZ))
            oLineA.Construction = True

            Dim TempPointB As Point
            TempPointB = oTG.CreatePoint((Math.Cos(RotateAngleRadian) * XOffset) + myPoint.Geometry.X,
                                    (Math.Sin(RotateAngleRadian) * XOffset) + myPoint.Geometry.Y, deltaZ)
            oLineB = My3DSketch.SketchLines3D.AddByTwoPoints(oLineA.EndSketchPoint, TempPointB)
            oLineB.Construction = True

            Dim TempPointC As Point
            ' Set TempPointC = oTG.CreatePoint(myPoint.Geometry.X, myPoint.Geometry.Y + YOffset, deltaZ)
            TempPointC = oTG.CreatePoint((-Math.Sin(RotateAngleRadian) * YOffset) + myPoint.Geometry.X,
                                    (Math.Cos(RotateAngleRadian) * YOffset) + myPoint.Geometry.Y, deltaZ)
            oLineC = My3DSketch.SketchLines3D.AddByTwoPoints(oLineA.EndSketchPoint, TempPointC)
            oLineC.Construction = True

            ' https://adndevblog.typepad.com/manufacturing/2013/07/inventor-api-create-constraints-for-3d-sketch.html
            ' Constrain oLineA to the z axis

            Dim oParallelConstr3DZ As ParallelToZAxisConstraint3D
            'Dim oParallelConstr3DX As ParallelToXAxisConstraint3D
            'Dim oParallelCOnstr3DY As ParallelToYAxisConstraint3D

            oParallelConstr3DZ = My3DSketch.GeometricConstraints3D.AddParallelToZAxis(oLineA)
            'Set oParallelConstr3DX = My3DSketch.GeometricConstraints3D.AddParallelToXAxis(oLineB)
            'Set oParallelCOnstr3DY = My3DSketch.GeometricConstraints3D.AddParallelToYAxis(oLineC)

            '' 10/21/20 ADDING USER PARAMETER IS NOT FUNCTIONING..
            Dim oUserParams As UserParameters
            oUserParams = MyPartDoc.ComponentDefinition.Parameters.UserParameters
            Dim oUserParam As Parameter
            ' Set oUserParam = oUserParams.AddByValue(UCSName & UserParamNameSuffix, deltaZ, kDefaultDisplayLengthUnits)

            ' Constrain oLineA Length to zed offset
            Dim oLineLenConstr3DZed As LineLengthDimConstraint3D
            oLineLenConstr3DZed = My3DSketch.DimensionConstraints3D.AddLineLength(oLineA)
            oLineLenConstr3DZed.Driven = False  ' set to true to use an user parameter

            Dim oModelparam As ModelParameter
            oModelparam = oLineLenConstr3DZed.Parameter
            oModelparam.Value = Math.Abs(deltaZ)

            ' Constrain oLineB length
            Dim oLineLenconstr3d As LineLengthDimConstraint3D
            oLineLenconstr3d = My3DSketch.DimensionConstraints3D.AddLineLength(oLineB)

            ' Set the driven property to false to ensure the parameter is a model parameter
            oLineLenconstr3d.Driven = False
            oUserParam = oLineLenconstr3d.Parameter

            ' set the new value in base units (cm)
            oUserParam.Value = XOffset

            ' Constrain oLineC length
            oLineLenconstr3d = My3DSketch.DimensionConstraints3D.AddLineLength(oLineC)

        End Sub

        ' Routine to create the UCS Definition from the 3D sketch
        Private Sub CreateNewUCSDef(ou As UserCoordinateSystemDefinition, mSK As Sketch3D)
            Dim skLineA As SketchLine3D
            Dim skLineB As SketchLine3D
            Dim skLineC As SketchLine3D

            skLineA = mSK.SketchLines3D.Item(1)
            skLineB = mSK.SketchLines3D.Item(2)
            skLineC = mSK.SketchLines3D.Item(3)

            ou.SetByThreePoints(skLineA.EndSketchPoint, skLineB.EndSketchPoint, skLineC.EndSketchPoint)

        End Sub

        ' Function to convert feet to centimeters, as all of Inventor's 
        ' internal length units are in centimeters
        Public Function ConvertFT_CM(val As Double) As Double

            Dim temp As Double
            Dim Conversion As Double : Conversion = 30.4764

            temp = val * Conversion

            ConvertFT_CM = temp

        End Function

        ' Fuction to convert from degrees to radians
        Public Function ConvertAngleToRad(v As Double) As Double

            Dim tempVal As Double

            tempVal = (v * 2 * dPi) / 360.0#
            ConvertAngleToRad = tempVal

        End Function

    End Module

End Namespace

