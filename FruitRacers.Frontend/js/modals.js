function switchModal(currentModal, nextModal) {
    $(currentModal).modal("hide");
    $(nextModal).modal("show");
}

$(document).ready(function() {

    $(document).on("click", "[data-switch-to]", function() {
        event.preventDefault();
        switchModal($(this).closest(".modal"), $(this).data("switch-to"));
    });

});