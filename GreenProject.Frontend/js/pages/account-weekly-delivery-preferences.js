var weeklyCrates = [];
var weeklyExtras = [];

$(document).ready(function() {

    // Get orders
    $("#modal-loading").showModal();
    API.getWeeklyOrder(localStorage.getObject("authData").userId)
    .then(function(data) {

        if (data.crates.length == 0 && data.extraProducts.length == 0) {
            // TODO handle no products in weekly order
        } else {

            data.deliveryInfo.address = new Address(data.deliveryInfo.address);

            console.log(data);

            // Setup summary
            $(".crate-count").html(data.crates.length);
            $(".product-count").html(data.extraProducts.length);
            $(".delivery-date").html(Utils.formatDate(data.deliveryInfo.deliveryDate));
            $(".delivery-address").html(data.deliveryInfo.address.addressString);

            // Set prices
            $(".subtotal").html(Utils.formatCurrency(data.prices.subtotal));
            $(".iva").html(Utils.formatCurrency(data.prices.iva));
            $(".shipping").html(Utils.formatCurrency(data.prices.shippingCost));
            $(".total").html(Utils.formatCurrency(data.prices.total));

            // Create crates and products
            data.crates.forEach(json => {
                let weeklyCrate = new WeeklyCrate(json);
                weeklyCrates.push(weeklyCrate);
                weeklyCrate.html.main.appendTo(".weekly-crates");
            });
            data.extraProducts.forEach(json => {

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
