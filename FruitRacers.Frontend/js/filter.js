$(document).ready(function() {

    // Filter toggle click handling
    $(".toggle-filters").click(function() {
        if ($("#filters-col").hasClass("d-none")) {
            // Show filters
            $(this).find(".mdi").removeClass("mdi-filter");
            $(this).find(".mdi.d-lg-block").addClass("mdi-chevron-left");
            $(this).find(".mdi.d-lg-none").addClass("mdi-chevron-up");
            $(this).attr("title", "Nascondi filtri");
            $(".toggle-filters-label").html("Nascondi filtri");
            $("#filters-col").removeClass("d-none");
            $("#results-col").addClass("col-lg-9");
            $(".card.product:not([data-class])").parent().removeClass("col-lg-3");
        } else {
            // Hide filters
            $(this).find(".mdi.d-lg-block").removeClass("mdi-chevron-left");
            $(this).find(".mdi.d-lg-none").removeClass("mdi-chevron-up");
            $(this).find(".mdi").addClass("mdi-filter");
            $(this).attr("title", "Mostra filtri");
            $(".toggle-filters-label").html("Mostra filtri");
            $("#filters-col").addClass("d-none");
            $("#results-col").removeClass("col-lg-9");
            $(".card.product:not([data-class])").parent().addClass("col-lg-3");
        }
    });

});