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
    Dim measurePanel1 As New ShapeContainer             'Creates a shape container to hold all the rectangle objects
    Dim measurePanel2 As New ShapeContainer

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'On load, 1 track is added, including 10 measures and its mixer componant
        Dim trackBackground As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\trackBackground.bmp")
        Dim muteUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteTrackButtonUp.png")
        Dim soloUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloTrackButtonUp.png")
        Dim muteMixerUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\muteButtonUp.png")
        Dim soloMixerUp As New Bitmap("H:\SE461\AlgoRhythm\Visual Studio 2012\Projects\AlgoRhythms\AlgoRhythms\My Project\Images\soloButtonUp.png")

        numTracks = 1                                   'Sets the number of tracks to 1, the one created on load
        numMeasures = 1                                 'Sets the number of tracks to 1 so 10 measures can be added in a loop later
        playPressed = False                             'Initialize playPressed to be off
        playHead = 1                                    'Starts at 1, at the beginning of the playbar

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
                rectangle.BringToFront()                                            'Brings the rectangle to the front
                colPlayHead.Add(rectangle)
            Next
        Next

        changeX = 0
        For j As Integer = 1 To 10                                                  'Counts from 1 to 10, adding a full measure to the UI each time
            Dim objMeasure As New clsMeasure(track.trackNumber, j, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False)
            track.objMeasureManager.addMeasure(objMeasure)
            objName = "pnlTrack" + numTracks.ToString + "Measure" + j.ToString      'Sets objName to the desired object name
            measurePanel2.Name = objName.ToString                                    'Sets the object name to be objName
            For i As Integer = 1 To 16 Step 4                                       'Counts from 1 to 16, by 4 to build and name each rectangle correctly
                objName = "pnlTrack" + numTracks.ToString + "Measure" + j.ToString + "Beat" + i.ToString    'Names each rectangle properly
                Dim rectangle As New RectangleShape                                 'Creates a rectangle object, representing one QUARTER note
                rectangle.Name = objName.ToString                                   'Sets the object name to be objName
                rectangle.Parent = measurePanel2                                    'Sets the rectangles parent to be the shape container created earlier
                rectangle.SetBounds(1 * changeX, 48, 20, 25)                        'Sets the size and lcoation of the rectangle
                changeX = changeX + 20                                              'Increases changeX by 20 so the next rectangle is placed correctly
                rectangle.BorderColor = Color.DarkOrange                            'Sets the boarder color to be orange, this will change depending on the selected instrument
                rectangle.FillColor = Color.Transparent                             'Sets the boarder color to be transparent
                rectangle.BringToFront()                                            'Brings the rectangle to the front
                AddHandler rectangle.MouseClick, AddressOf rectBeat_Click
            Next
        Next
        numMeasures = 10                                'Sets numMeasures to reflect the current number of measures

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
            Else
                tempTrack = tempTrack.Substring(8, 1)
                'PROBLEM HERE YEA?
                'After measure 9, this fails because 10 is 2 digits
                'objName = "pnlTrack" + numTracks.ToString + "Measure" + j.ToString + "Beat" + i.ToString
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
                                        If measure.beat(tempBeat) = False Then
                                            measure.beat(tempBeat) = True
                                        Else
                                            measure.beat(tempBeat) = False
                                        End If
                                    ElseIf tempMeasure.Length = 2 Then
                                        tempBeat = temp.Substring(22)
                                        If measure.beat(tempBeat) = False Then
                                            measure.beat(tempBeat) = True
                                        Else
                                            measure.beat(tempBeat) = False
                                        End If
                                    ElseIf tempMeasure.Length = 3 Then
                                        tempBeat = temp.Substring(23)
                                        If measure.beat(tempBeat) = False Then
                                            measure.beat(tempBeat) = True
                                        Else
                                            measure.beat(tempBeat) = False
                                        End If
                                    End If
                                    If measure.beat(tempBeat) = True Then
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
                                        If measure.beat(tempBeat) = False Then
                                            measure.beat(tempBeat) = True
                                        Else
                                            measure.beat(tempBeat) = False
                                        End If
                                    ElseIf tempMeasure.Length = 2 Then
                                        tempBeat = temp.Substring(22)
                                        If measure.beat(tempBeat) = False Then
                                            measure.beat(tempBeat) = True
                                        Else
                                            measure.beat(tempBeat) = False
                                        End If
                                    ElseIf tempMeasure.Length = 3 Then
                                        tempBeat = temp.Substring(24)
                                        If measure.beat(tempBeat) = False Then
                                            measure.beat(tempBeat) = True
                                        Else
                                            measure.beat(tempBeat) = False
                                        End If
                                    End If
                                    If measure.beat(tempBeat) = True Then
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
                                        If measure.beat(tempBeat) = False Then
                                            measure.beat(tempBeat) = True
                                        Else
                                            measure.beat(tempBeat) = False
                                        End If
                                    ElseIf tempMeasure.Length = 2 Then
                                        tempBeat = temp.Substring(24)
                                        If measure.beat(tempBeat) = False Then
                                            measure.beat(tempBeat) = True
                                        Else
                                            measure.beat(tempBeat) = False
                                        End If
                                    ElseIf tempMeasure.Length = 3 Then
                                        tempBeat = temp.Substring(25)
                                        If measure.beat(tempBeat) = False Then
                                            measure.beat(tempBeat) = True
                                        Else
                                            measure.beat(tempBeat) = False
                                        End If
                                    End If
                                    If measure.beat(tempBeat) = True Then
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
    End Sub

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

        Dim x As New Integer
        Dim y As New Integer
        Dim z As Integer
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

            y = 0
            For Each track In colTrack
                y = y + 1
                If y > x Then
                    'Initializing trmpTrack to be the current track
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

                    For Each track3 In colTrack                                             'search each track in collection to find which track to make changes to
                        z = z + 1                                                           'increase the index
                        If z > x Then
                            If Int(tempName) = (y - 1) Then
                                If track.solo = False Then
                                    pb.Image = soloUp
                                ElseIf track.solo = True Then
                                    pb.Image = soloDown
                                End If
                            End If
                        End If
                    Next

                    'Sets the track attributes
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

        Dim interval As Integer
        If playPressed = True Then
            pbStop.Enabled = True
            pbStop.Visible = True
            playPressed = False
            sender.image = playImage
        ElseIf playPressed = False Then
            pbStop.Enabled = False
            pbStop.Visible = False
            playPressed = True
            sender.image = pauseImage
            Try
                interval = Integer.Parse(txtTempo.Text.Trim)

                For j As Integer = playHead To colPlayHead.Count
                    colPlayHead.Item(j).FillColor = Color.FromArgb(101, 165, 210)
                    wait(60000 / interval / 4)
                    If playPressed = False Then
                        pbStop.Enabled = True
                        pbStop.Visible = True
                        playHead = j
                        Exit For
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show("Please enter BPM as a whole number.")
            End Try
        End If

    End Sub

    Public Sub wait(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
            Do While sw.ElapsedMilliseconds < interval
                Application.DoEvents()
            Loop
        sw.Stop()
    End Sub

    Private Sub pbStop_Click(sender As Object, e As EventArgs) Handles pbStop.Click
        If playPressed = False Then
            For Each RectangleShape In colPlayHead
                RectangleShape.FillColor = Color.Transparent
                playHead = 1
            Next
        End If
    End Sub

    Private Sub mainForm_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        lblAddMeasure.Text = colTrack.Count.ToString
    End Sub

    Private Sub lblAddMeasure_Click_1(sender As Object, e As EventArgs) Handles lblAddMeasure.Click
        'This sub adds 1 measure to every track, this may be adjusted later to add a user specified number of measures

        Dim objName As String                       'Stores a string to set the name of objects created at runtime
        Dim changeX As Integer = (80 * numMeasures) 'Sets changeX to be the current number of measures * 80, so that any new rectangles are added in the correct location

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
                rectangle.BringToFront()                                            'Brings the rectangle to the front
                colPlayHead.Add(rectangle)
            Next
        Next

        changeX = (80 * numMeasures)
        For k As Integer = 1 To numTracks                                               'Loops for each track that needs one measure added to it
            For i As Integer = (numMeasures + 1) To (numMeasures + 1)                   'Loops once, and allows i to be used when naming each rectangle
                objName = "pnlTrack" + k.ToString + "Measure" + numMeasures.ToString    'Sets objName to be the desired object name
                measurePanel2.Name = objName.ToString                                    'Sets the object name to be objName
                Dim objMeasure As New clsMeasure(k, i, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False)

                For Each track In colTrack
                    track.objMeasureManager.addMeasure(objMeasure)
                Next

                For j As Integer = 1 To 16 Step 4                                       'Loops from 1 to 16, by 4 to allow for proper naming of each rectangle
                    objName = "pnlTrack" + k.ToString + "Measure" + i.ToString + "Beat" + j.ToString    'Sets objName to be the desired objectName
                    Dim rectangle As New RectangleShape                                 'Creates a new rectangle object to be named and used
                    rectangle.Name = objName.ToString                                   'Sets the object name to be objName
                    rectangle.Parent = measurePanel2                                     'Sets the parent of the rectangle to be the shape container
                    rectangle.SetBounds(1 * changeX, 48 + (52 * (k - 1)), 20, 25)       'Sets the location and size of the rectangle
                    changeX = changeX + 20                                              'Increases changeX by 20 to account for the space of the previously added rectangle
                    rectangle.BorderColor = Color.DarkOrange                            'Sets the boarder color to be orang, this will change depending on the selected instrument type
                    rectangle.FillColor = Color.Transparent                             'Sets the background to be transparent
                    rectangle.BringToFront()                                            'Brings the rectangle to the front
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
        If playPressed = False Then
            If playHead > 16 Then
                playHead = playHead - 16
                For j As Integer = 1 To colPlayHead.Count
                    colPlayHead.Item(j).FillColor = Color.Transparent
                Next
                For j As Integer = 1 To playHead
                    colPlayHead.Item(j).FillColor = Color.FromArgb(101, 165, 210)
                Next
            Else
                playHead = 1
                For j As Integer = 1 To colPlayHead.Count
                    colPlayHead.Item(j).FillColor = Color.Transparent
                Next
            End If
        End If
    End Sub

    Private Sub pbStepForward_Click(sender As Object, e As EventArgs) Handles pbStepForward.Click
        If playPressed = False Then
            If playHead < (colPlayHead.Count - 16) Then
                playHead = playHead + 16
                For j As Integer = 1 To colPlayHead.Count
                    colPlayHead.Item(j).FillColor = Color.Transparent
                Next
                For j As Integer = 1 To playHead
                    colPlayHead.Item(j).FillColor = Color.FromArgb(101, 165, 210)
                Next
            Else
                playHead = colPlayHead.Count
                For j As Integer = 1 To colPlayHead.Count
                    colPlayHead.Item(j).FillColor = Color.FromArgb(101, 165, 210)
                Next
            End If
        End If
    End Sub
End Class
