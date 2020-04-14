// Purchasable item
var Purchasable = function(json) {
    for (let k in json) this[k] = json[k];
    this.html = {};
}

Purchasable.prototype.showRemoveModal = function() {
    console.log("show remove modal " + this.productId);
}

Purchasable.prototype.showDisableModal = function() {
    console.log("show disable modal " + this.productId);
}

Purchasable.prototype.showDeleteModal = function() {
    console.log("show delete modal " + this.productId);
}

Purchasable.prototype.disable = function() {
    console.log("disable " + this.productId);
}

Purchasable.prototype.delete = function() {
    console.log("delete " + this.productId);
}

Purchasable.prototype.edit = function() {
    console.log("edit " + this.productId);
}

// Product
function Product(json) {
    Purchasable.call(this, json);

    // Add templates
    this.html.main = getTemplate("ProductCard");
    this.html.detailsModal = getTemplate("ProductDetailsModal");
    this.html.quantityModal = getTemplate("ProductQuantityModal");

    let product = this;
    for (let k in product.html) {

        // Replace values in templates
        $(product.html[k]).find(".product-name").html(this.name);
        $(product.html[k]).find(".product-description").html(this.description);

        // Add event listeners
        $(product.html[k]).find(".product-image").click(function() { product.showDetailsModal(); });
        $(product.html[k]).find(".show-quantity-modal").click(function() { product.showQuantityModal(); });
        $(product.html[k]).find(".add-to-cart").click(function() { product.addToCart(); });
    }
}

Product.prototype = Object.create(Purchasable.prototype);
Product.prototype.constructor = Product;

Product.prototype.showDetailsModal = function() {
    console.log("show details modal " + this.productId);
    showModal($(this.html.detailsModal));
}

Product.prototype.showQuantityModal = function() {
    console.log("show quantity modal " + this.productId);
    showModal($(this.html.quantityModal));
}

Product.prototype.addToCart = function() {
    console.log("add to cart " + this.productId);
}

Product.prototype.addToCrate = function() {
    console.log("add to crate " + this.productId);
}

Product.prototype.addToOrder = function() {
    console.log("edit " + this.productId);
}

Product.prototype.removeFromCart = function() {
    console.log("remove from cart " + this.productId);
}

Product.prototype.removeFromCrate = function() {
    console.log("remove from crate " + this.productId);
}

Product.prototype.removeFromOrder = function() {
    console.log("remove from order " + this.productId);
}

// Crate
function Crate(json) {
    Purchasable.call(this, json);
}

Crate.prototype.addToPreferences = function() {
    console.log("add to preferences " + this.productId);
}

Crate.prototype.removeFromPreferences = function() {
    console.log("remove from preferences " + this.productId);
}
