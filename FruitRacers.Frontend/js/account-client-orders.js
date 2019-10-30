function checkCollapse() {
    if ($(window).width() >= 992) {
        $("#client-orders .collapse").addClass("uncollapse");
        $("#client-orders .collapse").removeClass("collapse");
    } else {
        $("#client-orders .uncollapse").addClass("collapse");
        $("#client-orders .uncollapse").removeClass("uncollapse");
    }
}

$(document).ready(function() {

    $(window).resize(function() {
        checkCollapse();
    });

    checkCollapse();

});