Public Class YokogawaHelper
    Public Function DecodedCanisSerialNumberYear(year As String) As String
        Select Case year
            Case "U"
                Return "17"
            Case "V"
                Return "18"
            Case "W"
                Return "20"
            Case "X"
                Return "21"
            Case "Y"
                Return "22"
            Case "Z"
                Return "23"
            Case Else
                Return "Invalid"
        End Select
    End Function

    Public Function DecodedCanisSerialNumberMonth(month As String) As String
        Select Case month
            Case "A"
                Return "01"
            Case "B"
                Return "02"
            Case "C"
                Return "03"
            Case "D"
                Return "04"
            Case "E"
                Return "05"
            Case "F"
                Return "06"
            Case "G"
                Return "07"
            Case "H"
                Return "08"
            Case "J"
                Return "09"
            Case "K"
                Return "10"
            Case "L"
                Return "11"
            Case "M"
                Return "12"
            Case Else
                Return "Invalid"
        End Select
    End Function
End Class
