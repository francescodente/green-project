class Modal extends Entity {

    constructor(json) {
        super(json);
    }

    show() {
        this.html.main.showModal();
    }
}

class ErrorModal extends Modal {

    constructor(json, message) {
        super(json);
        this.html.main = Entity.getTemplate("ErrorModal");

        console.log(json);

        if (json.responseJSON != null) {
            let propertyErrors = this.responseJSON.propertyErrors.map(err => err.code + " [" + err.property + "]");
            let globalErrors = this.responseJSON.globalErrors.map(err => err.code);
            this.errCodes = propertyErrors.concat(globalErrors).join("<br/>");
        }

        let error = this;
        for (let k in error.html) {

            // Replace values in templates
            if (message != null) {
                $(error.html[k]).find(".generic-text").html(message);
            }
            if ("status" in error) {
                $(error.html[k]).find(".status").html(error.status);
                $(error.html[k]).find(".status-text").html(error.statusText);
            }
            if ("errCodes" in error) {
                $(error.html[k]).find(".err-codes").html(error.errCodes);
            }
        }
    }

}

class InfoModal extends Modal {

    constructor(message) {
        super(null);
        this.html.main = Entity.getTemplate("InfoModal");

        let info = this;
        for (let k in info.html) {

            // Replace values in templates
            if (message != null) {
                $(info.html[k]).find(".info-text").html(message);
            }
        }
    }

}
