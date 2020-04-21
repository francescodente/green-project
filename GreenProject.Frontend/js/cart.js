var products = [];

$(document).ready(function() {

    // Uncollapse addresses section
    $('.area-collapse[data-target="#order-delivery-address"]').click();

    // Get cart content
    showModal($("#modal-loading"));
    getCart(localStorage.getObject("userData").userId)
    .done(function(data) {
        if (data.cartItems.length == 0) {
            $(".cart-empty").removeClass("d-none");
            $(".cart-not-empty").addClass("d-none");
        } else {
            // Create product objects
            data.cartItems.forEach((json) => {
                let product = new Product(json.product, json.quantity);
                products.push(product);
                $("#cart-products>table>tbody").append(product.html.cartEntry);
                // Add product to cart summary
                let productSummary = $(".summary-products>.product-summary.d-none")
                    .clone().removeClass("d-none");
                productSummary.find(".product-name").html(product.name);
                productSummary.find(".product-price").html(product.formattedPrice);
                productSummary.appendTo(".summary-products");
            });
            // Fill summary
            $(".subtotal").html(formatCurrency(data.prices.subtotal));
            $(".iva").html(formatCurrency(data.prices.iva));
            $(".shipping").html(formatCurrency(data.prices.shippingCost));
            $(".total").html(formatCurrency(data.prices.total));
        }
    })
    .fail(function(jqXHR) { new ErrorModal(jqXHR).show(); })
    .always(function(data) { fadeOutModal($("#modal-loading")); });

});
