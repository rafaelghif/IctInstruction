Public Class CanisSerialNumberModel
    Private _SerialNumber As String = ""
    Private _Model As String = ""
    Private _Style As String = ""
    Private _MacAddress As String = ""
    Private _LineCode As String = ""

    Public Property SerialNumber As String
        Get
            Return _SerialNumber
        End Get
        Set(value As String)
            _SerialNumber = value
        End Set
    End Property

    Public Property Model As String
        Get
            Return _Model
        End Get
        Set(value As String)
            _Model = value
        End Set
    End Property

    Public Property Style As String
        Get
            Return _Style
        End Get
        Set(value As String)
            _Style = value
        End Set
    End Property

    Public Property MacAddress As String
        Get
            Return _MacAddress
        End Get
        Set(value As String)
            _MacAddress = value
        End Set
    End Property

    Public Property LineCode As String
        Get
            Return _LineCode
        End Get
        Set(value As String)
            _LineCode = value
        End Set
    End Property
End Class
