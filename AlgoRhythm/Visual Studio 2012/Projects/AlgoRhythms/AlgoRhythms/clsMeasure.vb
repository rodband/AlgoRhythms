Public Class clsMeasure
    Public boolActiveBeat(16) As Boolean
    Public measureNumber As Integer
    Public trackNumber As Integer

    Public Sub New(ByVal tn As Integer, ByVal mn As Integer, ByVal boolBeat1 As Boolean, ByVal boolBeat2 As Boolean, ByVal boolBeat3 As Boolean, ByVal boolBeat4 As Boolean, ByVal boolBeat5 As Boolean, ByVal boolBeat6 As Boolean, ByVal boolBeat7 As Boolean, ByVal boolBeat8 As Boolean, ByVal boolBeat9 As Boolean, ByVal boolBeat10 As Boolean, ByVal boolBeat11 As Boolean, ByVal boolBeat12 As Boolean, ByVal boolBeat13 As Boolean, ByVal boolBeat14 As Boolean, ByVal boolBeat15 As Boolean, ByVal boolBeat16 As Boolean)
        measureNumber = mn
        boolActiveBeat(0) = boolBeat1
        boolActiveBeat(1) = boolBeat2
        boolActiveBeat(2) = boolBeat3
        boolActiveBeat(3) = boolBeat4
        boolActiveBeat(4) = boolBeat5
        boolActiveBeat(5) = boolBeat6
        boolActiveBeat(6) = boolBeat7
        boolActiveBeat(7) = boolBeat8
        boolActiveBeat(8) = boolBeat9
        boolActiveBeat(9) = boolBeat10
        boolActiveBeat(10) = boolBeat11
        boolActiveBeat(11) = boolBeat12
        boolActiveBeat(12) = boolBeat13
        boolActiveBeat(13) = boolBeat14
        boolActiveBeat(14) = boolBeat15
        boolActiveBeat(15) = boolBeat16
    End Sub

    Public Property beat As Boolean()
        Get
            Return boolActiveBeat
        End Get
        Set(value As Boolean())
            boolActiveBeat = value
        End Set
    End Property

    Public Property measureN As Integer
        Get
            Return measureNumber
        End Get
        Set(value As Integer)
            measureNumber = value
        End Set
    End Property

    Public Property trackN As Integer
        Get
            Return trackNumber
        End Get
        Set(value As Integer)
            trackNumber = value
        End Set
    End Property
End Class
