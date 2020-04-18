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
    showModal($("#modal-loading"));
    let url = new URL(window.location.href);
    let categories = url.searchParams.getAll("Categories");
    let isCrate = categories[0] == 1;
    getProducts(categories)
    .done(function(data) {
        if (data.results.length == 0) {
            $(".search-no-results").removeClass("d-none");
        } else {
            // Create product objects
            data.results.forEach((json) => {
                if (isCrate) {
                    products.push(new Crate(json));
                } else {
                    products.push(new Product(json));
                }
            });
            fillBootstrapRow($(".product-list"), products);
            $(".products-count").text(products.length);
        }
        // Handle pagination
        fillPagination($("#products-pagination"), data.pageNumber, data.pageCount);
    })
    .fail(function(data) {
        $(".search-error").removeClass("d-none");
    })
    .always(function(data) {
        fadeOutModal($("#modal-loading"));
    });

});
