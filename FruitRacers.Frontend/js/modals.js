$(document).ready(function() {

    $("#sign-up-link").click(function(event) {
        event.preventDefault();
        $("#modal-login").modal("hide");
        $("#modal-sign-up").modal("show");
    });

    $("#pwd-recovery-link").click(function(event) {
        event.preventDefault();
        $("#modal-login").modal("hide");
        $("#modal-pwd-recovery").modal("show");
    });

    $(".back-to-login").click(function(event) {
        event.preventDefault();
        $(this).closest(".modal").modal("hide");
        //$("#modal-sign-up").modal("hide");
        $("#modal-login").modal("show");
    });

    $("#modal-product .company-name").click(function() {
        event.preventDefault();
        $(this).closest(".modal").modal("hide");
        $("#modal-company").modal("show");
    });

});