Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Public Class State

    Private stateId As Integer
    Private stateName As String
    Private stateAbrv As String

    Public Property Id As Integer
        Get
            Return stateId
        End Get
        Set(value As Integer)
            stateId = value
        End Set
    End Property
    <Display(Name:="State")>
    Public Property Name As String
        Get
            Return stateName
        End Get
        Set(value As String)
            stateName = value
        End Set
    End Property

    Public Property Abrv As String
        Get
            Return stateAbrv
        End Get
        Set(value As String)
            stateAbrv = value
        End Set
    End Property
    Public Sub New()
        Me.Name = Nothing
        Me.Abrv = Nothing
    End Sub


    Public Sub New(name As String, abrv As String)
        Me.New()
        Me.Name = name
        Me.Abrv = abrv
    End Sub

End Class
