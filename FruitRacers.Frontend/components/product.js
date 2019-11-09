class Product {

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
        this.id = id;
        this.name = name;
        this.description = description;
        this.categories = categories;
        this.manufacturer = manufacturer;
        this.price = price;
        this.unit = unit;
        this.minQuantity = minQuantity;
        this.image = image;
    }

    get id() { return this._id; }
    set id(value) { this._id = value; }

    get name() { return this._name; }
    set name(value) { this._name = value; }

    get description() { return this._description; }
    set description(value) { this._description = value; }

    get categories() { return this._categories; }
    set categories(value) { this._categories = value; }

    get manufacturer() { return this._manufacturer; }
    set manufacturer(value) { this._manufacturer = value; }

    get price() { return this._price; }
    set price(value) { this._price = value; }

    get unit() { return this._unit; }
    set unit(value) { this._unit = value; }

    get minQuantity() { return this._minQuantity; }
    set minQuantity(value) { this._minQuantity = value; }

    get image() { return this._image; }
    set image(value) { this._image = value; }
}