function checkCollapse() {
    if ($(window).width() >= 992) {
        $(".collapse").addClass("uncollapse");
        $(".collapse").removeClass("collapse");
    } else {
        $(".uncollapse").addClass("collapse");
        $(".uncollapse").removeClass("uncollapse");
    }
}

$(document).ready(function() {

    $(window).resize(function() {
        checkCollapse();
    });

    checkCollapse();

});