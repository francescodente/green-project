// Root of the HTML class hierarchy
class Entity {

    constructor(json) {
        for (let k in json) this[k] = json[k];
        this.html = {};
    }

    // Retrieve a template matching the given name
    static getTemplate(templateName) {
        var html = $("[data-template-name='" + templateName + "']").clone();
        $(html).removeAttr("data-template-name");
        $(html).removeAttr("class");
        $(html).attr("class", $(html).attr("data-class"));
        $(html).removeAttr("data-class");
        return html;
    }

}