$(document).ready(function() {

    /**************************\
    |   TEXT INPUT, TEXTAREA   |
    \**************************/

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

    /**************\
    |   CHECKBOX   |
    \**************/

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

    /****************\
    |   FILE INPUT   |
    \****************/

    $(document).on("change", "[type=file]", function() {
        var fileCount = $(this).prop("files").length;
        if (fileCount > 0) {
            var countItem = $(this).parent().find(".count")
            countItem.removeClass("d-none");
            if ($(this).attr("multiple") !== undefined) {
                countItem.html(fileCount);
            }
        }
    });

    /****************\
    |   SEARCH BAR   |
    \****************/

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
        var icon = $(this).find(".mdi");
        if (icon.hasClass("mdi-chevron-up")) {
            icon.removeClass("mdi-chevron-up");
            icon.addClass("mdi-chevron-down");
            $(this).attr("title", "Mostra");
        } else {
            icon.removeClass("mdi-chevron-down");
            icon.addClass("mdi-chevron-up");
            $(this).attr("title", "Nascondi");
        }
    });

    /**************\
    |   DROPDOWN   |
    \**************/

    $(window).on("click scroll resize", function() {
        $(".dropdown").removeClass("active");
    });

    $(".dropdown ul li").each(function() {
        var delay = $(this).index() * 50 + "ms";
        $(this).css({
            "-webkit-transition-delay": delay,
            "-moz-transition-delay": delay,
            "-o-transition-delay": delay,
            "transition-delay": delay
        });
    });

    $("[data-toggle='dropdown']").click(function(event) {
        event.stopPropagation();
        $(".dropdown").removeClass("active");
        var target = $($(this).data("target"));
        if (target.hasClass("fixed")) {
            // Get offset relative to viewport
            var offsetX = $(this)[0].getBoundingClientRect().x;
            var offsetY = $(this)[0].getBoundingClientRect().y;
        } else {
            // Get offset relative to document
            var offsetX = $(this).offset().left;
            var offsetY = $(this).offset().top;
        }
        var x = offsetX + $(this).outerWidth() - target.width();
        var y = offsetY + $(this).outerHeight();
        target.css({ "top": y, "left": x });
        target.toggleClass("active");
    });

    $(".dropdown").click(function(event) {
        event.stopPropagation();
    });

});
