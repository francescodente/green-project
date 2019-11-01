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

});
