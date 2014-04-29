Imports System.IO

Public Class clsFileManager
    Private strFileName As String

    Public Sub saveAlgoRhythm(ByVal numT As Integer, ByVal numM As Integer, ByVal colTracks As Collection)
        Dim objAlgoRhythmsFile As StreamWriter
        strFileName = "Track_1.txt"
        File.Replace(strFileName, "Clear.txt", "Dumpster.txt")

        objAlgoRhythmsFile = File.AppendText(strFileName)

        objAlgoRhythmsFile.WriteLine(numT)
        objAlgoRhythmsFile.WriteLine(numM)

        For Each track In colTracks
            objAlgoRhythmsFile.Write(track.soundName & ", " & track.mute & ", " & track.Solo & ", ")
            For Each measure In track.objMeasureManager.colMeasures
                objAlgoRhythmsFile.Write(measure.beat(0) & " ")
                objAlgoRhythmsFile.Write(measure.beat(1) & " ")
                objAlgoRhythmsFile.Write(measure.beat(2) & " ")
                objAlgoRhythmsFile.Write(measure.beat(3) & " ")
                objAlgoRhythmsFile.Write(measure.beat(4) & " ")
                objAlgoRhythmsFile.Write(measure.beat(5) & " ")
                objAlgoRhythmsFile.Write(measure.beat(6) & " ")
                objAlgoRhythmsFile.Write(measure.beat(7) & " ")
                objAlgoRhythmsFile.Write(measure.beat(8) & " ")
                objAlgoRhythmsFile.Write(measure.beat(9) & " ")
                objAlgoRhythmsFile.Write(measure.beat(10) & " ")
                objAlgoRhythmsFile.Write(measure.beat(11) & " ")
                objAlgoRhythmsFile.Write(measure.beat(12) & " ")
                objAlgoRhythmsFile.Write(measure.beat(13) & " ")
                objAlgoRhythmsFile.Write(measure.beat(14) & " ")
                objAlgoRhythmsFile.Write(measure.beat(15) & " ")
            Next
            objAlgoRhythmsFile.WriteLine("")
        Next
        objAlgoRhythmsFile.Close()
    End Sub

    Public Sub loadAlgoRhythm(ByRef numT As Integer, ByRef numM As Integer, ByRef colTracks As Collection, ByVal fileName As String)
        Dim objAlgoRhythmsFile As StreamReader
        Dim currentLine As String
        Dim soundN As String
        Dim boolM As String
        Dim boolS As String

        Try
            objAlgoRhythmsFile = File.OpenText(fileName)

            Dim i As Integer
            i = 1
            numT = CInt(objAlgoRhythmsFile.ReadLine)
            numM = CInt(objAlgoRhythmsFile.ReadLine)
            While objAlgoRhythmsFile.Peek <> -1
                Dim measureManager As New clsMeasureManager

                currentLine = objAlgoRhythmsFile.ReadLine
                soundN = currentLine.Substring(0, currentLine.IndexOf(","))
                currentLine = currentLine.Substring(currentLine.IndexOf(",") + 2)

                boolM = currentLine.Substring(0, currentLine.IndexOf(","))
                currentLine = currentLine.Substring(currentLine.IndexOf(",") + 2)

                boolS = currentLine.Substring(0, currentLine.IndexOf(","))
                currentLine = currentLine.Substring(currentLine.IndexOf(",") + 2)

                For j As Integer = 1 To numM
                    Dim boolBeats(16) As Boolean
                    For k As Integer = 0 To 15
                        boolBeats(k) = CBool(currentLine.Substring(0, currentLine.IndexOf(" ")).Trim)
                        currentLine = currentLine.Substring(currentLine.IndexOf(" ") + 1)
                    Next
                    Dim measure As New clsMeasure(i, j, boolBeats(0), boolBeats(1), boolBeats(2), boolBeats(3), boolBeats(4), boolBeats(5), boolBeats(6), boolBeats(7), boolBeats(8), boolBeats(9), boolBeats(10), boolBeats(11), boolBeats(12), boolBeats(13), boolBeats(14), boolBeats(15))
                    measureManager.addMeasure(measure)
                Next

                Dim track As New clsTrack(i, soundN, CBool(boolM), CBool(boolS), False, measureManager)
                colTracks.Add(track)
                i = i + 1
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error.")
        End Try
    End Sub
End Class
