var Address = function(json) {
    for (let k in json) this[k] = json[k];
    this.html = {};

    this.html.main = getTemplate("AddressCard");
    this.html.deleteModal = getTemplate("DeleteAddressModal");

    this.addressString = this.street + " " + this.houseNumber + ", " + this.zipCode + " " + this.city + " (" + this.province + ")";

    let address = this;
    for (let k in address.html) {

        // Replace values in templates
        $(address.html[k]).find(".address-string").html(this.addressString);
        $(address.html[k]).find(".address-name").html(this.name);
        $(address.html[k]).find(".address-telephone").html(this.telephone);
        if (address.isDefaultAddress) {
            $(address.html[k]).addClass("default");
            $(address.html[k]).find(".address-set-default").remove();
        }

        // Add event listeners
        $(address.html[k]).find(".address-set-default").click(function() { address.setDefault(); });
        $(address.html[k]).find(".address-show-delete-modal").click(function() { address.showDeleteModal(); });
        $(address.html[k]).find(".address-delete").click(function() { address.deleteAddress(); });

    }
}

Address.prototype.showDeleteModal = function() {
    showModal($(this.html.deleteModal));
}

Address.prototype.deleteAddress = function() {
    showModal($("#modal-loading"));
    deleteAddress(localStorage.getObject("userData").userId, this.addressId)
    .done(function(data) {
        location.reload();
        console.log(data);
    })
    .fail(function(data) {
        console.log("fail");
        console.log(data);
        fadeOutModal($("#modal-loading"));
    });
}

Address.prototype.setDefault = function() {
    showModal($("#modal-loading"));
    setDefaultAddress(localStorage.getObject("userData").userId, this.addressId)
    .done(function(data) {
        location.reload();
    })
    .fail(function(data) {
        console.log("fail");
        console.log(data);
        fadeOutModal($("#modal-loading"));
    });
}
