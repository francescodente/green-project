$(document).ready(function() {
    let authData = localStorage.getObject("authData");

    // TODO clear localStorage if authData has expired

    if (authData === null) {
        // User is not logged in

        // Redirect to index if current page requires login
        if ($("body").hasClass("req-login")) {
            window.location.href = "index.php";
        }

        // User is not logged in
        $(".req-login").remove();

    } else {
        // User is logged in

        if (!authData.roles.includes("Administrator")) {
            // Redirect to index if current page requires missing admin rights
            if ($("body").hasClass("req-admin")) {
                window.location.href = "index.php";
            }
            $(".req-admin").remove();
        }

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