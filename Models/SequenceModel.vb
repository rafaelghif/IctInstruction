Public Class SequenceModel
    Private _SequenceNumber As Integer
    Private _Instruction As String
    Private _PictureName As String

    Public Property SequenceNumber As Integer
        Get
            Return _SequenceNumber
        End Get
        Set(value As Integer)
            _SequenceNumber = value
        End Set
    End Property

    Public Property Instruction As String
        Get
            Return _Instruction
        End Get
        Set(value As String)
            _Instruction = value
        End Set
    End Property

    Public Property PictureName As String
        Get
            Return _PictureName
        End Get
        Set(value As String)
            _PictureName = value
        End Set
    End Property
End Class
