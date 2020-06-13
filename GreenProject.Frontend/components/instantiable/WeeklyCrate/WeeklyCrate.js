// Order
class WeeklyCrate extends Entity {

    constructor(json) {
        super(json);

        this.html.main = Entity.getTemplate("WeeklyCrateTable");
        this.html.addProductModal = Entity.getTemplate("WeeklyCrateAddProductModal");

        // Create crate entry
        let crateQuantity = 0;
        if (this.products.length) {
            crateQuantity = this.products.map(product => product.quantity).reduce((tot, q) => parseFloat(tot) + parseFloat(q));
        }
        this.crateDescription = new Crate(this.crateDescription, crateQuantity, this.orderDetailId);

        // Create product entries
        for (let i = 0; i < this.products.length; i++) {
            this.products[i] = new Product(this.products[i].product, this.products[i].quantity / 2, this.products[i].maximum || Number.MAX_SAFE_INTEGER);
            this.products[i].weeklyCrateId = this.orderDetailId;
            this.products[i].parentCrateFreeSlots = this.crateDescription.capacity - this.crateDescription.occupiedSlots;
        }

        let weeklyCrate = this;

        for (let k in weeklyCrate.html) {

            // Init tooltips
            $(weeklyCrate.html[k]).find("[data-tooltip='tooltip']").tooltip();

            // Add crate entry
            $(weeklyCrate.html[k]).find("thead").append($(weeklyCrate.crateDescription.html.weeklyEntry));

            // Add product entries
            for (let i = weeklyCrate.products.length - 1; i >= 0; i--) {
                weeklyCrate.products[i].html.inCrateEntry.prependTo($(weeklyCrate.html[k]).find(".crate-products"));
            }

            // Set IDs to make collapses work
            $(weeklyCrate.html[k]).find("[id=collapse-ODID]").attr("id", "collapse-odid" + weeklyCrate.orderDetailId);
            $(weeklyCrate.html[k]).find("[data-target='#collapse-ODID']").attr("data-target", "#collapse-odid" + weeklyCrate.orderDetailId);

            // Add event listeners
            $(weeklyCrate.html[k]).find(".add-product").click(function() { weeklyCrate.showAddProductModal(); });
        }
        this.addCompatibleProducts();
    }

    // Get and add crate compatible products to modal
    addCompatibleProducts() {
        let weeklyCrate = this;
        $(weeklyCrate.html.addProductModal).find(".compatible-products-loader").addClass("d-block");
        $(weeklyCrate.html.addProductModal).find(".compatible-products").hide();
        API.getCrateCompatibilities(weeklyCrate.crateDescription.crateId)
        .then(function(data) {
            weeklyCrate.compatibleProducts = [];
            let crateProductIds = weeklyCrate.products.map(product => product.productId);
            data.forEach(json => {
                let product = new Product(json.product, 1, json.maximum || Number.MAX_SAFE_INTEGER);
                product.parentCrateFreeSlots = weeklyCrate.crateDescription.capacity - weeklyCrate.crateDescription.occupiedSlots;
                product.weeklyCrateId = weeklyCrate.orderDetailId;
                if (!crateProductIds.includes(product.productId)) {
                    weeklyCrate.compatibleProducts.push(product);
                    product.html.compatibleWithCrateEntry.appendTo($(weeklyCrate.html.addProductModal).find(".compatible-products tbody"));
                }
            });
            if (weeklyCrate.compatibleProducts.length == 0) {
                $(weeklyCrate.html.addProductModal).find(".compatible-products-no-results").removeClass("d-none");
            } else {
                $(weeklyCrate.html.addProductModal).find(".compatible-products").show();
            }
        })
        .catch(function(jqXHR) { console.log(jqXHR); ErrorModal.show(jqXHR) })
        .finally(function(data) {
            $(weeklyCrate.html.addProductModal).find(".compatible-products-loader").removeClass("d-block");
        });
    }

    showAddProductModal() {
        this.html.addProductModal.showModal();
    }

}
