// Init parallax fx
new universalParallax().init({
    speed: 4
});

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

$(document).ready(function() {

    // Menu item click handling
    $(document).on("click", ".menu-item:not([data-toggle])", function (event) {
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

    // Window scroll management
    $(window).scroll(function() {

        // Highlight current menu item
        highlightMenuItem();

    });

    setTimeout(highlightMenuItem, 100);

});
