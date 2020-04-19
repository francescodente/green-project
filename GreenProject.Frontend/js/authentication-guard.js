$(document).ready(function() {
    // CHANGE WITH A MORE APPROPRIATE LOGIN CHECK METHOD
    if (localStorage.getObject("authData") === null) {
        // User is not logged in
        $(".req-login").remove();
    } else {
        // User is logged in
        $(".req-logout").remove();
        updateCartBadge()
        .catch(function(jqXHR) { new Error(jqXHR).show(); });
    }

    $(document).on("click", ".btn-logout", function() {
        logout();
        location.reload();
    });
});