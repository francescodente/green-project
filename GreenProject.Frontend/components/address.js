class Address extends Entity {

    constructor(json) {
        super(json);

        // Get HTML templates
        this.html.main = Entity.getTemplate("AddressCard");
        this.html.richRadio = Entity.getTemplate("AddressRadio");
        this.html.button = Entity.getTemplate("AddressButton");
        this.html.deleteModal = Entity.getTemplate("DeleteAddressModal");
        this.html.setDefaultModal = Entity.getTemplate("SetDefaultAddressModal");
        this.html.setWeeklyModal = Entity.getTemplate("SetWeeklyAddressModal");

        // Get province and city
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

            // Init tooltips
            $( address.html[k]).find('[data-tooltip="tooltip"]').tooltip();

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

        address.html.button.click(function() {
            if (!$(this).hasClass("default")) {
                address.showSetWeeklyModal();
            }
        });
    }

    showDeleteModal() {
        this.html.deleteModal.showModal();
    }

    showSetDefaultModal() {
        this.html.setDefaultModal.showModal();
    }

    showSetWeeklyModal() {
        this.html.setWeeklyModal.showModal();
    }

    deleteAddress() {
        $("#modal-loading").showModal();
        API.deleteAddress(localStorage.getObject("authData").userId, this.addressId)
        .then(function(data) { location.reload() })
        .catch(function(jqXHR) {
            $("#modal-loading").fadeModal();
            new ErrorModal(jqXHR).show();
        });
    }

    setDefault() {
        $("#modal-loading").showModal();
        API.setDefaultAddress(localStorage.getObject("authData").userId, this.addressId)
        .then(function(data) { location.reload() })
        .catch(function(jqXHR) {
            $("#modal-loading").fadeModal();
            new ErrorModal(jqXHR).show();
        });
    }

}
