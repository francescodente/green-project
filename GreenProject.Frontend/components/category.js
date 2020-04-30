class Category extends Entity {

    constructor(json) {
        super(json);

        this.html.main = Entity.getTemplate("CategoryCard");

        // Build products link
        let subCategories = Category.getCategoryLeaves(this).map(c => c.categoryId);
        let searchParams = new URLSearchParams();
        subCategories.forEach(category => {
            searchParams.append("Categories", category);
        });
        let productsUrl = "products.php?" + searchParams.toString();
        let imageUrl = API.basePath + this.imageUrl;

        let category = this;
        for (let k in category.html) {

            // Replace values in templates
            $(category.html[k]).find(".category-name").html(this.name);
            if (this.description != null) {
                $(category.html[k]).find(".category-description").html(this.description);
            }
            if (this.imageUrl != null) {
                $(category.html[k]).find(".category-image").attr("src", imageUrl);
            }
            $(category.html[k]).find(".products-url").attr("href", productsUrl);

        }
    }

    // Given a category, returns the names of all the subcategories with no children
    static getCategoryLeaves(category) {
        let children = [];
        if (category.children.length == 0) {
            children.push(category);
        } else {
            category.children.forEach(child => {
                children = children.concat(Category.getCategoryLeaves(child));
            });
        }
        return children;
    }

}
