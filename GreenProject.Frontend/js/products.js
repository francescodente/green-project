var products = [];

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

    // Get products
    $("#products-loader").show();
    getProducts([])
    .done(function(data) {
        console.log(data);
        data.results.forEach((product) => {
            products.push(ProductCard(product));
        });
        fillBootstrapRow($(".product-list"), products);
        $(".products-count").text(products.length);

        products[0].addToCart();
    })
    .fail(function(data) {
        // TODO
    })
    .always(function(data) {
        $("#products-loader").hide();
    });

});
