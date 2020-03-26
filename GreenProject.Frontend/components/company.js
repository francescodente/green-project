class Company {

    constructor(
            id = 0,
            name = "Company name",
            description = "",
            address = "Company address",
            image = ""
        ) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.address = address;
        this.image = image;
    }

    get id() { return this._id; }
    set id(value) { this._id = value; }

    get name() { return this._name; }
    set name(value) { this._name = value; }

    get description() { return this._description; }
    set description(value) { this._description = value; }

    get address() { return this._address; }
    set address(value) { this._address = value; }

    get image() { return this._image; }
    set image(value) { this._image = value; }
}