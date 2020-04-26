const PAGE_SIZE = 8;

var orders = [];

$(document).ready(function() {

    // Get orders
    showModal($("#modal-loading"));
    let url = new URL(window.location.href);
    let pageNumber = url.searchParams.get("PageNumber");
    if (pageNumber == null) pageNumber = 0;
    getCustomerOrders(localStorage.getObject("authData").userId, pageNumber, PAGE_SIZE)
    .done(function(data) {
        console.log(data);
        if (data.results.length == 0) {
            $(".search-no-results").removeClass("d-none");
        } else {
            // Create product objects
            data.results.forEach((json) => {
                let order = new Order(json)
                orders.push(order);
                $(".order-list").append(order.html.main);
            });
        }
        // Handle pagination
        fillPagination($("#orders-pagination"), data.pageNumber, data.pageCount);
    })
    .fail(function(jqXHR) {
        console.log(jqXHR);
        $(".orders-error").removeClass("d-none");
    })
    .always(function(data) { fadeOutModal($("#modal-loading")) });

});