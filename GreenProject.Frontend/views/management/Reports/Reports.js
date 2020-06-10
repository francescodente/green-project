var categories;

$("[name='date']").val(moment().add(1, "d").format("DD/MM/YYYY"));
$("[name='month']").val(moment().format("MM/YYYY"));

function validateDate(dateString) {
    if (dateString.length == 7) {
        dateString = "01/" + dateString;
    }
    let date = moment(dateString, "DD/MM/YYYY");
    return date.isValid() ? date.format("YYYY-MM-DD") : null;
}

function awaitAndDownloadReport(reportPromise, fileName) {
    reportPromise
    .then(function(data) {
        $("#modal-loading").fadeModal();
        Utils.download(fileName, "text/csv", data);
    })
    .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
}

// Fill categories select
APIUtils.getOrUpdateCategories()
.then(function(data) {
    categories = data.children;
    let inputCategories = data.children.map(category => {
        return {
            key: category.categoryId,
            value: category.name
        };
    });
    $("#select-categories").fillSelect(inputCategories);
    $("[name='select-categories']").attr("checked", true);
    $("[data-toggle-all='select-categories']").attr("checked", true);
})
.catch(function(jqXHR) { ErrorModal.show(jqXHR) });

// Orders report
$("#report-orders").submit(function(e) {
    e.preventDefault();
    let dateInput = $(this).find("[name='date']");
    let date = validateDate(dateInput.val());
    if (date == null) {
        dateInput.addClass("error");
        return;
    }
    $("#modal-loading").showModal();
    let reportPromise = API.getOrdersReport(date);
    let fileName = "ordini_" + date + ".csv";
    awaitAndDownloadReport(reportPromise, fileName);
});

// Products report
$("#report-products").submit(function(e) {
    e.preventDefault();
    let dateInput = $(this).find("[name='date']");
    let date = validateDate(dateInput.val());
    if (date == null) {
        dateInput.addClass("error");
        return;
    }
    $("#modal-loading").showModal();
    let reportPromise = API.getProductsReport(date);
    let fileName = "ordini_" + date + ".csv";
    awaitAndDownloadReport(reportPromise, fileName);
});

// Supplier order report
$("#report-supplier-order").submit(function(e) {
    e.preventDefault();
    let dateInput = $(this).find("[name='date']");
    let date = validateDate(dateInput.val());
    if (date == null) {
        dateInput.addClass("error");
        return;
    }
    let selectedCategories = $("[name='select-categories']:checked").getInputValues();
    // Get leaves categories from selected first-level categories
    let categoryIds = categories
        .filter(category => selectedCategories.includes(category.categoryId.toString()))
        .flatMap(category => Category.getLeaves(category))
        .map(category => category.categoryId);
    let reportPromise = API.getSupplierOrderReport(date, categoryIds);
    let fileName = "fornitore_" + date + ".csv";
    awaitAndDownloadReport(reportPromise, fileName);
});

// Revenue report
$("#report-revenue").submit(function(e) {
    e.preventDefault();
    let dateInput = $(this).find("[name='month']");
    let date = validateDate(dateInput.val());
    if (date == null) {
        dateInput.addClass("error");
        return;
    }
    let reportPromise = API.getRevenueReport(date);
    let fileName = "fatturato_" + moment(date, "YYYY-MM-DD").format("MMM-YYYY") + ".csv";
    awaitAndDownloadReport(reportPromise, fileName);
});
