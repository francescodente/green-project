var tempEmail = localStorage.getObject("tempEmail");
if (tempEmail != null) tempEmail = tempEmail.email;
$("#modal-account-activation .email").html(tempEmail);

$(".resend-activation").click(function() {
    console.log("resend-activation");
    $(this).prop("disabled", true);
    $("#account-activation-loader").show();
    API.sendActivation(tempEmail)
    .then(function(data) {
        InfoModal.show("Messaggio inviato!<br/>Controlla la tua posta.");
    })
    .catch(function(jqXHR) { ErrorModal.show(jqXHR) })
    .finally(function(data) {
        $(".resend-activation").prop("disabled", false);
        $("#account-activation-loader").hide();
    });
});