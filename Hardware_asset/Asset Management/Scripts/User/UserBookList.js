$(document).ready(function () {
    UserBookGrid();
});

function UserBookGrid() {
    $("#userbookcollection").ejGrid({
        dataSource: bookdetailsList,
        allowSelection: false,
        allowSorting: true,
        contextMenuSettings: { enableContextMenu: false },
        allowFiltering: true,
        filterSettings: { filterType: "excel" },
        allowResizing: true,
        allowEditing: false,
        allowScrolling: false,
        enableTouch: false,
        load: window.GridToolTipBehavior,
        enableAltRow: true,
        allowPaging: true,
        pageSettings: { pageSize: 50 },
        actionBegin: function (args) {
            if (args.requestType == "filtering" && args.currentFilterObject[0].operator == "startswith")
                args.currentFilterObject[0].operator = "contains";
            this.model.query._params.push({ key: "$id", value: "" });
        },
        actionComplete: function (args) {
            if (args.model.currentViewData != null && args.model.currentViewData.length != 0) {
                $("#userbook-export").css("display", "block");
            }
            else {
                $("#userbook-export").css("display", "none");
            }
        },
        columns: [
                { field: "BookId", headerText: "Book ID", width: 32 },
                { headerText: "Book Name", field: "BookName", width: 45 },
                { headerText: "Book Category", field: "BookCategory", width: 32 },
                { headerText: "Author", field: "BookAuthor", width: 35 },
                { headerText: "Published", field: "Published", width: 35 },
                { headerText: "ISBN No", field: "ISBNNO", width: 35 },
                { headerText: "Total No of Copies", field: "NoOfCopies", width: 35 },
                { headerText: "Available Copies", field: "AvailableCopies", width: 34 },
                { headerText: "Book Review Link", field: "BookReviewLink", width: 34 },
                { headerText: "Action", width: 34 },
        ],
    });
}
