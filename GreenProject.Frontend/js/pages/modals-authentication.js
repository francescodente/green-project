// Prepares form for validation: removes previous errors, disables submit button
function prepForValidation(form) {
    form.find("[type='submit']").prop("disabled", true);
    form.find("input").removeClass("error");
    form.find(".error-message").hide();
}

$(document).ready(function() {

    // LOGIN
    $("#form-login").submit(function(event) {
        event.preventDefault();
        $("#login-loader").show();
        prepForValidation($(this));
        API.authToken({
            email: $("#login-email").val(),
            password: $("#login-password").val()
        })
        .done(function(data) {
            localStorage.setObject("authData", data);
            location.reload();
        })
        .fail(function(jqXHR) {
            let errCode = jqXHR.responseJSON.globalErrors[0].code;
            if (errCode == "Err.Auth.LoginFailed") {
                $("#login-email").addClass("error");
                $("#login-password").addClass("error");
                $("#login-failed-error").show();
            } else {
                $("#generic-login-error").show();
            }
            $("#login-loader").hide();
            $(".btn-login").prop("disabled", false);
        });
    });

    // REGISTRATION
    $("#form-sign-up").submit(function(event) {
        event.preventDefault();
        $("#form-sign-up .error-message").hide();
        // Check password fields
        let password = $("#sign-up-password").val();
        if (password != $("#confirm-password").val()) {
            $("#sign-up-password").addClass("error");
            $("#confirm-password").addClass("error");
            $("#sign-up-password-error").show();
            $(".btn-sign-up").prop("disabled", false);
            return;
        }
        // Perform registration
        $("#sign-up-loader").show();
        prepForValidation($(this));
        API.signup({
            user: {
                email: $("#sign-up-email").val(),
                marketingConsent: $("#marketing-consent").is(":checked")
            },
            password: password
        })
        .done(function(data) {
            console.log("done");
            console.log(data);
        })
        .fail(function(jqXHR) {
            if (jqXHR.responseJSON.propertyErrors.length &&
                jqXHR.responseJSON.propertyErrors[0].code == "Err.DuplicateField") {
                console.log(jqXHR.responseJSON.propertyErrors[0]);
                $("#sign-up-email").addClass("error");
            } else {
                $("#generic-sign-up-error").show();
            }
            $("#sign-up-loader").hide();
            $(".btn-sign-up").prop("disabled", false);
        });
    });

});