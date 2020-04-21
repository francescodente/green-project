var ErrorModal = function(json, message) {
    for (let k in json) this[k] = json[k];
    this.html = {};
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

ErrorModal.prototype.show = function() {
    showModal($(this.html.main));
}
