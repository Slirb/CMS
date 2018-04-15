Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports CharterSystem

Namespace Controllers
    Public Class CharterOperatorsController
        Inherits System.Web.Mvc.Controller

        Private db As New CharterSystem

        ' GET: CharterOperators
        Function Index() As ActionResult
            Dim operators As List(Of CharterOperator)
            operators = (From charterOperator In db.operators.Include(Function(o) o.Commentable).Include(Function(o) o.Company).Include(Function(o) o.Company.Contactable)
                         Select charterOperator).ToList()

            Return View(operators)
        End Function

        ' GET: CharterOperators/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperator As CharterOperator = (From co In db.operators.Include(Function(o) o.Commentable).Include(Function(o) o.Company).Include(Function(o) o.Company.Contactable)
                                                      Select co Where co.Id = id).FirstOrDefault()
            If IsNothing(charterOperator) Then
                Return HttpNotFound()
            End If
            Return View(charterOperator)
        End Function

        ' GET: CharterOperators/Create
        Function Create() As ActionResult
            Dim charterOperator As CharterOperator = New CharterOperator()
            charterOperator.Company.CreateCharterContacts(1)
            charterOperator.CreateCharterComments(1)

            ViewBag.States = New SelectList(db.states, "Id", "Name")
            ViewBag.OpInterests = New SelectList(db.operatorInterests, "Id", "Interest")
            ViewBag.OpModes = New SelectList(db.operatorModes, "Id", "Mode")
            ViewBag.OpStopCodes = New SelectList(db.operatorStopCodes, "Id", "StopCode")
            ViewBag.OpTypes = New SelectList(db.operatorTypes, "Id", "Type")
            Return View(charterOperator)
        End Function

        ' POST: CharterOperators/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal charterOperator As CharterOperator) As ActionResult
            If ModelState.IsValid Then
                charterOperator.Created = DateTime.Now()
                db.operators.Add(charterOperator)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.States = New SelectList(db.states, "Id", "Name")
            ViewBag.OpInterests = New SelectList(db.operatorInterests, "Id", "Interest")
            ViewBag.OpModes = New SelectList(db.operatorModes, "Id", "Mode")
            ViewBag.OpStopCodes = New SelectList(db.operatorStopCodes, "Id", "StopCode")
            ViewBag.OpTypes = New SelectList(db.operatorTypes, "Id", "Type")
            Return View(charterOperator)
        End Function

        ' GET: CharterOperators/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperator As CharterOperator = (From op In db.operators.Include(Function(c) c.Commentable).Include(Function(c) c.Company).Include(Function(c) c.Company.Contactable)
                                                      Select op Where op.Id = id).FirstOrDefault()
            If IsNothing(charterOperator) Then
                Return HttpNotFound()
            End If


            ViewBag.States = New SelectList(db.states, "Id", "Name")
            ViewBag.OpInterests = New SelectList(db.operatorInterests, "Id", "Interest")
            ViewBag.OpModes = New SelectList(db.operatorModes, "Id", "Mode")
            ViewBag.OpStopCodes = New SelectList(db.operatorStopCodes, "Id", "StopCode")
            ViewBag.OpTypes = New SelectList(db.operatorTypes, "Id", "Type")
            Return View(charterOperator)
        End Function

        ' POST: CharterOperators/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal charterOperator As CharterOperator) As ActionResult
            If ModelState.IsValid Then
                Dim existingOperator As CharterOperator = (From op In db.operators.AsNoTracking().Include(Function(c) c.Commentable).AsNoTracking().Include(Function(c) c.Company).AsNoTracking().Include(Function(c) c.Company.Contactable).AsNoTracking()
                                                           Select op Where op.Id = charterOperator.Id).FirstOrDefault()

                'update and edit existing operator contacts
                For Each contact In charterOperator.Contacts.Where(Function(c) c.Id = 0)
                    Static Dim contactCounter As Integer = -1
                    contact.Id = contactCounter
                    contactCounter -= 1
                Next

                For Each contact In charterOperator.Contacts
                    contact.Contactable = charterOperator.Company.Contactable
                    If contact.Id < 0 Then
                        db.Entry(contact).State = EntityState.Added
                    Else
                        db.Entry(contact).State = EntityState.Modified
                    End If
                    db.Entry(contact.Contactable).State = EntityState.Unchanged
                Next

                'Delete contacts
                Dim existingContacts As List(Of CharterContact) = existingOperator.Contacts
                Dim deletedContacts As List(Of CharterContact) = existingContacts.Where(Function(p) Not charterOperator.Contacts.Any(Function(p2) p2.Id = p.Id)).ToList()
                Dim savedContacts As List(Of CharterContact) = existingContacts.Where(Function(p) charterOperator.Contacts.Any(Function(c) c.Id = p.Id)).ToList()
                For Each contact In deletedContacts
                    Dim deleteContact As CharterContact = db.contacts.Find(contact.Id)
                    db.contacts.Remove(deleteContact)
                Next

                'Preserve uneditable data for existing contacts
                For Each contact In savedContacts
                    Dim savedContact As CharterContact = charterOperator.Contacts.Find(Function(c) c.Id = contact.Id)
                    savedContact.CreatedDateTime = contact.CreatedDateTime
                Next

                'update and edit existing comments
                For Each comment In charterOperator.Comments.Where(Function(c) c.Id = 0)
                    Static Dim commentCounter As Integer = -1
                    comment.Id = commentCounter
                    commentCounter -= 1
                Next



                For Each comment In charterOperator.Comments
                    comment.Commentable = charterOperator.Commentable
                    If comment.Id < 0 Then
                        db.Entry(comment).State = EntityState.Added
                    Else
                        db.Entry(comment).State = EntityState.Modified
                    End If
                    db.Entry(comment.Commentable).State = EntityState.Unchanged
                Next

                'delete comments
                Dim existingComments As List(Of CharterComment) = existingOperator.Comments
                Dim deletedComments As List(Of CharterComment) = existingComments.Where(Function(p) Not charterOperator.Comments.Any(Function(p2) p2.Id = p.Id)).ToList()
                Dim savedComments As List(Of CharterComment) = existingComments.Where(Function(p) charterOperator.Comments.Any(Function(c) c.Id = p.Id)).ToList()

                For Each comment In deletedComments
                    Dim deleteComment As CharterComment = db.comments.Find(comment.Id)
                    db.comments.Remove(deleteComment)
                Next

                'Preserve uneditable comment data
                For Each comment In savedComments
                    Dim saveComment As CharterComment = charterOperator.Comments.Find(Function(c) c.Id = comment.Id)
                    saveComment.CreateDateTime = comment.CreateDateTime
                Next

                db.Entry(charterOperator).State = EntityState.Modified
                db.Entry(charterOperator.Company).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            ViewBag.States = New SelectList(db.states, "Id", "Name")
            ViewBag.OpInterests = New SelectList(db.operatorInterests, "Id", "Interest")
            ViewBag.OpModes = New SelectList(db.operatorModes, "Id", "Mode")
            ViewBag.OpStopCodes = New SelectList(db.operatorStopCodes, "Id", "StopCode")
            ViewBag.OpTypes = New SelectList(db.operatorTypes, "Id", "Type")
            Return View(charterOperator)
        End Function

        ' GET: CharterOperators/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim charterOperator As CharterOperator = db.operators.Find(id)
            If IsNothing(charterOperator) Then
                Return HttpNotFound()
            End If
            Return View(charterOperator)
        End Function

        ' POST: CharterOperators/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim charterOperator As CharterOperator = (From op In db.operators.Include(Function(c) c.Commentable).Include(Function(c) c.Company).Include(Function(c) c.Company.Contactable)
                                                      Select op Where op.Id = id).FirstOrDefault()
            'Delete all related data
            db.comments.RemoveRange(charterOperator.Comments)
            db.contacts.RemoveRange(charterOperator.Contacts)
            db.contactable.Remove(charterOperator.Company.Contactable)
            db.commentable.Remove(charterOperator.Commentable)
            db.companies.Remove(charterOperator.Company)
            db.operators.Remove(charterOperator)
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
