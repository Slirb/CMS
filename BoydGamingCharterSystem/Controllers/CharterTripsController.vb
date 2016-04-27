Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports BoydGamingCharterSystem
Imports System.IO


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

            If searchString = "" Then
                searchString = Nothing
            End If

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
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And
                                                     t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
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
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.CarrierId = SelectedCarrier And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
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
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And
                                                     t.CarrierId = SelectedCarrier Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
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
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate And
                                                     t.CarrierId = SelectedCarrier Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.CarrierId = SelectedCarrier Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
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
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate And t.OperatorId = SelectedOperator Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
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
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate And t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate And t.OperatorId = SelectedOperator Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.OperatorId = SelectedOperator Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
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
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate And t.Arrival < EndDate Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival >= StartDate Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
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
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
                                        Join s In status On t.TripStatus Equals s
                                        Select t Where t.Arrival < EndDate Order By t.Arrival
                            End If

                        Else

                            'Check for confirmation number
                            If searchString IsNot Nothing Then
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Where(Function(trip) trip.Confirmation.Contains(searchString))
                                        Join s In status On t.TripStatus Equals s
                                        Select t Order By t.Arrival
                            Else
                                'Select trips matching search criteria
                                trips = From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).ToList()
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
            Dim charterTrips As CharterTrips = (From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company)
                                                Select t Where t.Id = id).FirstOrDefault()
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

            For index As Integer = 10 To 23
                hours.Add(New SelectListItem With {.Text = index.ToString, .Value = index.ToString})
            Next

            'Set the selected value for each hour dropdownbox
            ViewBag.ArriveHours = New SelectList(hours, "Value", "Text", selectedValue:=charterTrips.ArrivalDate.ToString("HH"))
            ViewBag.DepartHours = New SelectList(hours, "Value", "Text", selectedValue:=charterTrips.DepartureDate.ToString("HH"))


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

            'Set the selected value for each minute dropdownbox
            ViewBag.ArriveMinutes = New SelectList(minutes, "Value", "Text", selectedValue:=charterTrips.ArrivalDate.ToString("mm"))
            ViewBag.DepartMinutes = New SelectList(minutes, "Value", "Text", selectedValue:=charterTrips.DepartureDate.ToString("mm"))

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
        Function Edit(<Bind(Include:="Id,TripCity,TripStatus,Confirmation,ManifestCount,TripNotes", Prefix:="trip")> ByVal charterTrip As CharterTrips,
                       ArrivalDay As String, ArrivalHour As String, ArrivalMinute As String, DepartureDay As String, DepartureHour As String, DepartureMinute As String) As ActionResult

            charterTrip.Arrival = ArrivalDay + " " + ArrivalHour + ":" + ArrivalMinute + ":00"
            charterTrip.Departure = DepartureDay + " " + DepartureHour + ":" + DepartureMinute + ":00"


            If ModelState.IsValid Then

                'Check for confirmation number and generate if needed
                If charterTrip.Confirmation Is Nothing Or charterTrip.Confirmation = "" Then

                    charterTrip.Confirmation = "BI" + Date.Now.ToString("MMddyyyy") '+ charterTrip.CarrierId.ToString() + charterTrip.OperatorId.ToString()
                End If

                'Check for trip status and set to active if not currently finished or active
                If charterTrip.TripStatus.Equals("Completed") = False AndAlso charterTrip.TripStatus.Equals("Applied") = False Or charterTrip.TripStatus Is Nothing Then
                    charterTrip.TripStatus = "Active"
                End If

                db.Entry(charterTrip).State = EntityState.Modified

                db.SaveChanges()
            End If

            Return RedirectToAction("Edit", New With {.id = charterTrip.Id})

        End Function

        'Save notes for a trip
        <HttpPost()>
        Function SubmitNotes(ByVal id As Integer?, ByVal tripNotes As String) As ActionResult


            Dim charterTrip As CharterTrips = db.trips.Find(id)
            charterTrip.TripNotes = tripNotes
            db.Entry(charterTrip).State = EntityState.Modified
            db.SaveChanges()

            Return RedirectToAction("Edit", New With {.id = charterTrip.Id})
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

            charterTrip.ManifestCount = (From t In db.manifests.ToList
                                         Select t Where t.tripId = tripId).Count

            db.Entry(charterTrip).State = EntityState.Modified
            db.SaveChanges()

            Return RedirectToAction("Edit", New With {.id = charterTrip.Id})
        End Function

        'Add a single person to a manifest
        <HttpPost()>
        Function AddPerson(ByVal tripId As Integer, ByVal searchPerson As String) As ActionResult

            If searchPerson = "" Then
                Return RedirectToAction("Edit", New With {.id = tripId})
            End If

            Dim people As New List(Of CharterManifest)
            Dim state As State = db.states.Find(2)
            Dim charterTrip As CharterTrips = db.trips.Find(tripId)

            With people
                .Add(New CharterManifest(1, 300049, "Steve", "Harvey", "L", Date.Now, "Test Address", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(2, 302831, "Mary", "Poppins", "T", Date.Now, "Test Address 2", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(3, 300050, "Mark", "Finn", "A", Date.Now, "Test Address 3", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(4, 300831, "Amy", "Hope", "B", Date.Now, "Test Address 4", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(5, 300749, "John", "Jenkins", "C", Date.Now, "Test Address 5", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(6, 302031, "Katy", "Perry", "D", Date.Now, "Test Address 6", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(7, 310049, "Bob", "Villa", "E", Date.Now, "Test Address 7", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(8, 304631, "Ashley", "Higgins", "F", Date.Now, "Test Address 8", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(9, 560049, "Scott", "Speed", "G", Date.Now, "Test Address 9", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(10, 400049, "Sam", "Worthy", "H", Date.Now, "Test Address 10", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(11, 502831, "Nancy", "Monroe", "I", Date.Now, "Test Address 11", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(12, 313049, "Kevin", "Smith", "J", Date.Now, "Test Address 12", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(13, 302491, "Olivia", "Banks", "K", Date.Now, "Test Address 13", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(14, 307349, "Paul", "James", "L", Date.Now, "Test Address 14", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(15, 365831, "Terri", "Long", "M", Date.Now, "Test Address 15", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(2, 302001, "Elise", "Kelly", "N", Date.Now, "Test Address 16", Nothing, "Orlando", state, "56533", charterTrip))
            End With


            For Each person In people
                If person.cardNumber.Equals(Integer.Parse(searchPerson)) Then

                    Dim tempManifest = From t In db.manifests.Where(Function(manifest) manifest.cardNumber.Equals(person.cardNumber)).ToList
                                       Select t Where t.tripId = tripId

                    If tempManifest.Count < 1 Then

                        Dim name As CharterManifest =
                            New CharterManifest(-1, person.cardNumber, person.firstName, person.lastName, person.middleInitial, person.dob, person.addressLineOne,
                                                person.addressLineTwo, person.city, state, person.postalCode, charterTrip)

                        db.manifests.Add(name)
                        db.SaveChanges()

                        charterTrip.ManifestCount = (From t In db.manifests.ToList
                                                     Select t Where t.tripId = tripId).Count

                        db.Entry(charterTrip).State = EntityState.Modified
                        db.SaveChanges()
                    End If


                    Exit For
                End If
            Next

            Return RedirectToAction("Edit", New With {.id = charterTrip.Id})

        End Function


        'Add a csv manifest to a trip
        <HttpPost()>
        Function ImportManifest(ByVal id As Integer, ByVal manifest As HttpPostedFileBase) As ActionResult

            Dim fileName As String

            Try
                fileName = Path.GetFileName(manifest.FileName)
            Catch ex As Exception
                Return RedirectToAction("Edit", New With {.id = id})
            End Try


            Dim reader As StreamReader = New StreamReader(manifest.InputStream)
            Dim test As String = reader.ReadToEnd
            Dim importedNumbers As New List(Of Integer)()

            Dim lines As String() = Regex.Split(test, Environment.NewLine)

            For Each line In lines
                Dim values = Regex.Split(line, ",")
                If values(0) IsNot Nothing AndAlso values(0) <> "" Then
                    importedNumbers.Add(Integer.Parse(values(0)))
                End If

            Next




            Dim people As New List(Of CharterManifest)
            Dim state As State = db.states.Find(2)
            Dim charterTrip As CharterTrips = db.trips.Find(id)

            With people
                .Add(New CharterManifest(1, 300049, "Steve", "Harvey", "L", Date.Now, "Test Address", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(2, 302831, "Mary", "Poppins", "T", Date.Now, "Test Address 2", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(3, 300050, "Mark", "Finn", "A", Date.Now, "Test Address 3", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(4, 300831, "Amy", "Hope", "B", Date.Now, "Test Address 4", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(5, 300749, "John", "Jenkins", "C", Date.Now, "Test Address 5", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(6, 302031, "Katy", "Perry", "D", Date.Now, "Test Address 6", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(7, 310049, "Bob", "Villa", "E", Date.Now, "Test Address 7", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(8, 304631, "Ashley", "Higgins", "F", Date.Now, "Test Address 8", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(9, 560049, "Scott", "Speed", "G", Date.Now, "Test Address 9", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(10, 400049, "Sam", "Worthy", "H", Date.Now, "Test Address 10", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(11, 502831, "Nancy", "Monroe", "I", Date.Now, "Test Address 11", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(12, 313049, "Kevin", "Smith", "J", Date.Now, "Test Address 12", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(13, 302491, "Olivia", "Banks", "K", Date.Now, "Test Address 13", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(14, 307349, "Paul", "James", "L", Date.Now, "Test Address 14", Nothing, "Houston", state, "46511", charterTrip))
                .Add(New CharterManifest(15, 365831, "Terri", "Long", "M", Date.Now, "Test Address 15", Nothing, "Orlando", state, "56533", charterTrip))
                .Add(New CharterManifest(2, 302001, "Elise", "Kelly", "N", Date.Now, "Test Address 16", Nothing, "Orlando", state, "56533", charterTrip))
            End With


            For Each person In people

                For Each number In importedNumbers
                    If person.cardNumber.Equals(number) Then

                        Dim tempManifest = From t In db.manifests.Where(Function(mani) mani.cardNumber.Equals(person.cardNumber)).ToList
                                           Select t Where t.tripId = id

                        If tempManifest.Count < 1 Then

                            Dim name As CharterManifest =
                            New CharterManifest(-1, person.cardNumber, person.firstName, person.lastName, person.middleInitial, person.dob, person.addressLineOne,
                                                person.addressLineTwo, person.city, state, person.postalCode, charterTrip)

                            db.manifests.Add(name)
                            db.SaveChanges()

                            charterTrip.ManifestCount = (From t In db.manifests.ToList
                                                         Select t Where t.tripId = id).Count

                            db.Entry(charterTrip).State = EntityState.Modified
                            db.SaveChanges()
                        End If

                        Exit For
                    End If

                Next

            Next

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
            Dim charterTrips As CharterTrips = (From t In db.trips.Include(Function(c) c.CharterAgreements).Include(Function(c) c.CharterAgreements.CharterCarrier.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company).Include(Function(c) c.CharterAgreements.CharterOperator.Company.State).Include(Function(c) c.CharterAgreements.CharterCarrier.Company.State).ToList()
                                                Select t Where t.Id = id).FirstOrDefault()
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

        Public Function BlankTripRow() As ViewResult
            Dim row As CharterTrips = New CharterTrips()
            row.Arrival = Date.Now()
            row.Departure = Date.Now()
            Return View("CharterTrips/CharterTripCreateRow", row)
        End Function
    End Class
End Namespace
