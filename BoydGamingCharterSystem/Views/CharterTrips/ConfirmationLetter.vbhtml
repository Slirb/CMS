@ModelType BoydGamingCharterSystem.CharterTrips

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>ConfirmationLetter</title>
</head>
<body>
    <div> 
        <h1>Trip Confirmation</h1>
        <p>
            @DateTime.Now
        </p>
        @Html.DisplayFor(Function(model) model.CarrierName)
        @Html.DisplayFor(Function(model) model.CharterAgreements.CharterCarrier.Company.AddressLineOne)
        @Html.DisplayFor(Function(model) model.CharterAgreements.CharterCarrier.Company.AddressLineTwo)
        @Html.DisplayFor(Function(model) model.CharterAgreements.CharterCarrier.Company.City)
        @Html.DisplayFor(Function(model) model.CharterAgreements.CharterCarrier.Company.State.Name)
        @Html.DisplayFor(Function(model) model.CharterAgreements.CharterCarrier.Company.PostalCode)
        @Html.DisplayFor(Function(model) model.CharterAgreements.CharterCarrier.Company.Country)

        <p>
            Dear Group Leader,
        </p>
        <p>
            Thank you for choosing <!--Insert Location-->.  Listed below are the details of your bus scedule.<br />
             Please review the information carefully and contact us regarding any changes.  A completed manifest with names,<br />
             adresses, and birth dates is required one week prior to your trip date.  Your bus with not be accepted without<br />
             a complete manifest.
        </p>
        <p>
            Trip date:          @Html.DisplayFor(Function(model) model.Arrival) <br />
            Confirmation No:    @Html.DisplayFor(Function(model) model.Confirmation)<br />
            Carrier:            @Html.DisplayFor(Function(model) model.CarrierName)<br />

            Applied Commission:
            <!--Insert commission rate-->

         <p>
             All passengers must be 21 years or older with a valid photo ID.  Bus companies must have a Certificate of Liability<br />
              Insurance on file.  All busses are to load and unload at Front Entrance Bus Lane.  Upon arrival, our representative will meet the bus<br />
              and greet the passengers.
             <br />
             <br />

             We look forward to your group's arrival at <!--insert location-->!  Please call with any questions or concerns<br />
             <!--insert phone number for office--> Tour and Travel Department.  Our fax number is <!--insert fax number--><br />
         </p>
        
        <p>
            Respectfully Yours,
        </p>
    </div>
</body>
</html>
