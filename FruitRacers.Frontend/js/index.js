function scrollToItem(id) {
    $("html, body").animate({ scrollTop: $(id).offset().top }, 600);
}

function highlightMenuItem() {
    var position = $(this).scrollTop();
    $("section").each(function() {
        var targetTop = $(this).offset().top;
        var section = $(this).attr("data-section");
        // Highlights menu item 64px before its content reaches the top of the page
        if (position >= targetTop - 64) {
            $(".menu-item, #dropdown-menu a").removeClass("selected");
            $(".menu-item, #dropdown-menu a").each(function() {
                if ($(this).data("sections").includes(section)) {
                    $(this).addClass("selected");
                    return;
                }
            });
            return;
        }
    });
}

function checkMenuOpacity() {
    if($(this).scrollTop() > 56) {
        $("#menu:not(.filled)").addClass("filled");
    } else {
        $("#menu.filled").removeClass("filled");
    }
}

function toggleMenu(open) {
    if (open) {
        $("#menu-middle").addClass("open");
        $("body").addClass("menu-no-scroll");
    } else {
        $("#menu-middle").removeClass("open");
        $("body").removeClass("menu-no-scroll");
    }
}

// Init parallax fx
new universalParallax().init({
    speed: 4
});

$(document).ready(function() {

    // Menu toggle click handling
    $("#menu").on("click", "#menu-toggle", function () {
        toggleMenu(!$("#menu-middle").hasClass("open"))
    });

    // Menu shade click handling
    $("#menu").on("click", "#menu-shade", function () {
        toggleMenu(false);
    });

    // Menu item click handling
    $("#menu").on("click", ".menu-item", function (event) {
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
        checkMenuOpacity()
    });

    // Lock scrolling when a modal is shown
    $(".modal").on("show.bs.modal", function() {
        $("body").addClass("modal-no-scroll");
    });
    $(".modal").on("hide.bs.modal", function() {
        $("body").removeClass("modal-no-scroll");
    });

    setTimeout(highlightMenuItem, 200);
    setTimeout(checkMenuOpacity, 200);

});
