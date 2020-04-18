// Measurement units
var Units = {
    Piece: "pezzi",
    Kilogram: "Kg"
}

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
    let imageUrl = getBasePath() + this.imageUrl;
    let multiplier = this.price.unitMultiplier.toString().replace(".", ",");
    let unit = Units[this.price.unitName];
    let price = formatCurrency(this.price.value);

    for (let k in product.html) {

        // Replace values in templates
        $(product.html[k]).find(".product-name").html(this.name);
        $(product.html[k]).find(".product-description").html(this.description);
        if (product.imageUrl != null) {
            $(product.html[k]).find(".product-image").attr("src", imageUrl);
        }
        $(product.html[k]).find(".multiplier").html(multiplier);
        $(product.html[k]).find(".unit").html(unit);
        $(product.html[k]).find(".price").html(price);

        // Add event listeners
        $(product.html[k]).find(".product-image").click(function() { product.showDetailsModal(); });
        $(product.html[k]).find(".show-quantity-modal").click(function() { product.showQuantityModal(); });
        $(product.html[k]).find(".add-to-cart").click(function() { product.addToCart(); });
        $(product.html[k]).on("change paste keyup", "[name='quantity']", function() {
            product.reactToQuantityChange();
        });
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

Product.prototype.reactToQuantityChange = function() {
    let quantity = this.html.quantityModal.find("[name='quantity']").val();
    let multiplier = 0;
    let price = formatCurrency(0);
    if (quantity != null && quantity != "") {
        multiplier = (this.price.unitMultiplier * quantity).toString().replace(".", ",");
        price = formatCurrency(this.price.value * quantity);
    }
    $(this.html.quantityModal).find(".multiplier").html(multiplier);
    $(this.html.quantityModal).find(".price").html(price);
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

    // Add templates
    this.html.main = getTemplate("CrateCard");
    this.html.detailsModal = getTemplate("CrateDetailsModal");

    let crate = this;
    let imageUrl = getBasePath() + this.imageUrl;
    let capacity = this.capacity.toString().replace(".", ",");
    let price = formatCurrency(this.price);

    for (let k in crate.html) {

        // Replace values in templates
        $(crate.html[k]).find(".crate-name").html(this.name);
        $(crate.html[k]).find(".crate-description").html(this.description);
        if (this.imageUrl != null) {
            $(crate.html[k]).find(".crate-image").attr("src", imageUrl);
        }
        $(crate.html[k]).find(".capacity").html(capacity);
        $(crate.html[k]).find(".price").html(price);

        // Add event listeners
        $(crate.html[k]).find(".crate-image").click(function() { crate.showDetailsModal(); });
        $(crate.html[k]).find(".subscribe").click(function() { crate.addToPreferences(); });
    }
}

Crate.prototype = Object.create(Purchasable.prototype);
Crate.prototype.constructor = Crate;

Crate.prototype.showDetailsModal = function() {
    console.log("show details modal " + this.crateId);
    showModal($(this.html.detailsModal));
}

Crate.prototype.addToPreferences = function() {
    console.log("add to preferences " + this.crateId);
}

Crate.prototype.removeFromPreferences = function() {
    console.log("remove from preferences " + this.crateId);
}
