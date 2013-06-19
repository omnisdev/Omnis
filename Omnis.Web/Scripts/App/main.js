/// <reference path="../jquery-1.9.1-vsdoc.js" />
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
            else if (selectedMenu === "Color Mapping Options") {
                var windowColorMap = $("#wndColorMap");
                if (!windowColorMap.data("kendoWindow")) {
                    windowColorMap.kendoWindow({
                        width: "600px",
                        modal: true,
                        resizable: false,
                        title: "Color Mapping Options",
                        open: windowColorMapOpened
                    });
                }
                windowColorMap.data("kendoWindow").open().center();
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
        e.preventDefault();
        $("#wndImport").data("kendoWindow").close();
    });

    //
    // client side handler to close the dialog for map legend.
    $("#wndMapLegend-close-button").click(function (e) {
        e.preventDefault();
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
        e.preventDefault();
        var windowNewAddMap = $("#wndMapLegendAddNew");
        if (!windowNewAddMap.data("kendoWindow")) {
            windowNewAddMap.kendoWindow({
                width: "400px",
                modal: true,
                resizable: false,
                title: "Add New Map Legend",
                open: function () {
                    MapLegendViewModel.set("newMapLegendName", MapLegendViewModel.get("legendNameSelectedValue"));
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
        e.preventDefault();
        $("#wndMapLegendAddNew").data("kendoWindow").close();
    });

    //
    // client side click handler for CloseColorMapButton
    $("#CloseColorMapButton").click(function (e) {
        e.preventDefault();
        $("#wndColorMap").data("kendoWindow").close();
    });

    //
    // client side click handler for AddColorMapButton
    $("#AddColorMapButton").click(function (e) {
        e.preventDefault();
        var wndAddNewColorMap = $("#wndColorMap-Add");
        if (!wndAddNewColorMap.data("kendoWindow")) {
            wndAddNewColorMap.kendoWindow({
                width: "400px",
                modal: true,
                resizable: false,
                title: "Add New Color Map",
                open: function () {
                }
            });
        }
        wndAddNewColorMap.data("kendoWindow").open().center();
    });

    //
    // click handler for CancelColorMapButton
    $("#CancelColorMapButton").click(function (e) {
        e.preventDefault();
        $("#wndColorMap-Add").data("kendoWindow").close();
    });

    //
    // click handler for AddNewColorMapButton
    $("#AddNewColorMapButton").click(function (e) {
        e.preventDefault();
        var name = $("#NewColorName").val();
        var rgb = $("#NewColorRgb").val();
        var arr = rgb.split(",");
        var item = {};
        item.Name = name;
        item.R = arr[0];
        item.G = arr[1];
        item.B = arr[2];

        $.ajax({
            url: 'api/ColorMap/Add',
            type: 'POST',
            dataType: 'json',
            contentType: "application/json",
            data: JSON.stringify(item),
            beforeSend: function () {
                toastr.info("Creating new color map...", "New Color Map");
            },
            success: function (data) {
                toastr.success("New color map has been successfully created.", "New Color Map");
                $("#wndColorMap-Add").data("kendoWindow").close();
            },
            error: function (x, y, z) {
                toastr.error("Failed to create a new color map.", "New Color Map");
            }
        });
    });

    //
    // click handler for RefreshColorMapButton
    $("#RefreshColorMapButton").click(function (e) {
        e.preventDefault();
        toastr.info("Refeshing color map data...");
        colorMapDatasource.read();
        //$("#gridColorMap").data("kendoGrid").refresh();
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

var colorMapDatasource;

function windowColorMapOpened(e) {
    colorMapDatasource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "api/ColorMap/Get",
                dataType: "json"
            }
        },
        pageSize: 10,
        serverPaging: false,
        serverSorting: false
    });

    if ($("#gridColorMap").data("kendoGrid")) {
        $("#gridColorMap").data("kendoGrid").destroy();
    }
    $("#gridColorMap").kendoGrid({
        dataSource: colorMapDatasource,
        selectable: "row",
        pageable: true,
        sortable: true
    });
}