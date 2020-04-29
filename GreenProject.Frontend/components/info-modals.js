class Modal extends Entity {

    constructor(json) {
        super(json);
    }

    show() {
        showModal($(this.html.main));
    }
}

class ErrorModal extends Modal {

    constructor(json, message) {
        super(json);
        this.html.main = getTemplate("ErrorModal");

        if (json != null) {
            this.errCodes = this.responseJSON.globalErrors.map(err => err.code).join(", ");
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
        this.html.main = getTemplate("InfoModal");

        let info = this;
        for (let k in info.html) {

            // Replace values in templates
            if (message != null) {
                $(info.html[k]).find(".info-text").html(message);
            }
        }
    }

}
