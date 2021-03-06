class Product extends Purchasable {

    constructor(json, quantity = 1, maxQuantity = Number.MAX_SAFE_INTEGER) {
        super(json);
        this.quantity = quantity;
        this.crateSlots = quantity * 2;
        this.maxQuantity = maxQuantity;
        if (this.itemId != null) this.productId = this.itemId;

        // Add templates
        this.html.main = Entity.getTemplate("ProductCard");
        this.html.detailsModal = Entity.getTemplate("ProductDetailsModal");
        this.html.quantityModal = Entity.getTemplate("ProductQuantityModal");
        this.html.crateQuantityModal = Entity.getTemplate("ProductCrateQuantityModal");
        this.html.extraQuantityModal = Entity.getTemplate("ProductExtraQuantityModal");
        this.html.removeModal = Entity.getTemplate("ProductRemoveModal");
        this.html.crateRemoveModal = Entity.getTemplate("ProductCrateRemoveModal");
        this.html.extraRemoveModal = Entity.getTemplate("ProductExtraRemoveModal");
        this.html.cartEntry = Entity.getTemplate("ProductCartEntry");
        this.html.orderEntry = Entity.getTemplate("ProductOrderEntry");
        this.html.deliveryEntry = Entity.getTemplate("ProductDeliveryEntry");
        this.html.inCrateEntry = Entity.getTemplate("ProductInCrateEntry");
        this.html.compatibleWithCrateEntry = Entity.getTemplate("ProductCompatibleWithCrateEntry");
        this.html.starredEntry = Entity.getTemplate("StarredProductEntry");
        this.html.extraEntry = Entity.getTemplate("ExtraProductEntry");

        // Save formatted fields
        this.formattedMultiplier = (this.unitMultiplier * this.quantity).toString().replace(".", ",");
        this.formattedCrateMultiplier = this.quantity.toString().replace(".", ",");
        this.formattedUnit = Purchasable.getFormattedUnit(this.unitName, this.quantity != 1);
        this.formattedPrice = Utils.formatCurrency(this.price * this.quantity);

        let product = this;
        let imageUrl = API.uploadsAddress + this.imageUrl;
        let userData = localStorage.getObject("userData");
        let isSubscribed = userData == null ? false : userData.isSubscribed;

        for (let k in product.html) {
            let productHtml = product.html[k];

            // Init tooltips
            $(productHtml).find('[data-tooltip="tooltip"]').tooltip();

            // Replace values in templates
            $(productHtml).find(".product-name").html(this.name);
            $(productHtml).find(".product-description").html(this.description);
            if (product.imageUrl != null) {
                $(productHtml).find(".product-image").attr("src", imageUrl);
                $(productHtml).find(".product-image").attr("alt", this.name);
            }
            $(productHtml).find(".multiplier").html(product.formattedMultiplier);
            $(productHtml).find(".crate-multiplier").html(product.formattedCrateMultiplier);
            $(productHtml).find(".unit").html(product.formattedUnit);
            $(productHtml).find(".price").html(product.formattedPrice);

            // Remove items that require subscription if user is not subscribed
            if (!isSubscribed) {
                $(productHtml).find(".req-subscription").remove();
            }

            // Add event listeners
            $(productHtml).find(".product-modal-link").click(function(e) {
                e.preventDefault();
                product.showDetailsModal();
            });
            $(productHtml).find(".show-quantity-modal").click(function() { product.showQuantityModal($(this).attr("data-action")) });
            $(productHtml).find(".show-crate-quantity-modal").click(function() { product.showCrateQuantityModal($(this).attr("data-action")) });
            $(productHtml).find(".show-extra-quantity-modal").click(function() { product.showExtraQuantityModal($(this).attr("data-action")) });
            $(productHtml).find(".show-remove-modal").click(function() { product.showRemoveModal() });
            $(productHtml).find(".show-crate-remove-modal").click(function() { product.showCrateRemoveModal() });
            $(productHtml).find(".show-extra-remove-modal").click(function() { product.showExtraRemoveModal() });
            $(productHtml).find(".confirm-quantity").click(function() { product[$(this).attr("data-method")]() });
            $(productHtml).find(".remove-from-cart").click(function() { product.removeFromCart() });
            $(productHtml).find(".remove-from-crate").click(function() { product.removeFromCrate() });
            $(productHtml).find(".remove-from-extras").click(function() { product.removeFromExtras() });
            $(productHtml).on("change paste keyup", "input.quantity", function() {
                product.reactToQuantityChange(product.html.quantityModal);
            });
            $(productHtml).on("change paste keyup", "input.crate-quantity", function() {
                product.reactToQuantityChange(product.html.crateQuantityModal);
            });
            $(productHtml).on("change paste keyup", "input.extra-quantity", function() {
                product.reactToQuantityChange(product.html.extraQuantityModal);
            });
        }
    }

    reactToQuantityChange(quantityModal) {
        let input = quantityModal.find("[name='quantity']");
        let quantity = parseFloat(input.val());
        let maxQuantity = parseFloat(input.attr("max")) || this.maxQuantity;
        let multiplier = 0;
        let crateMultiplier = 0;
        let price = Utils.formatCurrency(0);
        if (quantity != null && quantity != "" && (maxQuantity == null || quantity <= maxQuantity)) {
            multiplier = (this.unitMultiplier * quantity).toString().replace(".", ",");
            crateMultiplier = (0.5 * quantity).toString().replace(".", ",");
            price = Utils.formatCurrency(this.price * quantity);
            quantityModal.find(".confirm-quantity").prop("disabled", false);
        } else {
            quantityModal.find(".confirm-quantity").prop("disabled", true);
        }
        input.parent().find(".dec").prop("disabled", quantity <= 1);
        input.parent().find(".inc").prop("disabled", quantity >= maxQuantity);
        quantityModal.find(".multiplier").html(multiplier);
        quantityModal.find(".crate-multiplier").html(crateMultiplier);
        quantityModal.find(".price").html(price);
    }

    showDetailsModal() {
        this.html.detailsModal.showModal();
    }

    showQuantityModal(action) {
        console.log("show cart quantity modal");
        if (localStorage.getObject("authData") === null) {
            InfoModal.show("Devi essere registrato e aver effettuato l'accesso per aggiungere prodotti al carrello.");
            return;
        }
        let quantityModal = this.html.quantityModal;
        // Set confirm method
        quantityModal.find(".confirm-quantity").attr("data-method", action == "add" ? "addToCart" : "editCartQuantity");
        quantityModal.find("[name='quantity']").val(this.quantity);
        this.reactToQuantityChange(quantityModal);
        quantityModal.showModal();
    }

    showCrateQuantityModal(action) {
        console.log("show crate quantity modal");
        let quantityModal = this.html.crateQuantityModal;
        // Set confirm method
        quantityModal.find(".confirm-quantity").attr("data-method", action == "add" ? "addToCrate" : "editCrateQuantity");
        quantityModal.find("[name='quantity']").val(action == "add" ? 1 : this.crateSlots);
        quantityModal.find("[name='quantity']").attr("max", this.maxQuantity < this.parentCrateFreeSlots ? this.maxQuantity : this.parentCrateFreeSlots);
        this.reactToQuantityChange(quantityModal);
        quantityModal.showModal();
    }

    showExtraQuantityModal(action) {
        console.log("show extra quantity modal");
        let quantityModal = this.html.extraQuantityModal;
        // Set confirm method
        quantityModal.find(".confirm-quantity").attr("data-method", action == "add" ? "addToExtras" : "editExtraQuantity");
        quantityModal.find("[name='quantity']").val(this.quantity);
        this.reactToQuantityChange(quantityModal);
        quantityModal.showModal();
    }

    showRemoveModal() {
        this.html.removeModal.showModal();
    }

    showCrateRemoveModal() {
        this.html.crateRemoveModal.showModal();
    }

    showExtraRemoveModal() {
        this.html.extraRemoveModal.showModal();
    }

    addToCart() {
        console.log("add to cart " + this.productId);
        let quantityModal = this.html.quantityModal;
        let quantity = quantityModal.find("[name='quantity']").val();
        quantityModal.find(".loader").show();
        quantityModal.find(".confirm-quantity").attr("disabled", true);
        API.addToCart(localStorage.getObject("authData").userId, this.productId, quantity)
        .then(function(data) {
            APIUtils.updateCartBadge()
            .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
            quantityModal.modal("hide");
            quantityModal.find(".loader").hide();
            quantityModal.find(".confirm-quantity").attr("disabled", false);
        })
        .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
    }

    editCartQuantity() {
        console.log("edit cart quantity " + this.productId);
        let quantityModal = this.html.quantityModal;
        let quantity = quantityModal.find("[name='quantity']").val();
        quantityModal.find(".loader").show();
        quantityModal.find(".confirm-quantity").attr("disabled", true);
        API.editCartQuantity(localStorage.getObject("authData").userId, this.productId, quantity)
        .then(function(data) { location.reload(); })
        .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
    }

    addToCrate() {
        console.log("add to crate " + this.productId + " " + this.weeklyCrateId);
        let quantityModal = this.html.crateQuantityModal;
        let quantity = quantityModal.find("[name='quantity']").val();
        quantityModal.find(".loader").show();
        quantityModal.find(".confirm-quantity").attr("disabled", true);
        APIUtils.addProductToCrate(this.weeklyCrateId, this, quantity)
        .then(function(data) { location.reload(); })
        .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
    }

    editCrateQuantity() {
        console.log("edit crate quantity " + this.productId + " " + this.weeklyCrateId);
        let quantityModal = this.html.crateQuantityModal;
        let quantity = quantityModal.find("[name='quantity']").val();
        quantityModal.find(".loader").show();
        quantityModal.find(".confirm-quantity").attr("disabled", true);
        APIUtils.editProductCrateQuantity(this.weeklyCrateId, this.productId, quantity)
        .then(function(data) { location.reload(); })
        .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
    }

    addToExtras() {
        console.log("add to extras " + this.productId);
        let quantityModal = this.html.extraQuantityModal;
        let quantity = quantityModal.find("[name='quantity']").val();
        quantityModal.find(".loader").show();
        quantityModal.find(".confirm-quantity").attr("disabled", true);
        APIUtils.addExtraProduct(this, quantity)
        .then(function(data) {
            if (location.pathname == "/account/subscription") {
                location.reload();
            } else {
                quantityModal.modal("hide");
                quantityModal.find(".loader").hide();
                quantityModal.find(".confirm-quantity").attr("disabled", false);
            }
        })
        .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
    }

    editExtraQuantity() {
        console.log("edit extra quantity " + this.orderDetailId);
        let quantityModal = this.html.extraQuantityModal;
        let quantity = quantityModal.find("[name='quantity']").val();
        quantityModal.find(".loader").show();
        quantityModal.find(".confirm-quantity").attr("disabled", true);
        APIUtils.editExtraProductQuantity(this.orderDetailId, quantity)
        .then(function(data) { location.reload(); })
        .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
    }

    removeFromCart() {
        $("#modal-loading").showModal();
        API.removeFromCart(localStorage.getObject("authData").userId, this.productId)
        .then(function(data) { location.reload(); })
        .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
    }

    removeFromCrate() {
        $("#modal-loading").showModal();
        APIUtils.removeProductFromCrate(this.weeklyCrateId, this.productId)
        .then(function(data) { location.reload(); })
        .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
    }

    removeFromExtras() {
        $("#modal-loading").showModal();
        APIUtils.removeFromWeeklyOrder(this.orderDetailId)
        .then(function(data) { location.reload(); })
        .catch(function(jqXHR) { ErrorModal.show(jqXHR) });
    }

}
