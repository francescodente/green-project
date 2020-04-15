// Given a category, returns all the subcategories with no children
function getCategoryLeaves(category) {
    if (category.children.length == 0) {
        return category;
    }
    let children = "";
}

// Category
var Category = function(json) {
    for (let k in json) this[k] = json[k];
    this.html = {};

    this.html.main = getTemplate("CategoryCard");

    let product = this;
    for (let k in product.html) {

        // Replace values in templates
        $(product.html[k]).find(".category-name").html(this.name);
        //$(product.html[k]).find(".category-description").html(this.description);
    }
}