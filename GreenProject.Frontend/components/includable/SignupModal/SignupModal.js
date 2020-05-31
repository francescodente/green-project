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
    Utils.prepForValidation($(this));
    API.signup({
        user: {
            email: $("#sign-up-email").val(),
            marketingConsent: true
        },
        password: password
    })
    .then(function(data) {
        localStorage.setObject("tempEmail", {
            email: data.email
        });
        Utils.removeGetModal();
        $("#modal-account-activation").showModal();
    })
    .catch(function(jqXHR) {
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