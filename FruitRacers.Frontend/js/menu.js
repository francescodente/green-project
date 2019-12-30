$(document).ready(function() {

    /**************\
    |   SUBMENUS   |
    \**************/

    // Close submenu
    $(window).on("click scroll resize", function() {
        if (["lg", "xl"].includes(getViewportSize())) {
            $(".submenu").removeClass("active");
            $(".menu-item").removeClass("expanded");
        }
    });

    // Open submenu
    $("body").on("click", "[data-toggle='submenu']", function(event) {
        event.stopPropagation();
        var target = $($(this).data("target"));
        var offsetX = $(this)[0].getBoundingClientRect().x;
        var offsetY = $(this)[0].getBoundingClientRect().y;
        if (target.outerWidth() > $(this).outerWidth()) {
            var x = offsetX + ($(this).outerWidth() - target.outerWidth()) / 2;
        } else {
            var x = offsetX;
        }
        var y = offsetY + $(this).outerHeight();
        target.css({ "top": y, "left": x, "min-width": $(this).outerWidth() });
        target.toggleClass("active");
        $(this).toggleClass("expanded");
    });

    // Stop submenu events propagation
    $("body").on("click", ".submenu", function(event) {
        event.stopPropagation();
    });

});