// Root of the HTML class hierarchy
class Entity {

    constructor(json) {
        for (let k in json) this[k] = json[k];
        this.html = {};
    }

}