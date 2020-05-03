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
