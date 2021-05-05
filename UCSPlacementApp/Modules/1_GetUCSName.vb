Imports Inventor
Namespace UCSPlacementApp

    Public Module GetUcsName

        Public Sub InputUCSName(chkVal As String)

            Try
                If Len(chkVal) > g_UCSMaxLen Then
                    chkVal = Left(Trim(chkVal), g_UCSMaxLen - Len(g_UCSPrefix))
                End If

                chkVal = g_UCSPrefix & chkVal

                g_UCSForm.tbUCSName.Text = chkVal

                ' Validate the name, to ensure it's not already in place
                chkVal = ValidateUCSName(chkVal)

                ' Place the validated name into the 
                ' global container/variable
                g_UCSName = chkVal

            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try

        End Sub


        ' Function to check if the ucsname is already being used.
        ' If the name is already in use, then add the suffix "i" to the
        ' existing name then index the "i" counter by one and
        ' add that suffix to the name of the new ucs being created.
        Private Function ValidateUCSName(n As String) As String


            ' Get a collection of all of the ucs's in the current part document
            Dim oCompDef As Inventor.PartComponentDefinition
            oCompDef = MyPartDoc.ComponentDefinition

            Dim i As Integer, count As Integer : count = 0

            Dim SuffixDelim As String : SuffixDelim = "_"
            Dim FormatZero As String : FormatZero = "00"
            Dim TempName As String

            Dim NameFound As Boolean : NameFound = False
            Dim MyUCS As Inventor.UserCoordinateSystem

            For i = 1 To oCompDef.UserCoordinateSystems.Count
                MyUCS = oCompDef.UserCoordinateSystems.Item(i)
                If MyUCS.Name = n Then '
                    MyUCS.Name = MyUCS.Name & SuffixDelim & Format$(count, FormatZero)
                    count = count + 1
                    NameFound = True
                    Exit For
                End If
            Next i

            If NameFound Then
                TempName = n & SuffixDelim & Format$(count, FormatZero)
            Else
                TempName = n
            End If

            ' Return modified/updated name
            ValidateUCSName = TempName

        End Function

    End Module

End Namespace
