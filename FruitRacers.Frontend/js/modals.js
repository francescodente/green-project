function switchModal(currentModal, nextModal) {
    $(currentModal).modal("hide");
    $(nextModal).modal("show");
}

$(document).ready(function() {

    // Handle modal switching
    $(document).on("click", "[data-switch-to]", function() {
        event.preventDefault();
        switchModal($(this).closest(".modal"), $(this).data("switch-to"));
    });

    // modal-address-management: highlight address item on text focus
    $(document).on("focus", ".new.address [type='text']", function() {
        $(this).parent().addClass("focus");
    });
    $(document).on("blur", ".new.address [type='text']", function() {
        $(this).parent().removeClass("focus");
    });

});