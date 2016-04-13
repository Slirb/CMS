@ModelType BoydGamingCharterSystem.CharterContact
<dl>
    
    <dt>
        @Html.DisplayNameFor(Function(model) model.FullName)
    
    </dt>
    
    <dd>
        @Html.DisplayFor(Function(model) model.FullName)
        
    </dd>
    
    <dt>
        @Html.DisplayNameFor(Function(model) model.Email)
    
    </dt>
    
    <dd>
        @Html.DisplayFor(Function(model) model.Email)
    
    </dd>
    
    <dt>
        @Html.DisplayNameFor(Function(model) model.PrimaryPhone)
        
    </dt>
    
    <dd>
        @If (String.IsNullOrEmpty(Model.PrimaryPhoneExtension)) Then
            Html.DisplayFor(Function(model) model.PrimaryPhone)
        Else
            Html.DisplayFor(Function(model) model.PrimaryPhone & " Ext. " & model.PrimaryPhoneExtension)
        End If
        
    </dd>
    
    <dt>
        @Html.DisplayNameFor(Function(model) model.AlternatePhone)
    </dt>
    
    <dd>
        @If (String.IsNullOrEmpty(Model.AlternatePhoneExtension)) Then
            Html.DisplayFor(Function(model) model.AlternatePhone)
        Else
            Html.DisplayFor(Function(model) model.AlternatePhone & " Ext. " & model.AlternatePhoneExtension)
        End If
        
    </dd>
    
    <dt>
        @Html.DisplayNameFor(Function(model) model.EmergencyPhone)
        
    </dt>
    
    <dd>
        @If (String.IsNullOrEmpty(Model.EmergencyPhoneExtension)) Then
            Html.DisplayFor(Function(model) model.EmergencyPhone)
        Else
            Html.DisplayFor(Function(model) model.EmergencyPhone & " Ext. " & model.EmergencyPhoneExtension)
        End If
        
    </dd>
    
</dl>
