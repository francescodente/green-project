$(document).ready(function() {

    /**************************\
    |   TEXT INPUT, TEXTAREA   |
    \**************************/

    // Label management
    $(".text-input input, textarea").filter(function() {
        return this.value.length > 0;
    }).addClass("has-value");
    $(".text-input input, textarea").blur(function() {
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
    $(".checkbox.toggle-all").click(function() {
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
    // On checkbox click
    $(".checkbox:not(.toggle-all)").click(function() {
        toggle = $(this).data("toggled-by");
        checkboxToggleCheck(toggle);
    });
    // On page load
    $(".checkbox[data-toggled-by]").each(function() {
        checkboxToggleCheck($(this).data("toggled-by"));
    });

    /****************\
    |   FILE INPUT   |
    \****************/

    $("[type=file]").change(function() {
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
    $(".search-bar .clear.btn").click(function() {
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
    $(".search-bar [type='text']").on("change paste keyup", function() {
        if(!$(this).val()) {
            $(this).parent().find(".clear.btn").prop("disabled", true);
        } else {
            $(this).parent().find(".clear.btn").prop("disabled", false);
        }
    });

    // Highlight search bar on text focus
    $(".search-bar [type='text']").focus(function() {
        console.log("focus");
        $(this).parent().addClass("focus");
    });
    $(".search-bar [type='text']").blur(function() {
        console.log("blur");
        $(this).parent().removeClass("focus");
    });

    /**************\
    |   COLLAPSE   |
    \**************/

    $("[data-toggle='collapse']").click(function() {
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

});
