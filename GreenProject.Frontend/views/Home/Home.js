// Get categories
$("#categories-loader").show();
var categories = [];
APIUtils.getOrUpdateCategories()
.then(function(data) {
    data.children.forEach((json) => {
        categories.push(new Category(json));
    });
    $(".category-list").fillRow(categories.map(category => category.html.main));
})
.catch(function(jqXHR) {
    $(".cat-error").removeClass("d-none");
})
.finally(function(data) {
    $("#categories-loader").hide();
});

// Can provide a modal ID via GET to show it
let modalId = location.searchParams.get("showmod");
if (modalId != null) {
    $("#" + modalId).showModal();
}

// Check for the presence of an activation token
let activationToken = location.searchParams.get("token");
if (activationToken != null) {
    $("#modal-loading").showModal();
    API.activate(activationToken)
    .then(function(data) {
        let url = new URL(location.href);
        url.searchParams.delete("token");
        history.replaceState({}, "", url);
        $("#account-activation-successful-modal").showModal();
    })
    .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
}
