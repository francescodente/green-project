class ProductCard {

    constructor() {
        // Create self variable to use inside JQuery functions
        var self = this;
        // Clone template into this object
        this._html = $("[data-class='ProductCard']").clone();
        $(this.html).removeAttr("data-class");
        // Handle click event
        $(this.html).click(function() {
            console.log("click");
            $("#modal-product .product-name").html(self.name);
        });
        // Handle cart button click event
        $(this.html).on("click", ".add-to-cart", function(event) {
            event.stopPropagation();
            console.log("cart-add " + self.id);
        });
        // Stop event propagation when opening company link
        $(this.html).on("click", ".company-name", function(event) {
            event.stopPropagation();
        });
    }

    get html() {
        return this._html;
    }

    get id() {
        return this._id;
    }

    set id(value) {
        this._id = value;
    }

    get name() {
        return this._name;
    }

    set name(value) {
        this._name = value;
        $(this.html).find(".product-name").html(this.name);
    }

    get companyId() {
        return this._companyId;
    }

    set companyId(value) {
        this._companyId = value;
    }

    get companyName() {
        return this._companyName;
    }

    set companyName(value) {
        this._companyName = value;
        $(this.html).find(".company-name").html(this.companyName);
    }

    get price() {
        return this._price;
    }

    set price(value) {
        this._price = value;
        $(this.html).find(".product-price").html(this.price);
    }

    get unit() {
        return this._unit;
    }

    set unit(value) {
        this._unit = value;
        $(this.html).find(".product-unit").html(this.unit);
    }

    get image() {
        return this._image;
    }

    set image(value) {
        this._image = value;
        $(this.html).find(".product-image").css("background-image", "url(" +  this.image + ")")
    }
}