var orders = [];
var zipCodes;
var selectedZipCodes;

// Add date to chips
var today = moment();
for (let i = 0; i < 5; i++) {
    let date = moment(today).add(i, "d");
    let chip = $(".date-" + i);
    chip.attr("href", date.format("YYYY-MM-DD"));
    if (i > 1) {
        chip.find("span").html(date.format("D MMM"));
    }
}

// Fill CAPs dropdown select
$("#select-zipcode").setSelectEnabled(false);
APIUtils.getOrUpdateZones()
.then(function(data) {
    zipCodes = data.children
        .flatMap(province => {
            province.cities.forEach(city => city.cityName += " (" + province.provinceName + ")");
            return province.cities;
        })
        .flatMap(city => {
            let zipCodes = [];
            city.zipCodes.forEach(zipCode => zipCodes.push({
                key: zipCode,
                value: zipCode + " - " + city.cityName
            }));
            return zipCodes;
        });
    $("#select-zipcode").fillSelect(zipCodes);
    $("#select-zipcode").setSelectEnabled(true);
})
.catch(function(jqXHR) { new ErrorModal(jqXHR).show() });

// Get orders
$("#modal-loading").showModal();
let url = new URL(window.location.href);
let deliveryDate = url.searchParams.get("DeliveryDate");
API.getOrders(deliveryDate, [])
.then(function(data) {
    console.log(data);
    if (data.results.length == 0) {
        $(".orders-no-results").removeClass("d-none");
    } else {
        // Create product objects
        data.results.forEach((json) => {
            let order = new Order(json)
            orders.push(order);
            $(".order-list").append(order.html.delivery);
        });
    }
})
.catch(function(jqXHR) {
    $(".orders-error").removeClass("d-none");
    new ErrorModal(jqXHR).show();
})
.finally(function(data) { $("#modal-loading").fadeModal() });