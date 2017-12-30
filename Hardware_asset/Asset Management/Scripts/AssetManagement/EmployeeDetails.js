$(document).ready(function () {
    var dataSource = ej.DataManager({
        url: "/account/EmployeeAssets", adaptor: new ej.UrlAdaptor()
    });
    $("#employee-grid").ejGrid({
        dataSource: dataSource,
        columns: [
            { field: "Eid", headerText: "Employee Id", textAlign: ej.TextAlign.Center },
            { field: "Name", headerText: "Name", width: 0 },
            { field: "Email", headerText: "Email", width: 100, textAlign: ej.TextAlign.Center },
            { field: "DateOfJoining", headerText: "Date of Joining", textAlign: ej.TextAlign.Center, format: "{0:MMM d, yyyy }" },
            { field: "AssetTypeName", headerText: "Asset Type", textAlign: ej.TextAlign.Center },
            { field: "TeamName", headerText: "Team Name", textAlign: ej.TextAlign.Center },
            { field: "ReportingPerson", headerText: "Reporting Person", textAlign: ej.TextAlign.Center },
            { field: "Location", headerText: "Location", textAlign: ej.TextAlign.Center }            
        ],
    });
});

function sendRefreshRequest() {
    var gridObj = $("#employee-grid").data("ejGrid");
    gridObj.refreshContent(false);
}