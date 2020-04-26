// Retrieve a template matching the given name
function getTemplate(templateName) {
    var html = $("[data-template-name='" + templateName + "']").clone();
    $(html).removeAttr("data-template-name");
    $(html).removeAttr("class");
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

// Gracefully fade out a modal
function fadeOutModal(modal) {
    modal.fadeOut();
    $(".modal-backdrop").fadeOut();
    setTimeout(function() {
        modal.modal("hide");
    }, 500);
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
    if (pageNumber == pageCount - 1 || pageCount == 0) {
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

// Fill the given dropdown with the provided key -> value array
function fillDropdownSelect(select, items) {
    let dropdownMenu = select.find(".dropdown-menu");
    let inputTemplate = select.find(".select-item-template>input");
    let labelTemplate = select.find(".select-item-template>label");
    dropdownMenu.empty();
    select.find(".text-input>input").val("");
    items.forEach(item => {
        let input = inputTemplate.clone();
        let label = labelTemplate.clone();
        input.attr("id", item.key).val(item.key);
        label.attr("for", item.key).html(item.value);
        if (inputTemplate.data("required") == true) {
            input.prop("required", true);
        }
        dropdownMenu.append(input, label);
    });
}

// Enable or disable a dropdown select item
function toggleDropdownSelectEnabled(select, enable) {
    if (enable) {
        select.find(".text-input").removeClass("disabled");
        select.find("input").prop("disabled", false);
    } else {
        select.find(".text-input").addClass("disabled");
        select.find("input").prop("disabled", true);
    }
}

// Format the given decimal number
function formatDecimal(value, nPlaces) {
    return value.toFixed(nPlaces).replace(".", ",");
}

// Format the given currency value
function formatCurrency(value) {
    return formatDecimal(value, 2) + "€";
}

// Format the given date from YYYY*MM*DD to DD/MM/YYYY
function formatDate(dateString) {
    let dd = dateString.substring(8, 10);
    let mm  = dateString.substring(5, 7);
    let yyyy = dateString.substring(0, 4);
    return dd + "/" + mm + "/" + yyyy;
}
