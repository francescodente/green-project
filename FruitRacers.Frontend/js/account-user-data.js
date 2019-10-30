$(document).ready(function() {

    $(".edit.btn").click(function() {
        if ($(this).find(".mdi-content-save").hasClass("d-none")) {
            // Switch to edit mode
            $(this).attr("title", "Salva");
            $(this).find(".mdi-pencil").addClass("d-none");
            $(this).find(".mdi-content-save").removeClass("d-none");
            var input = $(this).parent().find("input, textarea");
            input.prop("disabled", false);
            input.select();
        } else {
            // Save edits
            $(this).attr("title", "Modifica");
            $(this).find(".mdi-content-save").addClass("d-none");
            $(this).find(".mdi-pencil").removeClass("d-none");
            $(this).parent().find("input, textarea").prop("disabled", true);
            // TODO submit
        }
    });

});