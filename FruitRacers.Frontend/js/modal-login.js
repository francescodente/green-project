$(document).ready(function() {

    $("#sign-up-link").click(function(event) {
        event.preventDefault();
        $("#modal-login").modal("hide");
        $("#modal-sign-up").modal("show");
    });

    $("#back-to-login").click(function(event) {
        event.preventDefault();
        $("#modal-sign-up").modal("hide");
        $("#modal-login").modal("show");
    });

});