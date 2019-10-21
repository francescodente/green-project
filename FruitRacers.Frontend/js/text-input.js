$(document).ready(function() {

    $(".text-input input, textarea").filter(function () {
        return this.value.length > 0;
    }).addClass("has-value");

    $(".text-input input, textarea").blur(function () {
        if(!this.value) {
            $(this).removeClass("has-value");
        } else {
            $(this).addClass("has-value");
        }
    });

});
