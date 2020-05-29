var addresses = [];
var deferreds = [];
var addressesPromise = new Promise(function(resolve, reject){
    deferreds.push({resolve: resolve, reject: reject});
});

$(document).ready(function() {

    // Show addresses
    $("#order-preferences-loader").show();
    $(".order-preferences-content").hide();
    API.getAddresses(localStorage.getObject("authData").userId)
    .then(function(data) {
        if (data.addresses.length == 0) {
            $(".addresses-no-results").removeClass("d-none");
        } else {
            // Use address button for subscribed users; address radio otherwise
            let addressItem;
            if (APIUtils.isSubscribed() && location.pathname == "/account/subscription") {
                addressItem = "button";
            } else {
                addressItem = "richRadio";
            }
            data.addresses.forEach(json => {
                json.isDefaultAddress = json.addressId == data.defaultAddressId;
                let address = new Address(json);
                addresses.push(address);
                if (address.isDefaultAddress) {
                    $(".address-list").prepend(address.html[addressItem]);
                } else {
                    $(".address-list").append(address.html[addressItem]);
                }
            });
            deferreds[0].resolve(addresses);
        }
    })
    .catch(function(data) {
        $(".addresses-error").removeClass("d-none");
    })
    .finally(function(data) {
        $("#order-preferences-loader").hide();
        $(".order-preferences-content").show();
    });

});
