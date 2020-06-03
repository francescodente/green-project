$("[name='date']").val(moment().add(1, "d").format("DD/MM/YYYY"));

function formatDate(dateString) {
    let date = moment(dateString, "DD/MM/YYYY");
    if (date.isValid()) {
        return date.format("YYYY-MM-DD");
    }
    return null;
}

$(".report-form").submit(function(e) {
    e.preventDefault();
    let dateInput = $(this).find("[name='date']");
    let date = formatDate(dateInput.val());
    if (date == null) {
        dateInput.addClass("error");
        return;
    }
    $("#modal-loading").showModal();
    let reportPromise;
    let fileName;
    switch ($(this).attr("id")) {
        case "report-orders":
            reportPromise = API.getOrdersReport(date);
            fileName = "ordini_" + date + ".csv";
            break;
        case "report-products":
            reportPromise = API.getProductsReport(date);
            fileName = "pesi_" + date + ".csv";
            break;
        case "report-supplier-order":
            reportPromise = API.getSupplierOrderReport(date);
            fileName = "fornitore_" + date + ".csv";
            break;
        case "report-revenue":
            reportPromise = API.getRevenueReport(date);
            fileName = "fatturato_" + moment(date, "YYYY-MM-DD").format("MMM-YYYY") + ".csv";
            break;
        default:
            break;
    }
    reportPromise
    .then(function(data) {
        $("#modal-loading").fadeModal();
        Utils.download(fileName, "text/csv", data);
    })
    .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
});