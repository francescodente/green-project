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
