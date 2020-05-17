var orders = [];
var zipCodes;

var url = new URL(window.location.href);
var deliveryDate = url.searchParams.get("DeliveryDate");
var selectedZipCodes = url.searchParams.getAll("ZipCode");

// Add date to chips
var today = moment();
for (let i = 0; i < 5; i++) {
    let date = moment(today).add(i, "d");
    let chipRadio = $("#date-" + i);
    chipRadio.attr("value", date.format("YYYY-MM-DD"));
    if (i > 1) {
        let chipLabel = $("[for=date-" + i + "]");
        chipLabel.html(date.format("D MMM"));
    }
}
// Select the current date chip
$("[value='" + deliveryDate + "']").click();

// Fill zip codes select
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
    $("#select-zipcode .select-item-template").remove();
    $("#select-zipcode").setSelectEnabled(true);
    // Select current zip codes
    if (selectedZipCodes.length) {
        $("[name='select-zipcode']").attr("checked", false);
        selectedZipCodes.forEach(zipCode => {
            $("[name='select-zipcode'][value='" + zipCode + "']").attr("checked", true);
        });
    } else {
        $("[name='select-zipcode']").attr("checked", true);
        $("[data-toggle-all='select-zipcode']").attr("checked", true);
    }
})
.catch(function(jqXHR) { new ErrorModal(jqXHR).show() });

// Get orders
$("#modal-loading").showModal();
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

// Apply filters
$(".apply-filters").click(function() {
    let newUrl = new URL(url.href.split('?')[0]);
    let newDeliveryDate = $("[name='delivery-date']:checked").val();
    let newZipCodes = $("[name='select-zipcode']:checked").map(function() {
        return $(this).val();
    }).get();
    if (newZipCodes.length == zipCodes.length){
        newZipCodes = [];
    }
    newUrl.searchParams.append("DeliveryDate", newDeliveryDate);
    newZipCodes.forEach(zipCode => newUrl.searchParams.append("ZipCode", zipCode));
    window.location.href = newUrl.href;
});
