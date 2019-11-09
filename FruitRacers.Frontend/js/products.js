$(document).ready(function() {

    for (var i = 0; i < 24; i++) {
        var productCard = new ProductCard();
        $("<div class='" + $("#results-col").data("children-class") + "'>").html(productCard.html).appendTo("#results-col .row");
    }

});