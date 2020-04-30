// Get categories
$("#categories-loader").show();
var categories = [];
getOrUpdateCategories()
.then(function(data) {
    data.children.forEach((json) => {
        categories.push(new Category(json));
    });
    fillBootstrapRow($(".category-list"), categories);
})
.catch(function(jqXHR) {
    $(".cat-error").removeClass("d-none");
})
.finally(function(data) {
    $("#categories-loader").hide();
});