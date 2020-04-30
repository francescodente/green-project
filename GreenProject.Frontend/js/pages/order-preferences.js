var addresses = [];

$(document).ready(function() {

    // Show addresses
    $("#order-preferences-loader").show();
    $(".order-preferences-content").hide();
    getAddresses(localStorage.getObject("userData").userId)
    .done(function(data) {
        if (data.addresses.length == 0) {
            $(".addresses-no-results").removeClass("d-none");
        } else {
            data.addresses.forEach(json => {
                json.isDefaultAddress = json.addressId == data.defaultAddressId;
                let address = new Address(json);
                addresses.push(address);
                if (address.isDefaultAddress) {
                    $(".address-list").prepend(address.html.richRadio);
                } else {
                    $(".address-list").append(address.html.richRadio);
                }
            });
        }
    })
    .fail(function(data) {
        $(".addresses-error").removeClass("d-none");
    })
    .always(function(data) {
        $("#order-preferences-loader").hide();
        $(".order-preferences-content").show();
    });

});
