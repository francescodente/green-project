class ErrorModalClass {

    constructor() {
        this.html = {};
    }

    show(json, message) {
        this.html.main = Entity.getTemplate("ErrorModal");
        this.json = json;
        this.message = message;
        if (json != null) {
            console.log(json);
            this.html.main.find(".status").html(json.status);
            this.html.main.find(".status-text").html(json.statusText != null ? json.statusText : json.title);
            if (json.responseJSON != null) {
                let propertyErrors = this.responseJSON.propertyErrors.map(err => err.code + " [" + err.property + "]");
                let globalErrors = this.responseJSON.globalErrors.map(err => err.code);
                let errCodes = propertyErrors.concat(globalErrors).join("<br/>");
                this.html.main.find(".err-codes").html(errCodes);
            }
        }
        if (message != null) {
            this.html.main.find(".generic-text").html(message);
        }
        this.html.main.showModal();
    }

}

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

var ErrorModal = new ErrorModalClass();
var InfoModal = new InfoModalClass();
