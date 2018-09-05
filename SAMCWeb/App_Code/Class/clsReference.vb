Public Class ClsReference

    Private _CreatedBy As String
    Property CreatedBy() As String
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As String)
            _CreatedBy = value
        End Set
    End Property

    Private _DateCreated As DateTime
    Property DateCreated() As DateTime
        Get
            Return _DateCreated
        End Get
        Set(ByVal value As DateTime)
            _DateCreated = value
        End Set
    End Property

    Private _ModifiedBy As String
    Property ModifiedBy() As String
        Get
            Return _ModifiedBy
        End Get
        Set(ByVal value As String)
            _ModifiedBy = value
        End Set
    End Property

    Private _DateModified As DateTime
    Property DateModified() As DateTime
        Get
            Return _DateModified
        End Get
        Set(ByVal value As DateTime)
            _DateModified = value
        End Set
    End Property

End Class
