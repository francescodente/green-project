var addresses = [];
var deferreds = [];
var addressesPromise = new Promise(function(resolve, reject){
    deferreds.push({resolve: resolve, reject: reject});
});

$(document).ready(function() {

    let page = new URL(window.location.href).pathname;
    page = page.substring(page.lastIndexOf("/") + 1);

    // Show addresses
    $("#order-preferences-loader").show();
    $(".order-preferences-content").hide();
    API.getAddresses(localStorage.getObject("authData").userId)
    .then(function(data) {
        if (data.addresses.length == 0) {
            $(".addresses-no-results").removeClass("d-none");
        } else {
            data.addresses.forEach(json => {
                json.isDefaultAddress = json.addressId == data.defaultAddressId;
                let address = new Address(json);
                addresses.push(address);
                if (page == "account-weekly-delivery-preferences.php") {
                    $(".address-list").append(address.html.button);
                } else if (address.isDefaultAddress) {
                    $(".address-list").prepend(address.html.richRadio);
                } else {
                    $(".address-list").append(address.html.richRadio);
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
