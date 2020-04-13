$(document).ready(function() {
    if (sessionStorage.getItem("token") === null) {
        // User is not logged in
        console.log("not logged in");
        $(".req-login").remove();
    } else {
        // User is logged in
        console.log("logged in");
        $(".req-logout").remove();
    }

    $(document).on("click", ".btn-logout", function() {
        logout();
        location.reload();
    });
});