function getTemplate(className) {
    var html = $("[data-template-name='" + className + "']").clone();
    $(html).removeAttr("data-template-name");
    $(html).attr("class", $(html).attr("data-class"));
    $(html).removeAttr("data-class");
    return html;
}

function fillBootstrapRow(row, elems) {
    elems.forEach((elem) => {
        $("<div class='" + row.data("children-class") + "'>").html(elem.html.main).appendTo(row);
    });
}

function showModal(modal) {
    $(".modal.show").on("hidden.bs.modal", function() {
        $("body").addClass("modal-no-scroll");
    }).modal("hide");
    modal.modal("show");
}

function fillPagination(elem, pageNumber, pageCount) {
    if (pageNumber == 0) {
        elem.find(".page-prev").addClass("disabled");
    }
    if (pageNumber == pageCount - 1) {
        elem.find(".page-next").addClass("disabled");
    }
    for (let i = 0; i < pageCount; i++) {
        let page = elem.find(".pages>li.d-none").clone().removeClass("d-none");
        page.find("a").html(i + 1);
        if (pageNumber == i) {
            page.find("a").addClass("selected");
        }
        page.appendTo(elem.find(".pages"));
    }
}
