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
    <%: Scripts.Render("~/bundle/js") %>
    <script src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript">
        var map;
        $(document).ready(function () {
            $("#mainmenu").kendoMenu();
            google.maps.event.addDomListener(window, 'load', initialize);
        });        
        
        function initialize() {
            map = new GoogleMap('map-canvas');
            map.Initialize();
            map.SetMarker(14.62057, 120.96597);
        }
    </script>
</body>
</html>
