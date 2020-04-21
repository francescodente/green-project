$(document).ready(function() {
    // CHANGE WITH A MORE APPROPRIATE LOGIN CHECK METHOD
    if (localStorage.getObject("authData") === null) {

        // Redirect to hompeage if current page requires login
        if ($("body").hasClass("req-login")) {
            window.location.href = "index.php";
        }

        // User is not logged in
        $(".req-login").remove();

    } else {

        // User is logged in
        $(".req-logout").remove();
        getOrUpdateCurrentUserInfo()
        .catch(function(jqXHR) { new ErrorModal(jqXHR).show(); });
        updateCartBadge()
        .catch(function(jqXHR) { new ErrorModal(jqXHR).show(); });

    }

    getOrUpdateCategories()
    .catch(function(jqXHR) { new ErrorModal(jqXHR).show(); });
    getOrUpdateZones()
    .catch(function(jqXHR) { new ErrorModal(jqXHR).show(); });

    $(document).on("click", ".btn-logout", function() {
        logout();
        location.reload();
    });
});