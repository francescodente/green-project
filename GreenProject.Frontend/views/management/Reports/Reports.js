$("[name='date']").val(moment().add(1, "d").format("DD/MM/YYYY"));
$("[name='month']").val(moment().format("MM/YYYY"));

function formatDate(dateString) {
    if (dateString.length == 7) {
        dateString = "01/" + dateString;
    }
    let date = moment(dateString, "DD/MM/YYYY");
    if (date.isValid()) {
        return date.format("YYYY-MM-DD");
    }
    return null;
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
    let categories = data.children.map(category => {
        return {
            key: category.categoryId,
            value: category.name
        };
    });
    $("#select-categories").fillSelect(categories);
    $("[name='select-categories']").attr("checked", true);
    $("[data-toggle-all='select-categories']").attr("checked", true);
})
.catch(function(jqXHR) { ErrorModal.show(jqXHR) });

// Orders report
$("#report-orders").submit(function(e) {
    e.preventDefault();
    let dateInput = $(this).find("[name='date']");
    let date = formatDate(dateInput.val());
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
    let date = formatDate(dateInput.val());
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
    let date = formatDate(dateInput.val());
    if (date == null) {
        dateInput.addClass("error");
        return;
    }
    let categories = $("[name='select-categories']:checked").getInputValues();
    let reportPromise = API.getSupplierOrderReport(date, categories);
    let fileName = "fornitore_" + date + ".csv";
    awaitAndDownloadReport(reportPromise, fileName);
});

// Revenue report
$("#report-revenue").submit(function(e) {
    e.preventDefault();
    let dateInput = $(this).find("[name='month']");
    let date = formatDate(dateInput.val());
    if (date == null) {
        dateInput.addClass("error");
        return;
    }
    let reportPromise = API.getRevenueReport(date);
    let fileName = "fatturato_" + moment(date, "YYYY-MM-DD").format("MMM-YYYY") + ".csv";
    awaitAndDownloadReport(reportPromise, fileName);
});
