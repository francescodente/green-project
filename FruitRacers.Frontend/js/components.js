$(document).ready(function() {

    /****************\
    |   CHECKBOXES   |
    \****************/

    // Checkbox toggle all state management
    function checkboxToggleCheck(checkboxName) {
        var toggleAll = $(".checkbox[data-toggle-all='" + checkboxName + "']");
        switch($("[name='" + checkboxName + "']").not(":checked").length) {
            case 0:
                // All checked -> check
                toggleAll.prop("checked", true);
                toggleAll.prop("indeterminate", false);
                break;
            case $("[name='" + checkboxName + "']").length:
                // All unchecked -> uncheck
                toggleAll.prop("checked", false);
                toggleAll.prop("indeterminate", false);
                break;
            default:
                // Default -> indeterminate
                toggleAll.prop("checked", false);
                toggleAll.prop("indeterminate", true);
        }
    }
    // On page load
    $(".checkbox.toggle-all").each(function() {
        checkboxToggleCheck($(this).data("toggle-all"));
    });
    // On toggle all click
    $(document).on("click", ".checkbox.toggle-all", function() {
        var checkboxName = $(this).attr("data-toggle-all");
        $("[name='" + checkboxName + "']").not(":disabled").prop("checked", $(this).is(":checked"));
        checkboxToggleCheck(checkboxName);
    });
    // On checkbox click
    $(document).on("click", ".checkbox:not(.toggle-all)", function() {
        checkboxToggleCheck($(this).attr("name"));
    });

    /*************\
    |   SELECTS   |
    \*************/

    function updateSelectButton(selectItem) {
        var val;
        if (selectItem.is(".checkbox")) {
            val = selectItem.parent().find(".checkbox:checked").map(function() {
                return $("[for='" + $(this).attr("id") + "']").text();
            }).get().join(", ");
        } else if (selectItem.is(".radio:checked")) {
            val = $("[for='" + selectItem.attr("id") + "']").text();
        }
        selectItem.closest(".dropdown.select").find(".text-input input").val(val);
    }
    // Update button text on change
    $(document).on("change", ".dropdown.select .checkbox, .dropdown.select .radio", function(event) {
        updateSelectButton($(this));
    });
    // Update button on document load
    $(".dropdown.select").each(function() {
        updateSelectButton($(this).find(".checkbox, .radio").first());
    });
    // Prevent multi-select from closing on click
    $(document).on("click", ".dropdown-menu label", function(event) {
        if ($("#" + $(this).attr("for")).is(".checkbox")) {
            event.stopPropagation();
        }
    });

    /*****************\
    |   TEXT INPUTS   |
    \*****************/

    // Update character counter
    $(document).on("change paste keyup", ".text-input, .text-area", function () {
        var input = $(this).find("input, textarea");
        $(this).find(".counter").text(input.val().length + " / " + input.attr("maxlength"));
    });

    // Fix decimal for currency inputs
    $(document).on("blur", "[data-type='currency']", function () {
        if ($(this).val()) {
            $(this).val(parseFloat($(this).val()).toFixed(2));
        }
    });

    // Increse or decrease number input value
    function intRoundUp(num, multiple) {
        return Math.ceil(num / multiple) * multiple;
    }
    function intRoundDown(num, multiple) {
        return Math.floor(num / multiple) * multiple;
    }
    function updateNumberInput(input, amount) {
        var min = input.attr("min") ? parseInt(input.attr("min")) : Number.MIN_SAFE_INTEGER;
        var max = input.attr("max") ? parseInt(input.attr("max")) : Number.MAX_SAFE_INTEGER;
        var step = input.attr("step") ? parseInt(input.attr("step")) : 1;
        var value = input.val();
        if (value % step != 0) {
            if (amount == 1) {
                value = intRoundUp(value, step);
            } else {
                value = intRoundDown(value, step);
            }
        } else {
            value = (input.val() ? parseInt(input.val()) : 0) + amount * step;
        }
        var incButton = input.parent().find(".inc").prop("disabled", value >= max);
        var decButton = input.parent().find(".dec").prop("disabled", value <= min);
        input.val(value);
        if (value == min || value == max) {
            input.focus();
        }
    }
    $(document).on("click", ".text-input .inc", function () {
        updateNumberInput($(this).parent().find("[type='number']"), 1);
    });
    $(document).on("click", ".text-input .dec", function () {
        updateNumberInput($(this).parent().find("[type='number']"), -1);
    });

    /*****************\
    |   FILE INPUTS   |
    \*****************/

    $(document).on("change", "[type=file]", function() {
        // Update file counter
        var fileCount = $(this).prop("files").length;
        if (fileCount > 0) {
            var countItem = $(this).parent().find(".count")
            countItem.removeClass("d-none");
            if ($(this).attr("multiple") !== undefined) {
                countItem.html(fileCount);
            }
        }
    });

    /*****************\
    |   SEARCH BARS   |
    \*****************/

    // Clear button click handling
    $(document).on("click", ".search-bar .clear.btn", function() {
        var textInput = $(this).parent().find("[type='text']")
        textInput.val("");
        textInput.focus();
    });

    /**************\
    |   COLLAPSE   |
    \**************/

    $(document).on("click", "[data-toggle='collapse']", function() {
        $(this).attr("title", $(this).attr("aria-expanded") != "true" ? "Mostra" : "Nascondi");
    });

    /***************\
    |   DROPDOWNS   |
    \***************/

    // slideDown animation to expanding dropdown, dropleft and dropright
    $(".dropdown, .dropleft, .dropright").on("show.bs.dropdown", function() {
        $(this).find(".dropdown-menu").first().stop(true, true).slideDown(200);
    });
    // slideUp animation to collapsing dropdown, dropleft and dropright
    $(".dropdown, .dropleft, .dropright").on("hide.bs.dropdown", function() {
        $(this).find(".dropdown-menu").first().stop(true, true).slideUp(200);
    });

    /*************************\
    |   POPOVERS & TOOLTIPS   |
    \*************************/

    $('[data-toggle="popover"]').popover();
    $('[data-toggle="tooltip"]').tooltip();

    /*********************************\
    |   CAROUSEL FULL SCREEN TOGGLE   |
    \*********************************/

    $(document).on("click", ".carousel-full-screen-toggle", function(event) {
        event.preventDefault();
        var icon = $(this).find(".mdi")
        if ($($(this).attr("href")).hasClass("full-screen")) {
            // Toggle OFF full screen
            $($(this).attr("href")).removeClass("full-screen");
            $("body").removeClass("carousel-no-scroll");
            icon.removeClass("mdi-fullscreen-exit");
            icon.addClass("mdi-fullscreen");
            $(this).attr("title", "Visualizza a schermo intero");
        } else {
            // Toggle ON full screen
            $($(this).attr("href")).addClass("full-screen");
            $("body").addClass("carousel-no-scroll");
            icon.removeClass("mdi-fullscreen");
            icon.addClass("mdi-fullscreen-exit");
            $(this).attr("title", "Riduci");
        }
    });

    /************************\
    |   FULL SCREEN IMAGES   |
    \************************/

    $(document).on("click", ".img-click-zoom", function() {
        var image = $("<div class='img-fullscreen'><img src='" + $(this).attr("src") + "'/></div>");
        image.appendTo("body");
        setTimeout(function() {
            image.addClass("active");
        }, 20);
    });
    $(document).on("click", ".img-fullscreen", function() {
        $(this).remove();
    });

    /*************\
    |   SLIDERS   |
    \*************/

    function adjustProgress(slider) {
        // Update slider thumb
        var minValue = slider.attr("min");
        var range = slider.attr("max") - minValue;
        var relativeValue = slider.val() - minValue;
        var progressWidth = relativeValue / range * 100;
        slider.parent().find(".slider-progress").css("width", progressWidth + "%");
        // Update slider tooltip
        var tooltip = slider.parent().find(".slider-tooltip");
        tooltip.text(slider.val());
        tooltip.css("left", "calc(" + progressWidth + "% - " + tooltip.width() + "px)");
    }
    $(document).on("input", ".slider", function() {
        adjustProgress($(this));
    });
    $(document).ready(function() {
        $(".slider").each(function() { adjustProgress($(this)) });
    });

});
