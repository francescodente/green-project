$(document).ready(function() {

    $(".edit-field.btn").click(function() {
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

    $(".edit-form.btn").click(function() {
        var icon = $(this).find(".mdi");
        if (icon.hasClass("mdi-pencil")) {
            // Switch to edit mode
            icon.removeClass("mdi-pencil");
            icon.addClass("mdi-content-save");
            $(this).find("p").html("Salva");
            $(this).closest("form").find("input, textarea").prop("disabled", false);
        } else {
            // Save edits
            icon.removeClass("mdi-content-save");
            icon.addClass("mdi-pencil");
            $(this).find("p").html("Modifica");
            $(this).closest("form").find("input, textarea").prop("disabled", true);
            // TODO submit
        }
    });

});