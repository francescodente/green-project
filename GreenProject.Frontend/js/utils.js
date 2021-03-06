/************************\
|   STORAGE EXTENSIONS   |
\************************/

Storage.prototype.setObject = function(key, value) {
    this.setItem(key, JSON.stringify(value));
};

Storage.prototype.getObject = function(key) {
    let value = this.getItem(key);
    return JSON.parse(value);
};

Storage.prototype.setObjectProperty = function(objectKey, key, value) {
    let object = this.getObject(objectKey);
    object[key] = value;
    this.setObject(objectKey, object)
};

/************************\
|   LOCATION EXTENSION   |
\************************/

location.filename = location.pathname.split("/").pop();
location.searchParams = new URL(location).searchParams;

/***********************\
|   JQUERY EXTENSIONS   |
\***********************/

jQuery.fn.extend({

    // Properly hide any modals before showing the given one
    showModal: function() {
        if ($(this).hasClass("show")) return;
        $(".modal.show").on("hidden.bs.modal", function() {
            $("body").addClass("modal-no-scroll");
        }).modal("hide");
        this.modal("show");
    },

    // Gracefully fade out a modal
    fadeModal: function() {
        this.fadeOut();
        let modal = this;
        $(".modal-backdrop").fadeOut();
        setTimeout(function() {
            modal.modal("hide");
        }, 500);
    },

    // Fills a bootstrap row with given a set of objects
    fillRow: function(elems) {
        elems.forEach(elem => {
            $("<div class='" + this.data("children-class") + "'>").html(elem).appendTo(this);
        });
    },

    // Fill the given pagination DOM element
    fillPagination: function(pageNumber, pageCount) {
        let url = new URL(window.location.href);
        // Disable or add url to prev link
        if (pageNumber == 0) {
            this.find(".page-prev").addClass("disabled");
        } else {
            url.searchParams.set("PageNumber", pageNumber - 1);
            this.find(".page-prev").attr("href", url.toString());
        }
        // Disable or add url to next link
        if (pageNumber == pageCount - 1 || pageCount == 0) {
            this.find(".page-next").addClass("disabled");
        } else {
            url.searchParams.set("PageNumber", pageNumber + 1);
            this.find(".page-next").attr("href", url.toString());
        }
        // Create page links
        for (let i = 0; i < pageCount; i++) {
            url.searchParams.set("PageNumber", i);
            let page = this.find(".pages>li.d-none").clone().removeClass("d-none");
            page.find("a").html(i + 1);
            page.find("a").attr("href", url.toString());
            if (pageNumber == i) {
                page.find("a").addClass("selected");
            }
            page.appendTo(this.find(".pages"));
        }
    },

    // Fill the given dropdown with the provided key -> value array
    fillSelect: function(items) {
        let dropdownMenu = this.find(".dropdown-menu");
        let inputTemplate = this.find(".select-item-template>input");
        let labelTemplate = this.find(".select-item-template>label");
        dropdownMenu.find(":not(.toggle-all)").remove();
        this.find(".text-input>input").val("");
        items.forEach(item => {
            let input = inputTemplate.clone();
            let label = labelTemplate.clone();
            input.attr("id", item.key).val(item.key);
            label.attr("for", item.key).html(item.value);
            if (inputTemplate.data("required") == true) {
                input.prop("required", true);
            }
            dropdownMenu.append(input, label);
        });
    },

    // Enable or disable a dropdown select item
    setSelectEnabled: function(enabled) {
        if (enabled) {
            this.find(".text-input").removeClass("disabled");
            this.find("input").prop("disabled", false);
        } else {
            this.find(".text-input").addClass("disabled");
            this.find("input").prop("disabled", true);
        }
    },

    // From a selector, get input values into an array
    getInputValues: function() {
        return this.map(function() {
            return $(this).val();
        }).get();
    },

    classes: function() {
        return $(this).attr("class").split(/\s+/);
    }

});

/*******************\
|   UTILITY CLASS   |
\*******************/

class UtilsClass {

    constructor() {
        if (!!UtilsClass.Utils) {
            return UtilsClass.Utils;
        }
        UtilsClass.Utils = this;
    }

    // Format the given decimal number
    formatDecimal(value, nPlaces) {
        if (nPlaces == "auto") {
            return value.toString().replace(".", ",");
        }
        return value.toFixed(nPlaces).replace(".", ",");
    }

    // Format the given currency value
    formatCurrency(value) {
        return this.formatDecimal(value, 2) + "???";
    }

    createGoogleMapsLink(addressString) {
        return "https://www.google.it/maps?q=" + encodeURIComponent(addressString);
    }

    wait(ms, success = true) {
        return new Promise((resolve, reject) => setTimeout(() => {
            if (success)
                resolve();
            else
                reject();
        }, ms));
    }

    // Prepare form for validation: disable submit button, remove existing error messages
    prepForValidation(form) {
        form.find("[type='submit']").prop("disabled", true);
        form.find("input").removeClass("error");
        form.find(".error-message").hide();
    }

    // Remove showmod parameter from current URL
    removeGetModal() {
        let url = new URL(location.href);
        url.searchParams.delete("showmod");
        history.replaceState({}, "", url.href);
    }

    // Create, click and destroy a link to download the given content
    download(fileName, fileType, fileContent) {
        var element = document.createElement("a");
        element.setAttribute("href", "data:" + fileType + ";charset=utf-8," + encodeURIComponent(fileContent));
        element.setAttribute("download", fileName);
        element.style.display = "none";
        document.body.appendChild(element);
        element.click();
        document.body.removeChild(element);
    }

}

var Utils = Object.freeze(new UtilsClass());
