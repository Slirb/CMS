Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports BoydGamingCharterSystem


Namespace Controllers
    Public Class CharterTripsController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem

        ' GET: CharterTrips
        Function Index(Optional ByVal searchString As String = Nothing, Optional ByVal potential As Boolean = True, Optional ByVal active As Boolean = True,
                       Optional ByVal applied As Boolean = True, Optional ByVal completed As Boolean = True, Optional ByVal cancelled As Boolean = True,
                       Optional ByVal StartDate As String = Nothing, Optional ByVal EndDate As String = Nothing,
                       Optional ByVal SelectedCarrier As String = Nothing, Optional ByVal SelectedOperator As String = Nothing) As ActionResult


            Dim status As New List(Of String)
            Dim trips

            'Check potential checkbox
            If (potential = True) Then
                status.Add("Potential")
            End If

            'Check active checkbox
            If (active = True) Then
                status.Add("Active")
            End If

            'Check applied checkbox
            If (applied = True) Then
                status.Add("Applied")
            End If

            'Check completed checkbox
            If (completed = True) Then
                status.Add("Completed")
            End If

            'Check cancelled checkbox
            If (cancelled = True) Then
                status.Add("Cancelled")
            End If


            'Check for a selected carrier
            If SelectedCarrier IsNot Nothing And SelectedCarrier IsNot "" Then

                'Check for a selected Operator
                If SelectedOperator IsNot Nothing And SelectedOperator IsNot "" Then

                    'Check Start Date field
                    If StartDate IsNot Nothing And StartDate IsNot "" Then

                        'Check End Date field
                        If EndDate IsNot Nothing And EndDate IsNot "" Then

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And
                                                     t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And
                                                     t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            End If

                        End If

                    Else

                        'Check End Date field
                        If EndDate IsNot Nothing And EndDate IsNot "" Then

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            End If

                        End If

                    End If

                Else
                    'Check Start Date field
                    If StartDate IsNot Nothing And StartDate IsNot "" Then

                        'Check End Date field
                        If EndDate IsNot Nothing And EndDate IsNot "" Then

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And
                                                     t.CarrierId = SelectedCarrier Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And
                                                     t.CarrierId = SelectedCarrier Order By t.Arrival
                            End If

                        End If

                    Else

                        'Check End Date field
                        If EndDate IsNot Nothing And EndDate IsNot "" Then

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.CarrierId = SelectedCarrier Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.CarrierId = SelectedCarrier Order By t.Arrival
                            End If

                        End If

                    End If

                End If

            Else

                'Check for a selected Operator
                If SelectedOperator IsNot Nothing And SelectedOperator IsNot "" Then

                    'Check Start Date field
                    If StartDate IsNot Nothing And StartDate IsNot "" Then

                        'Check End Date field
                        If EndDate IsNot Nothing And EndDate IsNot "" Then

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate And t.OperatorId = SelectedOperator Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.OperatorId = SelectedOperator Order By t.Arrival
                            End If

                        End If

                    Else

                        'Check End Date field
                        If EndDate IsNot Nothing And EndDate IsNot "" Then

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate And t.OperatorId = SelectedOperator Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.OperatorId = SelectedOperator Order By t.Arrival
                            End If

                        End If

                    End If

                Else

                    'Check Start Date field
                    If StartDate IsNot Nothing And StartDate IsNot "" Then

                        'Check End Date field
                        If EndDate IsNot Nothing And EndDate IsNot "" Then

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate Order By t.Arrival
                            End If

                        End If

                    Else

                        'Check End Date field
                        If EndDate IsNot Nothing And EndDate IsNot "" Then

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Order By t.Arrival
                            End If

                        End If

                    End If

                End If

            End If

            'Populate Dropdown Boxes
            Dim car = (From x In db.carriers
                       Order By x.Company.Name
                       Select New SelectListItem With
             {.Value = x.Id.ToString(), .Text = x.Company.Name}).ToList()
            ViewData("Carriers") = car

            Dim ops = (From x In db.operators
                       Order By x.Company.Name
                       Select New SelectListItem With
             {.Value = x.Id.ToString(), .Text = x.Company.Name}).ToList()
            ViewData("Operators") = ops

            Return View(trips)
        End Function

        ' GET: CharterTrips/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterTrips As CharterTrips = db.trips.Find(id)
            If IsNothing(charterTrips) Then
                Return HttpNotFound()
            End If
            Return View(charterTrips)
        End Function

        ' GET: CharterTrips/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' GET: CharterTrips/Edit
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterTrips As CharterTrips = db.trips.Find(id)
            If IsNothing(charterTrips) Then
                Return HttpNotFound()
            End If



            'Populate Hours DropdownBoxes
            Dim hours = New List(Of SelectListItem)
            hours.Add(New SelectListItem With {.Text = "00", .Value = "00"})
            hours.Add(New SelectListItem With {.Text = "01", .Value = "01"})
            hours.Add(New SelectListItem With {.Text = "02", .Value = "02"})
            hours.Add(New SelectListItem With {.Text = "03", .Value = "03"})
            hours.Add(New SelectListItem With {.Text = "04", .Value = "04"})
            hours.Add(New SelectListItem With {.Text = "05", .Value = "05"})
            hours.Add(New SelectListItem With {.Text = "06", .Value = "06"})
            hours.Add(New SelectListItem With {.Text = "07", .Value = "07"})
            hours.Add(New SelectListItem With {.Text = "08", .Value = "08"})
            hours.Add(New SelectListItem With {.Text = "09", .Value = "09"})
            hours.Add(New SelectListItem With {.Text = "10", .Value = "10"})
            hours.Add(New SelectListItem With {.Text = "11", .Value = "11"})
            hours.Add(New SelectListItem With {.Text = "12", .Value = "12"})
            hours.Add(New SelectListItem With {.Text = "13", .Value = "13"})
            hours.Add(New SelectListItem With {.Text = "14", .Value = "14"})
            hours.Add(New SelectListItem With {.Text = "15", .Value = "15"})
            hours.Add(New SelectListItem With {.Text = "16", .Value = "16"})
            hours.Add(New SelectListItem With {.Text = "17", .Value = "17"})
            hours.Add(New SelectListItem With {.Text = "18", .Value = "18"})
            hours.Add(New SelectListItem With {.Text = "19", .Value = "19"})
            hours.Add(New SelectListItem With {.Text = "20", .Value = "20"})
            hours.Add(New SelectListItem With {.Text = "21", .Value = "21"})
            hours.Add(New SelectListItem With {.Text = "22", .Value = "22"})
            hours.Add(New SelectListItem With {.Text = "23", .Value = "23"})

            'Set the selected value for each hour dropdownbox
            ViewBag.ArriveHours = New SelectList(hours, "Value", "Text", selectedValue:=charterTrips.Arrival.Value.ToString("HH"))
            ViewBag.DepartHours = New SelectList(hours, "Value", "Text", selectedValue:=charterTrips.Departure.Value.ToString("HH"))


            Dim minutes = New List(Of SelectListItem)
            minutes.Add(New SelectListItem With {.Text = "00", .Value = "00"})
            minutes.Add(New SelectListItem With {.Text = "01", .Value = "01"})
            minutes.Add(New SelectListItem With {.Text = "02", .Value = "02"})
            minutes.Add(New SelectListItem With {.Text = "03", .Value = "03"})
            minutes.Add(New SelectListItem With {.Text = "04", .Value = "04"})
            minutes.Add(New SelectListItem With {.Text = "05", .Value = "05"})
            minutes.Add(New SelectListItem With {.Text = "06", .Value = "06"})
            minutes.Add(New SelectListItem With {.Text = "07", .Value = "07"})
            minutes.Add(New SelectListItem With {.Text = "08", .Value = "08"})
            minutes.Add(New SelectListItem With {.Text = "09", .Value = "09"})

            For index As Integer = 10 To 59
                minutes.Add(New SelectListItem With {.Text = index.ToString, .Value = index.ToString})
            Next

            'Set the selected value for each hour dropdownbox
            ViewBag.ArriveMinutes = New SelectList(minutes, "Value", "Text", selectedValue:=charterTrips.Arrival.Value.ToString("mm"))
            ViewBag.DepartMinutes = New SelectList(minutes, "Value", "Text", selectedValue:=charterTrips.Departure.Value.ToString("mm"))

            'Manifest for the trip
            Dim manifests As List(Of CharterManifest) = (From x In db.manifests
                                                         Order By x.cardNumber
                                                         Select x Where x.tripId = id).ToList()

            'Create view model to hold data
            Dim viewMod As New EditTripsModel
            viewMod.trip = charterTrips
            viewMod.manifests = manifests

            Return View(viewMod)
        End Function

        ' POST: CharterTrips/Edit
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,charterAgreementId,CarrierId,CarrierName,OperatorId,OperatorName,TripDestination,TripCity,TripStatus,Confirmation", Prefix:="trip")> ByVal charterTrip As CharterTrips,
                       ArrivalDay As String, ArrivalHour As String, ArrivalMinute As String, DepartureDay As String, DepartureHour As String, DepartureMinute As String) As ActionResult

            charterTrip.Arrival = ArrivalDay + " " + ArrivalHour + ":" + ArrivalMinute + ":00"
            charterTrip.Departure = DepartureDay + " " + DepartureHour + ":" + DepartureMinute + ":00"

            If ModelState.IsValid Then

                'Check for confirmation number and generate if needed
                If charterTrip.Confirmation Is Nothing Or charterTrip.Confirmation = "" Then

                    charterTrip.Confirmation = "BI" + Date.Now.ToString("MMddyyyy") + charterTrip.CarrierId.ToString() + charterTrip.OperatorId.ToString()
                End If

                'Check for trip status and set to active if not currently finished or active
                If charterTrip.TripStatus.Equals("Completed") = False AndAlso charterTrip.TripStatus.Equals("Applied") = False Or charterTrip.TripStatus Is Nothing Then
                    charterTrip.TripStatus = "Active"
                End If

                db.Entry(charterTrip).State = EntityState.Modified
                db.SaveChanges()
            End If


            'Populate Hours DropdownBoxes
            Dim hours = New List(Of SelectListItem)
            hours.Add(New SelectListItem With {.Text = "00", .Value = "00"})
            hours.Add(New SelectListItem With {.Text = "01", .Value = "01"})
            hours.Add(New SelectListItem With {.Text = "02", .Value = "02"})
            hours.Add(New SelectListItem With {.Text = "03", .Value = "03"})
            hours.Add(New SelectListItem With {.Text = "04", .Value = "04"})
            hours.Add(New SelectListItem With {.Text = "05", .Value = "05"})
            hours.Add(New SelectListItem With {.Text = "06", .Value = "06"})
            hours.Add(New SelectListItem With {.Text = "07", .Value = "07"})
            hours.Add(New SelectListItem With {.Text = "08", .Value = "08"})
            hours.Add(New SelectListItem With {.Text = "09", .Value = "09"})
            hours.Add(New SelectListItem With {.Text = "10", .Value = "10"})
            hours.Add(New SelectListItem With {.Text = "11", .Value = "11"})
            hours.Add(New SelectListItem With {.Text = "12", .Value = "12"})
            hours.Add(New SelectListItem With {.Text = "13", .Value = "13"})
            hours.Add(New SelectListItem With {.Text = "14", .Value = "14"})
            hours.Add(New SelectListItem With {.Text = "15", .Value = "15"})
            hours.Add(New SelectListItem With {.Text = "16", .Value = "16"})
            hours.Add(New SelectListItem With {.Text = "17", .Value = "17"})
            hours.Add(New SelectListItem With {.Text = "18", .Value = "18"})
            hours.Add(New SelectListItem With {.Text = "19", .Value = "19"})
            hours.Add(New SelectListItem With {.Text = "20", .Value = "20"})
            hours.Add(New SelectListItem With {.Text = "21", .Value = "21"})
            hours.Add(New SelectListItem With {.Text = "22", .Value = "22"})
            hours.Add(New SelectListItem With {.Text = "23", .Value = "23"})

            'Set the selected value for each hour dropdownbox
            ViewBag.ArriveHours = New SelectList(hours, "Value", "Text", selectedValue:=charterTrip.Arrival.Value.ToString("HH"))
            ViewBag.DepartHours = New SelectList(hours, "Value", "Text", selectedValue:=charterTrip.Departure.Value.ToString("HH"))


            Dim minutes = New List(Of SelectListItem)
            minutes.Add(New SelectListItem With {.Text = "00", .Value = "00"})
            minutes.Add(New SelectListItem With {.Text = "01", .Value = "01"})
            minutes.Add(New SelectListItem With {.Text = "02", .Value = "02"})
            minutes.Add(New SelectListItem With {.Text = "03", .Value = "03"})
            minutes.Add(New SelectListItem With {.Text = "04", .Value = "04"})
            minutes.Add(New SelectListItem With {.Text = "05", .Value = "05"})
            minutes.Add(New SelectListItem With {.Text = "06", .Value = "06"})
            minutes.Add(New SelectListItem With {.Text = "07", .Value = "07"})
            minutes.Add(New SelectListItem With {.Text = "08", .Value = "08"})
            minutes.Add(New SelectListItem With {.Text = "09", .Value = "09"})

            For index As Integer = 10 To 59
                minutes.Add(New SelectListItem With {.Text = index.ToString, .Value = index.ToString})
            Next

            'Set the selected value for each hour dropdownbox
            ViewBag.ArriveMinutes = New SelectList(minutes, "Value", "Text", selectedValue:=charterTrip.Arrival.Value.ToString("mm"))
            ViewBag.DepartMinutes = New SelectList(minutes, "Value", "Text", selectedValue:=charterTrip.Departure.Value.ToString("mm"))


            'Manifest for the trip
            Dim manifests As List(Of CharterManifest) = (From x In db.manifests
                                                         Order By x.cardNumber
                                                         Select x Where x.tripId = charterTrip.Id).ToList()

            'Create view model to hold data
            Dim viewMod As New EditTripsModel
            viewMod.trip = charterTrip
            viewMod.manifests = manifests

            Return View(viewMod)
        End Function

        'Cancel a trip
        Function CancelTrip(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterTrip As CharterTrips = db.trips.Find(id)
            If IsNothing(charterTrip) Then
                Return HttpNotFound()
            End If

            'Check completed status and cancel if not complete
            If charterTrip.TripStatus.Equals("Completed") = False Then
                charterTrip.TripStatus = "Cancelled"
                db.Entry(charterTrip).State = EntityState.Modified
                db.SaveChanges()
            Else
                Return RedirectToAction("Edit", New With {.id = charterTrip.Id})

            End If

            Return RedirectToAction("Index")
        End Function

        ' Delete a person from manifest
        Function DeletePerson(ByVal id As Integer?, ByVal tripId As Integer?) As ActionResult

            Dim charterTrip As CharterTrips = db.trips.Find(tripId)
            Dim charterManifest As CharterManifest = db.manifests.Find(id)
            db.manifests.Remove(charterManifest)
            db.SaveChanges()

            Return RedirectToAction("Edit", New With {.id = charterTrip.Id})
        End Function

        ' GET: CharterTrips/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterTrips As CharterTrips = db.trips.Find(id)
            If IsNothing(charterTrips) Then
                Return HttpNotFound()
            End If
            Return View(charterTrips)
        End Function

        ' POST: CharterTrips/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterTrips As CharterTrips = db.trips.Find(id)
            db.trips.Remove(charterTrips)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        ' GET: ConfirmationLetter/Edit/5
        Function ConfirmationLetter(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterTrips As CharterTrips = db.trips.Find(id)
            If IsNothing(charterTrips) Then
                Return HttpNotFound()
            End If

            If charterTrips.Confirmation Is Nothing Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Return View(charterTrips)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
