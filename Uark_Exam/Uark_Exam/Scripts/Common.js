function GetDataWithNoServerSide(tableId) {
    $("#" + tableId).DataTable({
        "dom": "<'row'<'col-sm-6'B><'col-sm-6 text-right'l>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",    
        "stateSave": true,
        "searching": false,
        "processing": true,
        "pageLength": 20,      
        "lengthChange": true,
        "lengthMenu": [[10, 15, 20, 50], [10, 15, 20, 50]],        
        "order": [0, "asc"],
        buttons: [
            'colvis','copy','csv', 'excel', 'pdf','print'
        ],
        //"ordering": false,       
        "initComplete": function () {

        }
    });   
}
function GetAjaxData(type, async, url, data) {
    //let returnObj;
    let _data = JSON.stringify(data);
    return $.ajax({
        type: type,
        async: async,
        url: url,
        data: _data,
        contentType: 'application/json; charset=UTF-8',
        dataType: "json"
    });
    //return returnObj;
}

$(function () {
    $('.datepicker').parent().addClass('input-group picker');
    $('.datepicker').after('<span class="input-group-addon">' +
        '<span class= "glyphicon glyphicon-calendar" ></span >' +
        ' </span >');
    $('.datepicker').attr('readonly','readonly')
    $('.picker').datetimepicker({
        locale: 'zh-tw',
        format: 'YYYY/MM/DD',
        showTodayButton: true,
        widgetPositioning: {
            horizontal: 'right',
            vertical: 'bottom'
        },
        showClear: true,
        ignoreReadonly: true

    });

});

