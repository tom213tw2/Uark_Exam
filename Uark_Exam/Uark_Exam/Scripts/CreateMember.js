$(function (){
    $('#OrgList').on('click',function ()
    {
        let data=  GetAjaxData('Post',false,GetOrdListUrl,null);
        let appendStr='';
        $('tbody').empty();
        $.each(data.responseJSON,function (index,ele){
            appendStr+='<tr>'
            appendStr+=`<td>${ele.Title}</td>`;
            appendStr+=`<td>${ele.OrgNo}</td>`;
            appendStr+=`<td><button class="input btn btn-info" data-title="${ele.Title}" data-id="${ele.Id}">Bridge in</button></td>`;
            appendStr+='</tr>'
        });
        $(appendStr).appendTo('tbody');
        $('#myModal').modal();
    });

    $('tbody').on('click','.input',function (){
        let orgId=$(this).data('id');
        let OrgName=$(this).data('title');
        $('#OrgName').val(OrgName);
        $('#OrgId').val(orgId);
        $('#myModal').modal('hide');
    });

});