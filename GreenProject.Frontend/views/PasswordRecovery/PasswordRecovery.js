$("#form-pwd-recovery").submit(function(event) {
    event.preventDefault();
    Utils.prepForValidation($(this));

    let newPwd = $("#new-password").val();
    let confPwd = $("#confirm-new-password").val();

    if (newPwd != confPwd) {
        $("#new-password").addClass("error");
        $("#confirm-new-password").addClass("error");
        $("#pwd-recovery-error-not-matching").show();
        $(".submit-pwd-recovery").prop("disabled", false);
        return;
    }
    /*if (newPwd.length < 8) {
        $("#new-password").addClass("error")
        $("#confirm-new-password").addClass("error");
        $("#pwd-recovery-error-not-compliant").show();
        return;
    }*/

    $("#modal-loading").showModal();

    return;

    API.changePsw(oldPwd, newPwd)
    .then(function(data) {
        InfoModal.show("La password è stata cambiata con successo.");
        $("#form-pwd-change")[0].reset();
    })
    .catch(function(jqXHR) { ErrorModal.show(jqXHR) })
    .finally(function(data) {
        $("#change-pwd-loader").hide();
        $("#submit-change-password").prop("disabled", false);
    });
});