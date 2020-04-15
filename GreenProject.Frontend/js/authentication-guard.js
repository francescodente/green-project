$(document).ready(function() {
    // CHANGE WITH A MORE APPROPRIATE LOGIN CHECK METHOD
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