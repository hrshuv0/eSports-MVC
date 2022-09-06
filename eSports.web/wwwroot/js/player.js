let dataTable;

$(document).ready(function(){
    $.ajax({
        url:"players/getAll",
        cache:false,
        method:"GET",
        success:function (response){
            updateDataTable(response.data);
        }
    });
});



function updateDataTable(data)
{
    alert("load data table working!")
    console.log(data)
    
    dataTable = $('#playerTableId').DataTable({
        "bDestroy":true,
        data:data,
        "columns":[
            {"data":"userName", "sDefaultContent":"" },
            {"data":"gameId", "sDefaultContent":"" },
            {"data":"email", "sDefaultContent":"" },
            {"data":"city", "sDefaultContent":"" },
            {"data":"phoneNumber", "sDefaultContent":"" }
        ]
        
        }        
    );
    
}