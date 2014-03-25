Public Class clsMeasure
    Public boolActiveBeat(16) As Boolean

    Public Sub New(ByVal boolMeasure() As Boolean)
        For i As Integer = 0 To 15 Step 1
            boolActiveBeat(i) = boolMeasure(i)
        Next
    End Sub

    Public Property beat As Boolean()
        Get
            Return boolActiveBeat
        End Get
        Set(value As Boolean())
            boolActiveBeat = value
        End Set
    End Property



End Class
