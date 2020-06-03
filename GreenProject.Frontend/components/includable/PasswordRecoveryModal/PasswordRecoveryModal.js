$("#form-pwd-recovery-modal").submit(function(e) {
    e.preventDefault();
    let email = $(this).find("#recovery-email").val();
    $("#pwd-recovery-modal-loader").show();
    $(".send-pwd-recovery").prop("disabled", true);
    API.passwordRecovery(email)
    .then(function(data) {
        InfoModal.show("Controlla la tua posta. Ti abbiamo inviato un messaggio con un link per reimpostare la password del tuo account.");
    })
    .catch(function(jqXHR) { ErrorModal.show(jqXHR) })
    .finally(function(data) {
        $(".send-pwd-recovery").prop("disabled", false);
        $("#pwd-recovery-modal-loader").hide();
    });
});