Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Core
Imports System.Data.Entity.Core.Objects
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports BoydGamingCharterSystem

Namespace Controllers
    Public Class CharterCarriersController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem


        ' GET: CharterCarriers
        Function Index() As ActionResult
            Dim carriers As List(Of CharterCarrier)
            'This fetches all related data
            'We may not want to do this as we don't need EVERY contact
            'of each carrier - only a specific one
            'This is something we could figure out a better solution if
            'it turns out it's really slow
            '
            carriers = (From carrier In db.carriers.Include(Function(c) c.Commentable).Include(Function(c) c.Company).Include(Function(c) c.Company.Contactable)
                        Select carrier).ToList()

            Return View(carriers)
        End Function

        ' GET: CharterCarriers/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterCarrier As CharterCarrier = (From carrier In db.carriers.Include(Function(c) c.Commentable).Include(Function(c) c.Company).Include(Function(c) c.Company.Contactable)
                                                    Select carrier Where carrier.Id = id).FirstOrDefault()


            If IsNothing(charterCarrier) Then
                Return HttpNotFound()
            End If
            Return View(charterCarrier)
        End Function

        ' GET: CharterCarriers/Create
        Function Create() As ActionResult
            Dim carrier As CharterCarrier = New CharterCarrier()
            carrier.Company.CreateCharterContacts(1)
            carrier.CreateCharterComments(1)
            'I suspect there is a better way to do this
            ViewBag.States = New SelectList(db.states, "Id", "Name")
            Return View(carrier)
        End Function

        ' POST: CharterCarriers/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(CharterCarrier As CharterCarrier)

            If ModelState.IsValid Then
                CharterCarrier.Created = DateTime.Now()
                db.carriers.Add(CharterCarrier)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            ViewBag.States = New SelectList(db.states, "Id", "Name")
            Return View(CharterCarrier)
        End Function

        ' GET: CharterCarriers/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult

            ViewBag.States = New SelectList(db.states, "Id", "Name")
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If


            Dim charterCarrier As CharterCarrier = (From carrier In db.carriers.Include(Function(c) c.Commentable).Include(Function(c) c.Company).Include(Function(c) c.Company.Contactable)
                                                    Select carrier Where carrier.Id = id).FirstOrDefault()
            If IsNothing(charterCarrier) Then
                Return HttpNotFound()
            End If
            Return View(charterCarrier)
        End Function

        ' POST: CharterCarriers/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(charterCarrier As CharterCarrier) As ActionResult
            If ModelState.IsValid Then

                'Delete contacts
                'CONTACTS CAN'T BE DELETED YET... don't know how :(
                'The remove button removes the contact from the DOM so any that aren't removed
                'will necessarily be missing from the CharterCarrier object coming in

                'This needs to be done by comparing what's on the database and what is submitted in the contacts
                'list I think. Not sure how I want to do this yet because it can cause some strange runtime errors


                'Dim submittedIds As List(Of Integer) = New List(Of Integer)
                'Dim existingIds As List(Of Integer) = New List(Of Integer)
                'Dim existingContacts As List(Of CharterContact) = New List(Of CharterContact)
                'existingContacts = (db.carriers.Find(charterCarrier.Id).Contacts).ToList()
                'Dim deleteContacts As List(Of CharterContact) = existingContacts.Where(Function(c) Not (charterCarrier.Contacts.Any(Function(s) s.Id = c.Id)))



                'Update and Edit new and existing contacts
                'Make sure each new Id is not equal to any other new Id
                For Each contact In charterCarrier.Contacts.Where(Function(c) c.Id = 0)
                    Static Dim contactCounter As Integer = -1
                    contact.Id = contactCounter
                    contactCounter -= 1
                Next

                For Each contact In charterCarrier.Contacts

                    contact.Contactable = charterCarrier.Company.Contactable
                    If contact.Id < 0 Then
                        db.Entry(contact).State = EntityState.Added
                    Else
                        db.Entry(contact).State = EntityState.Modified
                    End If
                    db.Entry(contact.Contactable).State = EntityState.Unchanged
                Next

                'Update and Edit new and existing comments

                For Each comment In charterCarrier.Comments.Where(Function(c) c.Id = 0)
                    Static Dim commentCounter As Integer = -1
                    comment.Id = commentCounter
                    commentCounter -= 1
                Next


                For Each comment In charterCarrier.Comments
                    comment.Commentable = charterCarrier.Commentable
                    If comment.Id = 0 Then
                        db.Entry(comment).State = EntityState.Added

                    Else
                        db.Entry(comment).State = EntityState.Modified
                    End If
                    db.Entry(comment.Commentable).State = EntityState.Unchanged
                    db.SaveChanges()
                Next



                db.Entry(charterCarrier).State = EntityState.Modified
                db.Entry(charterCarrier.Company).State = EntityState.Modified

                db.SaveChanges()

                Return RedirectToAction("Index")
            End If
            ViewBag.States = New SelectList(db.states, "Id", "Name")
            Return View(charterCarrier)
        End Function

        ' GET: CharterCarriers/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterCarrier As CharterCarrier = db.carriers.Find(id)
            If IsNothing(charterCarrier) Then
                Return HttpNotFound()
            End If
            Return View(charterCarrier)
        End Function

        ' POST: CharterCarriers/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult

            'This actually worked how I expected it to :)

            'Load all related data
            Dim charterCarrier As CharterCarrier = (From carrier In db.carriers.Include(Function(c) c.Commentable).Include(Function(c) c.Company).Include(Function(c) c.Company.Contactable)
                                                    Select carrier Where carrier.Id = id).FirstOrDefault()
            'Delete all related data
            db.comments.RemoveRange(charterCarrier.Comments)
            db.contacts.RemoveRange(charterCarrier.Contacts)
            db.contactable.Remove(charterCarrier.Company.Contactable)
            db.commentable.Remove(charterCarrier.Commentable)
            db.companies.Remove(charterCarrier.Company)
            db.carriers.Remove(charterCarrier)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function



        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
