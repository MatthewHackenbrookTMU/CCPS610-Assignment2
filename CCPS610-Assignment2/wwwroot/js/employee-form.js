$(document).ready(function () {
    $('.EmployeeForm').ready(function () {
        if (!$('div').is('.EmployeeForm')) {
            return;
        }

        $.ajax({
            url: '/Job/AllJobs',
            method: 'GET',
            success: function (data) {
                var select = $('select#JobId');
                var curVal = select.val(); //.find(":selected").val();
                select.empty();

                data.forEach(function (job) {
                    var option = `<option value="${job.jobId}">${job.jobTitle}</option>`;
                    select.append(option);
                });
                select.val(curVal);
            },
            error: function () {
                alert('Failed to load jobs.');
            }
        });

        $.ajax({
            url: '/employee/AllEmployees',
            method: 'GET',
            success: function (data) {
                var select = $('select#ManagerId');
                var curVal = select.val(); // find(":selected").val();

                select.empty();

                select.append('<option>None</option>');

                data.forEach(function (manager) {
                    var option = `<option value="${manager.employeeId}">${manager.firstName} ${manager.lastName}</option>`;
                    select.append(option);
                });
                select.val(curVal);
            },
            error: function () {
                alert('Failed to load employees.');
            }
        });

        $.ajax({
            url: '/Department/AllDeparments',
            method: 'GET',
            success: function (data) {
                var select = $('select#DepartmentId');
                var curVal = select.val(); // find(":selected").val();

                select.empty();

                select.append('<option>None</option>');

                data.forEach(function (dept) {
                    var option = `<option value="${dept.departmentId}">${dept.departmentName}</option>`;
                    select.append(option);
                });
                select.val(curVal);
            },
            error: function () {
                alert('Failed to load departments.');
            }
        });
    });
});