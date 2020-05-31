// Order
class Order extends Entity {

    constructor(json) {
        super(json);

        this.html.main = Entity.getTemplate("OrderCard");
        this.html.delivery = Entity.getTemplate("DeliveryOrderCard");
        this.html.shippedModal = Entity.getTemplate("OrderShippedModal");
        this.html.completedModal = Entity.getTemplate("OrderCompletedModal");
        this.html.clientInfoModal = Entity.getTemplate("ClientInfoModal");
        this.html.products = [];

        // Format address fields
        let address = this.deliveryInfo.address;
        let zones = localStorage.getObject("zones").children;
        zones.forEach(province => {
            province.cities.forEach(city => {
                city.zipCodes.map(zipCode => zipCode.zipCode).forEach(zipCode => {
                    if (zipCode == address.zipCode) {
                        address.city = city.cityName;
                        address.province = province.provinceName;
                    }
                })
            })
        });
        address.addressString = address.street + " " + address.houseNumber + ", " + address.zipCode + " " + address.city + " (" + address.province + ")";
        address.googleMapsLink = Utils.createGoogleMapsLink(address.addressString);
        // Format date fields
        this.deliveryInfo.formattedDeliveryDate = Utils.formatDate(this.deliveryInfo.deliveryDate);
        this.formattedTimestamp = Utils.formatDate(this.timestamp);
        // Format cost summary fields
        for (let k in this.prices) {
            let formattedK = "formatted" + k[0].toUpperCase() + k.slice(1);
            this.prices[formattedK] = Utils.formatCurrency(this.prices[k]);
        }

        // Create product/crate entries
        for (let i = 0; i < this.details.length; i++) {
            if (this.details[i].capacity == null) {
                this.details[i] = new Product(this.details[i], this.details[i].quantity);
            } else {
                this.details[i] = new Crate(this.details[i]);
            }
        }

        // Retrieve state HTML
        let stateHtml = OrderStates.filter(state => state.name == this.orderState)
                                   .map(state => state.html)[0];

        let order = this;
        for (let k in order.html) {

            // Init tooltips
            $(order.html[k]).find('[data-tooltip="tooltip"]').tooltip();

            // Replace values in templates
            $(order.html[k]).find(".order-number").html(this.orderNumber);
            $(order.html[k]).find(".order-state").html(stateHtml);
            $(order.html[k]).find(".order-date").html(this.formattedTimestamp);
            $(order.html[k]).find(".product-count").html(this.details.length);
            $(order.html[k]).find(".address").attr("href", address.googleMapsLink);
            $(order.html[k]).find(".telephone").html(address.telephone);
            $(order.html[k]).find(".telephone").attr("href", "tel:" + address.telephone);
            if (this.details.length == 1) {
                $(order.html[k]).find(".product-count-label").addClass("d-none");
            } else {
                $(order.html[k]).find(".product-count-label-1").addClass("d-none");
            }
            $(order.html[k]).find(".subtotal").html(this.prices.formattedSubtotal);
            $(order.html[k]).find(".iva").html(this.prices.formattedIva);
            $(order.html[k]).find(".shipping").html(this.prices.formattedShippingCost);
            $(order.html[k]).find(".total").html(this.prices.formattedTotal);
            $(order.html[k]).find(".delivery-date").html(this.deliveryInfo.formattedDeliveryDate);
            $(order.html[k]).find(".address").html(this.deliveryInfo.address.addressString);
            $(order.html[k]).find(".client-name").html(this.deliveryInfo.address.name);
            if (this.deliveryInfo.notes != null && this.deliveryInfo.notes != "") {
                $(order.html[k]).find(".notes").html(this.deliveryInfo.notes);
            } else {
                $(order.html[k]).find(".notes").html("-");
            }

            // Only show appropriate state button
            if (order.orderState != "Pending") {
                $(order.html[k]).find(".show-shipped-modal").remove();
            }
            if (order.orderState != "Shipping") {
                $(order.html[k]).find(".show-completed-modal").remove();
            }

            // Set IDs to make collapses work
            $(order.html[k]).find("[id=order-OID]").attr("id", "order-" + this.orderId);
            $(order.html[k]).find("[data-target='#order-OID']").attr("data-target", "#order-" + this.orderId);
            $(order.html[k]).find("[id=order-details-OID]").attr("id", "order-details-" + this.orderId);
            $(order.html[k]).find("[data-target='#order-details-OID']").attr("data-target", "#order-details-" + this.orderId);

            // Add event listeners
            $(order.html[k]).find(".show-client-modal").click(function(event) {
                event.preventDefault();
                event.stopPropagation();
                order.showClientModal();
            });
            $(order.html[k]).find(".show-shipped-modal").click(function(event) {
                event.stopPropagation();
                order.showShippedModal();
            });
            $(order.html[k]).find(".show-completed-modal").click(function(event) {
                event.stopPropagation();
                order.showCompletedModal();
            });
            $(order.html[k]).find(".set-state-shipped").click(function() {
                order.setState($(this).closest(".modal"), "Shipping");
            });
            $(order.html[k]).find(".set-state-completed").click(function() {
                order.setState($(this).closest(".modal"), "Completed");
            });
            $(order.html[k]).find(".address").click(function(event) { event.stopPropagation() });
        }

        // Add product entries
        this.details.forEach(product => product.html.orderEntry.appendTo(this.html.main.find(".order-products-list")));
        this.details.forEach(product => product.html.deliveryEntry.appendTo(this.html.delivery.find(".order-products-list")));
    }

    showClientModal() {
        this.html.clientInfoModal.showModal();
    }

    showShippedModal() {
        this.html.shippedModal.showModal();
    }

    showCompletedModal() {
        this.html.completedModal.showModal();
    }

    setState(modal, orderState) {
        modal.find(".loader").show();
        modal.find(".modal-bottom .btn").prop("disabled", true);
        API.changeOrderState(this.orderId, orderState)
        .then(function() { location.reload() })
        .catch(function() {
            modal.find(".loader").hide();
            modal.find(".modal-bottom .btn").prop("disabled", false);
            ErrorModal.show({});
        });
    }

}
