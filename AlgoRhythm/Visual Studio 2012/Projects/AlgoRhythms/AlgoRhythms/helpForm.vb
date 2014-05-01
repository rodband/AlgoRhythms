Public Class helpForm

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstHelp.SelectedIndexChanged
        If lstHelp.SelectedItem = "Creating a New File" Then
            lblTitle.Text = "Creating a New File"
            lblHelp.Text = "Creating a new file in AlgoRhythms is extremely easy. In fact, if you're reading this now, you've already done it! A new file is created every time AlgoRhythms is opened."
        End If
        If lstHelp.SelectedItem = "Understanding the Interface" Then
            lblTitle.Text = "UnderStanding the Interface"
            lblHelp.Text = "UnderStanding the AlgoRhythm interface can be daunting at first, but is easy to get used to. On opening the program, you will notice a large box that dominates the form; this is the Track area, which contains all the current tracks and the music beats associated with it. Also in this box, you will see the Add Track, Delete Track, and Add Measure buttons, which will be used to make your music your own. " &
                "At the top of the window, you should see a line of blue rectangles. This is the playbar, which will track your current position in music according to time. A green line will often appear on the form when music is being played. Each track has its own set of properties, including the instrument, and two buttons for muting and soloing. " &
                "To the right of the track list, you will see a line of orange rectangles for each track. This is the beat that each track can play. Initially, each orange rectangle represents a quarter note, but can be divided into 8th and 16th notes for faster beats. These rectangles can be toggled on and off in order to instruct the track to play a beat. " &
                "At the bottom of the box, you will see the 4 media control buttons (Skip back, Play/Pause, Stop, and Skip Forward), which are used to listen to the music you created. To the right of the form, you will see a list containing all the playable sounds & instruments. This is your Instrument List. It is here where you select the instrument for each track in your file. " &
                "Lastly, at the bottom of the form, you will see another box, which contains an array of sliders, along with a mute and solo button. These correspond to each track above and will allow you to modify the overall sound of each track individually."
        End If
        If lstHelp.SelectedItem = "Adding New Tracks" Then
            lblTitle.Text = "Adding New Tracks"
            lblHelp.Text = "Adding a track to your file is as simple as one button click. Simply click the Add Track button, which is located in the top left corner of the Track area. Once clicked, you will see a new track appear in the Track list indicating that no instrument has been selected yet, along with an empty list of orange beat boxes. In order to play your sound file, you must select an instrument for the track, even if you don't have the track playing any beats!"
        End If
        If lstHelp.SelectedItem = "Choosing an Instrument" Then
            lblTitle.Text = "Choosing an Instrument"
            lblHelp.Text = "In order to play your sound file, you must select an instrument to play. Doing this is quite simple. When you have an empty track with no instrument selected on your form, select it by clicking on the track. You will know when the track is selected when you see a gray border appear around the track. " &
                "Once the track is selected, go to the Instrument list and select a category. This will open up a secondary list of sounds associated with that category. From here, you can click the sound name once to preview the sound, or double-click it to set that instrument sound to the track. The same process applies when changing a track's instrument from one to another."
        End If
        If lstHelp.SelectedItem = "Giving a Track Music" Then
            lblTitle.Text = "Giving a Track Music"
            lblHelp.Text = "Once you have Tracks on the form and instruments selected for each of them, it's time to give your tracks music to play. This can be done by clicking each of the orange rectangles to the right of the track. You can activate a beat by clicking on it, which will fill in the rectangle. Each rectangle corresponds to a quarter beat, but can be divided by 8th and 16th beats by clicking the rectangle while holding down the SHIFT button. " &
                "Once a beat is divided, the box will become smaller and a second one will appear to the right of the originally divided beat. Once a beat is divided, it cannot be recombined back to a larger beat. This won't have any repercussions on the way your music sounds, however. If you want to play a quarter beat where you have two 8th beats, simply select the first beat and leave the second beat empty. Initially, all tracks start with 10 beats. However, " &
                "if you find that you need more beats, you can add them by pressing the Add Measure button. This will give all tracks on the form an extra measure, which will be appended to the end of the line. Click the Add Measure button until you get the desired number of beats."
        End If
        If lstHelp.SelectedItem = "Using the Media Controls" Then
            lblTitle.Text = "Using the Media Controls"
            lblHelp.Text = "Using AlgoRhythm's media controls is much like using media controls in any other program. Pushing the Play button will start the music from the current playHead position, which is noted by the green playhead line that scrolls across the notes. The same button can be pressed again to pause the music at its current playHead location. " &
                "Pressing the Stop Button will reset the playHead to the beginning. The skip controls only work when the music is paused, and will move the playHead forward or back exactly one measure, or 16 beats. To the left of the media buttons, you will see a tempo box containing a number. This represents the speed at which the music will be played and can be modified. " &
                "The number represents the number of beats played per minute."
        End If
        If lstHelp.SelectedItem = "Saving Your File" Then
            lblTitle.Text = "Saving Your File"
            lblHelp.Text = "After you are satisfied with the file you created, you may want to save your creation. To do this, click the Save As option in the File dropdown menu. Clicking this will cause an input box to open up, asking for a name to save your file as. After doing this, your file will have been saved and can be loaded at any time. " &
                "All files saved in AlgoRhythms will be saved as .txt files automatically, so there's no need to include that in your file name. You can also save a file that has already been initially saved. To do this, simply click the Save option in the File dropdown menu. If you would like to rename a saved file, simply click Save As and save it under a new file name."
        End If
    End Sub
End Class