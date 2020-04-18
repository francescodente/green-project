$(document).ready(function() {

    function fillFormFields() {
        let userData = localStorage.getObject("userData");
        $("#email").val(userData.email);
        $("#telephone").val(userData.telephone);
        $("#marketing-consent").prop("checked", userData.marketingConsent);
        if ("Person" in userData.rolesData) {
            let person = userData.rolesData.Person;
            $("#first-name").val(person.firstName);
            $("#last-name").val(person.lastName);
        } else {
            $("#first-name").val("");
            $("#last-name").val("");
        }
    }

    // CHANGE WITH A MORE APPROPRIATE LOGIN CHECK METHOD
    if (localStorage.getObject("authData") === null) {
        window.location.href = "index.php";
    }

    // Get user data
    showModal($("#modal-loading"));
    saveCurrentUserInfo()
    .then(function(data) {
        fillFormFields();
        fadeOutModal($("#modal-loading"));
    })
    .catch(function(data) {
        // TODO redirect to error page
    });

    /*$("#user-data").on("click", ".edit-field", function() {
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
    });*/

    $("#user-data").on("click", ".edit-form", function() {
        $(".user-data-form-options").addClass("d-none");
        $(".user-data-form-controls").removeClass("d-none");
        $(this).closest("form").find("input, textarea").prop("disabled", false);
    });

    $("#user-data").on("click", ".cancel-form-edits", function() {
        $(".user-data-form-controls").addClass("d-none");
        $(".user-data-form-options").removeClass("d-none");
        $(this).closest("form").find("input, textarea").prop("disabled", true);
        fillFormFields();
    });

    $("#form-user-data-personal").submit(function(event) {
        event.preventDefault();
        showModal($("#modal-loading"));
        setPersonRole(localStorage.getObject("authData").userId, {
            firstName: $("#first-name").val(),
            lastName: $("#last-name").val()
        })
        .done(function(data) {
            console.log("done");
            saveCurrentUserInfo().then(function() { location.reload(); });
        })
        .fail(function(data) {
            console.log("fail");
        });
    });

    $("#delete-user-data-personal").click(function() {
        console.log("delete");
        showModal($("#modal-loading"));
        deletePersonRole(localStorage.getObject("authData").userId)
        .done(function(data) {
            console.log("done");
            saveCurrentUserInfo().then(function() { location.reload(); });
        })
        .fail(function(data) {
            console.log("fail");
        })
        .always(function(data) {
            console.log("always");
        });
    });

});