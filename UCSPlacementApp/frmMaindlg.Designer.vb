<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMaindlg
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaindlg))
        Me.tbUCSName = New System.Windows.Forms.TextBox()
        Me.tbOriginElevation = New System.Windows.Forms.TextBox()
        Me.tbUCSElevation = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbAngleInput = New System.Windows.Forms.ListBox()
        Me.btnOriginPoint = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAddUCS = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbUCSName
        '
        Me.tbUCSName.Location = New System.Drawing.Point(121, 19)
        Me.tbUCSName.Name = "tbUCSName"
        Me.tbUCSName.Size = New System.Drawing.Size(100, 20)
        Me.tbUCSName.TabIndex = 0
        '
        'tbOriginElevation
        '
        Me.tbOriginElevation.Location = New System.Drawing.Point(247, 35)
        Me.tbOriginElevation.Name = "tbOriginElevation"
        Me.tbOriginElevation.Size = New System.Drawing.Size(100, 20)
        Me.tbOriginElevation.TabIndex = 1
        '
        'tbUCSElevation
        '
        Me.tbUCSElevation.Location = New System.Drawing.Point(121, 47)
        Me.tbUCSElevation.Name = "tbUCSElevation"
        Me.tbUCSElevation.Size = New System.Drawing.Size(100, 20)
        Me.tbUCSElevation.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "1. UCS NAME"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "2. ELEVATION"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(244, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "ORIGIN ELEVATION"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GroupBox1.Controls.Add(Me.lbAngleInput)
        Me.GroupBox1.Location = New System.Drawing.Point(37, 111)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 278)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ROTATION ABOUT Z-AXIS"
        '
        'lbAngleInput
        '
        Me.lbAngleInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbAngleInput.FormattingEnabled = True
        Me.lbAngleInput.Location = New System.Drawing.Point(64, 87)
        Me.lbAngleInput.Name = "lbAngleInput"
        Me.lbAngleInput.Size = New System.Drawing.Size(120, 132)
        Me.lbAngleInput.TabIndex = 0
        '
        'btnOriginPoint
        '
        Me.btnOriginPoint.Location = New System.Drawing.Point(12, 82)
        Me.btnOriginPoint.Name = "btnOriginPoint"
        Me.btnOriginPoint.Size = New System.Drawing.Size(209, 23)
        Me.btnOriginPoint.TabIndex = 9
        Me.btnOriginPoint.Text = "3. SELECT ORIGIN POINT"
        Me.btnOriginPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOriginPoint.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(12, 395)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 43)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "&EXIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAddUCS
        '
        Me.btnAddUCS.Location = New System.Drawing.Point(202, 395)
        Me.btnAddUCS.Name = "btnAddUCS"
        Me.btnAddUCS.Size = New System.Drawing.Size(75, 43)
        Me.btnAddUCS.TabIndex = 11
        Me.btnAddUCS.Text = "&ADD UCS"
        Me.btnAddUCS.UseVisualStyleBackColor = True
        '
        'frmMaindlg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(382, 450)
        Me.Controls.Add(Me.btnAddUCS)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnOriginPoint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbUCSElevation)
        Me.Controls.Add(Me.tbOriginElevation)
        Me.Controls.Add(Me.tbUCSName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmMaindlg"
        Me.Text = "LAYOUT UTILITY"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbUCSName As Windows.Forms.TextBox
    Friend WithEvents tbOriginElevation As Windows.Forms.TextBox
    Friend WithEvents tbUCSElevation As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents btnOriginPoint As Windows.Forms.Button
    Friend WithEvents lbAngleInput As Windows.Forms.ListBox
    Friend WithEvents btnExit As Windows.Forms.Button
    Friend WithEvents btnAddUCS As Windows.Forms.Button
End Class
