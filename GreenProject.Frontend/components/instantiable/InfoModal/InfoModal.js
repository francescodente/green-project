class InfoModalClass {

    constructor(message) {
        this.html = {};
    }

    show(message) {
        this.html.main = Entity.getTemplate("InfoModal");
        this.html.main.find(".info-text").html(message);
        this.html.main.showModal();
    }

}

var InfoModal = new InfoModalClass();
