var Address = function(json) {
    for (let k in json) this[k] = json[k];
    this.html = {};

    this.html.main = getTemplate("AddressCard");
    this.html.deleteModal = getTemplate("DeleteAddressModal");
    this.html.setDefaultModal = getTemplate("SetDefaultAddressModal");
    this.html.richRadio = getTemplate("AddressRadio");

    let zones = localStorage.getObject("zones").children;
    zones.forEach(province => {
        province.cities.forEach(city => {
            city.zipCodes.forEach(zipCode => {
                if (zipCode == this.zipCode) {
                    this.city = city.cityName;
                    this.province = province.provinceName;
                }
            })
        })
    });
    let id = "address-radio-" + this.addressId;
    this.addressString = this.street + " " + this.houseNumber + ", " + this.zipCode + " " + this.city + " (" + this.province + ")";


    let address = this;
    for (let k in address.html) {

        // Replace values in templates
        address.html[k].find(".address-string").html(address.addressString);
        address.html[k].find(".address-name").html(address.name);
        address.html[k].find(".address-telephone").html(address.telephone);
        if (address.isDefaultAddress) {
            address.html[k].addClass("default");
            address.html[k].find(".address-set-default").remove();
            address.html[k].find("input").prop("checked", true);
        }
        address.html[k].find("input").attr("id", id);
        address.html[k].find("input").val(address.addressId);
        address.html[k].find("label").attr("for", id);

        // Add event listeners
        address.html[k].find(".address-set-default").click(function() { address.setDefault(); });
        address.html[k].find(".address-show-delete-modal").click(function() { address.showDeleteModal(); });
        address.html[k].find(".address-delete").click(function() { address.deleteAddress(); });
        address.html[k].find("input").change(function() {
            if (!address.isDefaultAddress) {
                address.showSetDefaultModal();
            }
        });

    }
}

Address.prototype.showDeleteModal = function() {
    showModal($(this.html.deleteModal));
}

Address.prototype.showSetDefaultModal = function() {
    console.log("set default modal");
    showModal($(this.html.setDefaultModal));
}

Address.prototype.deleteAddress = function() {
    showModal($("#modal-loading"));
    deleteAddress(localStorage.getObject("userData").userId, this.addressId)
    .done(function(data) { location.reload(); })
    .fail(function(jqXHR) {
        fadeOutModal($("#modal-loading"));
        new ErrorModal(jqXHR).show();
    });
}

Address.prototype.setDefault = function() {
    showModal($("#modal-loading"));
    setDefaultAddress(localStorage.getObject("userData").userId, this.addressId)
    .done(function(data) {
        location.reload();
    })
    .fail(function(jqXHR) {
        fadeOutModal($("#modal-loading"));
        new ErrorModal(jqXHR).show();
    });
}
