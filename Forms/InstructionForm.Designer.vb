<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InstructionForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InstructionForm))
        Me.instructionTxt = New System.Windows.Forms.TextBox()
        Me.canisSerialNumberTxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.instructionPic = New System.Windows.Forms.PictureBox()
        Me.BackBtn = New System.Windows.Forms.Button()
        Me.NextBtn = New System.Windows.Forms.Button()
        Me.EndBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.inspectorCmb = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.instructionPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'instructionTxt
        '
        Me.instructionTxt.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructionTxt.Location = New System.Drawing.Point(15, 87)
        Me.instructionTxt.Multiline = True
        Me.instructionTxt.Name = "instructionTxt"
        Me.instructionTxt.ReadOnly = True
        Me.instructionTxt.Size = New System.Drawing.Size(674, 83)
        Me.instructionTxt.TabIndex = 1
        Me.instructionTxt.Text = "Please Scan The Canis Serial Number "
        '
        'canisSerialNumberTxt
        '
        Me.canisSerialNumberTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.canisSerialNumberTxt.Font = New System.Drawing.Font("Source Sans Pro", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.canisSerialNumberTxt.Location = New System.Drawing.Point(157, 27)
        Me.canisSerialNumberTxt.MaxLength = 12
        Me.canisSerialNumberTxt.Name = "canisSerialNumberTxt"
        Me.canisSerialNumberTxt.Size = New System.Drawing.Size(218, 29)
        Me.canisSerialNumberTxt.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Canis Serial No"
        '
        'instructionPic
        '
        Me.instructionPic.Location = New System.Drawing.Point(701, 13)
        Me.instructionPic.Name = "instructionPic"
        Me.instructionPic.Size = New System.Drawing.Size(334, 212)
        Me.instructionPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.instructionPic.TabIndex = 3
        Me.instructionPic.TabStop = False
        '
        'BackBtn
        '
        Me.BackBtn.Location = New System.Drawing.Point(68, 176)
        Me.BackBtn.Name = "BackBtn"
        Me.BackBtn.Size = New System.Drawing.Size(163, 40)
        Me.BackBtn.TabIndex = 4
        Me.BackBtn.Text = "BACK"
        Me.BackBtn.UseVisualStyleBackColor = True
        '
        'NextBtn
        '
        Me.NextBtn.Location = New System.Drawing.Point(293, 176)
        Me.NextBtn.Name = "NextBtn"
        Me.NextBtn.Size = New System.Drawing.Size(163, 40)
        Me.NextBtn.TabIndex = 5
        Me.NextBtn.Text = "NEXT"
        Me.NextBtn.UseVisualStyleBackColor = True
        '
        'EndBtn
        '
        Me.EndBtn.Location = New System.Drawing.Point(507, 176)
        Me.EndBtn.Name = "EndBtn"
        Me.EndBtn.Size = New System.Drawing.Size(163, 40)
        Me.EndBtn.TabIndex = 6
        Me.EndBtn.Text = "END"
        Me.EndBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Source Sans Pro", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(21, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "INSTRUCTION"
        '
        'inspectorCmb
        '
        Me.inspectorCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.inspectorCmb.Font = New System.Drawing.Font("Source Sans Pro", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inspectorCmb.FormattingEnabled = True
        Me.inspectorCmb.Location = New System.Drawing.Point(457, 27)
        Me.inspectorCmb.Name = "inspectorCmb"
        Me.inspectorCmb.Size = New System.Drawing.Size(238, 30)
        Me.inspectorCmb.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Source Sans Pro", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(379, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Inspector"
        '
        'InstructionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1047, 240)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.inspectorCmb)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.EndBtn)
        Me.Controls.Add(Me.NextBtn)
        Me.Controls.Add(Me.BackBtn)
        Me.Controls.Add(Me.instructionPic)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.canisSerialNumberTxt)
        Me.Controls.Add(Me.instructionTxt)
        Me.Font = New System.Drawing.Font("Source Sans Pro", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InstructionForm"
        Me.Text = "ICT Instruction Form"
        CType(Me.instructionPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents instructionTxt As TextBox
    Friend WithEvents canisSerialNumberTxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents instructionPic As PictureBox
    Friend WithEvents BackBtn As Button
    Friend WithEvents NextBtn As Button
    Friend WithEvents EndBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents inspectorCmb As ComboBox
    Friend WithEvents Label3 As Label
End Class
