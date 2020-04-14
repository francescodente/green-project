$(document).ready(function() {
    if (localStorage.getItem("token") === null) {
        // User is not logged in
        $(".req-login").remove();
    } else {
        // User is logged in
        $(".req-logout").remove();
    }

    $(document).on("click", ".btn-logout", function() {
        logout();
        location.reload();
    });
});