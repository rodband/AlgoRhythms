Public Class clsTrack
    Public strTrackNumber As String
    Public strSoundName As String
    Public boolMute As Boolean
    Public boolSolo As Boolean
    Public boolSelected As Boolean
    Public Sub New(ByVal tN As Integer, ByVal sN As String, ByRef m As Boolean, ByRef s As Boolean, ByRef sel As Boolean)
        strTrackNumber = tN
        strSoundName = sN
        boolMute = m
        boolSolo = s
        boolSelected = sel
    End Sub

    Public Property trackNumber As String
        Get
            Return strTrackNumber
        End Get
        Set(value As String)
            strTrackNumber = value
        End Set
    End Property

    Public Property soundName As String
        Get
            Return strSoundName
        End Get
        Set(value As String)
            strSoundName = value
        End Set
    End Property

    Public Property mute As Boolean
        Get
            Return boolMute
        End Get
        Set(value As Boolean)
            boolMute = value
        End Set
    End Property

    Public Property solo As Boolean
        Get
            Return boolSolo
        End Get
        Set(value As Boolean)
            boolSolo = value
        End Set
    End Property

    Public Property selected As Boolean
        Get
            Return boolSelected
        End Get
        Set(value As Boolean)
            boolSelected = value
        End Set
    End Property

End Class
