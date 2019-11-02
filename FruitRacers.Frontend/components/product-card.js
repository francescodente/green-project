class ProductCard extends Product {

    constructor(
        id = 0,
        name = "Product name",
        description = "",
        categories = [],
        manufacturer = null,
        price = 0,
        unit = "ND",
        minQuantity = 0,
        image = ""
    ) {
        super(id, name, description, categories, manufacturer, price, unit, minQuantity, image);

        // Clone template into this object
        this._html = getTemplate("ProductCard");

        // Set attributes again to fill HTML
        this.id = id;
        this.name = name;
        this.description = description;
        this.categories = categories;
        this.manufacturer = manufacturer;
        this.price = price;
        this.unit = unit;
        this.minQuantity = minQuantity;
        this.image = image;

        var self = this;

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
            $("#modal-company").modal();
        });
    }

    get html() { return this._html; }

    set name(value) {
        super.name = value;
        $(this.html).find(".product-name").html(this.name);
    }

    set categories(value) {
        super.categories = value;
        // TODO
    }

    set manufacturer(value) {
        super.manufacturer = value;
        //$(this.html).find(".company-name").html(this.companyName);
    }

    set price(value) {
        super.price = value;
        $(this.html).find(".product-price").html(this.price);
    }

    set unit(value) {
        super.unit = value;
        $(this.html).find(".product-unit").html(this.unit);
    }

    set image(value) {
        super.image = value;
        //$(this.html).find(".product-image").css("background-image", "url(" +  this.image + ")")
    }
}