var crates = [];
var products = [];

$(document).ready(function() {

    // Get orders
    $("#modal-loading").showModal();
    API.getWeeklyOrder(localStorage.getObject("authData").userId)
    .then(function(data) {
        console.log(data);

        if (data.crates.length == 0 && data.extraProducts.length == 0) {
            // TODO handle no products in weekly order
        } else {

            // Setup summary
            $(".crate-count").html(data.crates.length);
            $(".product-count").html(data.extraProducts.length);
            $(".delivery-date").html("data");
            $(".delivery-address").html("indirizzo");

            // Set prices
            $(".subtotal").html(Utils.formatCurrency(data.prices.subtotal));
            $(".iva").html(Utils.formatCurrency(data.prices.iva));
            $(".shipping").html(Utils.formatCurrency(data.prices.shippingCost));
            $(".total").html(Utils.formatCurrency(data.prices.total));

            // Create crates and products
            data.crates.forEach(json => {
                let crate = new Crate(json.crateDescription);
                crates.push(crate);
                crate.html.weeklyEntry.appendTo(".crate-test");
            });

            // TODO select address and add notes

        }

        /*if (data.results.length == 0) {
            $(".search-no-results").removeClass("d-none");
        } else {
            // Create product objects
            data.results.forEach((json) => {
                let order = new Order(json)
                orders.push(order);
                $(".order-list").append(order.html.main);
            });
        }*/
    })
    .catch(function(jqXHR) {
        console.log(jqXHR);
        //$(".orders-error").removeClass("d-none");
    })
    .finally(function(data) { $("#modal-loading").fadeModal() });

});
