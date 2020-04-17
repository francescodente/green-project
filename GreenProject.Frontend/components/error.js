var Error = function(json) {
    for (let k in json) this[k] = json[k];
    this.html = {};

    this.html.main = getTemplate("ErrorModal");

    let error = this;
    for (let k in error.html) {

        // Replace values in templates
        if ("genericText" in error) {
            $(error.html[k]).find(".generic-text").html(this.genericText);
        }
        if ("errCode" in error) {
            $(error.html[k]).find(".err-code").html(this.errCode);
        }
        if ("errText" in error) {
            $(error.html[k]).find(".err-text").html(this.errText);
        }
    }
}

Error.prototype.show = function() {
    showModal($(this.html.main));
}
