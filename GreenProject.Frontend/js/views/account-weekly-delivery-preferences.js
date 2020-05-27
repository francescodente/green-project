var weeklyCrates = [];
var weeklyExtras = [];
var deliveryInfo;
var addresses;
var starredProducts = [];

// Get weekly order
let userData = localStorage.getObject("userData");
if (!userData.isSubscribed && !userData.isLocallySubscribed) {
    $(".user-weekly-delivery").addClass("d-none");
    $(".weekly-delivery-not-subscribed").removeClass("d-none");
} else {

    $("#modal-loading").showModal();

    APIUtils.getWeeklyOrder(localStorage.getObject("authData").userId)
    .then(function(data) {

        if (data.crates.length == 0) {
            $(".no-weekly-crates").show();
        }

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

        if (userData.isSubscribed) {
            $("#locally-subscribed-alert").remove();
            $(".confirm-subscription").remove();

            // Setup delivery info
            data.deliveryInfo.address = new Address(data.deliveryInfo.address);
            deliveryInfo = data.deliveryInfo;
            $(".delivery-date").html(Utils.formatDate(deliveryInfo.deliveryDate));
            $(".delivery-address").html(deliveryInfo.address.addressString);
            prepareAddresses();
            $("#notes").val(deliveryInfo.notes);
        }
        if (userData.isLocallySubscribed) {
            $("#subscribed-alert").remove();
            $("#subscription-options").remove();
            $("#save-notes").remove();
        }

        // Show weekly delivery items from order-preferences.php
        $(".req-weekly-delivery").removeClass("d-none");

        $("#modal-loading").fadeModal();
    })
    .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });

    // Get starred products
    $("#starred-products-loader").show();
    $(".starred-products").hide();
    API.getProducts(null, 0, 30, true)
    .then(function(data) {
        if (data.results.length == 0) {
            $(".starred-products").hide();
            $(".starred-products-no-results").removeClass("d-none");
        } else {
            // Create product objects
            let weeklyExtraIds = weeklyExtras.map(weeklyExtra => weeklyExtra.productId);
            data.results.forEach(json => {
                let product = new Product(json);
                if(!weeklyExtraIds.includes(product.productId)) {
                    starredProducts.push(product);
                    product.html.starredEntry.appendTo(".starred-products tbody");
                }
            });
            if (starredProducts.length == 0) {
                $(".starred-products").addClass("d-none");
                $(".starred-products-no-results").removeClass("d-none");
            }
        }
    })
    .catch(function(jqXHR) {
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

    // Subscription creation
    $(".confirm-subscription").click(function(event) {
        console.log("confirm-subscription");
        // Check that the order contains at least one crate
        if (weeklyCrates.length == 0) {
            $("#missing-crate-modal").showModal();
            return;
        }
        // Warn the user if some crates have available slots
        if (!$(event.target).hasClass("skip-full-crate-check")) {
            for (let weeklyCrate of weeklyCrates) {
                if (weeklyCrate.crateDescription.occupiedSlots < weeklyCrate.crateDescription.capacity) {
                    $("#non-full-crate-modal").showModal();
                    return;
                }
            }
        }
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

    $(".submit-order").click(function() {
        console.log("submit-order");
        $("#modal-loading").showModal();
        APIUtils.subscribe(selectedAddress.addressId, $("#notes").val())
        .then(function(data) {
            $("#subscription-successful-modal").showModal();
        })
        .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
    });

}
