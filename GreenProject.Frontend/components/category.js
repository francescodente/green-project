class Category {

    constructor(
            id = 0,
            name = "Category name",
            image = ""
        ) {
        this.id = id;
        this.name = name;
        this.image = image;
    }

    get id() { return this._id; }
    set id(value) { this._id = value; }

    get name() { return this._name; }
    set name(value) { this._name = value; }

    get image() { return this._image; }
    set image(value) { this._image = value; }
}