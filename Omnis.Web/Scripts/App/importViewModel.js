//
// This is the viewModel for consumption on import dialog window.
var ImporterViewModel = kendo.observable({
    list: new kendo.data.ObservableArray([{}]),
    showClearDisplay: "none",
    showProcessDisplay: "none",
    selectButtonId: null,
    init: function (selectButtonId) {
        var currObj = this;
        currObj.selectButtonId = selectButtonId;
        currObj.list.bind("change", function (e) {
            if (e.items.length > 0) {
                currObj.set("showClearDisplay", "");
                currObj.set("showProcessDisplay", "");
            }
        });
    },
    add: function () {
        var currObj = this;
        currObj.selectButtonId.trigger("click");
    },
    remove: function (e) {
        var currObj = this;
        var name = e.data.name;
        var items = currObj.list;
        var index = -1;
        for (var i = 0; i < items.length; i++) {
            var itemName = items[i].name;
            if (_.isEqual(itemName, name)) {
                index = i;
                break;
            }
        }
        if (index > -1) {
            currObj.list.splice(index, 1);
            if (_.size(currObj.list) == 0) {
                currObj.set("showClearDisplay", "none");
                currObj.set("showProcessDisplay", "none");
            }
        }
    },
    clear: function () {
        var currObj = this;
        currObj.list.splice(0, this.list.length);
        currObj.set("showClearDisplay", "none");
        currObj.set("showProcessDisplay", "none");
    },
    process: function () {
        toastr.info("Processing of data is now in queue...", "Queue");
    },
    exists: function (nameItem) {
        var currObj = this;
        var foundItem = _.findWhere(currObj.list, { name: nameItem });
        return foundItem != null;
    }
});

kendo.bind($("#wndImport"), ImporterViewModel);
ImporterViewModel.init($("#selectFile"));
