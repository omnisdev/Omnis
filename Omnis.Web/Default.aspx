<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="Omnis.Web.Default" %>

<%@ Import Namespace="System.Web.Optimization" %>
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
    <%: Styles.Render("~/bundle/css") %>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"> 
    </script>
    <%: Scripts.Render("~/bundle/js") %>
    <script type="text/javascript">
        var map;
        $(document).ready(function () {
            $("#mainmenu").kendoMenu();

            google.maps.visualRefresh = true;
            google.maps.event.addDomListener(window, 'load', initialize);
        });

        //
        // initialize the goolge map in the browser.
        function initialize() {
            var mapDiv = document.getElementById("map-canvas");
            map = new GoogleMap(mapDiv);
            map.Initialize();
            map.SetMarker(14.62057, 120.96597);
        }
    </script>
</head>
<body>
    <div class="k-content">
        <header>
            <div id="header">
                <h1>
                    Omnis Web Client Interface</h1>
                <ul id="mainmenu">
                    <li>File
                        <ul>
                            <li>New Project</li>
                            <li>Open Project</li>
                            <li>Import Data</li>
                        </ul>
                    </li>
                    <li>View
                        <ul>
                            <li>Map Legend</li>
                            <li>BTS</li>
                            <li>CEL</li>
                            <li>Call Trace</li></ul>
                    </li>
                </ul>
            </div>
        </header>
    </div>
    <div id="map">
        <div id="map-canvas">
        </div>
    </div>
    <div class="k-content">
        <footer>This is developed by Omnis Development Philippines. Copyright (c) 2013.</footer></div>
</body>
</html>
