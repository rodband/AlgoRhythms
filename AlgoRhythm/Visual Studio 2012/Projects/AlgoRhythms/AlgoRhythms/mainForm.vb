Imports Microsoft.VisualBasic.PowerPacks

Public Class mainForm
    Dim numTracks As Integer                            'Keeps track of the curent number of tracks
    Dim numMeasures As Integer                          'Keeps track of the current unmber of measures
    Dim selectedTrack As Integer                        'Keeps track of which track is selected on the form
    Dim trackManager As New clsTrackManager
    Dim measureManager As New clsMeasureManager
    Dim colTrack As New Collection                      'current collection of tracks
    Dim colPBTrack As New Collection                    'current collection of track pictureboxes
    Dim colLBLTrack As New Collection                   'current collection of track labels
    Dim colPBMute As New Collection                     'current collection of muteButtons
    Dim colPBSolo As New Collection                     'current collection of soloButtons
    Dim colMeasures As New Collection
    Dim colPlayHead As New Collection
    Dim scrollMeasureBox As New PictureBox              'Forces a scroll bar to appear on pnlMeasures
    Dim playPressed As Boolean                          'Determines whether or not the playhead is activated
    Dim playHead As Integer                             'hold the loop position of the playhead
    Dim soloTrack As Boolean                            'Holds whether or not any tracks have been soloed
    Dim measurePanel1 As New ShapeContainer             'Creates a shape container to hold all the rectangle objects
    Dim measurePanel2 As New ShapeContainer
    Dim objFileManager As New clsFileManager
    Dim fileName As String

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()

        Dim loadFile As DialogResult = MessageBox.Show("Would you like to load an existing AlgoRhythm?", "Welcome!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If loadFile = Windows.Forms.DialogResult.No Then
            'On load, 1 track is added, including 10 measures and its mixer componant
            Dim trackBackground As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\trackBackground.bmp")
            Dim muteUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteTrackButtonUp.png")
            Dim soloUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloTrackButtonUp.png")
            Dim muteMixerUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteButtonUp.png")
            Dim soloMixerUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloButtonUp.png")

            fileName = "newFile"                            'generically set the new file's filename so that Saving the program can be called
            numTracks = 1                                   'Sets the number of tracks to 1, the one created on load
            numMeasures = 1                                 'Sets the number of tracks to 1 so 10 measures can be added in a loop later
            playPressed = False                             'Initialize playPressed to be off
            playHead = 1                                    'Starts at 1, at the beginning of the playbar
            soloTrack = False                               'set soloTrack to false, since no track is soloed at startup
            Dim objName As String                           'Stores a string to set the name of objects created at runtime

            Dim pictureBox As New PictureBox                'Creates a picture box object to be named and used
            objName = "pbTrack" + numTracks.ToString        'Sets objName to the desired object name
            pictureBox.Name = objName.ToString              'Sets the object name to be objName
            pnlTrackList.Controls.Add(pictureBox)           'Adds the picture box object to the pnlTrackList control
            pictureBox.SetBounds(0, 0, 166, 53)             'Sets the location and size of the picture box
            pictureBox.Image = trackBackground              'Sets the image of the picture box to track background
            pictureBox.BringToFront()                       'Brings the picture box to the front
            colPBTrack.Add(pictureBox)                      'add picture box to colPBTrack collection
            AddHandler pictureBox.Click, AddressOf pbTrack_Click

            Dim trackLabel As New Label                     'Creates a label object to be named and used
            objName = "lblTrack" + numTracks.ToString       'Sets objName to the desired object name
            trackLabel.Name = objName.ToString              'Sets the object name to be objName
            pnlTrackList.Controls.Add(trackLabel)           'Adds the label object to the pnlTrackList control
            trackLabel.SetBounds(10, 18, 127, 16)           'Sets the location and size of the picture box
            trackLabel.Text = "Select an Instrument"        'Sets the default text of the label
            trackLabel.BackColor = Color.FromArgb(40, 40, 40)   'Sets the background color of the label to match the trackBackground image
            trackLabel.BringToFront()                       'Brings the label to the front
            colLBLTrack.Add(trackLabel)                     'add track label to colLBLTrack collection

            Dim pbMute As New PictureBox                    'Creates a picture box to be named and used
            objName = "pbMuteTrack" + numTracks.ToString    'Sets objName to the desired object name
            pbMute.Name = objName.ToString                  'Sets the object name to be objName
            pnlTrackList.Controls.Add(pbMute)               'Adds the picture box object to the pnlTrackList control
            pbMute.SetBounds(138, 1, 25, 23)                'Sets the location and size of the picture box
            pbMute.Image = muteUp                           'Sets the image of the picture box to the mute buttons up state
            pbMute.BringToFront()                           'Brings the picture box to the front
            colPBMute.Add(pbMute)                           'Add mute button to the collection
            AddHandler pbMute.Click, AddressOf pbMute_Click 'Links the picture box to the pbMute_Click handler

            Dim pbSolo As New PictureBox                    'Creates a picture box to be named and used
            objName = "pbSoloTrack" + numTracks.ToString    'Sets objName to the desired object name
            pbSolo.Name = objName.ToString                  'Sets the object name to be objName
            pnlTrackList.Controls.Add(pbSolo)               'Adds the picture box object to the pnlTrackList control
            pbSolo.SetBounds(138, 28, 25, 23)               'Sets the location and size of the picture box
            pbSolo.Image = soloUp                           'Sets the image of the picture box to the solo buttons up state
            pbSolo.BringToFront()                           'Brings the picture box to the front
            colPBSolo.Add(pbSolo)                           'add solo button to colPBSolo collection
            AddHandler pbSolo.Click, AddressOf pbSolo_Click 'Links the picture box to the pbSolo_Click handler

            Dim objMeasureManager As New clsMeasureManager
            Dim track As New clsTrack(numTracks, "null", False, False, False, objMeasureManager)
            trackManager.addTrack(track)
            trackManager.fillCollection(colTrack)

            scrollMeasureBox.Name = "ScrollMeasureBox"      'Sets the name of the picture box that enables the scroll bar in pnlMeasures
            pnlMeasures.Controls.Add(scrollMeasureBox)      'Adds the picture box to pnlMeasures
            scrollMeasureBox.SetBounds(801, 0, 80, 52)      'Sets the location and size of the picture box

            Dim changeX As Integer = 0                      'Stores the change in x value for each rectangle object
            pnlMeasures.Controls.Add(measurePanel1)          'Adds the shape container to pnlMeasures
            pnlMeasures.Controls.Add(measurePanel2)          'Adds the shape container to pnlMeasures

            'CREATE PLAYHEAD
            For k As Integer = 1 To 10                                                  'Counts from 1 to 10, adding a full measure to the UI each time
                objName = "pnlPlayHead" + numTracks.ToString + "Measure" + k.ToString      'Sets objName to the desired object name
                measurePanel1.Name = objName.ToString                                    'Sets the object name to be objName
                For m As Integer = 1 To 16 Step 1                                       'Counts from 1 to 16, by 4 to build and name each rectangle correctly
                    objName = "pnlPlayHead" + numTracks.ToString + "Measure" + k.ToString + "Beat" + m.ToString    'Names each rectangle properly
                    Dim rectangle As New RectangleShape                                 'Creates a rectangle object, representing one QUARTER note
                    rectangle.Name = objName.ToString                                   'Sets the object name to be objName
                    rectangle.Parent = measurePanel1                                     'Sets the rectangles parent to be the shape container created earlier
                    rectangle.SetBounds(1 * changeX, 10, 5, 18)                        'Sets the size and lcoation of the rectangle
                    changeX = changeX + 5                                              'Increases changeX by 20 so the next rectangle is placed correctly
                    rectangle.FillStyle = FillStyle.Solid
                    rectangle.BorderColor = Color.FromArgb(101, 165, 210)                            'Sets the boarder color to be orange, this will change depending on the selected instrument
                    rectangle.FillColor = Color.Transparent                             'Sets the boarder color to be transparent
                    colPlayHead.Add(rectangle)
                    rectangle.BringToFront()                                            'Brings the rectangle to the front
                    AddHandler rectangle.Click, AddressOf rectPlayHead_Click
                Next
            Next

            changeX = 0
            For j As Integer = 1 To 10                                                  'Counts from 1 to 10, adding a full measure to the UI each time
                Dim objMeasure As New clsMeasure(track.trackNumber, j, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False)
                track.objMeasureManager.addMeasure(objMeasure)                          'add measure object to measure manager
                objName = "pnlTrack" + numTracks.ToString + "Measure" + j.ToString      'Sets objName to the desired object name
                measurePanel2.Name = objName.ToString                                    'Sets the object name to be objName
                For i As Integer = 1 To 16 Step 4                                       'Counts from 1 to 16, by 4 to build and name each rectangle correctly
                    objName = "pnlTrack" + numTracks.ToString + "Measure" + j.ToString + "Beat" + i.ToString    'Names each rectangle properly
                    Dim rectangle As New RectangleShape                                 'Creates a rectangle object, representing one QUARTER note
                    rectangle.Name = objName.ToString                                   'Sets the object name to be objName
                    rectangle.Parent = measurePanel2                                    'Sets the rectangles parent to be the shape container created earlier
                    rectangle.SetBounds(1 * changeX, 48, 20, 25)                        'Sets the size and location of the rectangle
                    changeX = changeX + 20                                              'Increases changeX by 20 so the next rectangle is placed correctly
                    rectangle.BorderColor = Color.DarkOrange                            'Sets the boarder color to be orange, this will change depending on the selected instrument
                    rectangle.FillColor = Color.Transparent                             'Sets the boarder color to be transparent
                    rectangle.BringToFront()                                            'Brings the rectangle to the front
                    AddHandler rectangle.MouseClick, AddressOf rectBeat_Click
                Next
            Next
            numMeasures = 10                                'Sets numMeasures to reflect the current number of measures

            track.objMeasureManager.fillCollection(colMeasures)

            Dim mixerGroupBox As New GroupBox               'Creates a groupBox to be named and used
            objName = "gbTrackMixer" + numTracks.ToString   'Sets objName to the desired object name
            mixerGroupBox.Name = objName.ToString           'Sets the object name to be objName
            gbMixer.Controls.Add(mixerGroupBox)             'Adds the group box to gbMixer
            mixerGroupBox.SetBounds(8, 22, 70, 162)         'Sets the size and location of the group box
            mixerGroupBox.BringToFront()                    'Brings the group box to the front

            Dim mixerTrackBar As New TrackBar               'Creates a track bar to be named and used
            objName = "tbTrackBar" + numTracks.ToString     'Sets objName to the desired object name
            mixerTrackBar.Name = objName.ToString           'Sets the object name to be objName
            mixerGroupBox.Controls.Add(mixerTrackBar)       'Adds the track bar to the mixerGroupBox created dynamically
            mixerTrackBar.Orientation = Orientation.Vertical 'Sets the orientation of the track bar to be vertical, so it represents volume for a track
            mixerTrackBar.SetBounds(19, 22, 45, 104)        'Sets the location and size of the track bar
            mixerTrackBar.Value = 5                         'Sets the value of the track bar to be 5, this represents 0db change to the default volume of the track
            mixerTrackBar.BringToFront()                    'Brings the track bar to the front

            Dim pbMixerMute As New PictureBox                   'Creates a picture box to be named and used
            objName = "pbMixerMute" + numTracks.ToString   'Sets objName to the desired object name
            pbMixerMute.Name = objName.ToString                 'Sets the object nme to be objName
            mixerGroupBox.Controls.Add(pbMixerMute)             'Adds the picture box to the mixerGroupBox created dynamically
            pbMixerMute.SetBounds(9, 132, 25, 23)               'Sets the size and location of the picture box
            pbMixerMute.Image = muteMixerUp                     'Sets the image to be the mute button's up state
            pbMixerMute.BringToFront()                          'Brings the picture box to the front
            AddHandler pbMixerMute.Click, AddressOf pbMute_Click 'Adds a handler that controls what happens on click

            Dim pbMixerSolo As New PictureBox                   'Creates a picture box to be named and used
            objName = "pbMixerSolo" + numTracks.ToString   'Sets objName to the desired object name
            pbMixerSolo.Name = objName.ToString                 'Sets the object nme to be objName
            mixerGroupBox.Controls.Add(pbMixerSolo)             'Adds the picture box to the mixerGroupBox created dynamically
            pbMixerSolo.SetBounds(35, 132, 25, 23)              'Sets the size and location of the picture box
            pbMixerSolo.Image = soloMixerUp                     'Sets the image to be the solo button's up state
            pbMixerSolo.BringToFront()                          'Brings the picture box to the front
            AddHandler pbMixerSolo.Click, AddressOf pbSolo_Click 'Adds a handler that controls what happens on click

            'LOADING AN EXISTING FILE OPTION
        Else
            Dim fileDialog As New OpenFileDialog()                                              'create fileOpener object
            Dim tempo As Integer
            fileDialog.InitialDirectory = "H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\bin\Debug"
            fileDialog.Filter = "txt files (*.txt)|*.txt"
            fileDialog.ShowDialog()                                                             'Show the dialog box

            fileName = fileDialog.FileName                                                      'set fileName to the file being opened
            fileName = fileName.Substring(82)                                                   'cut off the directory path
            fileName = fileName.Substring(0, fileName.IndexOf("."))
            objFileManager.loadAlgoRhythm(tempo, numTracks, numMeasures, colTrack, fileName)           'Load the file with File Manager
            txtTempo.Text = tempo

            'Create all the images to be used
            Dim trackBackground As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\trackBackground.bmp")
            Dim muteMixerUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteButtonUp.png")
            Dim soloMixerUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloButtonUp.png")
            Dim muteUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteTrackButtonUp.png")
            Dim soloUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloTrackButtonUp.png")
            Dim muteDown As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteButtonDown.png")
            Dim soloDown As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloButtonDown.png")
            Dim XVAL = 53                                                                       'the constant value for # of pixels object needs to be moved for object placement
            Dim changeX As Integer = 0                                                          'used for placing rectangle shapes

            Dim objName As String

            playPressed = False                                                                 'Initialize playPressed to be off
            playHead = 1                                                                        'set playhead to be 1
            pnlMeasures.Controls.Add(measurePanel1)                                             'Adds the shape container to pnlMeasures
            pnlMeasures.Controls.Add(measurePanel2)                                             'Adds the shape container to pnlMeasures

            'CREATE PLAYHEAD
            For k As Integer = 1 To numMeasures                                                  'Counts from 1 to 10, adding a full measure to the UI each time
                objName = "pnlPlayHead1Measure" + k.ToString                            'Sets objName to the desired object name
                measurePanel1.Name = objName.ToString                                   'Sets the object name to be objName
                For m As Integer = 1 To 16 Step 1                                       'Counts from 1 to 16, by 4 to build and name each rectangle correctly
                    objName = "pnlPlayHead1Measure" + k.ToString + "Beat" + m.ToString  'Names each rectangle properly
                    Dim rectangle As New RectangleShape                                 'Creates a rectangle object, representing one QUARTER note
                    rectangle.Name = objName.ToString                                   'Sets the object name to be objName
                    rectangle.Parent = measurePanel1                                    'Sets the rectangles parent to be the shape container created earlier
                    rectangle.SetBounds(1 * changeX, 10, 5, 18)                         'Sets the size and lcoation of the rectangle
                    changeX = changeX + 5                                               'Increases changeX by 20 so the next rectangle is placed correctly
                    rectangle.FillStyle = FillStyle.Solid
                    rectangle.BorderColor = Color.FromArgb(101, 165, 210)               'Sets the boarder color to be orange, this will change depending on the selected instrument
                    rectangle.FillColor = Color.Transparent                             'Sets the boarder color to be transparent
                    rectangle.BringToFront()                                            'Brings the rectangle to the front
                    colPlayHead.Add(rectangle)
                    AddHandler rectangle.MouseClick, AddressOf rectPlayHead_Click
                Next
            Next

            scrollMeasureBox.Name = "ScrollMeasureBox"      'Sets the name of the picture box that enables the scroll bar in pnlMeasures
            pnlMeasures.Controls.Add(scrollMeasureBox)      'Adds the picture box to pnlMeasures
            'scrollMeasureBox.SetBounds(801, 0, 80, 52)      'Sets the location and size of the picture box
            scrollMeasureBox.SetBounds(((80 * numMeasures) - pnlMeasures.HorizontalScroll.Value) + 1, 0, 80, 52)

            'for each track, create the objects
            For k As Integer = 1 To numTracks
                'create controls
                Dim pbMute As New PictureBox
                Dim pbSolo As New PictureBox
                Dim trackLabel As New Label

                trackManager.addTrack(colTrack.Item(k))                                 'add track to the front-end trackManager collection
                colTrack.Item(k).objMeasureManager.fillCollection(colMeasures)          'fill the track's measureManager with the collection of measures

                changeX = 0                                                             'reset changeX for each track

                objName = "pbTrack" + k.ToString                                        'Create the pictureBox for the new track
                Dim pictureBox As New PictureBox
                pictureBox.Name = objName.ToString
                pnlTrackList.Controls.Add(pictureBox)
                pictureBox.SetBounds(0, XVAL * (k - 1), 166, 53)
                pictureBox.Image = trackBackground
                colPBTrack.Add(pictureBox)
                pictureBox.BringToFront()
                AddHandler pictureBox.Click, AddressOf pbTrack_Click

                objName = "lblTrack" + k.ToString                                       'Create the new track label to display instrument
                trackLabel.Name = objName.ToString
                pnlTrackList.Controls.Add(trackLabel)
                trackLabel.SetBounds(10, 18 + (XVAL * (k - 1)), 127, 16)
                If colTrack.Item(k).soundName = "null" Then
                    trackLabel.Text = "Select an Instrument"
                Else
                    trackLabel.Text = colTrack.Item(k).soundName
                End If
                trackLabel.BackColor = Color.FromArgb(40, 40, 40)
                trackLabel.BringToFront()
                colLBLTrack.Add(trackLabel)

                objName = "pbMuteTrack" + k.ToString                                    'Create Mute Button for new track
                pbMute.Name = objName.ToString
                pnlTrackList.Controls.Add(pbMute)
                pbMute.SetBounds(138, 1 + (XVAL * (k - 1)), 25, 23)
                'display the correct mute image that corresponds to the track's info
                If colTrack.Item(k).mute = True Then
                    pbMute.Image = muteDown
                Else
                    pbMute.Image = muteUp
                End If
                pbMute.BringToFront()
                colPBMute.Add(pbMute)
                AddHandler pbMute.Click, AddressOf pbMute_Click

                objName = "pbSoloTrack" + k.ToString                                    'Create Solo Button for new track
                pbSolo.Name = objName.ToString
                pnlTrackList.Controls.Add(pbSolo)
                pbSolo.SetBounds(138, 28 + (XVAL * (k - 1)), 25, 23)
                'display the correct mute image that corresponds to the track's info
                If colTrack.Item(k).solo = True Then
                    pbSolo.Image = soloDown
                Else
                    pbSolo.Image = soloUp
                End If
                pbSolo.BringToFront()
                colPBSolo.Add(pbSolo)
                AddHandler pbSolo.Click, AddressOf pbSolo_Click

                Dim measurePanel As New ShapeContainer                                  'Create measurePanel for each track
                pnlMeasures.Controls.Add(measurePanel)

                'add number of measures to the track (visually)
                For j As Integer = 1 To numMeasures
                    'Create new measure object
                    objName = "pnlTrack" + k.ToString + "Measure" + j.ToString
                    measurePanel.Name = objName.ToString                                        'name the measure panel according to track number & measure number

                    'add quarter beats for each measure. (Step 4 for naming the rectangles appropriately
                    For i As Integer = 1 To 16 Step 4
                        'Checks if the beat needs to be split into 16th notes
                        If colTrack.Item(k).objMeasureManager.colMeasures.item(j).beat(i) = True Then
                            For m As Integer = i To i + 3
                                objName = "pnlTrack" + k.ToString + "Measure" + j.ToString + "Beat" + m.ToString
                                Dim rectangle As New RectangleShape
                                rectangle.Name = objName.ToString                                       'name beat rectangle according to track number, measure number & beat number
                                rectangle.Parent = measurePanel                                         'make the rectangle a parent of the measurePanel
                                rectangle.SetBounds(1 * changeX, 48 + (52 * (k - 1)), 5, 25)           'visually place the rectanle on the GUI
                                changeX = changeX + 5                                                  'Increase the changeX incrementor

                                If colTrack.Item(k).objMeasureManager.colMeasures.item(j).beat(m - 1) = True Then
                                    rectangle.FillStyle = FillStyle.Solid                                      'set fill style to solid
                                    rectangle.FillColor = Color.DarkOrange                                     'set appropriate color
                                    rectangle.BorderColor = Color.FromArgb(40, 40, 40)                         'set border color to color of panel's background (make it transparent)
                                Else
                                    rectangle.BorderColor = Color.DarkOrange
                                    rectangle.FillColor = Color.Transparent
                                End If
                                rectangle.BringToFront()
                                AddHandler rectangle.MouseClick, AddressOf rectBeat_Click                       'Set Rectangle's handler
                            Next
                            'Checks if the beat needs to be split into 16th notes
                        ElseIf colTrack.Item(k).objMeasureManager.colMeasures.item(j).beat(i + 2) = True Then
                            For m As Integer = i To i + 3
                                objName = "pnlTrack" + k.ToString + "Measure" + j.ToString + "Beat" + m.ToString
                                Dim rectangle As New RectangleShape
                                rectangle.Name = objName.ToString                                       'name beat rectangle according to track number, measure number & beat number
                                rectangle.Parent = measurePanel                                         'make the rectangle a parent of the measurePanel
                                rectangle.SetBounds(1 * changeX, 48 + (52 * (k - 1)), 5, 25)           'visually place the rectanle on the GUI
                                changeX = changeX + 5                                                  'Increase the changeX incrementor

                                If colTrack.Item(k).objMeasureManager.colMeasures.item(j).beat(m - 1) = True Then
                                    rectangle.FillStyle = FillStyle.Solid                                      'set fill style to solid
                                    rectangle.FillColor = Color.DarkOrange                                     'set appropriate color
                                    rectangle.BorderColor = Color.FromArgb(40, 40, 40)                         'set border color to color of panel's background (make it transparent)
                                Else
                                    rectangle.BorderColor = Color.DarkOrange
                                    rectangle.FillColor = Color.Transparent
                                End If
                                rectangle.BringToFront()
                                AddHandler rectangle.MouseClick, AddressOf rectBeat_Click                       'Set Rectangle's handler
                            Next
                            'Checks if the beat needs to be split into 8th notes
                        ElseIf colTrack.Item(k).objMeasureManager.colMeasures.item(j).beat(i + 1) = True Then
                            For m As Integer = i To i + 2 Step 2
                                objName = "pnlTrack" + k.ToString + "Measure" + j.ToString + "Beat" + m.ToString
                                Dim rectangle As New RectangleShape
                                rectangle.Name = objName.ToString                                       'name beat rectangle according to track number, measure number & beat number
                                rectangle.Parent = measurePanel                                         'make the rectangle a parent of the measurePanel
                                rectangle.SetBounds(1 * changeX, 48 + (52 * (k - 1)), 10, 25)           'visually place the rectanle on the GUI
                                changeX = changeX + 10                                                  'Increase the changeX incrementor

                                If colTrack.Item(k).objMeasureManager.colMeasures.item(j).beat(m - 1) = True Then
                                    rectangle.FillStyle = FillStyle.Solid                                      'set fill style to solid
                                    rectangle.FillColor = Color.DarkOrange                                     'set appropriate color
                                    rectangle.BorderColor = Color.FromArgb(40, 40, 40)                         'set border color to color of panel's background (make it transparent)
                                Else
                                    rectangle.BorderColor = Color.DarkOrange
                                    rectangle.FillColor = Color.Transparent
                                End If
                                rectangle.BringToFront()
                                AddHandler rectangle.MouseClick, AddressOf rectBeat_Click                       'Set Rectangle's handler
                            Next
                            'Creates a single quarter note
                        Else
                            objName = "pnlTrack" + k.ToString + "Measure" + j.ToString + "Beat" + i.ToString
                            Dim rectangle As New RectangleShape
                            rectangle.Name = objName.ToString                                       'name beat rectangle according to track number, measure number & beat number
                            rectangle.Parent = measurePanel                                         'make the rectangle a parent of the measurePanel
                            rectangle.SetBounds(1 * changeX, 48 + (52 * (k - 1)), 20, 25)           'visually place the rectanle on the GUI
                            changeX = changeX + 20                                                  'Increase the changeX incrementor

                            'fill or unfill the beat according to the loaded data
                            If colTrack.Item(k).objMeasureManager.colMeasures.item(j).beat(i - 1) = True Then
                                rectangle.FillStyle = FillStyle.Solid                                      'set fill style to solid
                                rectangle.FillColor = Color.DarkOrange                                     'set appropriate color
                                rectangle.BorderColor = Color.FromArgb(40, 40, 40)                         'set border color to color of panel's background (make it transparent)
                            Else
                                rectangle.BorderColor = Color.DarkOrange
                                rectangle.FillColor = Color.Transparent
                            End If
                            rectangle.BringToFront()
                            AddHandler rectangle.MouseClick, AddressOf rectBeat_Click                       'Set Rectangle's handler
                        End If
                    Next
                Next

                'Create mixer Groupbox for the new track object
                Dim mixerGroupBox As New GroupBox
                objName = "gbTrackMixer" + k.ToString                                   'name groupbox according to TrackNumber
                mixerGroupBox.Name = objName.ToString
                gbMixer.Controls.Add(mixerGroupBox)                                             'add the new groupbox to the Mixer Container
                mixerGroupBox.SetBounds(8 + (76 * (k - 1)), 22, 70, 162)                'Set the location of the groupbox
                mixerGroupBox.BringToFront()

                'Create the TrackBar for new track object
                Dim mixerTrackBar As New TrackBar
                objName = "tbTrackBar" + k.ToString                                     'name trackbar according to TrackNumber
                mixerTrackBar.Name = objName.ToString
                mixerGroupBox.Controls.Add(mixerTrackBar)                                       'add track bar to the mixerGroupBox created above            
                mixerTrackBar.Orientation = Orientation.Vertical                                'set the Track bar's orientation
                mixerTrackBar.SetBounds(19, 22, 45, 104)                                        'set the location of the trackbar in the groupbox
                mixerTrackBar.Value = 5                                                         'set the track bar's default value
                mixerTrackBar.BringToFront()

                'Create track bar's mute button
                Dim pbMixerMute As New PictureBox
                objName = "pbMixerMute" + k.ToString
                pbMixerMute.Name = objName.ToString                                             'name the mute button according to track number
                mixerGroupBox.Controls.Add(pbMixerMute)                                         'add the button to the mixerGroupBox created above
                pbMixerMute.SetBounds(9, 132, 25, 23)                                           'set the location of the trackbar in the groupbox
                pbMixerMute.Image = muteMixerUp
                pbMixerMute.BringToFront()
                AddHandler pbMixerMute.Click, AddressOf pbMute_Click                            'Set the mute button's handler

                'Create track bar's solo button
                Dim pbMixerSolo As New PictureBox
                objName = "pbMixerSolo" + k.ToString
                pbMixerSolo.Name = objName.ToString                                             'name the mute button according to track number
                mixerGroupBox.Controls.Add(pbMixerSolo)                                         'add the button to the mixerGroupBox created above
                pbMixerSolo.SetBounds(35, 132, 25, 23)                                          'set the location of the trackbar in the groupbox
                pbMixerSolo.Image = soloMixerUp
                pbMixerSolo.BringToFront()
                AddHandler pbMixerSolo.Click, AddressOf pbSolo_Click                            'Set the mute button's handler

                'set soloTrack variable
                For Each track In colTrack
                    If track.boolSolo = True Then
                        soloTrack = True
                        Exit For
                    Else
                        soloTrack = False
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub lstInstruments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstInstruments.SelectedIndexChanged
        'This sub controls what happens when an instrument category is selected from lstInstruments
        If lstInstruments.SelectedItem = "Kick" Then        'If the selected item is bass, lstSounds is cleared and filled with bass sounds
            lstSounds.Items.Clear()                         'Clears lstSounds so it only contains sounds from the currently selected category
            lstSounds.Items.Add("Simple Kick")
            lstSounds.Items.Add("Low Kick")
            lstSounds.Items.Add("Soft Kick")
            lstSounds.Items.Add("Deep Kick")
        End If
        If lstInstruments.SelectedItem = "Snare" Then       'If the selected item is snare, lstSounds is cleared and filled with bass sounds
            lstSounds.Items.Clear()                         'Clears lstSounds so it only contains sounds from the currently selected category
            lstSounds.Items.Add("Dry Snare")
            lstSounds.Items.Add("Deep Snare")
            lstSounds.Items.Add("Wet Snare")
            lstSounds.Items.Add("Snare + Reverb")
        End If
        If lstInstruments.SelectedItem = "Hi-Hats" Then     'If the selected item is hi-hats, lstSounds is cleared and filled with bass sounds
            lstSounds.Items.Clear()                         'Clears lstSounds so it only contains sounds from the currently selected category
            lstSounds.Items.Add("Closed Hi-Hat")
            lstSounds.Items.Add("Open Hi-Hat")
            lstSounds.Items.Add("Soft Hi-Hat")
            lstSounds.Items.Add("Electronic Hi-Hat")
        End If
        If lstInstruments.SelectedItem = "Crash" Then       'If the selected item is crash, lstSounds is cleared and filled with bass sounds
            lstSounds.Items.Clear()                         'Clears lstSounds so it only contains sounds from the currently selected category
            lstSounds.Items.Add("High Crash")
            lstSounds.Items.Add("Sweet Crash")
            lstSounds.Items.Add("Deep Crash")
            lstSounds.Items.Add("Cheap Crash")
        End If
        If lstInstruments.SelectedItem = "Toms" Then        'If the selected item is toms, lstSounds is cleared and filled with bass sounds
            lstSounds.Items.Clear()                         'Clears lstSounds so it only contains sounds from the currently selected category
            lstSounds.Items.Add("Floor Tom")
            lstSounds.Items.Add("High Floor Tom")
            lstSounds.Items.Add("Deep Tom")
            lstSounds.Items.Add("Loud Tom")
        End If
        If lstInstruments.SelectedItem = "Ride" Then        'If the selected item is ride, lstSounds is cleared and filled with bass sounds
            lstSounds.Items.Clear()                         'Clears lstSounds so it only contains sounds from the currently selected category
            lstSounds.Items.Add("Classic Ride")
            lstSounds.Items.Add("Sweet Ride")
        End If
        If lstInstruments.SelectedItem = "Misc Drums" Then        'If the selected item is ride, lstSounds is cleared and filled with bass sounds
            lstSounds.Items.Clear()                         'Clears lstSounds so it only contains sounds from the currently selected category
            lstSounds.Items.Add("China Cymbal")
        End If

        If lstInstruments.SelectedItem = "Sound Effects" Then        'If the selected item is ride, lstSounds is cleared and filled with bass sounds
            lstSounds.Items.Clear()                         'Clears lstSounds so it only contains sounds from the currently selected category
            lstSounds.Items.Add("Whistle")
            lstSounds.Items.Add("Slide Whistle")
            lstSounds.Items.Add("Train Bell")
        End If
    End Sub

    Private Sub lblAddTrack_Click(sender As Object, e As EventArgs) Handles lblAddTrack.Click
        Dim trackBackground As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\trackBackground.bmp")
        Dim muteMixerUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteButtonUp.png")
        Dim soloMixerUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloButtonUp.png")
        Dim muteUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteTrackButtonUp.png")
        Dim soloUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloTrackButtonUp.png")

        If numTracks < 5 Then
            Dim XVAL = 53                                                                   'The incrementor used to create and place rectangles
            numTracks = numTracks + 1                                                       'Increase the track counter

            Dim objName As String
            Dim pbMute As New PictureBox
            Dim pbSolo As New PictureBox
            Dim trackLabel As New Label

            objName = "pbTrack" + numTracks.ToString                                        'Create the pictureBox for the new track
            Dim pictureBox As New PictureBox
            pictureBox.Name = objName.ToString
            pnlTrackList.Controls.Add(pictureBox)
            pictureBox.SetBounds(0, XVAL * (numTracks - 1), 166, 53)
            pictureBox.Image = trackBackground
            colPBTrack.Add(pictureBox)
            AddHandler pictureBox.Click, AddressOf pbTrack_Click

            objName = "lblTrack" + numTracks.ToString                                       'Create the new track label to display instrument
            trackLabel.Name = objName.ToString
            pnlTrackList.Controls.Add(trackLabel)
            trackLabel.SetBounds(10, 18 + (XVAL * (numTracks - 1)), 127, 16)
            trackLabel.Text = "Select an Instrument"
            trackLabel.BackColor = Color.FromArgb(40, 40, 40)
            trackLabel.BringToFront()
            colLBLTrack.Add(trackLabel)

            objName = "pbMuteTrack" + numTracks.ToString                                    'Create Mute Button for new track
            pbMute.Name = objName.ToString
            pnlTrackList.Controls.Add(pbMute)
            pbMute.SetBounds(138, 1 + (XVAL * (numTracks - 1)), 25, 23)
            pbMute.Image = muteUp
            pbMute.BringToFront()
            colPBMute.Add(pbMute)
            AddHandler pbMute.Click, AddressOf pbMute_Click

            objName = "pbSoloTrack" + numTracks.ToString                                    'Create Solo Button for new track
            pbSolo.Name = objName.ToString
            pnlTrackList.Controls.Add(pbSolo)
            pbSolo.SetBounds(138, 28 + (XVAL * (numTracks - 1)), 25, 23)
            pbSolo.Image = soloUp
            pbSolo.BringToFront()
            colPBSolo.Add(pbSolo)
            AddHandler pbSolo.Click, AddressOf pbSolo_Click

            Dim objMeasureManager As New clsMeasureManager                                  'create new measure manager for the new track to hold the Track's measures
            Dim track As New clsTrack(numTracks, "null", False, False, False, objMeasureManager)
            trackManager.addTrack(track)
            trackManager.fillCollection(colTrack)

            Dim measurePanel As New ShapeContainer
            Dim changeX As Integer = 0
            pnlMeasures.Controls.Add(measurePanel)

            'add number of measures to the track (visually)
            For j As Integer = 1 To numMeasures
                'Create new measure object
                Dim objMeasure As New clsMeasure(track.trackNumber, j, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False)
                track.objMeasureManager.addMeasure(objMeasure)                              'add measure object to measure manager
                objName = "pnlTrack" + numTracks.ToString + "Measure" + j.ToString
                measurePanel.Name = objName.ToString                                        'name the measure panel according to track number & measure number

                'add quarter beats for each measure. (Step 4 for naming the rectangles appropriately
                For i As Integer = 1 To 16 Step 4
                    objName = "pnlTrack" + numTracks.ToString + "Measure" + j.ToString + "Beat" + i.ToString
                    Dim rectangle As New RectangleShape
                    rectangle.Name = objName.ToString                                       'name beat rectangle according to track number, measure number & beat number
                    rectangle.Parent = measurePanel                                         'make the rectangle a parent of the measurePanel
                    rectangle.SetBounds(1 * changeX, 48 + (52 * (numTracks - 1)), 20, 25)   'visually place the rectanle on the GUI
                    changeX = changeX + 20                                                  'Increase the changeX incrementor
                    rectangle.BorderColor = Color.DarkOrange
                    rectangle.FillColor = Color.Transparent
                    rectangle.BringToFront()
                    AddHandler rectangle.MouseClick, AddressOf rectBeat_Click               'Set Rectangle's handler
                Next
            Next

            track.objMeasureManager.fillCollection(colMeasures)

            'Create mixer Groupbox for the new track object
            Dim mixerGroupBox As New GroupBox
            objName = "gbTrackMixer" + numTracks.ToString                                   'name groupbox according to TrackNumber
            mixerGroupBox.Name = objName.ToString
            gbMixer.Controls.Add(mixerGroupBox)                                             'add the new groupbox to the Mixer Container
            mixerGroupBox.SetBounds(8 + (76 * (numTracks - 1)), 22, 70, 162)                'Set the location of the groupbox
            mixerGroupBox.BringToFront()

            'Create the TrackBar for new track object
            Dim mixerTrackBar As New TrackBar
            objName = "tbTrackBar" + numTracks.ToString                                     'name trackbar according to TrackNumber
            mixerTrackBar.Name = objName.ToString
            mixerGroupBox.Controls.Add(mixerTrackBar)                                       'add track bar to the mixerGroupBox created above            
            mixerTrackBar.Orientation = Orientation.Vertical                                'set the Track bar's orientation
            mixerTrackBar.SetBounds(19, 22, 45, 104)                                        'set the location of the trackbar in the groupbox
            mixerTrackBar.Value = 5                                                         'set the track bar's default value
            mixerTrackBar.BringToFront()

            'Create track bar's mute button
            Dim pbMixerMute As New PictureBox
            objName = "pbMixerMute" + numTracks.ToString
            pbMixerMute.Name = objName.ToString                                             'name the mute button according to track number
            mixerGroupBox.Controls.Add(pbMixerMute)                                         'add the button to the mixerGroupBox created above
            pbMixerMute.SetBounds(9, 132, 25, 23)                                           'set the location of the trackbar in the groupbox
            pbMixerMute.Image = muteMixerUp
            pbMixerMute.BringToFront()
            AddHandler pbMixerMute.Click, AddressOf pbMute_Click                            'Set the mute button's handler

            'Create track bar's solo button
            Dim pbMixerSolo As New PictureBox
            objName = "pbMixerSolo" + numTracks.ToString
            pbMixerSolo.Name = objName.ToString                                             'name the mute button according to track number
            mixerGroupBox.Controls.Add(pbMixerSolo)                                         'add the button to the mixerGroupBox created above
            pbMixerSolo.SetBounds(35, 132, 25, 23)                                          'set the location of the trackbar in the groupbox
            pbMixerSolo.Image = soloMixerUp
            pbMixerSolo.BringToFront()
            AddHandler pbMixerSolo.Click, AddressOf pbSolo_Click                            'Set the mute button's handler
        Else
            MessageBox.Show("You can only have 5 tracks playing at once.", "Maximum tracks reached", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'This will attempt to lock scroll box
        ' scrollMeasureBox.SetBounds(((80 * numMeasures) - pnlMeasures.HorizontalScroll.Value) + 1, (53 * numTracks) - pnlMeasures.VerticalScroll.Value + 1, 80, 52)
    End Sub

    Private Sub pbMute_Click(sender As Object, e As EventArgs)
        'This sub handles what happens when the mute button is clicked
        Dim tempName As String                                                  'Stores which track that the button that is clicked belongs to
        Dim mixName As String                                                   'Stores which button is clicked

        'create image bitmaps for each mute button
        Dim muteMixerDown As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteButtonDown.png")
        Dim muteMixerUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteButtonUp.png")
        Dim muteUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteTrackButtonUp.png")

        Dim x As New Integer                                                    'Index of colPBMute, in the loop (possibly find a way to index the loop without this)
        x = 1                                                                   'Start at 1, since collections do
        trackManager.fillCollection(colTrack)                                   'add colTrack to trackManager

        mixName = sender.name.ToString                                          'initialize mixName to be the name of the object that was clicked
        tempName = mixName.Substring(11)                                        'initialize tempName to be the index # of the track that was selected

        'search each track in collection to find which track to make changes to
        For Each track In colTrack
            If Int(tempName) = x Then
                'if false, set track.boolMute = true and change the bitmap's image
                If track.boolMute = False Then
                    track.boolMute = True
                    sender.image = muteMixerDown
                    'if true, set track.boolMute = false and change the bitmap's image
                ElseIf track.boolMute = True Then
                    track.boolMute = False
                    'find out which mute button was clicked between track and mixer
                    If mixName.Substring(3, 1) = "u" Then
                        sender.image = muteUp
                    ElseIf mixName.Substring(3, 1) = "i" Then
                        sender.image = muteMixerUp
                    End If
                End If
            End If
            x = x + 1                                                           'increase the index
        Next
    End Sub

    Private Sub pbSolo_Click(sender As Object, e As EventArgs)
        'This sub handles what happens when the solo button is clicked

        Dim tempName As String                                                  'Stores which Track the button that is clicked belongs to
        Dim mixName As String                                                   'Stores which button is clicked

        'create image bitmaps for each mute button
        Dim soloMixerDown As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloButtonDown.png")
        Dim soloMixerUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloButtonUp.png")
        Dim soloUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloTrackButtonUp.png")

        Dim x As New Integer                                                    'Index of colPBSolo, in the loop (possibly find a way to index the loop without this)
        x = 1                                                                   'Start at 1, since collections do
        trackManager.fillCollection(colTrack)                                   'add colTrack collection to trackManager

        mixName = sender.name.ToString                                          'initialize mixName to be the name of the object that was clicked
        tempName = mixName.Substring(11)                                        'initialize tempName to be the index # of the track that was selected

        'search each track in collection to find which track to make changes to
        For Each track In colTrack
            If Int(tempName) = x Then
                'if false, set track.boolSolo = true and change the bitmap's image
                If track.boolSolo = False Then
                    track.boolSolo = True
                    sender.image = soloMixerDown
                    soloTrack = True
                    'if true, set track.boolSolo = false and change the bitmap's image
                ElseIf track.boolSolo = True Then
                    track.boolSolo = False
                    'find out which solo button was clicked between track and mixer
                    If mixName.Substring(3, 1) = "o" Then
                        sender.image = soloUp
                    ElseIf mixName.Substring(3, 1) = "i" Then
                        sender.image = soloMixerUp
                    End If
                End If
            End If
            x = x + 1                                                           'increase the index
        Next
        'Determine whether or not any track is soloed
        For Each track In colTrack
            If track.boolSolo = True Then
                soloTrack = True
                Exit For
            Else
                soloTrack = False
            End If
        Next

    End Sub
    'handles the visual filling/unfilling of a rectangle
    Private Sub rectBeat_Click(sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim temp As String
        Dim tempTrack As String
        Dim tempMeasure As String
        Dim tempBeat As String

        'set variables appropriately
        temp = sender.name.ToString
        tempTrack = temp
        tempMeasure = temp
        tempBeat = temp

        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            'Split Beats
            If (My.Computer.Keyboard.ShiftKeyDown) Then
                'Splitting Quarter Notes into 8th notes
                If (sender.width > 10) Then
                    Dim newBeatName As String                                           'holds the new beat's name
                    Dim xCoord As Integer                                               'holds the old beat's left coordinate
                    Dim yCoord As Integer                                               'holds the old beat's bottom coordinate
                    Dim tempWidth As Integer                                            'holds the width of the old beat

                    xCoord = sender.left
                    yCoord = sender.bottom
                    tempWidth = sender.width
                    sender.width = (tempWidth / 2)                                      'sets to half the beat's width

                    'create the new rectangle beat
                    Dim rectangle As New RectangleShape
                    newBeatName = temp.Substring(temp.Length - 1)                       'set the new beat's name according to its location in the measure
                    temp = (temp.Substring(0, temp.Length - 1) & (CInt(newBeatName) + 2))
                    rectangle.Name = temp
                    rectangle.SetBounds(xCoord + (tempWidth / 2), yCoord - sender.height, tempWidth / 2, sender.height)             'set the location of the new beat on the GUI
                    rectangle.Parent = sender.parent                                    'Sets the new beat's parent to be the same as the old beat's parent
                    rectangle.BorderColor = Color.DarkOrange                            'Sets the boarder color to be orang, this will change depending on the selected instrument type
                    rectangle.FillColor = Color.Transparent                             'Sets the background to be transparent
                    rectangle.BringToFront()                                            'Brings the rectangle to the front
                    AddHandler rectangle.MouseClick, AddressOf rectBeat_Click

                    'Splitting 8th Notes into 16th Notes
                ElseIf (sender.width > 5) Then
                    Dim newBeatName As String                                           'holds the new beat's name
                    Dim xCoord As Integer                                               'holds the old beat's left coordinate
                    Dim yCoord As Integer                                               'holds the old beat's bottom coordinate
                    Dim tempWidth As Integer                                            'holds the width of the old beat

                    xCoord = sender.left
                    yCoord = sender.bottom
                    tempWidth = sender.width
                    sender.width = (tempWidth / 2)                                      'sets to half the beat's width

                    Dim rectangle As New RectangleShape
                    newBeatName = temp.Substring(temp.Length - 1)                       'set the new beat's name according to its location in the measure
                    temp = (temp.Substring(0, temp.Length - 1) & (CInt(newBeatName) + 1))
                    rectangle.Name = temp
                    rectangle.SetBounds(xCoord + (tempWidth / 2), yCoord - sender.height, tempWidth / 2, sender.height)             'set the location of the new beat on the GUI
                    rectangle.Parent = sender.parent
                    rectangle.BorderColor = Color.DarkOrange                            'Sets the boarder color to be orang, this will change depending on the selected instrument type
                    rectangle.FillColor = Color.Transparent                             'Sets the background to be transparent
                    rectangle.BringToFront()                                            'Brings the rectangle to the front
                    AddHandler rectangle.MouseClick, AddressOf rectBeat_Click

                End If
                'Fill/Unfill Beats
            Else
                tempTrack = tempTrack.Substring(8, 1)

                Dim measureLengthOne As New Integer             'Temp variable for one digit measures
                Dim measureLengthTwo As New Integer             'Temp variable for two digit measures
                Dim measureLengthThree As New Integer           'Temp variable for three digit measures

                Try
                    measureLengthOne = CInt(tempMeasure.Substring(16, 1))
                Catch ex As Exception
                    measureLengthOne = 0
                End Try
                Try
                    measureLengthTwo = CInt(tempMeasure.Substring(16, 2))
                Catch ex As Exception
                    measureLengthTwo = 0
                End Try
                Try
                    measureLengthTwo = CInt(tempMeasure.Substring(16, 3))
                Catch ex As Exception
                    measureLengthThree = 0
                End Try

                If measureLengthThree <> 0 Then
                    tempMeasure = measureLengthThree
                ElseIf measureLengthTwo <> 0 Then
                    tempMeasure = measureLengthTwo
                Else
                    tempMeasure = measureLengthOne
                End If

                For Each track In colTrack
                    If track.TrackNumber = CInt(tempTrack) Then
                        track.objMeasureManager.fillCollection(colMeasures)
                        For Each measure In colMeasures
                            If measure.measureNumber = tempMeasure.Trim Then
                                If tempMeasure.Trim < 10 Then
                                    If tempMeasure.Length = 1 Then
                                        tempBeat = temp.Substring(21)
                                        If measure.beat(tempBeat - 1) = False Then
                                            measure.beat(tempBeat - 1) = True                                       'set beat to active
                                        Else
                                            measure.beat(tempBeat - 1) = False                                      'set beat to inactive
                                        End If
                                    ElseIf tempMeasure.Length = 2 Then
                                        tempBeat = temp.Substring(22)
                                        If measure.beat(tempBeat - 1) = False Then
                                            measure.beat(tempBeat - 1) = True
                                        Else
                                            measure.beat(tempBeat - 1) = False
                                        End If
                                    ElseIf tempMeasure.Length = 3 Then
                                        tempBeat = temp.Substring(23)
                                        If measure.beat(tempBeat - 1) = False Then
                                            measure.beat(tempBeat - 1) = True
                                        Else
                                            measure.beat(tempBeat - 1) = False
                                        End If
                                    End If
                                    If measure.beat(tempBeat - 1) = True Then
                                        sender.FillStyle = FillStyle.Solid                                      'set fill style to solid
                                        sender.FillColor = Color.DarkOrange                                     'set appropriate color
                                        sender.BorderColor = Color.FromArgb(40, 40, 40)                         'set border color to color of panel's background (make it transparent)
                                        sender.BringToFront()                                                   'bring object back to front
                                    Else
                                        sender.FillStyle = FillStyle.Solid                                      'set fill style to solid
                                        sender.FillColor = Color.Transparent                                    'set appropriate color
                                        sender.BorderColor = Color.DarkOrange                                   'set border color to color of panel's background (make it transparent)
                                        sender.BringToFront()                                                   'bring object back to front
                                    End If
                                ElseIf (tempMeasure < 100) Then
                                    If tempMeasure.Length = 1 Then
                                        tempBeat = temp.Substring(22)
                                        If measure.beat(tempBeat - 1) = False Then
                                            measure.beat(tempBeat - 1) = True
                                        Else
                                            measure.beat(tempBeat - 1) = False
                                        End If
                                    ElseIf tempMeasure.Length = 2 Then
                                        tempBeat = temp.Substring(22)
                                        If measure.beat(tempBeat - 1) = False Then
                                            measure.beat(tempBeat - 1) = True
                                        Else
                                            measure.beat(tempBeat - 1) = False
                                        End If
                                    ElseIf tempMeasure.Length = 3 Then
                                        tempBeat = temp.Substring(24)
                                        If measure.beat(tempBeat - 1) = False Then
                                            measure.beat(tempBeat - 1) = True
                                        Else
                                            measure.beat(tempBeat - 1) = False
                                        End If
                                    End If
                                    If measure.beat(tempBeat - 1) = True Then
                                        sender.FillStyle = FillStyle.Solid                                      'set fill style to solid
                                        sender.FillColor = Color.DarkOrange                                     'set appropriate color
                                        sender.BorderColor = Color.FromArgb(40, 40, 40)                         'set border color to color of panel's background (make it transparent)
                                        sender.BringToFront()                                                   'bring object back to front
                                    Else
                                        sender.FillStyle = FillStyle.Solid                                      'set fill style to solid
                                        sender.FillColor = Color.Transparent                                    'set appropriate color
                                        sender.BorderColor = Color.DarkOrange                                   'set border color to color of panel's background (make it transparent)
                                        sender.BringToFront()                                                   'bring object back to front
                                    End If
                                Else
                                    If tempMeasure.Length = 1 Then
                                        tempBeat = temp.Substring(23)
                                        If measure.beat(tempBeat - 1) = False Then
                                            measure.beat(tempBeat - 1) = True
                                        Else
                                            measure.beat(tempBeat - 1) = False
                                        End If
                                    ElseIf tempMeasure.Length = 2 Then
                                        tempBeat = temp.Substring(24)
                                        If measure.beat(tempBeat - 1) = False Then
                                            measure.beat(tempBeat - 1) = True
                                        Else
                                            measure.beat(tempBeat - 1) = False
                                        End If
                                    ElseIf tempMeasure.Length = 3 Then
                                        tempBeat = temp.Substring(25)
                                        If measure.beat(tempBeat - 1) = False Then
                                            measure.beat(tempBeat - 1) = True
                                        Else
                                            measure.beat(tempBeat - 1) = False
                                        End If
                                    End If
                                    If measure.beat(tempBeat - 1) = True Then
                                        sender.FillStyle = FillStyle.Solid                                      'set fill style to solid
                                        sender.FillColor = Color.DarkOrange                                     'set appropriate color
                                        sender.BorderColor = Color.FromArgb(40, 40, 40)                         'set border color to color of panel's background (make it transparent)
                                        sender.BringToFront()                                                   'bring object back to front
                                    Else
                                        sender.FillStyle = FillStyle.Solid                                      'set fill style to solid
                                        sender.FillColor = Color.Transparent                                    'set appropriate color
                                        sender.BorderColor = Color.DarkOrange                                   'set border color to color of panel's background (make it transparent)
                                        sender.BringToFront()                                                   'bring object back to front
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        ElseIf (e.Button = Windows.Forms.MouseButtons.Right) Then
            'Do nothing
        End If

    End Sub
    'allows movement of playhead by clicking on playhead rectangles
    Private Sub rectPlayHead_Click(sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim temp As String
        Dim tempMeasure As String
        Dim tempBeat As String

        temp = sender.name
        tempMeasure = temp
        tempBeat = temp

        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            If playPressed = False Then
                Dim measureLengthOne As New Integer             'Temp variable for one digit measures
                Dim measureLengthTwo As New Integer             'Temp variable for two digit measures
                Dim measureLengthThree As New Integer           'Temp variable for three digit measures

                Try
                    measureLengthOne = CInt(tempMeasure.Substring(19, 1))
                Catch ex As Exception
                    measureLengthOne = 0
                End Try
                Try
                    measureLengthTwo = CInt(tempMeasure.Substring(19, 2))
                Catch ex As Exception
                    measureLengthTwo = 0
                End Try
                Try
                    measureLengthTwo = CInt(tempMeasure.Substring(19, 3))
                Catch ex As Exception
                    measureLengthThree = 0
                End Try
                'set tempMeasure from string
                If measureLengthThree <> 0 Then
                    tempMeasure = measureLengthThree
                ElseIf measureLengthTwo <> 0 Then
                    tempMeasure = measureLengthTwo
                Else
                    tempMeasure = measureLengthOne
                End If

                'set tempBeat from string
                If tempMeasure.Trim < 10 Then
                    If tempMeasure.Length = 1 Then
                        tempBeat = temp.Substring(24)
                    ElseIf tempMeasure.Length = 2 Then
                        tempBeat = temp.Substring(25)
                    ElseIf tempMeasure.Length = 3 Then
                        tempBeat = temp.Substring(26)
                    End If
                ElseIf (tempMeasure < 100) Then
                    If tempMeasure.Length = 1 Then
                        tempBeat = temp.Substring(25)
                    ElseIf tempMeasure.Length = 2 Then
                        tempBeat = temp.Substring(25)
                    ElseIf tempMeasure.Length = 3 Then
                        tempBeat = temp.Substring(27)
                    End If
                Else
                    If tempMeasure.Length = 1 Then
                        tempBeat = temp.Substring(26)
                    ElseIf tempMeasure.Length = 2 Then
                        tempBeat = temp.Substring(27)
                    ElseIf tempMeasure.Length = 3 Then
                        tempBeat = temp.Substring(28)
                    End If
                End If

                'clear the playhead
                For j As Integer = 1 To colPlayHead.Count
                    colPlayHead.Item(j).FillColor = Color.Transparent
                Next

                'move playHead counter

                playHead = ((CInt(tempMeasure) - 1) * 16) + CInt(tempBeat)

                'refill playhead
                For k As Integer = 1 To playHead
                    colPlayHead.Item(k).FillColor = Color.FromArgb(101, 165, 210)
                    'Move PlayHead line
                    If k = playHead Then
                        lnPlayHead.Visible = True
                        lnPlayHead.X1 = colPlayHead.Item(k).left + 2.5
                        lnPlayHead.X2 = colPlayHead.Item(k).left + 2.5
                    End If
                Next
            End If 
        End If
    End Sub

    'visually selects track on form
    Private Sub pbTrack_Click(sender As Object, e As EventArgs)
        Dim tempName As String

        trackManager.fillCollection(colTrack)
        tempName = sender.name.ToString
        tempName = tempName.Substring(7)                                        'set tempName to be the index
        selectedTrack = Int(tempName)                                           'set global variable selectedTrack to the index of the Track being selected

        'remove all picture box borders
        For Each PictureBox In colPBTrack
            PictureBox.BorderStyle = BorderStyle.None
        Next

        'Find which track was selected
        For Each track In colTrack
            If track.TrackNumber = tempName Then
                sender.BorderStyle = BorderStyle.FixedSingle                    'add border to selected track
                track.boolSelected = True                                       'set the boolSelected to be true if its the track clicked on
            Else
                track.boolSelected = False
            End If
        Next

        pnlMeasures.AutoScrollPosition = New Point(pnlMeasures.HorizontalScroll.Value, pnlTrackList.VerticalScroll.Value)           'Moves scroll bar to end of measures (to view measures that have been added)
    End Sub
    'play demo of sound when clicked in list
    Private Sub lstSounds_MouseClick(sender As Object, e As MouseEventArgs) Handles lstSounds.MouseClick
        My.Computer.Audio.Play("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Sounds\" + lstSounds.SelectedItem + ".wav", AudioPlayMode.Background)
    End Sub
    'handles the event for selecting the instrument sound to a track 
    Private Sub lstSounds_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstSounds.MouseDoubleClick
        Dim x As New Integer                                                    'Index of colLBLTrack, in the loop
        x = 1                                                                   'Start at 1, since collections do
        For Each track In colTrack
            If track.boolSelected = True Then
                track.strSoundName = lstSounds.SelectedItem.ToString()
                colLBLTrack.Item(x).text = lstSounds.SelectedItem.ToString()
            End If
            x = x + 1                                                           'Increases x by 1 for each loop
        Next
    End Sub
    'Deletes the selected track from the form
    Private Sub lblDeleteTrack_Click(sender As Object, e As EventArgs) Handles lblDeleteTrack.Click
        'create image bitmaps for each button
        Dim muteDown As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteButtonDown.png")
        Dim muteUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteTrackButtonUp.png")
        Dim soloDown As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloButtonDown.png")
        Dim soloUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloTrackButtonUp.png")
        Dim tempName As String                                                  'Stores which track that the button that is clicked belongs to
        Dim mixName As String                                                   'Stores which button is clicked

        Dim x As New Integer                                                    'Used as a counter when traversing through colTrack when searching for the selected track
        Dim y As New Integer                                                    'Used as a counter when traversing through colTrack a second time
        Dim z As Integer                                                        'Used as a counter
        Dim tempTrack As clsTrack
        Dim c As Control
        Dim pb As PictureBox

        If colTrack.Count > 1 Then
            x = 0
            For Each track In colTrack
                x = x + 1
                If track.selected = True Then
                    'exits with current value of x
                    Exit For
                End If
            Next

            y = 0                                                                           'Start at 0
            'make changes to all tracks below deleted track
            For Each track In colTrack
                y = y + 1
                If y > x Then
                    'Initializing tempTrack to be the current track (back-end stuff)
                    tempTrack = track
                    tempTrack.trackNumber = track.trackNumber
                    tempTrack.soundName = track.soundName
                    tempTrack.solo = track.solo
                    tempTrack.mute = track.mute
                    tempTrack.selected = track.selected
                    tempTrack.measureManager = track.measureManager

                    c = colLBLTrack.Item(y - 1)
                    c.Text = tempTrack.soundName

                    pb = colPBMute.Item(y - 1)
                    z = 0                                                                   'Start at 0
                    mixName = pb.Name.ToString                                              'initialize mixName to be the name of the pictureBox that belongs to the above control
                    tempName = mixName.Substring(11)                                        'initialize tempName to be the index # of the track of the above control
                    'change mute buttons

                    For Each track2 In colTrack                                             'search each track in collection to find which track to make changes to
                        z = z + 1                                                           'increase the index
                        If z > x Then
                            If Int(tempName) = (y - 1) Then
                                If track2.mute = False Then
                                    pb.Image = muteUp
                                ElseIf track2.mute = True Then
                                    pb.Image = muteDown
                                End If
                            End If
                        End If
                    Next

                            pb = colPBSolo.Item(y - 1)
                            z = 0                                                                   'Start at 0
                            mixName = pb.Name.ToString                                              'initialize mixName to be the name of the pictureBox that belongs to the above control
                            tempName = mixName.Substring(11)                                        'initialize tempName to be the index # of the track of the above control
                            'change solo buttons
                            For Each track3 In colTrack                                             'search each track in collection to find which track to make changes to
                                z = z + 1                                                           'increase the index
                                If z > x Then
                                    If Int(tempName) = (y - 1) Then
                                        If track3.solo = False Then
                                            pb.Image = soloUp
                                        ElseIf track3.solo = True Then
                                            pb.Image = soloDown
                                        End If
                                    End If
                                End If
                            Next

                            'Sets the track attributes (back-end)
                            colTrack.Item(y - 1).trackNumber = tempTrack.trackNumber
                            colTrack.Item(y - 1).soundName = tempTrack.soundName
                            colTrack.Item(y - 1).solo = tempTrack.solo
                            colTrack.Item(y - 1).mute = tempTrack.mute
                            colTrack.Item(y - 1).selected = tempTrack.selected
                            colTrack.Item(y - 1).measureManager = tempTrack.measureManager
                            numTracks = numTracks - 1                                       'Decreases numTracks Counter
                        End If
                    Next

            c = colLBLTrack.Item(colLBLTrack.Count)
            c.Dispose()                                                     'allegedly removes control from form
            colLBLTrack.Remove(colLBLTrack.Count)                                           'removes control from collection

            'Delete Mute/Solo button from collection
            c = colPBMute.Item(colPBMute.Count)
            c.Dispose()                                                     'allegedly removes control from form
            colPBMute.Remove(colPBMute.Count)
            c = colPBSolo.Item(colPBSolo.Count)
            colPBSolo.Remove(colPBSolo.Count)
            c.Dispose()

            'delete picturebox from collection
            c = colPBTrack.Item(colPBTrack.Count)
            colPBTrack.Remove(colPBTrack.Count)
            c.Dispose()

            colTrack.Remove(x)

            'still need to delete all the mixer items

            'delete all measures from collection (can't get this to work)
            'For Each measure In track.objMeasureManager

            'Next

            'remove track from collection
        Else
            MessageBox.Show("You must have at least one track.", "Warning")
        End If
    End Sub

    Private Sub pbPlay_Click(sender As Object, e As EventArgs) Handles pbPlay.Click
        Dim playImage As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\PlayButton.bmp")
        Dim pauseImage As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\PauseButton.bmp")
        Dim measureNumber As Integer            'Finds the measure number that the playhead is currently at
        Dim beatNumber As Integer               'Finds the beat of the measure the playhead is currently at

        Dim interval As Integer                                                                                                         'Holds the interval which controls the speed in which the beats are played
        Dim i As Integer = 1

        'Check if track has sound. If not, display messagebox, give the track focus, exit sub
        For Each track In colTrack
            If track.soundName = "null" Then
                Dim tempName As String
                MessageBox.Show("You must select an instrument for track " & i, "Select an Instrument", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'give track focus
                trackManager.fillCollection(colTrack)
                tempName = i                                     'set tempName to be the index
                selectedTrack = Int(tempName)                                           'set global variable selectedTrack to the index of the Track being selected

                'remove all picture box borders
                For Each PictureBox In colPBTrack
                    PictureBox.BorderStyle = BorderStyle.None
                Next

                'Find which track was selected

                If track.TrackNumber = tempName Then
                    Dim j As Integer = 1
                    For Each PictureBox In colPBTrack
                        If j = i Then
                            PictureBox.BorderStyle = BorderStyle.FixedSingle                                        'Add border
                            Exit For
                        End If
                        j = j + 1
                    Next
                    track.boolSelected = True                                       'set the boolSelected to be true if its the track clicked on
                Else
                    track.boolSelected = False
                End If
                'Exit procedure
                Exit Sub
            End If
            i = i + 1
        Next
        'if player was currently playing, pause it
        If playPressed = True Then
            pbStop.Enabled = True                                                                                                       'enable the resetButton
            pbStop.Visible = True                                                                                                       'make resetButton visible
            playPressed = False                                                                                                         'Turn playPressed to False, because music is paused
            sender.image = playImage                                                                                                    'Change the image to play button image
        ElseIf playPressed = False Then                                                                                         'if player was currently not playing, start playing
            lnPlayHead.Visible = True                                                                                                   'make the playHead Line visible
            pbStop.Enabled = False                                                                                                      'Disable resetButton
            pbStop.Visible = False                                                                                                      'Make resetButton invisible
            playPressed = True                                                                                                          'Turn playPressed to True, because music is playing now
            sender.image = pauseImage                                                                                                   'Change the image to pause button image

            Try
                interval = Integer.Parse(txtTempo.Text.Trim)                                                                            'set the interval to Tempo.Text

                'Loop Filling the Playhead Rectangles, starting at playhead counter and running to end of collection
                For j As Integer = playHead To colPlayHead.Count
                    colPlayHead.Item(j).FillColor = Color.FromArgb(101, 165, 210)                                                           'Fill the playhead rectangle

                    'Move the Playhead Line
                    lnPlayHead.X1 = colPlayHead.Item(j).left + 2
                    lnPlayHead.X2 = colPlayHead.Item(j).left + 2

                    pnlMeasures.AutoScrollPosition = New Point(((colPlayHead.Item(j).Left - 250)), colPlayHead.Item(j).Top)                 'Scroll the panel with the playhead
                    'START SOUND
                    'if no track is soloed
                    If soloTrack = False Then
                        For Each track In colTrack
                            'if track is not muted
                            If track.boolMute = False Then
                                measureNumber = (j \ 16)                                                                                            'Sets measureNumber to the measure that the current beat is in
                                'keeps playHead from breaking at last measure
                                If (j \ 16) = numMeasures Then
                                    measureNumber = measureNumber - 1
                                End If
                                If (j Mod 16) = 0 Then
                                    measureNumber = measureNumber - 1
                                End If
                                beatNumber = (j Mod 16)                                                                                             'sets beatNumber to the current beat within the measure
                                'makes sure playHead plays the last beat of each measure
                                If beatNumber = 0 Then
                                    beatNumber = 16
                                End If

                                'if the beat is active, play the sound
                                If (track.objMeasureManager.colMeasures.Item(measureNumber + 1).beat(beatNumber - 1) = True) Then
                                    'Checks that a sound is selected for each track
                                    If track.soundName = "null" Then
                                        MessageBox.Show("Please select a sound for track " & track.trackNumber & ".", "No Instrument Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)                               'Display Error message
                                        'Reset playHead
                                        For Each RectangleShape In colPlayHead
                                            RectangleShape.FillColor = Color.Transparent
                                        Next
                                        'Return to paused state
                                        pbStop.Enabled = True
                                        playPressed = False
                                        pbStop.Visible = True
                                        sender.image = playImage
                                        pbPlay.Visible = True
                                        playHead = 1
                                        lnPlayHead.Visible = False
                                        Exit Sub                                                                                                    'Exit Procedure
                                    Else
                                        My.Computer.Audio.Play("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Sounds\" + track.soundName + ".wav", AudioPlayMode.Background)           'Play Track's Sound
                                    End If
                                End If
                            End If

                        Next
                        'There are tracks that are soloed
                    Else
                        For Each track In colTrack
                            If track.boolSolo = True Then
                                If track.boolMute = False Then
                                    measureNumber = (j \ 16)                                                                                            'Sets measureNumber to the measure that the current beat is in
                                    'keeps playHead from breaking at last measure
                                    If (j \ 16) = numMeasures Then
                                        measureNumber = measureNumber - 1
                                    End If
                                    beatNumber = (j Mod 16)                                                                                             'sets beatNumber to the current beat within the measure
                                    'makes sure playHead plays the last beat of each measure
                                    If beatNumber = 0 Then
                                        beatNumber = 16
                                    End If

                                    'if the beat is active, play the sound
                                    If (track.objMeasureManager.colMeasures.Item(measureNumber + 1).beat(beatNumber - 1) = True) Then
                                        'Checks that a sound is selected for each track
                                        If track.soundName = "null" Then
                                            MessageBox.Show("Please select a sound for track " & track.trackNumber & ".", "No Instrument Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)                               'Display Error message
                                            'Reset playHead
                                            For Each RectangleShape In colPlayHead
                                                RectangleShape.FillColor = Color.Transparent
                                            Next
                                            'Return to paused state
                                            pbStop.Enabled = True
                                            playPressed = False
                                            pbStop.Visible = True
                                            sender.image = playImage
                                            pbPlay.Visible = True
                                            playHead = 1
                                            lnPlayHead.Visible = False
                                            Exit Sub                                                                                                    'Exit Procedure
                                        Else
                                            My.Computer.Audio.Play("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Sounds\" + track.soundName + ".wav", AudioPlayMode.Background)           'Play Track's Sound
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    End If


                    'end sound
                    wait(60000 / interval / 4)                                                                                              'Call Wait Function
                    'If music was halted, stop the loop, set to pause state
                    If playPressed = False Then                                                                                             'Change Play/Pause button Image
                        pbStop.Enabled = True
                        pbStop.Visible = True
                        playHead = j                                                                                                        'Set the playhead's location
                        Exit For
                    End If
                    'if playhead has reached end of music, reset to paused state, but keep playhead filled
                    If j = colPlayHead.Count Then
                        playHead = j
                        pbStop.Enabled = True
                        playPressed = False
                        pbStop.Visible = True
                        sender.image = playImage
                        pbPlay.Visible = False
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error when pressing play", MessageBoxButtons.OK, MessageBoxIcon.Error)                         'Display Error Message
            End Try
        End If

    End Sub
    'Procedure for setting the interval between beats
    Public Sub wait(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
            Do While sw.ElapsedMilliseconds < interval
                Application.DoEvents()
            Loop
        sw.Stop()
    End Sub

    Private Sub pbStop_Click(sender As Object, e As EventArgs) Handles pbStop.Click
        'make sure music is not currently playing
        If playPressed = False Then
            'Reset Playhead
            For Each RectangleShape In colPlayHead
                RectangleShape.FillColor = Color.Transparent                                                                            'Unfill rectangle
            Next
            playHead = 1                                                                                                                'Reset playHead counter to 1
            lnPlayHead.Visible = False                                                                                                  'Remove playHead Line from form
            pbPlay.Visible = True                                                                                                           'make playButton Visible
        Else
            MessageBox.Show("Please Pause the Music before Reseting", "Unable to Reset PlayHead", MessageBoxButtons.OK, MessageBoxIcon.Error)           'Display Error Message
        End If

    End Sub

    Private Sub lblAddMeasure_Click(sender As Object, e As EventArgs) Handles lblAddMeasure.Click
        'This sub adds 1 measure to every track, this may be adjusted later to add a user specified number of measures

        Dim objName As String                       'Stores a string to set the name of objects created at runtime
        Dim changeX As Integer = (80 * numMeasures) 'Sets changeX to be the current number of measures * 80, so that any new rectangles are added in the correct location

        For m As Integer = 1 To 16 Step 1                                       'Counts from 1 to 16, by 4 to build and name each rectangle correctly
            objName = "pnlPlayHead1Measure" + (numMeasures + 1).ToString + "Beat" + m.ToString    'Names each rectangle properly
            Dim rectangle As New RectangleShape                                 'Creates a rectangle object, representing one QUARTER note
            rectangle.Name = objName.ToString                                   'Sets the object name to be objName
            rectangle.Parent = measurePanel1                                     'Sets the rectangles parent to be the shape container created earlier
            rectangle.SetBounds(1 * changeX, 10, 5, 18)                        'Sets the size and lcoation of the rectangle
            changeX = changeX + 5                                              'Increases changeX by 20 so the next rectangle is placed correctly
            rectangle.FillStyle = FillStyle.Solid
            rectangle.BorderColor = Color.FromArgb(101, 165, 210)                            'Sets the boarder color to be orange, this will change depending on the selected instrument
            rectangle.FillColor = Color.Transparent                             'Sets the boarder color to be transparent
            rectangle.BringToFront()                                            'Brings the rectangle to the front
            colPlayHead.Add(rectangle)
            AddHandler rectangle.MouseClick, AddressOf rectPlayHead_Click
        Next

        changeX = (80 * numMeasures)
        For k As Integer = 1 To numTracks                                               'Loops for each track that needs one measure added to it
            For i As Integer = (numMeasures + 1) To (numMeasures + 1)                   'Loops once, and allows i to be used when naming each rectangle
                objName = "pnlTrack" + k.ToString + "Measure" + numMeasures.ToString    'Sets objName to be the desired object name
                measurePanel2.Name = objName.ToString                                   'Sets the object name to be objName
                Dim objMeasure As New clsMeasure(k, i, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False)

                For Each track In colTrack
                    track.objMeasureManager.addMeasure(objMeasure)
                Next

                For j As Integer = 1 To 16 Step 4                                       'Loops from 1 to 16, by 4 to allow for proper naming of each rectangle
                    objName = "pnlTrack" + k.ToString + "Measure" + i.ToString + "Beat" + j.ToString    'Sets objName to be the desired objectName
                    Dim rectangle As New RectangleShape                                 'Creates a new rectangle object to be named and used
                    rectangle.Name = objName.ToString                                   'Sets the object name to be objName
                    rectangle.Parent = measurePanel2                                    'Sets the parent of the rectangle to be the shape container
                    rectangle.SetBounds(1 * changeX, 48 + (52 * (k - 1)), 20, 25)       'Sets the location and size of the rectangle
                    changeX = changeX + 20                                              'Increases changeX by 20 to account for the space of the previously added rectangle
                    rectangle.BorderColor = Color.DarkOrange                            'Sets the boarder color to be orang, this will change depending on the selected instrument type
                    rectangle.FillColor = Color.Transparent                             'Sets the background to be transparent
                    rectangle.BringToFront()                                            'Brings the rectangle to the front
                    pnlMeasures.AutoScrollPosition = New Point((rectangle.Left + 10), rectangle.Top)           'Moves scroll bar to end of measures (to view measures that have been added)
                    AddHandler rectangle.MouseClick, AddressOf rectBeat_Click
                Next
                changeX = changeX - 80              'Resets changeX back 80 so account for the next track
            Next
        Next

        For Each track In colTrack
            track.objMeasureManager.fillCollection(colMeasures)         'Fills the collection for each track on the front end
        Next

        numMeasures = numMeasures + 1               'Increases nummeasures by 1, because you've added a measure
        scrollMeasureBox.SetBounds(((80 * numMeasures) - pnlMeasures.HorizontalScroll.Value) + 1, 0, 80, 52)        'Moves the scrollMeasureBox so the scrollbar in pnlMeasures works correnctly
    End Sub

    Private Sub pbStepBack_Click(sender As Object, e As EventArgs) Handles pbStepBack.Click
        'Make sure music is not playing
        If playPressed = False Then
            'if playHead is more than 16 beats in
            If playHead > 16 Then
                playHead = playHead - 16                                                                            'Move the playHead back 16 beats

                'start over playhead rectangles
                For j As Integer = 1 To colPlayHead.Count
                    colPlayHead.Item(j).FillColor = Color.Transparent
                Next
                'fill the appropriate rectangles
                For j As Integer = 1 To playHead
                    colPlayHead.Item(j).FillColor = Color.FromArgb(101, 165, 210)
                    lnPlayHead.Visible = True                                                                       'Set playhead line to visible
                    'move playhead line
                    lnPlayHead.X1 = colPlayHead.Item(j).Left + 2.5
                    lnPlayHead.X2 = colPlayHead.Item(j).Left + 2.5
                    If j = playHead Then
                        pnlMeasures.AutoScrollPosition = New Point(colPlayHead.Item(j).left - 100, colPlayHead.Item(j).Top)           'Moves scroll bar to end of measures (to view measures that have been added)
                    End If
                Next
                'make sure play button is enabled
                If playHead < colPlayHead.Count Then
                    pbPlay.Visible = True
                    pbPlay.Enabled = True
                End If
            Else
                playHead = 1
                For j As Integer = 1 To colPlayHead.Count
                    colPlayHead.Item(j).FillColor = Color.Transparent
                    'Move playHead Line
                    If j = 1 Then
                        lnPlayHead.X1 = colPlayHead.Item(j).Left + 1
                        lnPlayHead.X2 = colPlayHead.Item(j).Left + 1
                    End If
                   
                Next
            End If
        Else
            MessageBox.Show("Unable to Skip. Pause the music first.", "Skip Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)      'Display Error
        End If
    End Sub

    Private Sub pbStepForward_Click(sender As Object, e As EventArgs) Handles pbStepForward.Click
        If playPressed = False Then
            If playHead < (colPlayHead.Count - 16) Then
                playHead = playHead + 16

                'start over playhead rectangles
                For j As Integer = 1 To colPlayHead.Count
                    colPlayHead.Item(j).FillColor = Color.Transparent
                Next
                'fill the appropriate rectangles
                For j As Integer = 1 To playHead
                    colPlayHead.Item(j).FillColor = Color.FromArgb(101, 165, 210)
                    lnPlayHead.Visible = True                                                                       'Set playhead line to visible
                    'move playhead line
                    lnPlayHead.X1 = colPlayHead.Item(j).Left + 2.5
                    lnPlayHead.X2 = colPlayHead.Item(j).Left + 2.5
                    If j = playHead Then
                        pnlMeasures.AutoScrollPosition = New Point(colPlayHead.Item(j).left - 450, colPlayHead.Item(j).Top)           'Moves scroll bar to end of measures (to view measures that have been added)
                    End If
                Next

            Else
                playHead = colPlayHead.Count
                For j As Integer = 1 To colPlayHead.Count
                    colPlayHead.Item(j).FillColor = Color.FromArgb(101, 165, 210)
                    If j = colPlayHead.Count Then
                        lnPlayHead.X1 = colPlayHead.Item(j).Left + 4
                        lnPlayHead.X2 = colPlayHead.Item(j).Left + 4
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If fileName = "newFile" Then
            fileName = InputBox("Enter the name of the file", "Enter File Name", "newFile")
            If fileName = "" Then                                                                                                           'If user cancelled save
                Exit Sub
            Else
                Dim filepath As String = "H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\bin\Debug\" & fileName & ".txt"
                'Check if file already exists
                If Not System.IO.File.Exists(filepath) Then
                    System.IO.File.Create(filepath).Dispose()
                    objFileManager.saveAlgoRhythm(txtTempo.Text, numTracks, numMeasures, colTrack, fileName)
                    MessageBox.Show("File successfully saved!")
                Else
                    MessageBox.Show("This file already exists. Please save file with a unique name.", "File Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            
        End If
        objFileManager.saveAlgoRhythm(txtTempo.Text, numTracks, numMeasures, colTrack, fileName)
        MessageBox.Show("File successfully saved!")
    End Sub

    Private Sub OpenProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenProjectToolStripMenuItem.Click
        'Will be unable to load a project if things have already been placed, since dynamically created items can't be deleted at runtime
        MessageBox.Show("Due to our program's current abilities, a project must be loaded at startup. Please restart the program and load a file from the prompt.", "Restart Program Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        'display warning Message box
        Dim closeProgram As DialogResult = MessageBox.Show("Are you sure you want to close AlgoRhythms?", "Close AlgoRhythms?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        'if user chooses yes, close program
        If closeProgram = Windows.Forms.DialogResult.Yes Then
            If fileName = "newFile" Then                                                                                                                            'If the file hasn't been saved yet, do save as process
                Do                                                                                                                                                     'If user cancels save, prompt for save again
                    Dim saveFile As DialogResult
                    If fileName = "" Then                                                                                                                                               'Display  correct message box if save has been previously aborted
                        saveFile = MessageBox.Show("Save Aborted. Would you still like to save?", "Save Progress?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    Else
                        saveFile = MessageBox.Show("Would you like to save your progress?", "Save Progress?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    End If

                    If saveFile = Windows.Forms.DialogResult.Yes Then
                        fileName = InputBox("Enter the name of the file", "Enter File Name", "newFile")
                        If Not fileName = "" Then                                                                                                                                           'Don't continue to save the program if fileName is empty
                            Dim filepath As String = "H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\bin\Debug\" & fileName & ".txt"
                            'Check if file already exists
                            If Not System.IO.File.Exists(filepath) Then                                                                                                                 'If file doesn't already exist
                                System.IO.File.Create(filepath).Dispose()                                                                                                                   'Create file
                                objFileManager.saveAlgoRhythm(txtTempo.Text, numTracks, numMeasures, colTrack, fileName)                                                                                   'save file in newly created txt file
                                MessageBox.Show("File successfully saved!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)                                            'Display confirmation message
                            Else                                                                                                                                                        'If file exists already
                                MessageBox.Show("This file already exists. Please save file with a unique name.", "File Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error)        'Display error message box that file already exists
                            End If
                            Me.Close()
                        End If

                    Else
                        Me.Close()                                                                                                                                                          'Close form
                        Exit Do                                                                                                                                                             'Exit loop
                    End If
                Loop While fileName = ""
            Else                                                                                                                                                                        'If file has been saved before, do save process
                Dim saveFile As DialogResult = MessageBox.Show("Would you like to save your progress?", "Save Progress?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)          'Ask if user wants to save progress
                If saveFile = Windows.Forms.DialogResult.Yes Then
                    objFileManager.saveAlgoRhythm(txtTempo.Text, numTracks, numMeasures, colTrack, fileName)                                                                                               'Save file
                    MessageBox.Show("File successfully saved!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)                                                        'Show confirmation box
                    Me.Close()                                                                                                                                                              'Close Form
                Else                                                                                                                                                                    'User doesn't want to save progress
                    MessageBox.Show("File not Saved. Closing Program", "File Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        fileName = InputBox("Enter the name of the file", "Enter File Name", "newFile")
        Dim filepath As String = "H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\bin\Debug\" & fileName & ".txt"
        'Check if file already exists
        If Not System.IO.File.Exists(filepath) Then
            System.IO.File.Create(filepath).Dispose()
            objFileManager.saveAlgoRhythm(txtTempo.Text, numTracks, numMeasures, colTrack, fileName)
            MessageBox.Show("File successfully saved!")
        Else
            MessageBox.Show("This file already exists. Please save file with a unique name.", "File Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub pnlTrackList_Scroll(sender As Object, e As ScrollEventArgs) Handles pnlTrackList.Scroll
        pnlMeasures.AutoScrollPosition = New Point(pnlMeasures.HorizontalScroll.Value, pnlTrackList.VerticalScroll.Value)           'Moves scroll bar to end of measures (to view measures that have been added)
    End Sub

    Private Sub menuHelp_Click(sender As Object, e As EventArgs) Handles menuHelp.Click
        helpForm.Show()

    End Sub
End Class
