const PAGE_SIZE = 2;

var orders = [];

$(document).ready(function() {

    // Get orders
    $("#modal-loading").showModal();
    let url = new URL(window.location.href);
    let pageNumber = url.searchParams.get("PageNumber");
    if (pageNumber == null) pageNumber = 0;
    API.getCustomerOrders(localStorage.getObject("authData").userId, pageNumber, PAGE_SIZE)
    .done(function(data) {
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
        $("#orders-pagination").fillPagination(data.pageNumber, data.pageCount);
    })
    .fail(function(jqXHR) {
        $(".orders-error").removeClass("d-none");
    })
    .always(function(data) { $("#modal-loading").fadeModal() });

});
