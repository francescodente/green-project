function fillFormFields(userData) {
    $("#email").val(userData.email);
    $("#marketing-consent").prop("checked", userData.marketingConsent);
    if ("Person" in userData.rolesData) {
        let person = userData.rolesData.Person;
        $("#code").val(person.code);
        $("#first-name").val(person.firstName);
        $("#last-name").val(person.lastName);
        if (person.dateOfBirth != null) {
            $("#birth-date").val(moment(person.dateOfBirth).format("DD/MM/YYYY"));
        }
        $("[name=gender][value=" + person.gender + "]").prop("checked", true);
    } else {
        $("#code").val("");
        $("#first-name").val("");
        $("#last-name").val("");
        $("#birth-date").val("");
        $("[name=gender]").prop("checked", false);
    }
    $("input").removeClass("error");
}

function validateDateOfBirth(dateString) {
    let date = moment(dateString, "DD/MM/YYYY");
    if (!date.isValid || date.isAfter(moment())) {
        return false;
    }
    return date.format("YYYY-MM-DD");
}

// Get user data
$("#modal-loading").showModal();
APIUtils.getOrUpdateCurrentUserInfo(true)
.then(function(data) {
    fillFormFields(data);
    $("#modal-loading").fadeModal();
})
.catch(function(jqXHR) { ErrorModal.show(jqXHR); })

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

    $("#modal-loading").showModal();
    API.setPersonRole(localStorage.getObject("authData").userId, data)
    .then(function(data) {
        let authData = localStorage.getObject("authData");
        if (!authData.roles.includes("Person")) {
            authData.roles.push("Person");
            localStorage.setObject("authData", authData);
        }
        localStorage.removeItem("userData");
        location.reload();
    })
    .catch(function(jqXHR) { ErrorModal.show(jqXHR); });
});

// Delete personal data
$("#delete-user-data-personal").click(function() {
    $("#modal-loading").showModal();
    API.deletePersonRole(localStorage.getObject("authData").userId)
    .then(function(data) {
        let authData = localStorage.getObject("authData");
        authData.roles = authData.roles.filter(role => role != "Person");
        localStorage.setObject("authData", authData);
        localStorage.removeItem("userData");
        location.reload();
    })
    .catch(function(jqXHR) { ErrorModal.show(jqXHR); });
});

// Marketing consent handling
$("#marketing-consent").click(function(e) {
    e.preventDefault();
    if (!$(this).prop("checked")) {
        $("#modal-marketing-consent-delete").showModal();
    } else {
        setMarketingConsent(true);
    }

});

$("#delete-marketing-consent").click(function() {
    setMarketingConsent(false);
});

function setMarketingConsent(enabled) {
    $("#modal-loading").showModal();
    Utils.wait(1000) // TODO replace with proper API call
    .then(function(data) {
        $("#modal-loading").fadeModal();
        $("#marketing-consent").prop("checked", enabled);
    })
    .catch(function(jqXHR) { ErrorModal.show(jqXHR); });
}
