class Product extends Purchasable {

    constructor(json, quantity = 1, maxQuantity = null) {
        super(json);
        this.quantity = quantity;
        this.maxQuantity = maxQuantity;

        // Add templates
        this.html.main = Entity.getTemplate("ProductCard");
        this.html.detailsModal = Entity.getTemplate("ProductDetailsModal");
        this.html.quantityModal = Entity.getTemplate("ProductQuantityModal");
        this.html.removeModal = Entity.getTemplate("ProductRemoveModal");
        this.html.crateRemoveModal = Entity.getTemplate("ProductCrateRemoveModal");
        this.html.cartEntry = Entity.getTemplate("ProductCartEntry");
        this.html.orderEntry = Entity.getTemplate("ProductOrderEntry");
        this.html.inCrateEntry = Entity.getTemplate("ProductInCrateEntry");
        this.html.compatibleWithCrateEntry = Entity.getTemplate("ProductCompatibleWithCrateEntry");
        this.html.crateQuantityModal = Entity.getTemplate("ProductCrateQuantityModal");
        this.html.starredEntry = Entity.getTemplate("StarredProductEntry");

        // Save formatted fields
        this.formattedMultiplier = (this.unitMultiplier * this.quantity).toString().replace(".", ",");
        this.formattedUnit = Purchasable.getFormattedUnit(this.unitName, this.quantity != 1);
        this.formattedPrice = Utils.formatCurrency(this.price * this.quantity);

        let product = this;
        let imageUrl = API.basePath + this.imageUrl;
        let userData = localStorage.getObject("userData");
        let isSubscribed = userData == null ? false : userData.isSubscribed;

        for (let k in product.html) {

            // Init tooltips
            $(product.html[k]).find('[data-tooltip="tooltip"]').tooltip();

            // Replace values in templates
            $(product.html[k]).find(".product-name").html(this.name);
            $(product.html[k]).find(".product-description").html(this.description);
            if (product.imageUrl != null) {
                $(product.html[k]).find(".product-image").attr("src", imageUrl);
                $(product.html[k]).find(".product-image").attr("alt", this.name);
            }
            $(product.html[k]).find(".multiplier").html(product.formattedMultiplier);
            $(product.html[k]).find(".unit").html(product.formattedUnit);
            $(product.html[k]).find(".price").html(product.formattedPrice);
            if (product.maxQuantity != null) {
                $(product.html[k]).find("[name='quantity']").attr("max", product.maxQuantity);
            }

            // Remove items that require subscription if user is not subscribed
            if (!isSubscribed) {
                $(product.html[k]).find(".req-subscription").remove();
            }

            // Add event listeners
            $(product.html[k]).find(".product-modal-link").click(function(e) {
                e.preventDefault();
                product.showDetailsModal();
            });
            $(product.html[k]).find(".show-quantity-modal").click(function() { product.showQuantityModal(); });
            $(product.html[k]).find(".show-crate-quantity-modal").click(function() { product.showCrateQuantityModal(); });
            $(product.html[k]).find(".show-remove-modal").click(function() { product.showRemoveModal(); });
            $(product.html[k]).find(".show-crate-remove-modal").click(function() { product.showCrateRemoveModal(); });
            $(product.html[k]).find(".add-to-cart").click(function() { product.addToCart(); });
            $(product.html[k]).find(".remove-from-cart").click(function() { product.removeFromCart(); });
            $(product.html[k]).find(".remove-from-crate").click(function() { product.removeFromCrate(); });
            $(product.html[k]).find(".add-to-crate").click(function() { product.addToCrate(); });
            $(product.html[k]).on("change paste keyup", "input.quantity", function() {
                product.reactToQuantityChange(product.html.quantityModal);
            });
            $(product.html[k]).on("change paste keyup", "input.crate-quantity", function() {
                product.reactToQuantityChange(product.html.crateQuantityModal);
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
        this.reactToQuantityChange(this.html.quantityModal);
        this.html.quantityModal.showModal();
    }

    showCrateQuantityModal() {
        console.log("show crate quantity modal");
        this.html.crateQuantityModal.showModal();
    }

    showRemoveModal() {
        this.html.removeModal.showModal();
    }

    showCrateRemoveModal() {
        console.log("show crate remove modal");
        this.html.crateRemoveModal.showModal();
    }

    reactToQuantityChange(quantityModal) {
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
            .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
        } else {
            API.addToCart(localStorage.getObject("userData").userId, this.productId, quantity)
            .then(function(data) {
                APIUtils.updateCartBadge()
                .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
                quantityModal.modal("hide");
                quantityModal.find(".loader").hide();
                quantityModal.find(".add-to-cart").attr("disabled", false);
            })
            .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
        }
    }

    addToCrate() {
        console.log("add to crate " + this.productId + " " + this.orderDetailId);
    }

    addToOrder() {
        console.log("edit " + this.productId);
    }

    removeFromCart() {
        API.removeFromCart(localStorage.getObject("userData").userId, this.productId)
        .then(function(data) { location.reload(); })
        .catch(function(jqXHR) { new ErrorModal(jqXHR).show() });
    }

    removeFromCrate() {
        console.log("remove from crate " + this.productId);
    }

    removeFromOrder() {
        console.log("remove from order " + this.productId);
    }

}
