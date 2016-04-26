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

            'Dim state As State = db.states.AsNoTracking.SingleOrDefault(Function(s) s.Id = 51)
            'If State Is Nothing Then
            'ModelState.AddModelError("StateId", "A valid state is required")
            'End If

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

            'Dim state As State = db.states.AsNoTracking.SingleOrDefault(Function(s) s.Id = 51)
            'If state Is Nothing Then
            'ModelState.AddModelError("State", "A valid state is required")
            'End If

            If ModelState.IsValid Then

                'Get existing carrier data and disconnect it from the database to prevent primary key collisions - this is for comparing
                'the current data to the submitted data. Anything that's removed from the submitted will exist on the current
                'and that difference will need to be reconciled
                Dim existingCarrier As CharterCarrier = (From carrier In db.carriers.AsNoTracking().Include(Function(c) c.Commentable).AsNoTracking().Include(Function(c) c.Company).AsNoTracking().Include(Function(c) c.Company.Contactable).AsNoTracking()
                                                         Select carrier Where carrier.Id = charterCarrier.Id).FirstOrDefault()

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

                'Delete contacts

                Dim existingContacts As List(Of CharterContact) = existingCarrier.Contacts
                Dim deletedContacts As List(Of CharterContact) = existingContacts.Where(Function(p) Not charterCarrier.Contacts.Any(Function(p2) p2.Id = p.Id)).ToList()
                Dim savedContacts As List(Of CharterContact) = existingContacts.Where(Function(p) charterCarrier.Contacts.Any(Function(c) c.Id = p.Id)).ToList()
                For Each contact In deletedContacts
                    Dim deleteContact As CharterContact = db.contacts.Find(contact.Id)
                    db.contacts.Remove(deleteContact)
                Next
                'Preserve data uneditable data here
                For Each contact In savedContacts
                    Dim saveContact As CharterContact = charterCarrier.Contacts.Find(Function(c) c.Id = contact.Id)
                    saveContact.CreatedDateTime = contact.CreatedDateTime
                Next


                'Update and Edit new and existing comments

                'Prevent primary key collisions as new comments all have an id of 0
                For Each comment In charterCarrier.Comments.Where(Function(c) c.Id = 0)
                    Static Dim commentCounter As Integer = -1
                    comment.Id = commentCounter
                    commentCounter -= 1
                Next

                For Each comment In charterCarrier.Comments
                    comment.Commentable = charterCarrier.Commentable
                    If comment.Id < 0 Then
                        db.Entry(comment).State = EntityState.Added
                    Else
                        db.Entry(comment).State = EntityState.Modified
                    End If
                    db.Entry(comment.Commentable).State = EntityState.Unchanged

                Next

                'Delete comments
                Dim existingComments As List(Of CharterComment) = existingCarrier.Comments
                Dim deletedComments As List(Of CharterComment) = existingComments.Where(Function(p) Not charterCarrier.Comments.Any(Function(p2) p2.Id = p.Id)).ToList()
                Dim savedComments As List(Of CharterComment) = existingComments.Where(Function(p) charterCarrier.Comments.Any(Function(c) c.Id = p.Id)).ToList()

                For Each comment In deletedComments
                    Dim deleteComment As CharterComment = db.comments.Find(comment.Id)
                    db.comments.Remove(deleteComment)
                Next
                'Preserve data uneditable data here
                For Each comment In savedComments
                    Dim saveComment As CharterComment = charterCarrier.Comments.Find(Function(c) c.id = comment.Id)
                    saveComment.CreateDateTime = comment.CreateDateTime
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
