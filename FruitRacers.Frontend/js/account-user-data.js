$(document).ready(function() {

    $("#user-data").on("click", ".edit-field", function() {
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
            $(this).blur();
            // TODO submit
        }
    });

    $("#user-data").on("click", ".edit-form", function() {
        var icon = $(this).find(".mdi");
        if (icon.hasClass("mdi-pencil")) {
            // Switch to edit mode
            icon.removeClass("mdi-pencil");
            icon.addClass("mdi-content-save");
            $(this).find("span").html("Salva");
            $(this).closest("form").find("input, textarea").prop("disabled", false);
            $(this).closest("form").find(".file-input").removeClass("disabled");
        } else {
            // Save edits
            icon.removeClass("mdi-content-save");
            icon.addClass("mdi-pencil");
            $(this).find("span").html("Modifica");
            $(this).closest("form").find("input, textarea").prop("disabled", true);
            $(this).closest("form").find(".file-input").addClass("disabled");
            // TODO submit
        }
    });

});