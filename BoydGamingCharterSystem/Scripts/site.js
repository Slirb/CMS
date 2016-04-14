$(document).ready(function () {

    $(".addItem").click(function () {
        var container = $(this).data("append");
        $.ajax({
            url: this.href,
            cache: false,
            method: 'POST',
            success: function (html) {
                $(container).append(html);
            }
        });
        return false;
    });
    $(document).on("click", ".deleteRow", function () {
        
      
        $(this).parent().parent().remove();
        return false;
    })
});

