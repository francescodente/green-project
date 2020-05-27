var products = [];
var selectedAddress;

// Uncollapse sections
$('.area-collapse[data-target="#order-payment-method"]').click();
$('.area-collapse[data-target="#order-delivery-address"]').click();
$('.area-collapse[data-target="#order-notes"]').click();

// Get cart content
$("#modal-loading").showModal();
API.getCart(localStorage.getObject("authData").userId)
.then(function(data) {
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
        $(".subtotal").html(Utils.formatCurrency(data.prices.subtotal));
        $(".iva").html(Utils.formatCurrency(data.prices.iva));
        $(".shipping").html(Utils.formatCurrency(data.prices.shippingCost));
        $(".total").html(Utils.formatCurrency(data.prices.total));
    }
})
.catch(function(jqXHR) { new ErrorModal(jqXHR).show() })
.finally(function(data) { $("#modal-loading").fadeModal() });

// Cart confirm
$(".confirm-cart").click(function() {
    // Check if and address is selected
    selectedAddress = $("[name='delivery-address']:checked");
    if (!selectedAddress.length) {
        $("#missing-address-modal").showModal();
        return;
    }
    if (!localStorage.getObject("authData").roles.includes("Person")) {
        $("#missing-role-modal").showModal();
        return;
    }
    selectedAddress = addresses.filter(address => address.addressId == selectedAddress.val())[0];
    let zipCode = selectedAddress.zipCode;
    // Get expected delivery date
    $("#modal-loading").showModal();
    API.getZoneSchedule(zipCode)
    .then(function(data) {
        $("#expected-date-modal .expected-date").html(Utils.formatDate(data));
        $("#expected-date-modal .delivery-address").html(selectedAddress.addressString);
        $("#expected-date-modal .notes").html($("#notes").val() == "" ? "-" : $("#notes").val());
        $("#expected-date-modal").showModal();
    })
    .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
});

// Cart submission
$(".submit-order").click(function() {
    $("#modal-loading").showModal();
    API.confirmCart(localStorage.getObject("authData").userId, {
        addressId: selectedAddress.addressId,
        notes: $("#notes").val()
    })
    .then(function(data) {
        $(".cart-not-empty").addClass("d-none");
        $(".cart-empty").removeClass("d-none");
        $("#order-placed-modal").showModal();
    })
    .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
});
