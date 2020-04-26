// Order
var Order = function(json) {
    for (let k in json) this[k] = json[k];
    this.html = {};

    this.html.main = getTemplate("OrderCard");
    this.html.products = [];

    // Format address fields
    let address = this.deliveryInfo.address;
    let zones = localStorage.getObject("zones").children;
    zones.forEach(province => {
        province.cities.forEach(city => {
            city.zipCodes.forEach(zipCode => {
                if (zipCode == address.zipCode) {
                    address.city = city.cityName;
                    address.province = province.provinceName;
                }
            })
        })
    });
    address.addressString = address.street + " " + address.houseNumber + ", " + address.zipCode + " " + address.city + " (" + address.province + ")";
    // Format date fields
    this.deliveryInfo.formattedDeliveryDate = formatDate(this.deliveryInfo.deliveryDate);
    this.formattedTimestamp = formatDate(this.timestamp);
    // Format cost summary fields
    for (k in this.prices) {
        let formattedK = "formatted" + k[0].toUpperCase() + k.slice(1);
        this.prices[formattedK] = formatCurrency(this.prices[k]);
    }

    // Create product entries
    for (let i = 0; i < this.details.length; i++) {
        this.details[i] = new Product(this.details[i]);
    }

    // Retrieve state HTML
    let stateHtml = OrderStates.filter(state => state.name == this.orderState)
                               .map(state => state.html)[0];

    let order = this;
    for (let k in order.html) {

        // Replace values in templates
        $(order.html[k]).find(".order-number").html(this.orderNumber);
        $(order.html[k]).find(".order-state").html(stateHtml);
        $(order.html[k]).find(".order-date").html(this.formattedTimestamp);
        $(order.html[k]).find(".subtotal").html(this.prices.formattedSubtotal);
        $(order.html[k]).find(".iva").html(this.prices.formattedIva);
        $(order.html[k]).find(".shipping").html(this.prices.formattedShippingCost);
        $(order.html[k]).find(".total").html(this.prices.formattedTotal);
        $(order.html[k]).find(".delivery-date").html(this.deliveryInfo.formattedDeliveryDate);
        $(order.html[k]).find(".address").html(this.deliveryInfo.address.addressString);
        if (this.deliveryInfo.notes != null && this.deliveryInfo.notes != "") {
            $(order.html[k]).find(".notes").html(this.deliveryInfo.notes);
        } else {
            $(order.html[k]).find(".notes").html("-");
        }

        // Add product entries
        this.details.forEach(product => product.html.orderEntry.appendTo($(order.html[k]).find(".order-products-list")));

        // Set IDs to make collapses work
        $(order.html[k]).find("[id=order-OID]").attr("id", "order-" + this.orderId);
        $(order.html[k]).find("[data-target='#order-OID']").attr("data-target", "#order-" + this.orderId);
        $(order.html[k]).find("[id=order-details-OID]").attr("id", "order-details-" + this.orderId);
        $(order.html[k]).find("[data-target='#order-details-OID']").attr("data-target", "#order-details-" + this.orderId);

    }
}
