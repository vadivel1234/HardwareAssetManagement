$(document).ready(function () {
    var dataSource = ej.DataManager({
        url: "/account/EmployeeAssets", adaptor: new ej.UrlAdaptor()
    });
    $("#assetGrid").ejGrid({
        dataSource: dataSource,
        columns: [
            { field: "Eid", headerText: "Release Version", template: true, templateID: "#versionPageLink", textAlign: ej.TextAlign.Center },
            { field: "Name", headerText: "Studio Name", width: 0, visible: false },
            { field: "Email", headerText: "Release Date", width: 100, format: "{0:MMM d, yyyy }", textAlign: ej.TextAlign.Center },
            { field: "DateOfJoining", headerText: "General Availability and Patching Support", textAlign: ej.TextAlign.Center },
            { field: "TeamName", headerText: "Developer Support", textAlign: ej.TextAlign.Center },
            { field: "Location", headerText: "Extended Support", textAlign: ej.TextAlign.Center },
            { field: "AssetCount", headerText: "Retired Date", width: 100, textAlign: ej.TextAlign.Center }
        ],
    });
});

function sendRefreshRequest() {
    var gridObj = $("#ProductGrid").data("ejGrid");
    gridObj.refreshContent(false);
}