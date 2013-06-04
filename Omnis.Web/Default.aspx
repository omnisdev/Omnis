<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="Omnis.Web.Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>Omnis Web Client Interface</title>
    <meta name="description" content="" />
    <meta name="author" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="shortcut icon" href="favicon.ico" />
    <link rel="apple-touch-icon" href="apple-touch-icon.png" />
    <link rel="stylesheet" href="Styles/style.css?v=2" />
    <link rel="stylesheet" media="handheld" href="Styles/handheld.css?v=2" />
    <link href="Content/kendo/2013.1.319/kendo.common.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/kendo/2013.1.319/kendo.bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/libs/modernizr-1.7.min.js" type="text/javascript"></script>
    <style>
        html, body, #map-canvas
        {
            height: 100%;
            margin: 10px;
            padding: 0;
        }
    </style>
</head>
<body>
    <div class="k-content">
        <header>
            <div id="header">
                <h1>
                    Omnis Web Client Interface</h1>
                <ul id="mainmenu">
                    <li>Import
                        <ul>
                            <li>Log file</li>
                        </ul>
                    </li>
                </ul>
            </div>
        </header>
    </div>
    <div id="map-canvas">
    </div>
    <footer>This is developed by Omnis Development Philippines. Copyright (c) 2013.</footer>
    <script src="<%= ResolveUrl("~/Scripts/kendo/2013.1.319/jquery.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/kendo/2013.1.319/kendo.core.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/kendo/2013.1.319/kendo.web.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/underscore.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/plugins.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/script.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/App/main.js") %>" type="text/javascript"></script>
    <script src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script>
        // Enable the visual refresh
        google.maps.visualRefresh = true;

        var map;
        function initializeMap() {
            var mapOptions = {
                zoom: 15,
                center: new google.maps.LatLng(14.62057, 120.96597),
                mapTypeId: google.maps.MapTypeId.TERRAIN
            };
            map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
        }
        google.maps.event.addDomListener(window, 'load', initializeMap);

        $(document).ready(function () {
            $("#mainmenu").kendoMenu();
        });
    </script>
</body>
</html>
