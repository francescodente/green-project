// Retrieve a template matching the given name
function getTemplate(templateName) {
    var html = $("[data-template-name='" + templateName + "']").clone();
    $(html).removeAttr("data-template-name");
    $(html).attr("class", $(html).attr("data-class"));
    $(html).removeAttr("data-class");
    return html;
}

// Fills a bootstrap row with given a set of objects
function fillBootstrapRow(row, elems) {
    elems.forEach((elem) => {
        $("<div class='" + row.data("children-class") + "'>").html(elem.html.main).appendTo(row);
    });
}

// Properly hide any modals before showing the given one
function showModal(modal) {
    $(".modal.show").on("hidden.bs.modal", function() {
        $("body").addClass("modal-no-scroll");
    }).modal("hide");
    modal.modal("show");
}

// Fill the given pagination DOM element
function fillPagination(elem, pageNumber, pageCount) {
    let url = new URL(window.location.href);
    // Disable or add url to prev link
    if (pageNumber == 0) {
        elem.find(".page-prev").addClass("disabled");
    } else {
        url.searchParams.set("PageNumber", pageNumber - 1);
        elem.find(".page-prev").attr("href", url.toString());
    }
    // Disable or add url to next link
    if (pageNumber == pageCount - 1) {
        elem.find(".page-next").addClass("disabled");
    } else {
        url.searchParams.set("PageNumber", pageNumber + 1);
        elem.find(".page-next").attr("href", url.toString());
    }
    // Create page links
    for (let i = 0; i < pageCount; i++) {
        url.searchParams.set("PageNumber", i);
        let page = elem.find(".pages>li.d-none").clone().removeClass("d-none");
        page.find("a").html(i + 1);
        page.find("a").attr("href", url.toString());
        if (pageNumber == i) {
            page.find("a").addClass("selected");
        }
        page.appendTo(elem.find(".pages"));
    }
}
