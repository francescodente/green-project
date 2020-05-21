var weeklyCrates = [];
var weeklyExtras = [];
var deliveryInfo;
var addresses;
var starredProducts = [];

// Get weekly order
if (!localStorage.getObject("userData").isSubscribed) {
    $("#user-weekly-delivery").addClass("d-none");
    $(".weekly-delivery-not-subscribed").removeClass("d-none");
} else {

    $("#modal-loading").showModal();
    API.getWeeklyOrder(localStorage.getObject("authData").userId)
    .then(function(data) {

        if (data.crates.length == 0 && data.extraProducts.length == 0) {
            // TODO handle no products in weekly order
        } else {

            data.deliveryInfo.address = new Address(data.deliveryInfo.address);
            deliveryInfo = data.deliveryInfo;
            console.log(data);

            // Setup summary
            $(".crate-count").html(data.crates.length + " cassette");
            if (data.extraProducts.length) {
                $(".extra-products-text").removeClass("d-none");
                $(".product-count").html(data.extraProducts.length);
                if (data.extraProducts.length == 1) {
                    $(".extra-product-count-text").html("prodotto extra");
                }
            }
            $(".product-count").html(data.extraProducts.length);
            $(".delivery-date").html(Utils.formatDate(deliveryInfo.deliveryDate));
            $(".delivery-address").html(deliveryInfo.address.addressString);

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
            for (let i = data.extraProducts.length - 1; i >= 0; i--) {
                let extraProduct = new Product(data.extraProducts[i], data.extraProducts[i].quantity);
                weeklyExtras.push(extraProduct);
                extraProduct.html.extraEntry.prependTo(".weekly-extras>tbody");
            }

            prepareAddresses();
            $("#notes").val(deliveryInfo.notes);

            // Show weekly delivery items from order-preferences.php
            $(".req-weekly-delivery").removeClass("d-none");
        }
    })
    .catch(function(jqXHR) {
        console.log(jqXHR);
        new ErrorModal(jqXHR).show();
    })
    .finally(function(data) { $("#modal-loading").fadeModal() });

    // Get starred products
    $("#starred-products-loader").show();
    $(".starred-products").hide();
    API.getProducts(null, 0, 30, true)
    .then(function(data) {
        if (data.results.length == 0) {

        } else {
            // Create product objects
            data.results.forEach(json => {
                let product = new Product(json);
                starredProducts.push(product);
                product.html.starredEntry.appendTo(".starred-products tbody");
            });
        }
    })
    .catch(function(jqXHR) {
        console.log(jqXHR);
        new ErrorModal(jqXHR).show();
    })
    .finally(function(data) {
        $("#starred-products-loader").hide();
        $(".starred-products").show();
    });

    async function prepareAddresses() {
        addresses = await addressesPromise;
        // Uncheck default address, add listeners
        addresses.forEach(address => {
            address.html.button.removeClass("default");
            address.html.setWeeklyModal.find(".weekly-set").click(function() {
                saveAddress(address, false);
            });
            address.html.setWeeklyModal.find(".weekly-set-default").click(function() {
                saveAddress(address, true);
            });
        });
        // Remove selected address from address list
        addresses.filter(address => address.addressId == deliveryInfo.address.addressId)[0]
                 .html.button.remove();
        // Properly add back selected address
        deliveryInfo.address.html.button.addClass("default");
        deliveryInfo.address.html.button.prependTo(".address-list");
    }

    // Enable save button when notes field changes
    $("body").on("change paste keyup", "#notes", function() {
        $("#save-notes").prop("disabled", false);
    });

    // Save notes
    $("#save-notes").click(function() {
        console.log("save notes");
        $("#modal-loading").showModal();
        APIUtils.setWeeklyDeliveryInfo(deliveryInfo.address.addressId, $("#notes").val())
        .then(function(data) { location.reload() })
        .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
    });

    // Save address (also optionally make it default)
    function saveAddress(address, setDefault) {
        $("#modal-loading").showModal();
        let promises = [];
        promises.push(APIUtils.setWeeklyDeliveryInfo(address.addressId, $("#notes").val()));
        if (setDefault) {
            promises.push(API.setDefaultAddress(localStorage.getObject("authData").userId, address.addressId));
        }
        Promise.all(promises)
        .then(function(data) { location.reload() })
        .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
    }

    // Skip weekly delivery
    $(".skip-delivery").click(function() {
        $("#modal-loading").showModal();
        API.skipWeeklyOrder(localStorage.getObject("authData").userId)
        .then(function(data) { location.reload() })
        .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
    });

    // Delete subscription
    $(".delete-subscription").click(function() {
        $("#modal-loading").showModal();
        API.unsubscribe(localStorage.getObject("authData").userId)
        .then(function(data) {
            localStorage.setObjectProperty("userData", "isSubscribed", false);
            location.reload()
        })
        .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
    });

}
