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

        APIUtils.getOrUpdateCurrentUserInfo()
        .then(function(data) {
            // Show change password modal if user must change password
            if (data.shouldChangePassword) {
                $("#modal-pwd-change").attr("data-backdrop", "static");
                $("#modal-pwd-change").attr("data-keyboard", "false");
                $("#modal-pwd-change [data-dismiss='modal']").remove();
                $("#modal-pwd-change .btn-logout").removeClass("d-none");
                $("#modal-pwd-change .change-pwd-msg").removeClass("d-none");
                $("#modal-pwd-change").showModal();
            }
        })
        .catch(function(jqXHR) { new ErrorModal(jqXHR).show(); });

        APIUtils.updateCartBadge()
        .catch(function(jqXHR) { new ErrorModal(jqXHR).show(); });

    }

    $(document).on("click", ".btn-logout", function() {
        API.logout();
        location.reload();
    });
});
