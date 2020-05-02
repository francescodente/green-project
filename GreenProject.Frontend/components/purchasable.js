// Measurement units
const Units = [
    {
        name: "Piece",
        singular: "pezzo",
        plural: "pezzi"
    },
    {
        name: "Kilogram",
        singular: "Kg",
        plural: "Kg"
    }
]

// Purchasable item
class Purchasable extends Entity {

    constructor(json) {
        super(json);
    }

    static getFormattedUnit(unitName, plural = false) {
        return Units.filter(unit => unit.name == unitName)
                    .map(unit => plural ? unit.plural : unit.singular)[0];
    }

    showRemoveModal() {
        console.log("show remove modal " + this.productId);
    }

    showDisableModal() {
        console.log("show disable modal " + this.productId);
    }

    showDeleteModal() {
        console.log("show delete modal " + this.productId);
    }

    disable() {
        console.log("disable " + this.productId);
    }

    delete() {
        console.log("delete " + this.productId);
    }

    edit() {
        console.log("edit " + this.productId);
    }

}


// Product
class Product extends Purchasable {

    constructor(json, quantity = 1) {
        super(json);
        this.quantity = quantity;

        // Add templates
        this.html.main = Entity.getTemplate("ProductCard");
        this.html.detailsModal = Entity.getTemplate("ProductDetailsModal");
        this.html.quantityModal = Entity.getTemplate("ProductQuantityModal");
        this.html.removeModal = Entity.getTemplate("ProductRemoveModal");
        this.html.cartEntry = Entity.getTemplate("ProductCartEntry");
        this.html.orderEntry = Entity.getTemplate("ProductOrderEntry");

        // Save formatted fields
        this.formattedMultiplier = (this.unitMultiplier * this.quantity).toString().replace(".", ",");
        this.formattedUnit = Purchasable.getFormattedUnit(this.unitName, this.quantity != 1);
        this.formattedPrice = Utils.formatCurrency(this.price * this.quantity);

        let product = this;
        let imageUrl = API.basePath + this.imageUrl;

        for (let k in product.html) {

            // Init tooltips
            $(product.html[k]).find('[data-tooltip="tooltip"]').tooltip();

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
            $(product.html[k]).find(".product-modal-link").click(function() { product.showDetailsModal(); });
            $(product.html[k]).find(".show-quantity-modal").click(function() { product.showQuantityModal(); });
            $(product.html[k]).find(".show-remove-modal").click(function() { product.showRemoveModal(); });
            $(product.html[k]).find(".add-to-cart").click(function() { product.addToCart(); });
            $(product.html[k]).find(".remove-from-cart").click(function() { product.removeFromCart(); });
            $(product.html[k]).on("change paste keyup", "[name='quantity']", function() {
                product.reactToQuantityChange();
            });
        }
    }

    showDetailsModal() {
        this.html.detailsModal.showModal();
    }

    showQuantityModal() {
        if (localStorage.getObject("authData") === null) {
            new InfoModal("Devi essere registrato e aver effettuato l'accesso per aggiungere prodotti al carrello.").show();
            return;
        }
        this.html.quantityModal.find("[name='quantity']").val(this.quantity);
        this.reactToQuantityChange();
        this.html.quantityModal.showModal();
    }

    showCrateQuantityModal() {
        console.log("show crate quantity modal");
        //showModal($(this.html.quantityModal));
    }

    showRemoveModal() {
        this.html.removeModal.showModal();
    }

    showCrateRemoveModal() {
        console.log("show crate remove modal");
        //showModal($(this.html.quantityModal));
    }

    reactToQuantityChange() {
        let quantityModal = this.html.quantityModal
        let quantity = quantityModal.find("[name='quantity']").val();
        let multiplier = 0;
        let price = Utils.formatCurrency(0);
        if (quantity != null && quantity != "") {
            multiplier = (this.unitMultiplier * quantity).toString().replace(".", ",");
            price = Utils.formatCurrency(this.price * quantity);
            quantityModal.find(".add-to-cart").prop("disabled", false);
        } else {
            quantityModal.find(".add-to-cart").prop("disabled", true);
        }
        quantityModal.find(".multiplier").html(multiplier);
        quantityModal.find(".price").html(price);
    }

    addToCart() {
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
            API.editCartQuantity(localStorage.getObject("userData").userId, this.productId, quantity)
            .then(function(data) { location.reload(); })
            .catch(function(jqXHR) { new ErrorModal(jqXHR).show(); });
        } else {
            API.addToCart(localStorage.getObject("userData").userId, this.productId, quantity)
            .then(function(data) {
                APIUtils.updateCartBadge()
                .catch(function(jqXHR) { new ErrorModal(jqXHR).show(); });
                quantityModal.modal("hide");
                quantityModal.find(".loader").hide();
                quantityModal.find(".add-to-cart").attr("disabled", false);
            })
            .catch(function(jqXHR) { new ErrorModal(jqXHR).show(); });
        }
    }

    addToCrate() {
        console.log("add to crate " + this.productId);
    }

    addToOrder() {
        console.log("edit " + this.productId);
    }

    removeFromCart() {
        API.removeFromCart(localStorage.getObject("userData").userId, this.productId)
        .then(function(data) { location.reload(); })
        .catch(function(jqXHR) { new ErrorModal(jqXHR).show(); });
    }

    removeFromCrate() {
        console.log("remove from crate " + this.productId);
    }

    removeFromOrder() {
        console.log("remove from order " + this.productId);
    }

}


// Crate
class Crate extends Purchasable {

    constructor(json) {
        super(json);

        // Add templates
        this.html.main = Entity.getTemplate("CrateCard");
        this.html.detailsModal = Entity.getTemplate("CrateDetailsModal");

        let crate = this;
        let imageUrl = API.basePath + this.imageUrl;
        let capacity = this.capacity.toString().replace(".", ",");
        let price = Utils.formatCurrency(this.price);

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
            $(crate.html[k]).find(".crate-modal-link").click(function() { crate.showDetailsModal(); });
            $(crate.html[k]).find(".subscribe").click(function() { crate.addToPreferences(); });
        }
    }

    showDetailsModal() {
        this.html.detailsModalshowModal();
    }

    addToPreferences() {
        if (localStorage.getObject("authData") === null) {
            new InfoModal("Devi essere registrato e aver effettuato l'accesso per abbonarti a una cassetta settimanale.").show();
            return;
        }
        console.log("add to preferences " + this.crateId);
    }

    removeFromPreferences() {
        console.log("remove from preferences " + this.crateId);
    }

}
