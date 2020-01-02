$(document).ready(function() {

    /****************************\
    |   TEXT INPUTS, TEXTAREAS   |
    \****************************/

    // Label management
    $(".text-input input, textarea").filter(function() {
        return this.value.length > 0;
    }).addClass("has-value");
    $(document).on("blur", ".text-input input, textarea", function() {
        if(!this.value) {
            $(this).removeClass("has-value");
        } else {
            $(this).addClass("has-value");
        }
    });

    /****************\
    |   CHECKBOXES   |
    \****************/

    // Checkbox toggle all click
    $(document).on("click", ".checkbox.toggle-all", function() {
        if ($(this).is(":checked")) {
            $('[data-toggled-by="' + $(this).attr("data-toggle") + '"]').prop('checked', true);
        } else {
            $('[data-toggled-by="' + $(this).attr("data-toggle") + '"]').prop('checked', false);
        }
    });

    // Checkbox toggle all check / uncheck
    function checkboxToggleCheck(toggle) {
        if ($('.checkbox[data-toggled-by="' + toggle + '"]').not(':checked').length == 0) {
            $('.checkbox[data-toggle="' + toggle + '"]').prop('checked', true);
        } else {
            $('.checkbox[data-toggle="' + toggle + '"]').prop('checked', false);
        }
    }
    // On page load
    $(".checkbox[data-toggled-by]").each(function() {
        checkboxToggleCheck($(this).data("toggled-by"));
    });
    // On checkbox click
    $(document).on("click", ".checkbox:not(.toggle-all)", function() {
        toggle = $(this).data("toggled-by");
        checkboxToggleCheck(toggle);
    });

    /*************\
    |   SELECTS   |
    \*************/

    // Select action functions
    function openSelectInput(selectInput) {
        selectInput.find("ul li.selected").focus();
        selectInput.addClass("active");
    }
    function closeSelectInput(selectInput) {
        selectInput.removeClass("active");
        selectInput.find("button").focus();
    }
    function selectInputValue(selectInput, selectedOption) {
        selectInput.find("ul li").removeClass("selected").attr("aria-selected", "false");
        selectedOption.addClass("selected").attr("aria-selected", "true");
        var button = selectInput.find("button");
        button.val(selectedOption.attr("value"));
        button.find("p").text(selectedOption.text());
    }

    // Close select when resizing window or clicking away from it
    $(window).on("click resize", function() {
        $(".select-input").removeClass("active");
    });
    // Prep all select inputs on page load
    $(".select-input").each(function() {
        selectInputValue($(this), $(this).find("ul li.selected"));
    });
    // Click on button to open select
    $(document).on("click", ".select-input button", function(event) {
        event.stopPropagation();
        $(".select-input").removeClass("active");
        openSelectInput($(this).closest(".select-input"));
    });
    // Click on element to select it
    $(document).on("click", ".select-input ul li", function() {
        selectInputValue($(this).closest(".select-input"), $(this));
    });
    // Key bindings handling
    $(document).on("keyup", ".select-input.active", function(event) {
        // TODO add tab, fix enter to open
        var escapeKey = 27;
        var enterKey = 13;
        var upKey = 38;
        var downKey = 40;
        event.preventDefault();
        if (event.which == enterKey) {
            selectInputValue($(this), $(this).find("ul li:focus"));
            closeSelectInput($(this));
        } else if (event.which == escapeKey) {
            closeSelectInput($(this));
        } else if (event.which == upKey) {
            $(this).find("ul li:focus").prev().focus();
        } else if (event.which == downKey) {
            $(this).find("ul li:focus").next().focus();
        }
    });

    /*****************\
    |   FILE INPUTS   |
    \*****************/

    $(document).on("change", "[type=file]", function() {
        alert("change");
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
        $(this).prop("disabled", true);
    });
    // Enable / disable clear button on page load
    $(".search-bar [type='text']").filter(function() {
        return this.value.length > 0;
    }).parent().find(".clear.btn").prop("disabled", false);
    // Enable / disable clear button on value changed
    $(document).on("change paste keyup", ".search-bar [type='text']", function() {
        if(!$(this).val()) {
            $(this).parent().find(".clear.btn").prop("disabled", true);
        } else {
            $(this).parent().find(".clear.btn").prop("disabled", false);
        }
    });

    // Highlight search bar on text focus
    $(document).on("focus", ".search-bar [type='text']", function() {
        $(this).parent().addClass("focus");
    });
    $(document).on("blur", ".search-bar [type='text']", function() {
        $(this).parent().removeClass("focus");
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

    $(window).on("click resize", function() {
        $(".dropdown").removeClass("active");
    });

    $("[data-toggle='dropdown']").click(function(event) {
        event.stopPropagation();
        var target = $($(this).data("target"));
        if (target.hasClass("active")) {
            target.removeClass("active");
            return;
        }
        $(".dropdown").removeClass("active");
        if (target.hasClass("fixed")) {
            // Get offset relative to viewport
            var offsetX = $(this)[0].getBoundingClientRect().x;
            var offsetY = $(this)[0].getBoundingClientRect().y;
        } else {
            // Get offset relative to parent
            var offsetX = $(this)[0].offsetLeft;
            var offsetY = $(this)[0].offsetTop;
        }
        var x = offsetX + $(this).outerWidth() - target.width();
        var y = offsetY + $(this).outerHeight();
        target.css({ "top": y, "left": x });
        target.addClass("active");
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

});
