function init() {
    var map = new google.maps.Map(document.getElementById('map'), {
        // Map settings
        zoom: 17,
        center: new google.maps.LatLng(53.070843, 8.800274),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });
}

// Style
var styles = [
    {
        featureType: "all",
        elementType: "labels",
        stylers: [
            { visibility: "off" }
        ]
    }
];

$(document).ready(function() {

    google.maps.event.addDomListener(window, 'load', init);

    // Set style
    map.setOptions({styles: styles});
});
