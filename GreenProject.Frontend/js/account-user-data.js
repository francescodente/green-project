$(document).ready(function() {

    function fillFormFields() {
        let userData = localStorage.getObject("userData");
        $("#email").val(userData.email);
        $("#marketing-consent").prop("checked", userData.marketingConsent);
        if ("Person" in userData.rolesData) {
            let person = userData.rolesData.Person;
            $("#code").val(person.code);
            $("#first-name").val(person.firstName);
            $("#last-name").val(person.lastName);
            if (person.dateOfBirth != null) {
                let dd = person.dateOfBirth.substring(8, 10);
                let mm = person.dateOfBirth.substring(5, 7);
                let yyyy  = person.dateOfBirth.substring(0, 4);
                let date = dd + "/" + mm + "/" + yyyy;
                $("#birth-date").val(date);
            }
            $("[name=gender][value=" + person.gender + "]").prop("checked", true);
        } else {
            $("#code").val("");
            $("#first-name").val("");
            $("#last-name").val("");
            $("#birth-date").val("");
            $("[name=gender]").prop("checked", false);
        }
    }

    function validateDateOfBirth(date) {
        let pattern = /^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/;
        if (date == null || date == "" || !pattern.test(date)) {
            return false;
        }
        let dd = date.substring(0, 2);
        let mm = date.substring(3, 5);
        let yyyy  = date.substring(6, 10);
        let dateObject = new Date(yyyy + "/" + mm + "/" + dd);
        let dateString = ("0" + dateObject.getDate()).slice(-2) + "/"
                       + ("0" + (dateObject.getMonth()+1)).slice(-2) + "/"
                       + dateObject.getFullYear();
        if (date != dateString) {
            return false;
        }
        if (dateObject.getTime() > new Date().getTime()) {
            return false
        }
        return yyyy + "-" + mm + "-" + dd;
    }

    // Get user data
    showModal($("#modal-loading"));
    getOrUpdateCurrentUserInfo()
    .then(function(data) { fillFormFields(); })
    .catch(function(jqXHR) { new ErrorModal(jqXHR).show(); })
    .finally(function(data) { fadeOutModal($("#modal-loading")); });

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

    // Edit form click
    $("#user-data").on("click", ".edit-form", function() {
        $(".user-data-form-options").addClass("d-none");
        $(".user-data-form-controls").removeClass("d-none");
        $(this).closest("form").find("input, textarea").prop("disabled", false);
    });

    // Cancel form edits click
    $("#user-data").on("click", ".cancel-form-edits", function() {
        $(".user-data-form-controls").addClass("d-none");
        $(".user-data-form-options").removeClass("d-none");
        $(this).closest("form").find("input, textarea").prop("disabled", true);
        fillFormFields();
    });

    // Submit personal data
    $("#form-user-data-personal").submit(function(event) {
        event.preventDefault();

        // Check code format
        let code = $("#code").val().toUpperCase();
        if (!CFValidator.validate(code).isValid && !PIValidator.validate(code).isValid) {
            $("#code").addClass("error");
            return;
        }

        let data = {
            code: code,
            firstName: $("#first-name").val(),
            lastName: $("#last-name").val()
        };

        // Check date format
        let date = $("#birth-date").val();
        if (date != null && date != "") {
            date = validateDateOfBirth($("#birth-date").val());
            if (date == false) {
                $("#birth-date").addClass("error");
                return;
            } else {
                data.dateOfBirth = date;
            }
        }

        // Check gender
        let gender = $("[name='gender']:checked").val();
        if (gender != null) {
            data.gender = gender;
        }

        showModal($("#modal-loading"));
        setPersonRole(localStorage.getObject("authData").userId, data)
        .done(function(data) {
            console.log("done");
            localStorage.removeItem("userData");
            location.reload();
        })
        .fail(function(jqXHR) { new ErrorModal(jqXHR).show(); });
    });

    // Delete personal data
    $("#delete-user-data-personal").click(function() {
        showModal($("#modal-loading"));
        deletePersonRole(localStorage.getObject("authData").userId)
        .done(function(data) {
            localStorage.removeItem("userData");
            location.reload();
        })
        .fail(function(jqXHR) { new ErrorModal(jqXHR).show(); });
    });

});