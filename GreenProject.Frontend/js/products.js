/*$(document).ready(function() {

    for (var i = 0; i < 24; i++) {
        var productCard = new ProductCard();
        $("<div class='" + $("#results-col").data("children-class") + "'>").html(productCard.html).appendTo("#results-col .row");
    }

});*/

$(document).ready(function() {

    // Filter toggle click handling
    $("#products-content").on("click", ".toggle-filters", function() {
        if ($("#filters-col").hasClass("d-none")) {
            // Show filters
            $("#filters-col").removeClass("d-none");
            $("#results-col").addClass("col-lg-9");
            $(".product-card:not([data-class])").parent().removeClass("col-lg-3");
        } else {
            // Hide filters
            $("#filters-col").addClass("d-none");
            $("#results-col").removeClass("col-lg-9");
            $(".product-card:not([data-class])").parent().addClass("col-lg-3");
        }
    });

});
