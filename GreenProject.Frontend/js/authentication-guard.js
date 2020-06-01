$(document).ready(function() {
    let authData = localStorage.getObject("authData");
    let roleClasses = ["req-norole", "req-person", "req-delivery", "req-admin"];
    let roles = {
        NoRole: ["req-norole"],
        Person: ["req-person", "req-norole"],
        DeliveryMan: ["req-delivery"],
        Administrator: ["req-admin", "req-delivery"]
    };

    if (authData == null) {
        // User is not logged in

        // Redirect to index if current page requires login
        if ($(".content").hasClass("req-login")) {
            location.href = "/home";
        }

        roleClasses.forEach(roleClass => {
            if ($(".content").hasClass(roleClass)) {
                location.href = "/home";
            }
            $("." + roleClass).remove();
        });
        $(".req-logout").removeClass("req-logout");
        $(".req-login").remove();

    } else {
        // User is logged in
        if (authData.roles.length == 0) authData.roles.push("NoRole");

        // Create list of restricted-access components to keep
        let allowedItemClasses = authData.roles.flatMap(role => roles[role]);
        let deniedItemClasses = roleClasses.filter(e => !allowedItemClasses.includes(e));
        console.log(allowedItemClasses);
        console.log(deniedItemClasses);

        // Redirect to homepage if access to the current page is denied
        $(".content").classes().forEach(itemClass => {
            if (itemClass.includes("req-") && deniedItemClasses.includes(itemClass)) {
                location.href = "/home";
            }
        });

        // Show allowed components, remove denied components
        allowedItemClasses.forEach(itemClass => $("." + itemClass).removeClass(itemClass));
        deniedItemClasses.forEach(itemClass => $("." + itemClass).remove());
        $(".req-login").removeClass("req-login");
        $(".req-logout").remove();

        /*if (!authData.roles.includes("Administrator")) {
            // Redirect to index if current page requires missing admin rights
            if ($(".content").hasClass("req-admin")) {
                window.location.href = "/home";
            }
            $(".req-admin").remove();
        }*/

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
        .catch(function(jqXHR) { ErrorModal.show(jqXHR); });

        APIUtils.updateCartBadge()
        .catch(function(jqXHR) { ErrorModal.show(jqXHR); });

    }

    $(document).on("click", ".btn-logout", function() {
        API.logout();
        location.reload();
    });
});
