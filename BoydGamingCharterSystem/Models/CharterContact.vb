Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Imports BoydGamingCharterSystem
Public Class CharterContact
    Public Property Id As Integer
    <Display(Name:="First Name")>
    Public Property FirstName As String
    <Display(Name:="Last Name")>
    Public Property LastName As String
    <Display(Name:="Phone Number")>
    Public Property PrimaryPhone As String
    <Display(Name:="Phone Number Extension")>
    Public Property PrimaryPhoneExtension As String
    <Display(Name:="Alternate Phone Number")>
    Public Property AlternatePhone As String
    <Display(Name:="Alternate Phone Number Extension")>
    Public Property AlternatePhoneExtension As String
    <Display(Name:="Emergency Phone Number")>
    Public Property EmergencyPhone As String
    <Display(Name:="Emergency Phone Number Extension")>
    Public Property EmergencyPhoneExtension As String
    <Display(Name:="Fax Number")>
    Public Property FaxNumber As String
    <Display(Name:="Fax Number Extension")>
    Public Property FaxNumberExtension As String
    <Display(Name:="Email")>
    <DataType(DataType.EmailAddress)>
    <EmailAddress(ErrorMessage:="Invalid Email Address")>
    Public Property Email As String
    Public Property Contactable As Contactable
    Public Property CreatedDateTime As Date?

    <NotMapped>
    <Display(Name:="Contact Name")>
    Public ReadOnly Property FullName As String
        Get
            Dim name As String
            If Not (String.IsNullOrEmpty(Me.FirstName)) And Not (String.IsNullOrEmpty(Me.LastName)) Then
                name = Me.FirstName & " " & LastName
            ElseIf Not (String.IsNullOrEmpty(Me.FirstName)) Then
                name = Me.FirstName
            ElseIf Not (String.IsNullOrEmpty(Me.LastName)) Then
                name = Me.LastName
            Else
                name = "N/A"
            End If

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
