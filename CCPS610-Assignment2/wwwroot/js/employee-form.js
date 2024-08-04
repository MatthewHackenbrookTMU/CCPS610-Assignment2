function PopulateJobs() {
    $.ajax({
        url: '/Job/AllJobs',
        method: 'GET',
        success: function (data) {
            var select = $('select#JobId');
            var curVal = select.val(); //.find(":selected").val();
            select.empty();

            data.forEach(function (job) {
                var option = `<option value="${job.jobId}">${job.jobId} - ${job.jobTitle}</option>`;
                select.append(option);
            });
            select.val(curVal);
        },
        error: function () {
            alert('Failed to load jobs.');
        }
    });
}

function PopulateManagers() {
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
}

function PopulateDepartments() {
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
}

function EnforceEditRestrictions() {
    $('.non-editable').each(function () {
        var field = $(this);
        field.attr('readonly', 'readonly');
    });
}

$(document).ready(function () {
    $('.EmployeeForm').ready(function () {
        if (!$('div').is('.EmployeeForm')) {
            return;
        }

        var id = $('#employeeId').val();
        console.log(id);

        if (id > 0)
        {
            EnforceEditRestrictions();
        }

        PopulateJobs();
        PopulateManagers();
        PopulateDepartments();

    });
});