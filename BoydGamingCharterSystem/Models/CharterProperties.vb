Imports System.ComponentModel.DataAnnotations


Public Class CharterProperties
    <Key>
    Private propertyID As Integer
    Private propertyCode As Integer
    Private propertyName As String
    Private propertyShortName As String
    Private propertyCreatedDate As DateTime
    Private propertyCreatedByUser As String
    Private propertyLastUpdatedDate As DateTime?
    Private propertyLasteUpdatedByUser As String

    Public Property DepartmentName As String
    Public Property ContactNumber As String
    Public Property FaxNumber As String

    Public Property ID() As Integer
        Get
            Return propertyID
        End Get
        Set(ByVal value As Integer)
            propertyID = value
        End Set
    End Property


    Public Property Name() As String
        Get
            Return propertyName
        End Get
        Set(value As String)
            propertyName = value
        End Set

    End Property


    Public Property ShortName() As String
        Get
            Return propertyShortName
        End Get
        Set(value As String)
            propertyShortName = value
        End Set

    End Property


    Public Property Code() As Integer
        Get
            Return propertyCode
        End Get
        Set(value As Integer)
            propertyCode = value
        End Set

    End Property


    Public Property CreatedDate() As DateTime?
        Get
            Return propertyCreatedDate
        End Get
        Set(ByVal value As DateTime?)
            propertyCreatedDate = value
        End Set
    End Property


    Public Property CreatedBy() As String
        Get
            Return propertyCreatedByUser
        End Get
        Set(ByVal value As String)
            propertyCreatedByUser = value
        End Set
    End Property


    Public Property UpdatedDate() As DateTime?
        Get
            Return propertyLastUpdatedDate
        End Get
        Set(ByVal value As DateTime?)
            propertyLastUpdatedDate = value
        End Set
    End Property

    Public Property UpdatedBy() As String
        Get
            Return propertyLasteUpdatedByUser
        End Get
        Set(ByVal value As String)
            propertyLasteUpdatedByUser = value
        End Set
    End Property


    Public Sub New()
        Me.propertyID = Nothing
        Me.propertyCode = Nothing
        Me.propertyName = Nothing
        Me.propertyShortName = Nothing
        Me.propertyCreatedDate = Nothing
        Me.propertyCreatedByUser = Nothing
        Me.propertyLastUpdatedDate = Nothing
        Me.propertyLasteUpdatedByUser = Nothing
        Me.ContactNumber = Nothing
        Me.DepartmentName = Nothing
        Me.FaxNumber = Nothing


    End Sub


    ''Need to finish this
    ''Public Sub New(id As Integer, name As String)
    ''Me.ID = id
    ''Me.Name = name
    ''End Sub
End Class
