Imports System
Imports System.Data
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

Public Class ClsAnimal

    Dim DBAnimal As New ClsDBAnimal

    Private _AnimalTypeCode As String
    Public Property AnimalTypeCode As String
        Get
            Return _AnimalTypeCode
        End Get
        Set(value As String)
            _AnimalTypeCode = value
        End Set
    End Property

    Private _AnimalTypeName As String
    Public Property AnimalTypeName As String
        Get
            Return _AnimalTypeName
        End Get
        Set(value As String)
            _AnimalTypeName = value
        End Set
    End Property

    Private _BreedCode As String
    Public Property BreedCode As String
        Get
            Return _BreedCode
        End Get
        Set(value As String)
            _BreedCode = value
        End Set
    End Property

    Private _BreedName As String
    Public Property BreedName As String
        Get
            Return _BreedName
        End Get
        Set(value As String)
            _BreedName = value
        End Set
    End Property

    Private _SexCode As String
    Public Property SexCode As String
        Get
            Return _SexCode
        End Get
        Set(value As String)
            _SexCode = value
        End Set
    End Property

    Private _SexName As String
    Public Property SexName As String
        Get
            Return _SexName
        End Get
        Set(value As String)
            _SexName = value
        End Set
    End Property

    Private _StatusCode As String
    Public Property StatusCode As String
        Get
            Return _StatusCode
        End Get
        Set(value As String)
            _StatusCode = value
        End Set
    End Property

    Private _StatusName As String
    Public Property StatusName As String
        Get
            Return _StatusName
        End Get
        Set(value As String)
            _StatusName = value
        End Set
    End Property

    Private _StatusDescription As String
    Public Property StatusDescription As String
        Get
            Return _StatusDescription
        End Get
        Set(value As String)
            _StatusDescription = value
        End Set
    End Property

    Private _CreatedBy As String
    Public Property CreatedBy As String
        Get
            Return _CreatedBy
        End Get
        Set(value As String)
            _CreatedBy = value
        End Set
    End Property

    Private _DateCreated As DateTime
    Public Property DateCreated As DateTime
        Get
            Return _DateCreated
        End Get
        Set(value As DateTime)
            _DateCreated = value
        End Set
    End Property

    Private _ModifiedBy As String
    Public Property ModifiedBy As String
        Get
            Return _ModifiedBy
        End Get
        Set(value As String)
            _ModifiedBy = value
        End Set
    End Property

    Private _DateModified As DateTime
    Public Property DateModified As DateTime
        Get
            Return _DateModified
        End Get
        Set(value As DateTime)
            _DateModified = value
        End Set
    End Property

    Public Function GetAnimalType(ByVal ClsAnimal As ClsAnimal, ByRef DBConn As MySqlConnection) As DataTable
        Return DBAnimal.GetAnimalType(ClsAnimal, DBConn)
    End Function

    Public Function GetAnimalBreed(ByVal ClsAnimal As ClsAnimal, ByRef DBConn As MySqlConnection) As DataTable
        Return DBAnimal.GetAnimalBreedList(ClsAnimal, DBConn)
    End Function

    Public Function GetAnimalSex(ByVal ClsAnimal As ClsAnimal, ByRef DBConn As MySqlConnection) As DataTable
        Return DBAnimal.GetAnimalSexListing(ClsAnimal, DBConn)
    End Function

    Public Function GetAnimalStatus(ByVal ClsAnimal As ClsAnimal, ByRef DBConn As MySqlConnection) As DataTable
        Return DBAnimal.GetAnimalStatus(ClsAnimal, DBConn)
    End Function

    Public Function ConcatAnimalTypeBreed(ByVal ClsAnimal As ClsAnimal, ByRef DBConn As MySqlConnection) As DataTable
        Return DBAnimal.ConcatAnimalTypeBreed(ClsAnimal, DBConn)
    End Function

    'Add New Client
    'Public Function AddNewCustomer(ByVal ClsCustomer As ClsCustomer, ByRef DBConn As MySqlConnection, ByRef DBTrans As MySqlTransaction) As Boolean
    '    Return DBCustomer.AddNewCustomer(ClsCustomer, DBConn, DBTrans)
    'End Function

End Class
