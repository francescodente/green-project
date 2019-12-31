function getViewportSize() {
    return $('#sizer').find('div:visible').data('size');
}

function scrollToItem(id) {
    $("html, body").animate({ scrollTop: $(id).offset().top }, 600);
}

function highlightMenuItem() {
    if ($("[data-section]").length) {
        // Need to check scroll
        var position = $(this).scrollTop();
        $("section").each(function() {
            var targetTop = $(this).offset().top;
            var section = $(this).attr("data-section");
            // Highlights menu item 64px before its content reaches the top of the page
            if (position >= targetTop - 64) {
                $(".menu-item").removeClass("selected");
                $(".menu-item[href*='" + section + "']").addClass("selected");
            }
        });
    } else {
        // Can highlight menu item based on current window
        var url = location.href;
        var currentPage = url.substring(url.lastIndexOf('/') + 1).split("#")[0];
        $(".menu-item").removeClass("selected");
        $(".menu-item[href*='" + currentPage + "']").addClass("selected");
    }
}

function checkMenuScroll() {
    if($(this).scrollTop() > 0) {
        $(".top-bar:not(.scroll)").addClass("scroll");
        $(".top-bar .menu-item, .top-bar .btn.icon").removeClass("light");
    } else {
        $(".top-bar.scroll").removeClass("scroll");
        $(".top-bar .menu-item, .top-bar .btn.icon").addClass("light");
    }
}

function toggleMenu(open) {
    if (open) {
        $(".menu").addClass("open");
        $("body").addClass("menu-no-scroll");
    } else {
        $(".menu").removeClass("open");
        $("body").removeClass("menu-no-scroll");
    }
}

function switchModal(currentModal, nextModal) {
    $(currentModal).modal("hide");
    $(nextModal).modal("show");
}

// Init parallax fx
new universalParallax().init({
    speed: 4
});

$(document).ready(function() {

    // Menu toggle click handling
    $("body").on("click", ".menu-toggle", function () {
        toggleMenu(!$(".menu").hasClass("open"))
    });

    // Menu shade click handling
    $("body").on("click", ".menu-shade", function () {
        toggleMenu(false);
    });

    // Menu item click handling
    $("body").on("click", ".menu-item:not([data-toggle])", function (event) {
        var url = location.href;
        var currentPage = url.substring(url.lastIndexOf('/') + 1).split("#")[0];
        var href = $(this).attr("href").split("#");
        var targetPage = href[0];
        var hash = href[1];
        if (currentPage == targetPage && hash != null) {
            event.preventDefault();
            toggleMenu(false);
            scrollToItem("#" + hash);
        }
    });

    // Back to top button click handling
    $(document).on("click", "#go-top-btn", function (event) {
        $("html, body").animate({ scrollTop: 0 }, 600);
    });

    // Window scroll management
    $(window).scroll(function() {

        // Highlight current menu item
        highlightMenuItem();

        // Remove menu transparency
        checkMenuScroll()
    });

    setTimeout(highlightMenuItem, 100);
    setTimeout(checkMenuScroll, 100);

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

    // Handle modal switching
    $(document).on("click", "[data-switch-to]", function() {
        event.preventDefault();
        switchModal($(this).closest(".modal"), $(this).data("switch-to"));
    });

    /************\
    |   TOASTS   |
    \************/

    var toastTimeoutId;

    $(document).on("click", "[data-toggle='toast']", function() {
        var target = $($(this).data("target"));
        target.fadeIn();
        if (!target.hasClass("indefinite")) {
            toastTimeoutId = setTimeout(function() {
                target.fadeOut();
            }, 8000)
        }
    });

    $(document).on("click", "[data-dismiss='toast']", function() {
        var target = $(this).closest(".toast");
        clearTimeout(toastTimeoutId);
        target.fadeOut();
    });

});
