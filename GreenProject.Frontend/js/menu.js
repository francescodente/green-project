function toggleMenu(open) {
    if (open) {
        $(".menu").addClass("open");
        $("body").addClass("menu-no-scroll");
    } else {
        $(".menu").removeClass("open");
        $("body").removeClass("menu-no-scroll");
    }
}

$(document).ready(function() {

    // Menu toggle click handling
    $(document).on("click", ".menu-toggle", function () {
        toggleMenu(!$(".menu").hasClass("open"))
    });

    // Menu shade click handling
    $(document).on("click", ".menu-shade", function () {
        toggleMenu(false);
    });

    /*****************\
    |   MENU SCROLL   |
    \*****************/

    function checkMenuScroll() {
        if($(this).scrollTop() > 0) {
            $(".top-bar:not(.scroll)").addClass("scroll");
            $(".top-bar-center>.menu-item, .top-bar .btn.icon").removeClass("light");
        } else {
            $(".top-bar.scroll").removeClass("scroll");
            $(".top-bar-center>.menu-item, .top-bar .btn.icon").addClass("light");
        }
    }
    $(window).scroll(function() {
        checkMenuScroll();
    });
    setTimeout(checkMenuScroll, 200);

    /*************\
    |   SUBMENU   |
    \*************/

    function openSubMenu(submenuToggle, submenuItem) {
        // Compute position and apply CSS
        var offsetX = submenuToggle[0].getBoundingClientRect().x;
        var offsetY = submenuToggle[0].getBoundingClientRect().y;
        if (submenuItem.outerWidth() > submenuToggle.outerWidth()) {
            var x = offsetX + (submenuToggle.outerWidth() - submenuItem.outerWidth()) / 2;
        } else {
            var x = offsetX;
        }
        var y = offsetY + submenuToggle.outerHeight();
        submenuItem.css({ "top": y, "left": x, "min-width": submenuToggle.outerWidth() });
        // Add classes
        submenuToggle.addClass("expanded");
        submenuItem.addClass("active");
    }

    // Close all submenus if called with no parameters
    function closeSubMenu(submenuToggle = $(".menu-item"), submenuItem = $(".submenu")) {
        submenuToggle.removeClass("expanded");
        submenuItem.removeClass("active");
    }

    $(window).on("click scroll resize", function() {
        if (["lg", "xl"].includes(getViewportSize())) {
            closeSubMenu();
        }
    });

    $(document).on("click", "[data-toggle='submenu']", function(event) {
        event.stopPropagation();
        if ($(this).hasClass("expanded")) {
            // If submenu is open, close it
            closeSubMenu($(this), $($(this).data("target")));
        } else {
            // If desktop mode is on, cose other submenus
            if (["lg", "xl"].includes(getViewportSize())) {
                closeSubMenu();
            }
            // Open submenu
            openSubMenu($(this), $($(this).data("target")));
        }
    });
});