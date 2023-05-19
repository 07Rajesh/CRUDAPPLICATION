// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


   
 $(function () {

   
});


function GetEmployees() {
    apiCallAjax("Employee/GetEmployees", null, "GET", true, function (result) {

        console.log(result)
        $('#tblEmployees').dat;
       /* $('#tblEmployees')({
            "paging": true,
            "lengthChange": false,
            "searching": true,
            "ordering": true,
            "info": true,
            "autoWidth": false,
            "responsive": true,
            "data": result.data,
            "columns": [
                { "data": "id" },

            ]
        });*/

       
    })
}