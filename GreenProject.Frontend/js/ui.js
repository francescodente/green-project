function getViewportSize() {
    return $('#sizer').find('div:visible').data('size');
}

function scrollToItem(id) {
    $("html, body").animate({ scrollTop: $(id).offset().top }, 600);
}

$(document).ready(function() {

    // Back to top button click handling
    $(document).on("click", "#go-top-btn", function (event) {
        $("html, body").animate({ scrollTop: 0 }, 600);
    });

    /************\
    |   MODALS   |
    \************/

    // Lock scrolling when a modal is shown
    $(".modal:not(.toast)").on("show.bs.modal", function() {
        $("body").addClass("modal-no-scroll");
    });
    $(".modal:not(.toast)").on("hide.bs.modal", function() {
        $("body").removeClass("modal-no-scroll");
    });

    /************\
    |   TOASTS   |
    \************/

    var currentToast = null;
    var currentToastTimeoutId = 0;

    function dismissToast() {
        if (currentToastTimeoutId != 0) {
            clearTimeout(currentToastTimeoutId);
            currentToastTimeoutId = 0;
        }
        if (currentToast != null) {
            currentToast.fadeOut();
            currentToast = null;
        }
    }

    $(document).on("click", "[data-toggle='toast']", function() {
        // Hide other toast if present
        if (currentToast != null) {
            dismissToast();
        }
        // Show toast
        var target = $($(this).data("target"));
        target.fadeIn();
        currentToast = target;
        if (!target.hasClass("indefinite")) {
            currentToastTimeoutId = setTimeout(function() { dismissToast() }, 8000);
        }
    });

    $(document).on("click", "[data-dismiss='toast']", function() { dismissToast() });

});
