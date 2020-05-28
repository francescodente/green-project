function getProvinces() {
    return zones.children.map(zone => zone.provinceName);
}

function getCities(provinceName) {
    return zones.children.filter(zone => zone.provinceName == provinceName)
        .flatMap(zone => zone.cities)
        .map(city => city.cityName);
}

function getZipCodes(provinceName, cityName) {
    return zones.children.filter(zone => zone.provinceName == provinceName)
        .flatMap(zone => zone.cities)
        .filter(city => city.cityName == cityName)
        .flatMap(city => city.zipCodes)
        .map(zipCode => zipCode.zipCode);
}

// Get zones
$("#address-form-loader").show();
$(".form-fields").hide();
var zones;
APIUtils.getOrUpdateZones()
.then(function(data) {
    zones = data;
    let provinces = getProvinces().map(p => { return { key: p, value: p }; });
    $("#select-province").fillSelect(provinces);
    $("#select-city").setSelectEnabled(false);
    $("#select-zipcode").setSelectEnabled(false);
})
.catch(function(jqXHR) { new ErrorModal(jqXHR).show() })
.finally(function(data) {
    $("#address-form-loader").hide();
    $(".form-fields").show();
});

// Province selected
$("body").on("change", "[name='select-province']", function() {
    let cities = getCities(this.value).map(c => { return { key: c, value: c }; });
    $("#select-city").fillSelect(cities);
    $("#select-zipcode").fillSelect([]);
    $("#select-city").setSelectEnabled(true);
    $("#select-zipcode").setSelectEnabled(false);
});

// City selected
$("body").on("change", "[name='select-city']", function() {
    let province = $("[name='select-province']:checked").val();
    let zipCodes = getZipCodes(province, this.value).map(z => { return { key: z, value: z }; });
    $("#select-zipcode").fillSelect(zipCodes);
    $("#select-zipcode").setSelectEnabled(true);
});

// Check if submit button can be enabled
$("body").on("change", "#modal-new-address input", function() {
    let phoneLength = $("#address-telephone").val().length;
    if ($("[name='select-province']:checked").length &&
        $("[name='select-city']:checked").length &&
        $("[name='select-zipcode']:checked").length &&
        $("#street").val().length &&
        $("#house-number").val().length &&
        $("#address-name").val().length &&
        (phoneLength >=8 && phoneLength <= 20)) {
        $(".submit-address").attr("disabled", false);
    } else {
        $(".submit-address").attr("disabled", true);
    }
});

// Form submission
$("body").on("submit", "#modal-new-address", function(event) {
    event.preventDefault();
    $("#address-form-loader").show();
    $(".form-fields").hide();
    $(".submit-address").attr("disabled", true);
    API.createAddress(localStorage.getObject("authData").userId, {
        "street": $("#street").val(),
        "houseNumber": $("#house-number").val(),
        "name": $("#address-name").val(),
        "telephone": $("#address-telephone").val(),
        "zipCode": $("[name='select-zipcode']:checked").val()
    })
    .then(function(data) { location.reload() })
    .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
});