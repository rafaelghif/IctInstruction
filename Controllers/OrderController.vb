Imports System.IO

Public Class OrderController
    Private ReadOnly yokogawaHelper As New YokogawaHelper()
    Public canisSerialNumber As New CanisSerialNumberModel()

    Public Function SearchCanisSerialNumber(canisSerialNumberPath As String, canisSerialNumberFileName As String, canisSerialNumberInput As String) As CanisSerialNumberModel
        Dim isFoundCanisSerialNumber As Boolean = False
        Dim canisSerialNumberData As New CanisSerialNumberModel()

        If Not File.Exists(Path.Combine(canisSerialNumberPath, canisSerialNumberFileName)) Then
            Return Nothing
        End If

        Dim canisSerialNumberRows As String() = File.ReadAllLines(Path.Combine(canisSerialNumberPath, canisSerialNumberFileName))

        For Each canisSerialNumberRow As String In canisSerialNumberRows
            Dim canisSerialNumberArr As String() = canisSerialNumberRow.Split(",")
            If canisSerialNumberArr(0) = canisSerialNumberInput Then
                isFoundCanisSerialNumber = True
                canisSerialNumberData.SerialNumber = canisSerialNumberArr(0).Trim()
                canisSerialNumberData.Model = canisSerialNumberArr(1).Trim()
                canisSerialNumberData.Style = canisSerialNumberArr(2).Trim()
                canisSerialNumberData.MacAddress = canisSerialNumberArr(3).Trim()
                canisSerialNumberData.LineCode = canisSerialNumberArr(4).Trim()
                Exit For
            End If
        Next

        If isFoundCanisSerialNumber = True Then
            canisSerialNumber = canisSerialNumberData
            Return canisSerialNumberData
        End If

        Return Nothing
    End Function

    Public Function GetCanisFileName(productionCode As String, year As String, month As String, day As String) As String
        Dim canisYear As String = YokogawaHelper.DecodedCanisSerialNumberYear(year)
        Dim canisMonth As String = YokogawaHelper.DecodedCanisSerialNumberMonth(month)

        If canisMonth = "Invalid" Then
            Return canisMonth
        End If

        If canisYear = "Invalid" Then
            Return canisYear
        End If

        Return $"{productionCode}{canisYear}{canisMonth}{day}.txt"
    End Function
End Class
