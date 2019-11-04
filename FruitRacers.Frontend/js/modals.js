function switchModal(currentModal, nextModal) {
    $(currentModal).modal("hide");
    $(nextModal).modal("show");
}

$(document).ready(function() {

    $("#sign-up-link").click(function(event) {
        event.preventDefault();
        switchModal("#modal-login", "#modal-sign-up");
    });

    $("#pwd-recovery-link").click(function(event) {
        event.preventDefault();
        switchModal("#modal-login", "#modal-pwd-recovery");
    });

    $(".back-to-login").click(function(event) {
        event.preventDefault();
        switchModal($(this).closest(".modal"), "#modal-login");
    });

    $("#modal-product .company-name").click(function() {
        event.preventDefault();
        switchModal("#modal-product", "#modal-company");
    });

});