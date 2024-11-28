
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData3').DataTable({
        "ajax": { url: '/admin/parent/getall' },
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'surname', "width": "15%" },
            { data: 'maidenName', "width": "10%" },
            { data: 'personalNo', "width": "10%" },
            {
                data: 'dateOfBirth',
                "width": "10%",
                render: function (data) {
                    if (data) {
                        const date = new Date(data);
                        return date.toLocaleDateString(); 
                    }
                    return '';
                }
            },
            { data: 'gender.alDescription', "width": "10%" },
            {
                data: 'idParent',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/parent/edit?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                     <a onClick=Delete('/admin/parent/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                     <a href="/admin/parent/viewdetails?id=${data}" class="btn btn-info mx-2">
                                <i class="bi bi-eye"></i> View
                            </a>
                    </div>`
                },
                "width": "30%"
            }
        ] 
    });
}


function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}