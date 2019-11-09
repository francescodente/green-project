function getTemplate(className) {
    var html = $("[data-html-for='" + className + "']").clone();
    $(html).removeAttr("data-html-for");
    $(html).attr("class", $(html).attr("data-class"));
    $(html).removeAttr("data-class");
    return html;
}

function fillBootstrapRow(gridRow, elems) {
    $.each(elems, function(value) {
        $("<div class='" + $(gridRow).data("children-class") + "'>").html(value.html).appendTo(gridRow);
    });
}