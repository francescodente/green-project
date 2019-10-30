$(document).ready(function() {

    $(".edit.btn").click(function() {
        var icon = $(this).find(".mdi");
        if (icon.hasClass("mdi-pencil")) {
            // Switch to edit mode
            $(this).attr("title", "Salva");
            icon.removeClass("mdi-pencil");
            icon.addClass("mdi-content-save");
            var input = $(this).parent().find("input, textarea");
            input.prop("disabled", false);
            input.select();
        } else {
            // Save edits
            $(this).attr("title", "Modifica");
            icon.removeClass("mdi-content-save");
            icon.addClass("mdi-pencil");
            $(this).parent().find("input, textarea").prop("disabled", true);
            // TODO submit
        }
    });

});