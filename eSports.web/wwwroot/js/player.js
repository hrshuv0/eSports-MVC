let dataTable;

$(document).ready(function(){
    $.ajax({
        url:"Admin/players/getAll",
        cache:false,
        method:"GET",
        success:function (response){
            updateDataTable(response.data);
        }
    });
});



function updateDataTable(data)
{
    
}