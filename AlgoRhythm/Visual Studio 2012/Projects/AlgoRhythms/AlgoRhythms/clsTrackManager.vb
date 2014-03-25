Public Class clsTrackManager
    Dim colTracks As New Collection

    Public Sub addTrack(ByRef track As clsTrack)
        colTracks.Add(track)
    End Sub

    Public Sub fillCollection(ByRef colTrack As Collection)
        colTrack.Clear()
        For Each track In colTracks
            colTrack.Add(track)
        Next
    End Sub
    'procedure that will save any modified changes to collection (opposite of fill collection as discussed)
    Public Sub updateCollection(ByRef colTrack As Collection)

    End Sub
    'handles setting boolMute for when mute button is clicked
    Public Sub muteClicked(ByRef boolMute As Boolean)
        If boolMute = False Then
            boolMute = True
        ElseIf boolMute = True Then
            boolMute = False
        End If
    End Sub
    'handles setting boolSolo for when solo button is clicked
    Public Sub soloClicked(ByRef boolSolo As Boolean)
        If boolSolo = False Then
            boolSolo = True
        ElseIf boolSolo = True Then
            boolSolo = False
        End If
    End Sub
End Class
