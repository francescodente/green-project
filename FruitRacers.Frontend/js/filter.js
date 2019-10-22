$(document).ready(function() {

    // Filter toggle click handling
    $(".toggle-filters").click(function() {
        if ($("#filters-col").hasClass("d-none")) {
            $(this).find(".mdi").removeClass("mdi-filter");
            $(this).find(".mdi").addClass("mdi-chevron-left");
            $(this).attr("title", "Nascondi filtri");
            $("#filters-col").removeClass("d-none");
            $("#results-col").removeClass("col-12");
            $("#results-col").addClass("col-9");
            $(".product-card").parent().removeClass("col-md-4 col-lg-3");
            $(".product-card").parent().addClass("col-lg-4");
        } else {
            $(this).find(".mdi").removeClass("mdi-chevron-left");
            $(this).find(".mdi").addClass("mdi-filter");
            $(this).attr("title", "Mostra filtri");
            $("#filters-col").addClass("d-none");
            $("#results-col").removeClass("col-9");
            $("#results-col").addClass("col-12");
            $(".product-card").parent().removeClass("col-lg-4");
            $(".product-card").parent().addClass("col-md-4 col-lg-3");
        }
    });

});