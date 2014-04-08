<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.menuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BounceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbInstrumentSelector = New System.Windows.Forms.GroupBox()
        Me.lstSounds = New System.Windows.Forms.ListBox()
        Me.lstInstruments = New System.Windows.Forms.ListBox()
        Me.gbMain = New System.Windows.Forms.GroupBox()
        Me.lblDeleteTrack = New System.Windows.Forms.Label()
        Me.pnlTrackList = New System.Windows.Forms.Panel()
        Me.pnlMeasures = New System.Windows.Forms.Panel()
        Me.pbPlay = New System.Windows.Forms.PictureBox()
        Me.pbStepForward = New System.Windows.Forms.PictureBox()
        Me.pbStepBack = New System.Windows.Forms.PictureBox()
        Me.pbStop = New System.Windows.Forms.PictureBox()
        Me.lblAddTrack = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.btnAddMeasure = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ShapeContainer5 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape60 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape61 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape63 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape64 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.gbMixer = New System.Windows.Forms.GroupBox()
        Me.ilTrackList = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteTrackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrPlayHead = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.gbInstrumentSelector.SuspendLayout()
        Me.gbMain.SuspendLayout()
        CType(Me.pbPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStepForward, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStepBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuFile, Me.menuEdit, Me.menuHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1061, 26)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip"
        '
        'menuFile
        '
        Me.menuFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.menuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProjectToolStripMenuItem, Me.OpenProjectToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.BounceToolStripMenuItem})
        Me.menuFile.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menuFile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.menuFile.Name = "menuFile"
        Me.menuFile.Size = New System.Drawing.Size(48, 22)
        Me.menuFile.Text = "File"
        '
        'NewProjectToolStripMenuItem
        '
        Me.NewProjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.NewProjectToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.NewProjectToolStripMenuItem.Name = "NewProjectToolStripMenuItem"
        Me.NewProjectToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.NewProjectToolStripMenuItem.Text = "New Project"
        '
        'OpenProjectToolStripMenuItem
        '
        Me.OpenProjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.OpenProjectToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem"
        Me.OpenProjectToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.OpenProjectToolStripMenuItem.Text = "Open Project"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.SaveToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.SaveAsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save As"
        '
        'BounceToolStripMenuItem
        '
        Me.BounceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.BounceToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.BounceToolStripMenuItem.Name = "BounceToolStripMenuItem"
        Me.BounceToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.BounceToolStripMenuItem.Text = "Bounce"
        '
        'menuEdit
        '
        Me.menuEdit.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menuEdit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.menuEdit.Name = "menuEdit"
        Me.menuEdit.Size = New System.Drawing.Size(49, 22)
        Me.menuEdit.Text = "Edit"
        '
        'menuHelp
        '
        Me.menuHelp.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menuHelp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.menuHelp.Name = "menuHelp"
        Me.menuHelp.Size = New System.Drawing.Size(54, 22)
        Me.menuHelp.Text = "Help"
        '
        'gbInstrumentSelector
        '
        Me.gbInstrumentSelector.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.gbInstrumentSelector.Controls.Add(Me.lstSounds)
        Me.gbInstrumentSelector.Controls.Add(Me.lstInstruments)
        Me.gbInstrumentSelector.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbInstrumentSelector.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.gbInstrumentSelector.Location = New System.Drawing.Point(822, 29)
        Me.gbInstrumentSelector.Name = "gbInstrumentSelector"
        Me.gbInstrumentSelector.Size = New System.Drawing.Size(227, 409)
        Me.gbInstrumentSelector.TabIndex = 1
        Me.gbInstrumentSelector.TabStop = False
        Me.gbInstrumentSelector.Text = "Instruments"
        '
        'lstSounds
        '
        Me.lstSounds.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.lstSounds.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstSounds.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSounds.ForeColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lstSounds.FormattingEnabled = True
        Me.lstSounds.ItemHeight = 14
        Me.lstSounds.Location = New System.Drawing.Point(119, 22)
        Me.lstSounds.MultiColumn = True
        Me.lstSounds.Name = "lstSounds"
        Me.lstSounds.Size = New System.Drawing.Size(102, 364)
        Me.lstSounds.TabIndex = 1
        '
        'lstInstruments
        '
        Me.lstInstruments.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.lstInstruments.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstInstruments.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstInstruments.ForeColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lstInstruments.FormattingEnabled = True
        Me.lstInstruments.ItemHeight = 19
        Me.lstInstruments.Items.AddRange(New Object() {"Kick", "Snare", "Hi-Hats", "Crash", "Toms", "Ride", "Misc Drums", "Sound Effects"})
        Me.lstInstruments.Location = New System.Drawing.Point(6, 22)
        Me.lstInstruments.Name = "lstInstruments"
        Me.lstInstruments.Size = New System.Drawing.Size(102, 380)
        Me.lstInstruments.TabIndex = 0
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.lblDeleteTrack)
        Me.gbMain.Controls.Add(Me.pnlTrackList)
        Me.gbMain.Controls.Add(Me.pnlMeasures)
        Me.gbMain.Controls.Add(Me.pbPlay)
        Me.gbMain.Controls.Add(Me.pbStepForward)
        Me.gbMain.Controls.Add(Me.pbStepBack)
        Me.gbMain.Controls.Add(Me.pbStop)
        Me.gbMain.Controls.Add(Me.lblAddTrack)
        Me.gbMain.Controls.Add(Me.ShapeContainer1)
        Me.gbMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.gbMain.Location = New System.Drawing.Point(26, 29)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(774, 409)
        Me.gbMain.TabIndex = 2
        Me.gbMain.TabStop = False
        '
        'lblDeleteTrack
        '
        Me.lblDeleteTrack.AutoSize = True
        Me.lblDeleteTrack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDeleteTrack.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lblDeleteTrack.Location = New System.Drawing.Point(105, 19)
        Me.lblDeleteTrack.Name = "lblDeleteTrack"
        Me.lblDeleteTrack.Size = New System.Drawing.Size(91, 18)
        Me.lblDeleteTrack.TabIndex = 14
        Me.lblDeleteTrack.Text = "- Delete Track"
        '
        'pnlTrackList
        '
        Me.pnlTrackList.AutoScroll = True
        Me.pnlTrackList.Location = New System.Drawing.Point(3, 44)
        Me.pnlTrackList.Name = "pnlTrackList"
        Me.pnlTrackList.Size = New System.Drawing.Size(193, 302)
        Me.pnlTrackList.TabIndex = 1
        '
        'pnlMeasures
        '
        Me.pnlMeasures.AutoScroll = True
        Me.pnlMeasures.BackColor = System.Drawing.Color.Transparent
        Me.pnlMeasures.Location = New System.Drawing.Point(202, 9)
        Me.pnlMeasures.Name = "pnlMeasures"
        Me.pnlMeasures.Size = New System.Drawing.Size(563, 337)
        Me.pnlMeasures.TabIndex = 13
        '
        'pbPlay
        '
        Me.pbPlay.BackColor = System.Drawing.Color.Transparent
        Me.pbPlay.Image = CType(resources.GetObject("pbPlay.Image"), System.Drawing.Image)
        Me.pbPlay.Location = New System.Drawing.Point(321, 358)
        Me.pbPlay.Name = "pbPlay"
        Me.pbPlay.Size = New System.Drawing.Size(50, 48)
        Me.pbPlay.TabIndex = 6
        Me.pbPlay.TabStop = False
        '
        'pbStepForward
        '
        Me.pbStepForward.BackColor = System.Drawing.Color.Transparent
        Me.pbStepForward.Image = CType(resources.GetObject("pbStepForward.Image"), System.Drawing.Image)
        Me.pbStepForward.Location = New System.Drawing.Point(433, 358)
        Me.pbStepForward.Name = "pbStepForward"
        Me.pbStepForward.Size = New System.Drawing.Size(50, 48)
        Me.pbStepForward.TabIndex = 5
        Me.pbStepForward.TabStop = False
        '
        'pbStepBack
        '
        Me.pbStepBack.BackColor = System.Drawing.Color.Transparent
        Me.pbStepBack.Image = CType(resources.GetObject("pbStepBack.Image"), System.Drawing.Image)
        Me.pbStepBack.InitialImage = CType(resources.GetObject("pbStepBack.InitialImage"), System.Drawing.Image)
        Me.pbStepBack.Location = New System.Drawing.Point(265, 358)
        Me.pbStepBack.Name = "pbStepBack"
        Me.pbStepBack.Size = New System.Drawing.Size(50, 48)
        Me.pbStepBack.TabIndex = 4
        Me.pbStepBack.TabStop = False
        '
        'pbStop
        '
        Me.pbStop.BackColor = System.Drawing.Color.Transparent
        Me.pbStop.Image = CType(resources.GetObject("pbStop.Image"), System.Drawing.Image)
        Me.pbStop.Location = New System.Drawing.Point(377, 358)
        Me.pbStop.Name = "pbStop"
        Me.pbStop.Size = New System.Drawing.Size(50, 48)
        Me.pbStop.TabIndex = 3
        Me.pbStop.TabStop = False
        '
        'lblAddTrack
        '
        Me.lblAddTrack.AutoSize = True
        Me.lblAddTrack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAddTrack.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lblAddTrack.Location = New System.Drawing.Point(6, 19)
        Me.lblAddTrack.Name = "lblAddTrack"
        Me.lblAddTrack.Size = New System.Drawing.Size(80, 18)
        Me.lblAddTrack.TabIndex = 2
        Me.lblAddTrack.Text = "+ Add Track"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 19)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(768, 387)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.SystemColors.Control
        Me.LineShape1.BorderWidth = 2
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = -4
        Me.LineShape1.X2 = 774
        Me.LineShape1.Y1 = 336
        Me.LineShape1.Y2 = 336
        '
        'btnAddMeasure
        '
        Me.btnAddMeasure.Location = New System.Drawing.Point(806, 553)
        Me.btnAddMeasure.Name = "btnAddMeasure"
        Me.btnAddMeasure.Size = New System.Drawing.Size(244, 23)
        Me.btnAddMeasure.TabIndex = 14
        Me.btnAddMeasure.Text = "Add Measure"
        Me.btnAddMeasure.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.ShapeContainer5)
        Me.Panel5.Location = New System.Drawing.Point(969, 582)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(80, 52)
        Me.Panel5.TabIndex = 13
        '
        'ShapeContainer5
        '
        Me.ShapeContainer5.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer5.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer5.Name = "ShapeContainer5"
        Me.ShapeContainer5.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape60, Me.RectangleShape61, Me.RectangleShape63, Me.RectangleShape64})
        Me.ShapeContainer5.Size = New System.Drawing.Size(80, 52)
        Me.ShapeContainer5.TabIndex = 0
        Me.ShapeContainer5.TabStop = False
        '
        'RectangleShape60
        '
        Me.RectangleShape60.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RectangleShape60.BorderColor = System.Drawing.Color.Black
        Me.RectangleShape60.FillColor = System.Drawing.Color.DarkOrange
        Me.RectangleShape60.FillGradientColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RectangleShape60.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape60.Location = New System.Drawing.Point(60, 13)
        Me.RectangleShape60.Name = "RectangleShape12"
        Me.RectangleShape60.Size = New System.Drawing.Size(20, 25)
        '
        'RectangleShape61
        '
        Me.RectangleShape61.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RectangleShape61.BorderColor = System.Drawing.Color.Black
        Me.RectangleShape61.FillColor = System.Drawing.Color.DarkOrange
        Me.RectangleShape61.FillGradientColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RectangleShape61.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape61.Location = New System.Drawing.Point(40, 13)
        Me.RectangleShape61.Name = "RectangleShape11"
        Me.RectangleShape61.Size = New System.Drawing.Size(20, 25)
        '
        'RectangleShape63
        '
        Me.RectangleShape63.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RectangleShape63.BorderColor = System.Drawing.Color.Black
        Me.RectangleShape63.FillColor = System.Drawing.Color.DarkOrange
        Me.RectangleShape63.FillGradientColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RectangleShape63.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape63.Location = New System.Drawing.Point(20, 13)
        Me.RectangleShape63.Name = "RectangleShape9"
        Me.RectangleShape63.Size = New System.Drawing.Size(20, 25)
        '
        'RectangleShape64
        '
        Me.RectangleShape64.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RectangleShape64.BorderColor = System.Drawing.Color.Black
        Me.RectangleShape64.FillColor = System.Drawing.Color.DarkOrange
        Me.RectangleShape64.FillGradientColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RectangleShape64.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape64.Location = New System.Drawing.Point(0, 13)
        Me.RectangleShape64.Name = "RectangleShape2"
        Me.RectangleShape64.Size = New System.Drawing.Size(20, 25)
        '
        'gbMixer
        '
        Me.gbMixer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMixer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.gbMixer.Location = New System.Drawing.Point(26, 444)
        Me.gbMixer.Name = "gbMixer"
        Me.gbMixer.Size = New System.Drawing.Size(774, 203)
        Me.gbMixer.TabIndex = 3
        Me.gbMixer.TabStop = False
        Me.gbMixer.Text = "Mixer"
        '
        'ilTrackList
        '
        Me.ilTrackList.ImageStream = CType(resources.GetObject("ilTrackList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilTrackList.TransparentColor = System.Drawing.Color.Transparent
        Me.ilTrackList.Images.SetKeyName(0, "trackBackground.bmp")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteTrackToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(140, 26)
        '
        'DeleteTrackToolStripMenuItem
        '
        Me.DeleteTrackToolStripMenuItem.Name = "DeleteTrackToolStripMenuItem"
        Me.DeleteTrackToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.DeleteTrackToolStripMenuItem.Text = "Delete Track"
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1061, 659)
        Me.Controls.Add(Me.btnAddMeasure)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.gbMain)
        Me.Controls.Add(Me.gbMixer)
        Me.Controls.Add(Me.gbInstrumentSelector)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "mainForm"
        Me.Text = "AlgoRhythms"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gbInstrumentSelector.ResumeLayout(False)
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        CType(Me.pbPlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStepForward, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStepBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents menuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BounceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbInstrumentSelector As System.Windows.Forms.GroupBox
    Friend WithEvents lstInstruments As System.Windows.Forms.ListBox
    Friend WithEvents gbMain As System.Windows.Forms.GroupBox
    Public WithEvents gbMixer As System.Windows.Forms.GroupBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents ilTrackList As System.Windows.Forms.ImageList
    Friend WithEvents lstSounds As System.Windows.Forms.ListBox
    Friend WithEvents pnlTrackList As System.Windows.Forms.Panel
    Friend WithEvents lblAddTrack As System.Windows.Forms.Label
    Friend WithEvents pbPlay As System.Windows.Forms.PictureBox
    Friend WithEvents pbStepForward As System.Windows.Forms.PictureBox
    Friend WithEvents pbStepBack As System.Windows.Forms.PictureBox
    Friend WithEvents pbStop As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteTrackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrPlayHead As System.Windows.Forms.Timer
    Friend WithEvents pnlMeasures As System.Windows.Forms.Panel
    Friend WithEvents btnAddMeasure As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer5 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape60 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape61 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape63 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape64 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lblDeleteTrack As System.Windows.Forms.Label

End Class
