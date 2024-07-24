$(document).ready(function () {
    $('#employeetablebody').ready(function () {
        if (!$('div').is('.EmployeeList')) {
            return;
        }


        $.ajax({
            url: '/employee/AllEmployees',
            method: 'GET',
            success: function (data) {
                var tableBody = $('#employeetablebody');
                tableBody.empty(); // Clear existing rows

                data.forEach(function (employee) {
                    var row = `<tr>
                        <td>${employee.employeeId}</td>
                        <td>${employee.firstName ?? 'N/A'}</td>
                        <td>${employee.lastName}</td>
                        <td>${employee.email}</td>
                        <td>${employee.phoneNumber ?? 'N/A'}</td>
                        <td>${new Date(employee.hireDate).toLocaleDateString()}</td>
                        <td>${employee.jobId}</td>
                        <td>${employee.salary?.toFixed(2) ?? 'N/A'}</td>
                        <td>${employee.commissionPct?.toFixed(2) ?? 'N/A'}</td>
                        <td>${employee.managerId ?? 'N/A'}</td>
                        <td>${employee.departmentId ?? 'N/A'}</td>
                        <td class="edit-btn"><a href="/Employee/Edit/${employee.employeeId}" class="btn btn-secondary">Edit</a><a style="margin-left: 100px;" href="/Employee/Delete/${employee.employeeId}" class="btn btn-danger">Delete</a></td>
                    </tr>`;
                    tableBody.append(row);
                });
            },
            error: function () {
                alert('Failed to load employees.');
            }
        });
    });
});