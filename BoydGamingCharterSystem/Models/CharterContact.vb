Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Imports BoydGamingCharterSystem
Public Class CharterContact
    Public Property Id As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property PrimaryPhone As String
    Public Property PrimaryPhoneExtension As String
    Public Property AlternatePhone As String
    Public Property AlternatePhoneExtension As String
    Public Property EmergencyPhone As String
    Public Property EmergencyPhoneExtension As String
    Public Property FaxNumber As String
    Public Property FaxNumberExtension As String
    Public Property Email As String
    Public Property CreatedDateTime As Date?
    <NotMapped>
    Public Property DeleteContact As Boolean

    <NotMapped>
    <Display(Name:="Contact Name")>
    Public ReadOnly Property FullName As String
        Get
            Dim name As String = Me.FirstName & " " & Me.LastName
            Return name
        End Get
    End Property

    <NotMapped>
    <Display(Name:="Contact Phone")>
    Public ReadOnly Property Phone As String
        Get
            Dim contactPhone As String = Me.PrimaryPhone
            If Not (String.IsNullOrEmpty(Me.PrimaryPhoneExtension)) Then
                contactPhone &= "x" & Me.PrimaryPhoneExtension
            End If
            Return contactPhone
        End Get
    End Property

    Public Sub New()
        Me.CreatedDateTime = DateTime.Now()

    End Sub

End Class

Public Class Contactable
    Public Property ContactableId() As Integer
    Public Overridable Property Contacts() As List(Of CharterContact)

    Public Sub New()
        Me.Contacts = New List(Of CharterContact)

    End Sub
End Class
