var GoogleMap = function(container) {
    var map;
    init = function() {
        var mapOptions = {
            zoom: 15,
            center: new google.maps.LatLng(14.62057, 120.96597),
            mapTypeId: google.maps.MapTypeId.TERRAIN
        };
        map = new google.maps.Map(document.getElementById(container), mapOptions);

        // marker options
        var markerOptions = {
            position: new google.maps.LatLng(14.62057, 120.96597),
            map: map
        };

        var marker = new google.maps.Marker(markerOptions);
        marker.setMap(map);
        return map;
    };
    return {
        initialize: init
    };
};