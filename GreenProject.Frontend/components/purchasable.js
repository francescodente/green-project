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
function Product(json, quantity = 1) {
    Purchasable.call(this, json);
    this.quantity = quantity;

    // Add templates
    this.html.main = getTemplate("ProductCard");
    this.html.detailsModal = getTemplate("ProductDetailsModal");
    this.html.quantityModal = getTemplate("ProductQuantityModal");
    this.html.removeModal = getTemplate("ProductRemoveModal");
    this.html.cartEntry = getTemplate("ProductCartEntry");

    // Save formatted fields
    this.formattedMultiplier = (this.price.unitMultiplier * this.quantity).toString().replace(".", ",");
    this.formattedUnit = Units[this.price.unitName];
    this.formattedPrice = formatCurrency(this.price.value * this.quantity);

    let product = this;
    let imageUrl = getBasePath() + this.imageUrl;

    for (let k in product.html) {

        // Replace values in templates
        $(product.html[k]).find(".product-name").html(this.name);
        $(product.html[k]).find(".product-description").html(this.description);
        if (product.imageUrl != null) {
            $(product.html[k]).find(".product-image").attr("src", imageUrl);
        }
        $(product.html[k]).find(".multiplier").html(product.formattedMultiplier);
        $(product.html[k]).find(".unit").html(product.formattedUnit);
        $(product.html[k]).find(".price").html(product.formattedPrice);

        // Add event listeners
        $(product.html[k]).find(".product-image").click(function() { product.showDetailsModal(); });
        $(product.html[k]).find(".show-quantity-modal").click(function() { product.showQuantityModal(); });
        $(product.html[k]).find(".show-remove-modal").click(function() { product.showRemoveModal(); });
        $(product.html[k]).find(".add-to-cart").click(function() { product.addToCart(); });
        $(product.html[k]).find(".remove-from-cart").click(function() { product.removeFromCart(); });
        $(product.html[k]).on("change paste keyup", "[name='quantity']", function() {
            product.reactToQuantityChange();
        });
    }
}

Product.prototype = Object.create(Purchasable.prototype);
Product.prototype.constructor = Product;

Product.prototype.showDetailsModal = function() {
    showModal(this.html.detailsModal);
}

Product.prototype.showQuantityModal = function() {
    this.html.quantityModal.find("[name='quantity']").val(this.quantity);
    this.reactToQuantityChange();
    showModal(this.html.quantityModal);
}

Product.prototype.showCrateQuantityModal = function() {
    console.log("show crate quantity modal");
    //showModal($(this.html.quantityModal));
}

Product.prototype.showRemoveModal = function() {
    showModal(this.html.removeModal);
}

Product.prototype.showCrateRemoveModal = function() {
    console.log("show crate remove modal");
    //showModal($(this.html.quantityModal));
}

Product.prototype.reactToQuantityChange = function() {
    let quantityModal = this.html.quantityModal
    let quantity = quantityModal.find("[name='quantity']").val();
    let multiplier = 0;
    let price = formatCurrency(0);
    if (quantity != null && quantity != "") {
        multiplier = (this.price.unitMultiplier * quantity).toString().replace(".", ",");
        price = formatCurrency(this.price.value * quantity);
        quantityModal.find(".add-to-cart").prop("disabled", false);
    } else {
        quantityModal.find(".add-to-cart").prop("disabled", true);
    }
    quantityModal.find(".multiplier").html(multiplier);
    quantityModal.find(".price").html(price);
}

Product.prototype.addToCart = function() {
    let quantityModal = this.html.quantityModal
    // Detect if request comes from cart
    let page = new URL(window.location.href).pathname;
    page = page.substring(page.lastIndexOf("/") + 1);
    let isFromCart = page == "cart.php";
    // Get quantity
    let quantity = quantityModal.find("[name='quantity']").val();
    if (quantity == null || quantity == "") return;
    // Perform request
    quantityModal.find(".loader").show();
    quantityModal.find(".add-to-cart").attr("disabled", true);
    if (isFromCart) {
        editCartQuantity(localStorage.getObject("userData").userId, this.productId, quantity)
        .done(function(data) { location.reload(); })
        .fail(function(jqXHR) { new Error(jqXHR).show(); });
    } else {
        addToCart(localStorage.getObject("userData").userId, this.productId, quantity)
        .done(function(data) {
            updateCartBadge()
            .catch(function(jqXHR) { new Error(jqXHR).show(); });
            quantityModal.modal("hide");
            quantityModal.find(".loader").hide();
            quantityModal.find(".add-to-cart").attr("disabled", false);
        })
        .fail(function(jqXHR) { new Error(jqXHR).show(); });
    }
}

Product.prototype.addToCrate = function() {
    console.log("add to crate " + this.productId);
}

Product.prototype.addToOrder = function() {
    console.log("edit " + this.productId);
}

Product.prototype.removeFromCart = function() {
    console.log("remove from cart " + this.productId);
    removeFromCart(localStorage.getObject("userData").userId, this.productId)
    .done(function(data) { location.reload(); })
    .fail(function(jqXHR) { new Error(jqXHR).show(); });
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
