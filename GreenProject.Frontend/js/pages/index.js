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
let url = new URL(window.location.href);
let modalId = url.searchParams.get("showmod");
if (modalId != null) {
    $("#" + modalId).showModal();
}
