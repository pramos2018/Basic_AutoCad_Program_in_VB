<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BasicAutoCadApp
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
        Me.gBoxShortCuts = New System.Windows.Forms.GroupBox()
        Me.penSize = New System.Windows.Forms.NumericUpDown()
        Me.lblPenSize = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRotate = New System.Windows.Forms.Button()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.btnFont = New System.Windows.Forms.Button()
        Me.btnPaste = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnCut = New System.Windows.Forms.Button()
        Me.gBoxMenus = New System.Windows.Forms.GroupBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.fileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportAsImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.clearMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangeFontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomINToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.helpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListComponentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDropDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.lblText = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtInput = New System.Windows.Forms.ToolStripTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.gBoxShortCuts.SuspendLayout()
        CType(Me.penSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gBoxMenus.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gBoxShortCuts
        '
        Me.gBoxShortCuts.Controls.Add(Me.penSize)
        Me.gBoxShortCuts.Controls.Add(Me.lblPenSize)
        Me.gBoxShortCuts.Controls.Add(Me.btnExit)
        Me.gBoxShortCuts.Controls.Add(Me.btnClear)
        Me.gBoxShortCuts.Controls.Add(Me.btnRotate)
        Me.gBoxShortCuts.Controls.Add(Me.btnColor)
        Me.gBoxShortCuts.Controls.Add(Me.btnFont)
        Me.gBoxShortCuts.Controls.Add(Me.btnPaste)
        Me.gBoxShortCuts.Controls.Add(Me.btnCopy)
        Me.gBoxShortCuts.Controls.Add(Me.btnCut)
        Me.gBoxShortCuts.Location = New System.Drawing.Point(21, 12)
        Me.gBoxShortCuts.Name = "gBoxShortCuts"
        Me.gBoxShortCuts.Size = New System.Drawing.Size(83, 479)
        Me.gBoxShortCuts.TabIndex = 0
        Me.gBoxShortCuts.TabStop = False
        Me.gBoxShortCuts.Text = "ShortCuts"
        '
        'penSize
        '
        Me.penSize.Location = New System.Drawing.Point(22, 259)
        Me.penSize.Name = "penSize"
        Me.penSize.Size = New System.Drawing.Size(48, 20)
        Me.penSize.TabIndex = 5
        '
        'lblPenSize
        '
        Me.lblPenSize.AutoSize = True
        Me.lblPenSize.Location = New System.Drawing.Point(19, 243)
        Me.lblPenSize.Name = "lblPenSize"
        Me.lblPenSize.Size = New System.Drawing.Size(52, 13)
        Me.lblPenSize.TabIndex = 0
        Me.lblPenSize.Text = "Pen Size:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(16, 426)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(54, 32)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(16, 19)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(55, 25)
        Me.btnClear.TabIndex = 0
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRotate
        '
        Me.btnRotate.Location = New System.Drawing.Point(16, 205)
        Me.btnRotate.Name = "btnRotate"
        Me.btnRotate.Size = New System.Drawing.Size(55, 25)
        Me.btnRotate.TabIndex = 0
        Me.btnRotate.Text = "Rotate"
        Me.btnRotate.UseVisualStyleBackColor = True
        '
        'btnColor
        '
        Me.btnColor.Location = New System.Drawing.Point(16, 174)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(55, 25)
        Me.btnColor.TabIndex = 0
        Me.btnColor.Text = "Color"
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'btnFont
        '
        Me.btnFont.Location = New System.Drawing.Point(16, 143)
        Me.btnFont.Name = "btnFont"
        Me.btnFont.Size = New System.Drawing.Size(55, 25)
        Me.btnFont.TabIndex = 0
        Me.btnFont.Text = "Font"
        Me.btnFont.UseVisualStyleBackColor = True
        '
        'btnPaste
        '
        Me.btnPaste.Location = New System.Drawing.Point(16, 112)
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(55, 25)
        Me.btnPaste.TabIndex = 0
        Me.btnPaste.Text = "Paste"
        Me.btnPaste.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(16, 81)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(55, 25)
        Me.btnCopy.TabIndex = 0
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnCut
        '
        Me.btnCut.Location = New System.Drawing.Point(16, 50)
        Me.btnCut.Name = "btnCut"
        Me.btnCut.Size = New System.Drawing.Size(55, 25)
        Me.btnCut.TabIndex = 0
        Me.btnCut.Text = "Cut"
        Me.btnCut.UseVisualStyleBackColor = True
        '
        'gBoxMenus
        '
        Me.gBoxMenus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxMenus.Controls.Add(Me.MenuStrip1)
        Me.gBoxMenus.Location = New System.Drawing.Point(125, 12)
        Me.gBoxMenus.Name = "gBoxMenus"
        Me.gBoxMenus.Size = New System.Drawing.Size(541, 52)
        Me.gBoxMenus.TabIndex = 1
        Me.gBoxMenus.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileMenu, Me.clearMenu, Me.helpMenu, Me.lblDropDown, Me.cbox1, Me.lblText, Me.txtInput})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 16)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(535, 27)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'fileMenu
        '
        Me.fileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewFileToolStripMenuItem, Me.OpenFileToolStripMenuItem, Me.SaveFileToolStripMenuItem, Me.SaveFileAsToolStripMenuItem, Me.ExportAsImageToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.fileMenu.Name = "fileMenu"
        Me.fileMenu.Size = New System.Drawing.Size(37, 23)
        Me.fileMenu.Text = "&File"
        '
        'NewFileToolStripMenuItem
        '
        Me.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem"
        Me.NewFileToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.NewFileToolStripMenuItem.Text = "&New File"
        '
        'OpenFileToolStripMenuItem
        '
        Me.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem"
        Me.OpenFileToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.OpenFileToolStripMenuItem.Text = "&Open File"
        '
        'SaveFileToolStripMenuItem
        '
        Me.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem"
        Me.SaveFileToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SaveFileToolStripMenuItem.Text = "&Save File"
        '
        'SaveFileAsToolStripMenuItem
        '
        Me.SaveFileAsToolStripMenuItem.Name = "SaveFileAsToolStripMenuItem"
        Me.SaveFileAsToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SaveFileAsToolStripMenuItem.Text = "&Save File As"
        '
        'ExportAsImageToolStripMenuItem
        '
        Me.ExportAsImageToolStripMenuItem.Name = "ExportAsImageToolStripMenuItem"
        Me.ExportAsImageToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ExportAsImageToolStripMenuItem.Text = "&Export as Image"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'clearMenu
        '
        Me.clearMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripSeparator1, Me.ChangeFontToolStripMenuItem, Me.ChangeColorToolStripMenuItem, Me.ZoomINToolStripMenuItem, Me.ZoomOutToolStripMenuItem})
        Me.clearMenu.Name = "clearMenu"
        Me.clearMenu.Size = New System.Drawing.Size(39, 23)
        Me.clearMenu.Text = "&Edit"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.CutToolStripMenuItem.Text = "Cu&t"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.CopyToolStripMenuItem.Text = "&Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.PasteToolStripMenuItem.Text = "&Paste"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(144, 6)
        '
        'ChangeFontToolStripMenuItem
        '
        Me.ChangeFontToolStripMenuItem.Name = "ChangeFontToolStripMenuItem"
        Me.ChangeFontToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ChangeFontToolStripMenuItem.Text = "Change &Font"
        '
        'ChangeColorToolStripMenuItem
        '
        Me.ChangeColorToolStripMenuItem.Name = "ChangeColorToolStripMenuItem"
        Me.ChangeColorToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ChangeColorToolStripMenuItem.Text = "Change &Color"
        '
        'ZoomINToolStripMenuItem
        '
        Me.ZoomINToolStripMenuItem.Name = "ZoomINToolStripMenuItem"
        Me.ZoomINToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ZoomINToolStripMenuItem.Text = "Zoom &IN"
        '
        'ZoomOutToolStripMenuItem
        '
        Me.ZoomOutToolStripMenuItem.Name = "ZoomOutToolStripMenuItem"
        Me.ZoomOutToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ZoomOutToolStripMenuItem.Text = "Zoom &Out"
        '
        'helpMenu
        '
        Me.helpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.ListComponentsToolStripMenuItem})
        Me.helpMenu.Name = "helpMenu"
        Me.helpMenu.Size = New System.Drawing.Size(44, 23)
        Me.helpMenu.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'ListComponentsToolStripMenuItem
        '
        Me.ListComponentsToolStripMenuItem.Name = "ListComponentsToolStripMenuItem"
        Me.ListComponentsToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ListComponentsToolStripMenuItem.Text = "&List Components"
        '
        'lblDropDown
        '
        Me.lblDropDown.Name = "lblDropDown"
        Me.lblDropDown.Size = New System.Drawing.Size(54, 23)
        Me.lblDropDown.Text = "Shape:"
        '
        'cbox1
        '
        Me.cbox1.Name = "cbox1"
        Me.cbox1.Size = New System.Drawing.Size(100, 23)
        '
        'lblText
        '
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(44, 23)
        Me.lblText.Text = "Text:"
        '
        'txtInput
        '
        Me.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(175, 23)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(125, 95)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(541, 384)
        Me.Panel1.TabIndex = 2
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(134, 75)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(128, 13)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Selected Shape: Drawing"
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 503)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gBoxMenus)
        Me.Controls.Add(Me.gBoxShortCuts)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form6"
        Me.Text = "Basic AutoCad Program"
        Me.gBoxShortCuts.ResumeLayout(False)
        Me.gBoxShortCuts.PerformLayout()
        CType(Me.penSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gBoxMenus.ResumeLayout(False)
        Me.gBoxMenus.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gBoxShortCuts As System.Windows.Forms.GroupBox
    Friend WithEvents gBoxMenus As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnColor As System.Windows.Forms.Button
    Friend WithEvents btnFont As System.Windows.Forms.Button
    Friend WithEvents btnPaste As System.Windows.Forms.Button
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnCut As System.Windows.Forms.Button
    Friend WithEvents penSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPenSize As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents fileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents helpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clearMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblDropDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents lblText As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtInput As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRotate As System.Windows.Forms.Button
    Friend WithEvents ExportAsImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ChangeFontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomINToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListComponentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
