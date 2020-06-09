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
    if (newPwd.length < 8) {
        $("#new-password").addClass("error")
        $("#confirm-new-password").addClass("error");
        $("#pwd-recovery-error-not-compliant").show();
        $(".submit-pwd-recovery").prop("disabled", false);
        return;
    }

    $("#modal-loading").showModal();

    API.passwordRecoveryAccept(location.searchParams.get("token"), newPwd)
    .then(function(data) {
        $("#modal-password-recovery-success").showModal();
        $("#new-password").val("");
        $("#confirm-new-password").val("");
    })
    .catch(function(jqXHR) { ErrorModal.show(jqXHR) })
    .finally(function(data) {
        $(".submit-pwd-recovery").prop("disabled", false);
    });
});