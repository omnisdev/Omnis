//
// view model for map legend.
var MapLegendViewModel = new kendo.observable({
    list: new kendo.data.ObservableArray([{}]),
    listBySelectedName: new kendo.data.ObservableArray([{}]),
    mapGrid: null,
    selectedName: null,
    newMapLegendName: null,
    newMapLegendDisplay: null,
    newMapLegendColorId: null,
    newMapLegendDialogDiv: null,
    init: function (gridDiv, newMapDialogDiv) {
        var currObj = this;
        mapGrid = gridDiv;
        newMapLegendDialogDiv = newMapDialogDiv;
        // mock data only...
        var data = [
                    { Id: 0, Name: "Signal Bar", ColorId: 2, Display: "1 <= Signal bar < 0", RGB: "0,0,255", ColorName: "Blue" },
                    { Id: 1, Name: "Signal Bar", ColorId: 2, Display: "1 <= Signal bar < 0", RGB: "0,125,255", ColorName: "Blue" },
                    { Id: 2, Name: "Signal Bar", ColorId: 2, Display: "1 <= Signal bar < 0", RGB: "125,0,255", ColorName: "Blue" },
                    { Id: 3, Name: "Signal", ColorId: 2, Display: "1 <= Signal bar < 0", RGB: "0,0,255", ColorName: "Blue" },
                    { Id: 4, Name: "Signal", ColorId: 2, Display: "1 <= Signal bar < 0", RGB: "0,0,255", ColorName: "Blue" },
                    { Id: 5, Name: "Technology", ColorId: 2, Display: "1 <= Signal bar < 0", RGB: "0,0,255", ColorName: "Blue" },
                    { Id: 6, Name: "Technology", ColorId: 2, Display: "1 <= Signal bar < 0", RGB: "0,0,255", ColorName: "Blue" },
                    { Id: 7, Name: "DL Throughput", ColorId: 2, Display: "1 <= Signal bar < 0", RGB: "0,0,255", ColorName: "Blue" },
                    { Id: 8, Name: "DL Throughput", ColorId: 2, Display: "1 <= Signal bar < 0", RGB: "0,0,255", ColorName: "Blue" },
                    { Id: 9, Name: "UL Throughput", ColorId: 2, Display: "1 <= Signal bar < 0", RGB: "0,0,255", ColorName: "Blue" }
                ];
        this.set("list", data);
        if (currObj.get("selectedName") == null) {
            currObj.set("listBySelectedName", currObj.get("list"));
        }
        // when the list is updated, also re-filter the data.
        currObj.list.bind("change", function (e) {
            if (e.items.length > 0) {
                var filteredList = _.where(currObj.get("list"), { Name: currObj.get("selectedName") });
                currObj.set("listBySelectedName", filteredList);
            }
        });
    },
    legendNames: function () {
        var legends = _.pluck(this.get("list"), "Name");
        return _.sortBy(_.uniq(legends), function (item) { return item; });
    },
    legendNameSelected: function (e) {
        var currObj = this;
        var selectedItem = e.sender._selectedValue;
        var filteredList = _.where(currObj.get("list"), { Name: selectedItem });
        currObj.set("listBySelectedName", filteredList);
        currObj.set("selectedName", selectedItem);
    },
    getColorIds: function () {
        // generate mock color ids.
        var colors = [];
        for (var i = 0; i < 60; i++) {
            colors.push(i.toString());
        }
        return colors;
    },
    addMapLegend: function () {
        var currObj = this;
        var name = currObj.get("newMapLegendName");
        var display = currObj.get("newMapLegendDisplay");
        var colorid = currObj.get("newMapLegendColorId");
        if (validator.validate()) {
            // add new mock data.
            currObj.list.push({ Id: 10, Name: name, ColorId: colorid, Display: display, RGB: "0,0,0", ColorName: "Black" });
            toastr.info("New map legend has been successfully created.", "New Map Legend");
            if (newMapLegendDialogDiv != null) {
                newMapLegendDialogDiv.data("kendoWindow").close();
            }
        }
    }
});

kendo.bind($("#wndMapLegend"), MapLegendViewModel);
kendo.bind($("#wndMapLegendAddNew"), MapLegendViewModel);
MapLegendViewModel.init($("#gridMapLegend"), $("#wndMapLegendAddNew"));

var validator = $("#wndMapLegendAddNew").kendoValidator().data("kendoValidator");