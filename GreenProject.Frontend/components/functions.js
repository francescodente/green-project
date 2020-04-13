function getTemplate(className) {
    var html = $("[data-html-for='" + className + "']").clone();
    $(html).removeAttr("data-html-for");
    $(html).attr("class", $(html).attr("data-class"));
    $(html).removeAttr("data-class");
    return html;
}

function fillBootstrapRow(row, elems) {
    elems.forEach((elem) => {
        $("<div class='" + row.data("children-class") + "'>").html(elem.html).appendTo(row);
    });
}