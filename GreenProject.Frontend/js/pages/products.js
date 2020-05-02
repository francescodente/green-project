const PAGE_SIZE = 24;

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
    $("#modal-loading").showModal();
    let url = new URL(window.location.href);
    let pageNumber = url.searchParams.get("PageNumber");
    if (pageNumber == null) pageNumber = 0;
    let categories = url.searchParams.getAll("Categories");
    let isCrate = categories[0] == 1;
    API.getProducts(categories, pageNumber, PAGE_SIZE)
    .then(function(data) {
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
            $(".product-list").fillRow(products.map(product => product.html.main));
            $(".products-count").text(products.length);
        }
        // Handle pagination
        $("#products-pagination").fillPagination(data.pageNumber, data.pageCount);
    })
    .catch(function(jqXHR) {
        $(".search-error").removeClass("d-none");
    })
    .finally(function(data) { $("#modal-loading").fadeModal() });

});
