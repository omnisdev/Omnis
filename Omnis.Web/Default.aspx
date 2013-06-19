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
    <link href="Content/toastr.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/kendo/2013.1.319/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/kendo/2013.1.319/kendo.core.min.js" type="text/javascript"></script>
    <script src="Scripts/kendo/2013.1.319/kendo.web.min.js" type="text/javascript"></script>
    <script src="Scripts/libs/modernizr-1.7.min.js" type="text/javascript"></script>    
    <script src="Scripts/underscore.min.js" type="text/javascript"></script>
    <script src="Scripts/plugins.js" type="text/javascript"></script>
    <script src="Scripts/App/main.js" type="text/javascript"></script>
    <script src="Scripts/App/map.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
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
        <div id="imported-list" class="rectangle-border" data-bind="source: list" 
            data-template="window-item-import-template"
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
            <input type="text" id="ddMapLegend" data-role="dropdownlist" 
                data-option-label="(All)"
                data-bind="source: legendNames, value: legendNameSelectedValue, events: { change: legendNameSelected }" />
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
                        data-bind="source: legendNames, value: legendNameSelectedValue" 
                        required validationMessage="Name is required." />
                    <span class="k-invalid-msg" data-for="newMapLegendName"></span>
                </td>
            </tr>
            <tr>
                <td>
                    Display
                </td>
                <td>
                    <input id="newMapLegendDisplay" name="newMapLegendDisplay" type="text" maxlength="255"
                        class="k-input" data-bind="value: newMapLegendDisplay" required validationMessage="Display is required." />
                    <span class="k-invalid-msg" data-for="newMapLegendDisplay"></span>
                </td>
            </tr>
            <tr>
                <td>
                    Color ID
                </td>
                <td>
                    <input id="newMapLegendColorId" name="newMapLegendColorId" type="text" maxlength="3"
                        class="k-input" data-bind="source: getColorIds, value: newMapLegendColorId" 
                        data-role="dropdownlist" validationMessage="Color ID is required." required />
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
    <%--Color mapping dialog window--%>
    <div id="wndColorMap" class="dialog-window">
        <div id="gridColorMap"></div>
        <p></p>
        <button id="AddColorMapButton" class="k-button">+ Add Color Map</button>&nbsp;
        <button id="RefreshColorMapButton" class="k-button">Refresh</button>&nbsp;
        <button id="CloseColorMapButton" class="k-button">Close</button>      
    </div>
    <%--Add color map dialog window--%>
    <div id="wndColorMap-Add">
        Color name: <input type="text" class="k-input" id="NewColorName"/>
        <p></p>
        RGB: <input type="text" class="k-input" id="NewColorRgb"/>
        <p></p>
        <button id="AddNewColorMapButton" class="k-button">Save</button>&nbsp;        
        <button id="CancelColorMapButton" class="k-button">Cancel</button>
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
    <script type="text/javascript">
        
    </script>
</body>
</html>
