$(document).on('click', '.ripple', function(e) {

	var rippleElement = $('<span class="ripple-effect"></span>');
	var buttonElement = $(this);
	var btnOffset = buttonElement.offset();
	var xPos = e.pageX - btnOffset.left;
	var yPos = e.pageY - btnOffset.top;
	var size = parseInt(Math.min(buttonElement.height(), buttonElement.width()) * 0.5);
	var animateSize = parseInt(Math.max(buttonElement.width(), buttonElement.height()) * Math.PI);

	rippleElement.css({
		top: yPos,
		left: xPos,
		width: size,
		height: size
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