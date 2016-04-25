Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Imports BoydGamingCharterSystem
<Table("Contact")>
Public Class CharterContact
    Public Property Id As Integer

    <Required(ErrorMessage:="First name is required")>
    <Display(Name:="First Name")>
    Public Property FirstName As String

    <Required(ErrorMessage:="Last name is required")>
    <Display(Name:="Last Name")>
    Public Property LastName As String

    <RegularExpression("^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage:="Invalid phone number")>
    <Display(Name:="Phone Number")>
    Public Property PrimaryPhone As String

    <Range(0, Integer.MaxValue, ErrorMessage:="Extensions must be numeric")>
    <Display(Name:="Phone Number Extension")>
    Public Property PrimaryPhoneExtension As String

    <RegularExpression("^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage:="Invalid phone number")>
    <Display(Name:="Alternate Phone Number")>
    Public Property AlternatePhone As String

    <Range(0, Integer.MaxValue, ErrorMessage:="Extensions must be numeric")>
    <Display(Name:="Alternate Phone Number Extension")>
    Public Property AlternatePhoneExtension As String

    <RegularExpression("^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage:="Invalid phone number")>
    <Display(Name:="Emergency Phone Number")>
    Public Property EmergencyPhone As String

    <Range(0, Integer.MaxValue, ErrorMessage:="Extensions must be numeric")>
    <Display(Name:="Emergency Phone Number Extension")>
    Public Property EmergencyPhoneExtension As String

    <RegularExpression("^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage:="Invalid fax number")>
    <Display(Name:="Fax Number")>
    Public Property FaxNumber As String

    <Range(0, Integer.MaxValue, ErrorMessage:="Extensions must be numeric")>
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

    '<NotMapped>
    'Public ReadOnly Property ContactableId As Integer
    '    Get
    '        Return Me.Contactable.ContactableId
    '    End Get
    'End Property

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
        'Me.Contactable = New Contactable
        Me.CreatedDateTime = DateTime.Now()
    End Sub

End Class


<Table("Contactable")>
Public Class Contactable
    Public Property ContactableId() As Integer
    Public Overridable Property Contacts() As List(Of CharterContact)

    Public Sub New()
        Me.Contacts = New List(Of CharterContact)

    End Sub
End Class
