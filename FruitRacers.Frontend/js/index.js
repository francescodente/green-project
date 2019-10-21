function scrollToItem(id) {
	$("html, body").animate({ scrollTop: $(id).offset().top }, 600);
}

function highlightMenuItem() {
	var position = $(this).scrollTop();
	$("section").each(function() {
        var targetTop = $(this).offset().top;
        var section = $(this).attr("data-section");
        // Highlights menu item 64px before it reaches the top of the page
        if (position >= targetTop - 64) {
            $(".menu-item").removeClass("selected");
            $(".menu-item").each(function() {
                if ($(this).data("sections").includes(section)) {
                    $(this).addClass("selected");
                    return;
                }
            });
            return;
        }
    });
}

new universalParallax().init({
	speed: 4
});

$(document).ready(function() {

    // Menu toggle click handling
    $("#menu-toggle").click(function () {
        if ($("#menu-middle").hasClass("open")) {
            $("#menu-middle").removeClass("open");
            $("body").removeClass("no-scroll");
        } else {
            $("#menu-middle").addClass("open");
            $("body").addClass("no-scroll");
        }
    });

    // Menu shade click handling
    $("#menu-shade").click(function () {
        $("#menu-middle").removeClass("open");
        $("body").removeClass("no-scroll");
    });

	// Menu item click handling
	$(".menu-item").click(function (event) {
        var url = location.href;
        var currentPage = url.substring(url.lastIndexOf('/') + 1).split("#")[0];
        var href = $(this).attr("href").split("#");
        var targetPage = href[0];
        var hash = href[1];
        if (currentPage == targetPage && hash != null) {
            event.preventDefault();
            $("#menu-middle").removeClass("open");
            scrollToItem("#" + hash);
        }
	});

    // Back to top button click handling
    $("#go-top-btn").click(function (event) {
        $("html, body").animate({ scrollTop: 0 }, 600);
    });

	$(window).scroll(function() {

		// Highlight current menu item
	    highlightMenuItem();

	    // Remove menu transparency
	    if($(this).scrollTop() > 56) {
	    	$("#menu:not(.filled)").addClass("filled");
	    } else {
	    	$("#menu.filled").removeClass("filled");
	    }
	});

    setTimeout(highlightMenuItem, 200);

});
