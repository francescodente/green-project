function scrollToItem(id) {
	$("html, body").animate({ scrollTop: $(id).offset().top }, 600);
}

function highlightMenuItem() {
	var position = $(this).scrollTop();
	$("section").each(function() {
        var targetTop = $(this).offset().top;
        var id = $(this).attr("data-section");
        // Highlights menu item 100px before it reaches the top of the page
        if (position >= targetTop - 64) {
            $(".menu-item").removeClass("selected");
			$(".menu-item[href='#" + id  + "']").addClass("selected");
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
        } else {
            $("#menu-middle").addClass("open");
        }
    });

    // Menu shade click handling
    $("#menu-shade").click(function () {
        $("#menu-middle").removeClass("open");
    });

	// Menu item click handling
	$(".menu-item").click(function (event) {
        if ($(this).attr("href").charAt(0) == "#") {
            event.preventDefault();
            $("#menu-middle").removeClass("open");
            scrollToItem($(this).attr("href"));
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
