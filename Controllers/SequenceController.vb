Imports System.IO

Public Class SequenceController
    Public sequenceList As New List(Of SequenceModel)

    Public Function GetSequence(sequenceFilePath As String) As List(Of SequenceModel)
        If Not File.Exists(sequenceFilePath) Then
            ErrorAlert("Sequence not found! Please Contact Engineering!")
            Return Nothing
        End If

        Dim sequenceRows As String() = File.ReadAllLines(sequenceFilePath)

        For Each sequenceRow As String In sequenceRows
            Dim sequenceData As New SequenceModel()
            Dim sequenceArr As String() = sequenceRow.Split(",")

            If sequenceArr.Length <> 3 Then
                ErrorAlert("Invalid Sequence Format!")
                Return Nothing
            End If

            sequenceData.SequenceNumber = sequenceArr(0)
            sequenceData.Instruction = sequenceArr(1)
            sequenceData.PictureName = sequenceArr(2)

            sequenceList.Add(sequenceData)
        Next

        Return sequenceList
    End Function
End Class
