const PAGE_SIZE = 8;

var orders = [];

$(document).ready(function() {

    // Get orders
    $("#modal-loading").showModal();
    let pageNumber = location.searchParams.get("PageNumber");
    if (pageNumber == null) pageNumber = 0;
    API.getCustomerOrders(localStorage.getObject("authData").userId, pageNumber, PAGE_SIZE)
    .then(function(data) {
        if (data.results.length == 0) {
            $(".orders-no-results").removeClass("d-none");
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
    .catch(function(jqXHR) {
        if (jqXHR.status == 403) {
            $(".orders-no-results").removeClass("d-none");
            $("#orders-pagination").fillPagination(0, 0);
        } else {
            $(".orders-error").removeClass("d-none");
        }
    })
    .finally(function(data) { $("#modal-loading").fadeModal() });

});
