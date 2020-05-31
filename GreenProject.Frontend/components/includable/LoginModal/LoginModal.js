$("#form-login").submit(function(event) {
    event.preventDefault();
    $("#login-loader").show();
    Utils.prepForValidation($(this));
    API.authToken({
        email: $("#login-email").val(),
        password: $("#login-password").val()
    })
    .then(function(data) {
        localStorage.removeItem("userData");
        localStorage.setObject("authData", data);
        Utils.removeGetModal();
        location.reload();
    })
    .catch(function(jqXHR) {
        if (jqXHR.responseJSON == null) {
            ErrorModal.show(jqXHR);
            return;
        }
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