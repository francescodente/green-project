// Order
class WeeklyCrate extends Entity {

    constructor(json) {
        super(json);

        this.html.main = Entity.getTemplate("WeeklyCrateTable");
        this.html.addProductModal = Entity.getTemplate("WeeklyCrateAddProductModal");

        // Create crate entry
        this.crateDescription = new Crate(this.crateDescription);

        // Create product entries
        for (let i = 0; i < this.products.length; i++) {
            this.products[i] = new Product(this.products[i], this.products[i].quantity);
        }

        let weeklyCrate = this;

        for (let k in weeklyCrate.html) {

            // Init tooltips
            $(weeklyCrate.html[k]).find('[data-tooltip="tooltip"]').tooltip();

            // Add crate entry
            $(weeklyCrate.html[k]).find("thead").append($(weeklyCrate.crateDescription.html.weeklyEntry));

            // Add product entries
            //this.details.forEach(product => product.html.orderEntry.appendTo($(order.html[k]).find(".order-products-list")));

            // Add event listeners
            $(weeklyCrate.html[k]).find(".add-product").click(function() { weeklyCrate.showAddProductModal(); });
        }

        this.addCompatibleProducts();
    }

    // Get and add crate compatible products to modal
    addCompatibleProducts() {
        let weeklyCrate = this;
        API.getCrateCompatibilities(weeklyCrate.crateDescription.crateId)
        .then(function(data) {
            weeklyCrate.compatibleProducts = [];
            data.forEach(json => {
                let product = new Product(json.product, 1, json.maximum);
                product.orderDetailId = weeklyCrate.orderDetailId;
                weeklyCrate.compatibleProducts.push(product);
                product.html.compatibleWithCrateEntry.appendTo($(weeklyCrate.html.addProductModal).find(".compatible-products tbody"));
            });
        })
        .catch(function(jqXHR) { console.log(jqXHR); new ErrorModal(jqXHR).show() });
    }

    showAddProductModal() {
        this.html.addProductModal.showModal();
    }

}
