var addresses = [];

// Show addresses
$("#modal-loading").showModal();
API.getAddresses(localStorage.getObject("userData").userId)
.done(function(data) {
    if (data.addresses.length == 0) {
        $(".addresses-no-results").removeClass("d-none");
    } else {
        data.addresses.forEach(json => {
            json.isDefaultAddress = json.addressId == data.defaultAddressId;
            let address = new Address(json);
            addresses.push(address);
            if (address.isDefaultAddress) {
                $(".address-list").prepend(address.html.main);
            } else {
                $(".address-list").append(address.html.main);
            }
        });
    }
})
.fail(function(data) { $(".addresses-error").removeClass("d-none") })
.always(function(data) { $("#modal-loading").fadeModal() });