var products = [];
var selectedAddress;

$(document).ready(function() {

    // Uncollapse sections
    $('.area-collapse[data-target="#order-payment-method"]').click();
    $('.area-collapse[data-target="#order-delivery-address"]').click();
    $('.area-collapse[data-target="#order-notes"]').click();

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

    // Cart confirm
    $(".confirm-cart").click(function() {
        // Check if and address is selected
        selectedAddress = $("[name='delivery-address']:checked");
        if (!selectedAddress.length) {
            new InfoModal("Seleziona un indirizzo di consegna per procedere con la creazione dell'ordine").show();
            return;
        }
        selectedAddress = addresses.filter(address => address.addressId == selectedAddress.val())[0];
        let zipCode = selectedAddress.zipCode;
        // Get expected delivery date
        showModal($("#modal-loading"));
        getZoneSchedule(zipCode)
        .done(function(data) {
            $("#expected-date-modal .expected-date").html(formatDate(data));
            showModal($("#expected-date-modal"));
        })
        .fail(function(jqXHR) { new ErrorModal(jqXHR).show() });
    });

    // Cart submission
    $(".submit-cart").click(function() {
        showModal($("#modal-loading"));
        confirmCart(localStorage.getObject("userData").userId, {
            addressId: selectedAddress.addressId,
            notes: $("#notes").val()
        })
        .done(function(data) {
            $(".cart-not-empty").addClass("d-none");
            $(".cart-empty").removeClass("d-none");
            showModal($("#order-placed-modal"));
        })
        .fail(function(jqXHR) { new ErrorModal(jqXHR).show() });
    });

});
