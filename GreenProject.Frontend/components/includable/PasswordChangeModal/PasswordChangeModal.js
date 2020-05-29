// Prepares form for validation: removes previous errors, disables submit button
function prepForValidation(form) {
    form.find("[type='submit']").prop("disabled", true);
    form.find("input").removeClass("error");
    form.find(".error-message").hide();
}

function invalidForm(form) {
    form.find("[type='submit']").prop("disabled", false);
}

// LOGIN
$("#form-pwd-change").submit(function(event) {
    event.preventDefault();
    prepForValidation($(this));

    let oldPwd = $("#old-password").val();
    let newPwd = $("#new-password").val();
    let confPwd = $("#confirm-new-password").val();

    if (newPwd != confPwd) {
        $("#new-password").addClass("error");
        $("#confirm-new-password").addClass("error");
        $("#pwd-change-error-not-matching").show();
        invalidForm($(this));
        return;
    }
    if (oldPwd == newPwd) {
        $("#old-password").addClass("error");
        $("#new-password").addClass("error");
        $("#confirm-new-password").addClass("error");
        $("#pwd-change-error-same-pwd").show();
        invalidForm($(this));
        return;
    }
    /*if (newPwd.length < 8) {
        $("#new-password").addClass("error")
        $("#confirm-new-password").addClass("error");
        $("#pwd-change-error-not-compliant").show();
        invalidForm($(this));
        return;
    }*/

    $("#change-pwd-loader").show();

    API.changePsw(oldPwd, newPwd)
    .then(function(data) {
        InfoModal.show("La password è stata cambiata con successo.");
        $("#form-pwd-change")[0].reset();
    })
    .catch(function(jqXHR) {
        console.log(jqXHR);
        if (jqXHR.responseJSON && jqXHR.responseJSON.globalErrors.length) {
            let errCode = jqXHR.responseJSON.globalErrors[0].code;
            if (errCode == "Err.Auth.LoginFailed") {
                $("#old-password").addClass("error")
                $("#pwd-change-error-auth-failed").show();
                return;
            }
        }
        ErrorModal.show(jqXHR);
    })
    .finally(function(data) {
        $("#change-pwd-loader").hide();
        $("#submit-change-password").prop("disabled", false);
    });
});