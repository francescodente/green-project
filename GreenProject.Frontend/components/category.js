// Given a category, returns the names of all the subcategories with no children
function getCategoryLeaves(category) {
    let children = [];
    if (category.children.length == 0) {
        children.push(category);
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

    // Build products link
    let subCategories = getCategoryLeaves(this).map(c => c.categoryId);
    let searchParams = new URLSearchParams();
    searchParams.append("PageNumber", 0);
    searchParams.append("PageSize", 24);
    subCategories.forEach(category => {
        searchParams.append("Categories", category);
    });
    let productsUrl = "products.php?" + searchParams.toString();
    let imageUrl = getBasePath() + this.imageUrl;

    let product = this;
    for (let k in product.html) {

        // Replace values in templates
        $(product.html[k]).find(".category-name").html(this.name);
        if (this.description != null) {
            $(product.html[k]).find(".category-description").html(this.description);
        }
        if (this.imageUrl != null) {
            $(product.html[k]).find(".category-image").attr("src", imageUrl);
        }
        $(product.html[k]).find(".products-url").attr("href", productsUrl);

    }
}