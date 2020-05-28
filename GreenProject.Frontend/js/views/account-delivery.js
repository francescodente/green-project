const PAGE_SIZE = 12;

var orders = [];
var zipCodes;
var states = OrderStates.map(state => state.name);

// Extract search params
var baseUrl = location.href.split('?')[0];
var dateFrom = location.searchParams.get("From");
var dateTo = location.searchParams.get("To");
var selectedZipCodes = location.searchParams.getAll("ZipCodes");
var selectedStates = location.searchParams.getAll("States");
var pageNumber = 0;
var lastPage = 0;

var today = moment();
if (dateFrom == null || dateTo == null) {
    let todayString = today.format("YYYY-MM-DD");
    dateFrom = todayString;
    dateTo = todayString;
}
if (selectedStates.length == 0) {
    selectedStates = [0, 2];
}
if (pageNumber == null) pageNumber = 0;

var scrollHandler = function() { checkScroll() }

// Add date to chips
let pastFrom = "1970-01-01";
let pastTo = moment(today).subtract(1, "d").format("YYYY-MM-DD");
$("#date-past").val(pastFrom + "|" + pastTo);
for (let i = 0; i < 5; i++) {
    let date = moment(today).add(i, "d");
    let dateVal = date.format("YYYY-MM-DD");
    let chipRadio = $("#date-" + i);
    chipRadio.val(dateVal + "|" + dateVal);
    if (i > 1) {
        let chipLabel = $("[for=date-" + i + "]");
        chipLabel.html(date.format("D MMM"));
    }
}
// Select the current date chip
if (dateTo == pastTo) {
    $("#date-past").click();
} else {
    $("[value='" + dateFrom + "|" + dateTo + "']").click();
}

// Select current states
selectedStates.forEach(state => {
    $("[name='order-state'][value='" + state + "']").attr("checked", true);
});

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
                key: zipCode.zipCode,
                value: zipCode.zipCode + " - " + city.cityName
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
API.getOrders(dateFrom, dateTo, selectedZipCodes, selectedStates, pageNumber, PAGE_SIZE)
.then(function(data) {
    if (data.results.length == 0) {
        $(".orders-no-results").removeClass("d-none");
    } else {
        lastPage = data.pageCount - 1;
        // Create product objects
        data.results.forEach((json) => {
            let order = new Order(json)
            orders.push(order);
            $(".order-list").append(order.html.delivery);
        });
        // Add scroll listener to load more content
        $(window).scroll(scrollHandler);
    }
})
.catch(function(jqXHR) {
    $(".orders-error").removeClass("d-none");
    new ErrorModal(jqXHR).show();
})
.finally(function(data) { $("#modal-loading").fadeModal() });

// Apply filters
$(".apply-filters").click(function() {
    let newUrl = new URL(baseUrl);
    let dates = $("[name='delivery-date']:checked").val().split("|");
    let newZipCodes = $("[name='select-zipcode']:checked").getInputValues();
    if (newZipCodes.length == zipCodes.length) {
        newZipCodes = [];
    }
    let newStates = $("[name='order-state']:checked").getInputValues();
    newUrl.searchParams.append("From", dates[0]);
    newUrl.searchParams.append("To", dates[1]);
    newZipCodes.forEach(zipCode => newUrl.searchParams.append("ZipCodes", zipCode));
    newStates.forEach(state => newUrl.searchParams.append("States", state));
    window.location.href = newUrl.href;
});

// Collapse button text management
$(".btn-collapse").click(function() {
    $(this).find("span").html($(this).attr("aria-expanded") == "true" ? "Mostra filtri" : "Nascondi filtri");
});

// Always keep a state checkbox selected
$("[name=order-state]").change(function(event) {
    if ($("[name=order-state]:checked").length == 0) this.checked = true;
});

// Load more orders on scroll
function checkScroll() {
    if ($(window).scrollTop() + $(window).height() != $(document).height()) {
        return;
    }
    if (pageNumber < lastPage) {
        pageNumber++;
        $(window).off("scroll", scrollHandler);
        $(".orders-loader").show();
        console.log("load more");
        API.getOrders(dateFrom, dateTo, selectedZipCodes, selectedStates, pageNumber, PAGE_SIZE)
        .then(function(data) {
            if (data.results.length == 0) {
                return;
            } else {
                lastPage = data.pageCount - 1;
                // Create product objects
                data.results.forEach((json) => {
                    let order = new Order(json)
                    orders.push(order);
                    $(".order-list").append(order.html.delivery);
                });
                // Add scroll listener to load more content
                $(window).scroll(scrollHandler);
            }
        })
        .catch(function(jqXHR) {
            $(".orders-error").removeClass("d-none");
            new ErrorModal(jqXHR).show();
        })
        .finally(function(data) { $(".orders-loader").hide() });
    } else {
        $(".no-more-results").removeClass("d-none");
    }
}
