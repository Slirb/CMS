Imports System.ComponentModel.DataAnnotations

Public Class CharterOperator

    <Key>
    Private operatorId As Integer

    Private operatorName As String


    Public Property Id() As Integer
        Get
            Return operatorId
        End Get
        Private Set(ByVal value As Integer)
            operatorId = value
        End Set
    End Property


    Public Property Name() As String
        Get
            Return operatorName
        End Get
        Set(value As String)
            operatorName = value
        End Set

    End Property
    Public Sub New(id As Integer, name As String)
        Me.Id = id
        Me.Name = name
    End Sub



End Class
