$(document).on("click", ".ripple", function(e) {

    var rippleElement = $("<span class='ripple-effect'></span>");
    var buttonElement = $(this);
    var btnOffset = buttonElement.offset();
    var xPos = e.pageX - btnOffset.left;
    var yPos = e.pageY - btnOffset.top;
    var animateSize = parseInt(Math.max(buttonElement.outerWidth(), buttonElement.outerHeight()) * Math.PI);

    rippleElement.css({
        top: yPos,
        left: xPos,
        width: 0,
        height: 0
    })
    .appendTo(buttonElement)
    .animate({
        width: animateSize,
        height: animateSize,
        opacity: 0
    }, 700, function() {
        $(this).remove();
    });
});