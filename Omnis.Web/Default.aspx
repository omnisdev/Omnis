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
            //
            // initialize the google map.
            google.maps.visualRefresh = true;
            google.maps.event.addDomListener(window, 'load', initialize);

            //
            // initialize the kendo declarative widgets.
            kendo.init($("body"));

            //
            // initialize the kendo menu.
            $("#mainmenu").kendoMenu({
                select: function (e) {
                    var selectedMenu = $(e.item).find("span").text();
                    if (selectedMenu === "Map Legend") {
                        $("#splitter").data("kendoSplitter").toggle("#left-pane");
                    }
                    else if (selectedMenu === "Import Data") {
                        var windowImport = $("#wndImport");
                        if (!windowImport.data("kendoWindow")) {
                            windowImport.kendoWindow({
                                width: "400px",
                                modal: true,
                                resizable: false,
                                title: "Import Log files",
                                open: function (e) {
                                    ImporterViewModel.clear();
                                }
                            });
                        }
                        windowImport.data("kendoWindow").open().center();
                    }
                    else if (selectedMenu === "Map Legend Settings") {
                        var windowMapLegend = $("#wndMapLegend");
                        if (!windowMapLegend.data("kendoWindow")) {
                            windowMapLegend.kendoWindow({
                                width: "600px",
                                modal: true,
                                resizable: false,
                                title: "Map Legend Settings"
                            });
                        }
                        windowMapLegend.data("kendoWindow").open().center();
                    }
                }
            });

            // 
            // initialize the kendo splitter.
            var splitter = $("#splitter").kendoSplitter({
                orientation: "horizontal",
                panes: [
                    { collapsible: true, size: "150px" },
                    { collapsible: false }
                ]
            }).data("kendoSplitter");

            //
            // initially collapse the left pane in the splitter.
            splitter.collapse("#left-pane");

            //
            // initialize the legend bars.
            $("#panelbar").kendoPanelBar({
                expandMode: "single"
            });

            // 
            // register click handler for hiding map legend pane.
            $("#hide-map-legend").click(function (e) {
                $("#splitter").data("kendoSplitter").collapse("#left-pane");
            });

            //
            // client side handler to close the import window.
            $("#window-close-import").click(function (e) {
                $("#wndImport").data("kendoWindow").close();
            });

            //
            // client side handler to close the dialog for map legend.
            $("#wndMapLegend-close-button").click(function (e) {
                $("#wndMapLegend").data("kendoWindow").close();
            });

            //
            // client side handler when selecting file in file dialog.
            // this depends on importViewModel.
            $("#selectFile").change(function (e) {
                var selectedFile = $(this).val();
                if (!_.isEmpty(selectedFile)) {
                    if (ImporterViewModel.exists(selectedFile)) {
                        toastr.warning("The selected import file already exists in list.", "Warning");
                    }
                    else {
                        var item = new Object();
                        item.name = selectedFile;
                        ImporterViewModel.list.push(item);
                    }
                }
            });

            //
            // client side handler when adding new map legend.
            $("#wndMapLegend-add-button").click(function (e) {
                var windowNewAddMap = $("#wndMapLegendAddNew");
                if (!windowNewAddMap.data("kendoWindow")) {
                    windowNewAddMap.kendoWindow({
                        width: "400px",
                        modal: true,
                        resizable: false,
                        title: "Add New Map Legend",
                        open: function () {
                            MapLegendViewModel.set("newMapLegendName", MapLegendViewModel.get("selectedName"));
                            MapLegendViewModel.set("newMapLegendDisplay", null);
                            MapLegendViewModel.set("newMapLegendColorId", null);
                        }
                    });
                }
                windowNewAddMap.data("kendoWindow").open().center();
            });

            //
            // client side handler to close the add new map dialog window.
            $("#wndMapLegendAddNew-close-button").click(function (e) {
                $("#wndMapLegendAddNew").data("kendoWindow").close();
            });
        });

        //
        // initialize the goolge map in the browser.
        function initialize() {
            toastr.info("Loading map in progress...", "Map");
            var mapDiv = document.getElementById("map-canvas");
            map = new GoogleMap(mapDiv);
            map.Initialize();
            map.SetMarker(14.62057, 120.96597);
        }              
    </script>
    <style type="text/css">
        
    </style>
</head>
<body>
    <div id="header">
        <header>
            <h1>
                Omnis Web Client Interface</h1>
        </header>
        <ul id="mainmenu">
            <li>File
                <ul>
                    <li>Import Data</li>
                    <li>Configuration
                        <ul>
                            <li>Color Mapping Options</li>
                            <li>Map Legend Settings</li>
                        </ul>
                    </li>
                </ul>
            </li>
            <li>Views
                <ul>
                    <li>Map Legend</li>
                    <li>Queue</li>
                </ul>
            </li>
        </ul>
    </div>
    <div id="splitter">
        <div id="left-pane">
            <div class="left-content">
                <div class="rectangle" id="hide-map-legend">
                    Map Legend</div>
                <div id="organizer">
                    <ul id="panelbar">
                        <li class="k-state-active"><span class="k-link k-state-selected">Signal Bar</span>
                        </li>
                        <li>Signal</li>
                        <li>DL Throughput</li>
                        <li>UL Throughtput</li>
                        <li>Technology</li>
                    </ul>
                    <div id="bottom">
                    </div>
                </div>
            </div>
        </div>
        <div id="center-pane">
            <div class="map-content">
                <div id="map-canvas">
                </div>
            </div>
        </div>
    </div>
    <div class="k-content">
        <footer>This is developed by Omnis Development Philippines. Copyright (c) 2013.</footer></div>
    <%--Define various dialog windows here--%>
    <%--Import data dialog window--%>
    <div id="wndImport" class="dialog-window">
        <div>
            Select iPhone log file(s) to import (*.csv).</div>
        <br />
        <div id="imported-list" class="rectangle-border" data-bind="source: list" data-template="window-item-import-template"
            data-role="listview">
        </div>
        <br />
        <div>
            <button id="window-clear-import" class="k-button" data-bind="click: clear, style: { display: showClearDisplay }">
                Clear</button>
            <button id="window-browse-import" class="k-button" data-bind="click: add">
                Browse...</button>
            <button id="window-process-import" class="k-button" data-bind="click: process, style: { display: showProcessDisplay }">
                Process</button>
            <button id="window-close-import" class="k-button">
                Close</button>
            <input id="selectFile" type="file" style="display: none;" />
        </div>
    </div>
    <%--Map legend dialog window definition--%>
    <div id="wndMapLegend" class="dialog-window">
        <div>
            <span>Select Map Legend:</span>&nbsp;
            <input type="text" id="ddMapLegend" data-role="dropdownlist" data-bind="source: legendNames, events: { change: legendNameSelected }" />
            <p>
            </p>
            <table data-role="grid" id="gridMapLegend">
                <thead>
                    <tr>
                        <th>
                            Name
                        </th>
                        <th>
                            Display
                        </th>
                        <th>
                            Color ID
                        </th>
                        <th>
                            Color
                        </th>
                    </tr>
                </thead>
                <tbody data-template="grid-map-legend-rowTemplate" data-bind="source: listBySelectedName">
                </tbody>
            </table>
            <p>
            </p>
            <button id="wndMapLegend-add-button" class="k-button">
                + Add New Map Legend</button>
            <button id="wndMapLegend-close-button" class="k-button">
                Close</button>
        </div>
    </div>
    <%--Add new Map legend dialog window--%>
    <div id="wndMapLegendAddNew" class="dialog-window">
        <table class="tableForm">
            <tr>
                <td>
                    Name
                </td>
                <td>
                    <input id="newMapLegendName" name="newMapLegendName" type="text" data-role="dropdownlist"
                        data-bind="source: legendNames, value: newMapLegendName" required validationmessage="Name is required." />
                    <span class="k-invalid-msg" data-for="newMapLegendName"></span>
                </td>
            </tr>
            <tr>
                <td>
                    Display
                </td>
                <td>
                    <input id="newMapLegendDisplay" name="newMapLegendDisplay" type="text" maxlength="255"
                        class="k-input" data-bind="value: newMapLegendDisplay" required validationmessage="Display is required." />
                    <span class="k-invalid-msg" data-for="newMapLegendDisplay"></span>
                </td>
            </tr>
            <tr>
                <td>
                    Color ID
                </td>
                <td>
                    <input id="newMapLegendColorId" name="newMapLegendColorId" type="text" maxlength="3"
                        class="k-input" data-bind="source: getColorIds, value: newMapLegendColorId" data-role="dropdownlist"
                        validationmessage="Color ID is required." required />
                    <span class="k-invalid-msg" data-for="newMapLegendColorId"></span>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <button class="k-button" data-bind="click: addMapLegend">
                        Create</button>&nbsp;
                    <button class="k-button" id="wndMapLegendAddNew-close-button">
                        Close</button>
                </td>
            </tr>
        </table>
    </div>
    <%--Define various HTML templates here--%>
    <%--Template for import items--%>
    <script type="text/x-kendo-template" id="window-item-import-template">
        <div style="white-space:nowrap;display:inline-block;padding:3px;">
            <button data-bind="click: remove" class="k-button">Remove</button>&nbsp;<span data-bind="text: name"></span>    
        </div>    
    </script>
    <%--Template for map legend row--%>
    <script type="text/x-kendo-template" id="grid-map-legend-rowTemplate">
        <tr data-uid="#= uid #">
            <td>
                <img src="Content/icon_edit_small.png" class="icon-small" title="Edit" />&nbsp;
                <img src="Content/icon_delete_small.png" class="icon-small" title="Delete" />
                <strong>#: kendo.toString(get("Name")) #</strong>
            </td>
            <td data-bind="text: Display"></td>
            <td data-bind="text: ColorId"></td>
            <td>
                <div style='height:12px;width:12px;border:1px;background-color:rgb(#: kendo.toString(get("RGB")) #);'
                    title='#: kendo.toString(get("ColorName")) #'></div>
            </td>
        </tr>
    </script>
    <script src="Scripts/toastr.min.js" type="text/javascript"></script>
    <script src="Scripts/App/importViewModel.js" type="text/javascript"></script>
    <script src="Scripts/App/mapLegendViewModel.js" type="text/javascript"></script>
    <script>
        
    </script>
</body>
</html>
