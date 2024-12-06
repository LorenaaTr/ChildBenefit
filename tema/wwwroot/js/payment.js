var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData4').DataTable({
        "ajax": { url: '/admin/payment/getall' },
        "columns": [
            {
                data: 'paymentDate',
                width: '15%',
                render: function (data) {
                    if (data) {
                        const date = new Date(data);
                        const day = String(date.getDate()).padStart(2, '0');
                        const month = String(date.getMonth() + 1).padStart(2, '0');
                        const year = date.getFullYear();
                        return `${day}/${month}/${year}`; // Format to DD/MM/YYYY
                    }
                    return '';
                }
            },
            { data: 'amount', "width": "15%" },
            { data: 'parent.personalNo', "width": "15%" },
            { data: 'parent.name', "width": "15%" },
            {
                data: 'idPayment',
                render: function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/admin/payment/viewdetails?id=${data}" class="btn btn-info mx-2">
                                <i class="bi bi-eye"></i> Shiko
                            </a>
                        </div>`;
                },
                "width": "15%"
            },
            {
                data: null, // This is for the "Pay Now" form column
                render: function (data, type, row) {
                    // Only display the form if parentId is available
                    if (row && row.parent && row.parent.idParent) {
                        return `
                            <form method="post" action="/Admin/Payment/CreateCheckoutSession" class="d-inline-block">
                                <input type="hidden" name="parentId" value="${row.parent.idParent}" />
                                <button type="submit" class="btn btn-primary">Pay Now</button>
                            </form>`;
                    }
                    return ''; // Return an empty string if no parentId is available
                },
                "width": "15%"
            }
        ]
    });
}
