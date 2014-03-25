Public Class clsMeasureManager
    Dim colMeasures As New Collection

    Public Sub addMeasure(ByRef measure As clsMeasure)
        colMeasures.Add(measure)
    End Sub

    'finish this
    Public Sub fillCollection(ByRef colMeasure As Collection)
        colMeasure.Clear()

        For Each measure In colMeasures
            colMeasure.Add(measure)
        Next
    End Sub
    'sets active beat accordingly when beat is clicked (do we need to pass the index of the beat clicked as well as the boolean array?)
    Public Sub beatClicked(ByRef boolActiveBeat As Boolean(), beatIndex As Integer)
        'this entire procedure is a prototype as of now
        If boolActiveBeat(beatIndex) = True Then
            boolActiveBeat(beatIndex) = False
        ElseIf boolActiveBeat(beatIndex) = False Then
            boolActiveBeat(beatIndex) = True
        End If
    End Sub
End Class
