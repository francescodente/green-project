// Given a category, returns the names of all the subcategories with no children
function getCategoryLeaves(category) {
    let children = [];
    if (category.children.length == 0) {
        children.push(category.name);
    } else {
        category.children.forEach(child => {
            children = children.concat(getCategoryLeaves(child));
        });
    }
    return children;
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