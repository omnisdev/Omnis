// This javascript file includes the functionality for Google Maps API.
// Created by Benjamin Fallar III
// Date created on 6/5/2013
var GoogleMap = function (container) {
    var map;
    init = function () {
        var mapOptions = {
            zoom: 15,
            center: new google.maps.LatLng(14.62057, 120.96597),
            mapTypeId: google.maps.MapTypeId.TERRAIN
        };
        map = new google.maps.Map(document.getElementById(container), mapOptions);              
        return map;
    };
    setMark = function(lat, long) {
        // marker options
        var markerOptions = {
            position: new google.maps.LatLng(lat, long),
            map: map
        };
        var marker = new google.maps.Marker(markerOptions);
        marker.setMap(map);
    };
    return {
        Initialize: init,
        SetMarker: setMark
    };
};