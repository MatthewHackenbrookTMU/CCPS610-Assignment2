
function Actions(id) {
    
}

$('#jobtablebody').ready(function () {
    if (!$('div').is('.JobList'))
    {
        return;
    }


    $.ajax({
        url: '/job/alljobs',
        method: 'GET',
        success: function (data) {
            var tableBody = $('#jobtablebody');
            tableBody.empty(); // Clear existing rows

            data.forEach(function (job) {
                var row = `<tr>
                        <td>${job.jobId}</td>
                        <td>${job.jobTitle}</td>
                        <td>${job.minSalary ?? 'N/A'}</td>
                        <td>${job.maxSalary ?? 'N/A'}</td>
                    </tr>`;
                tableBody.append(row);
            });
        },
        error: function () {
            alert('Failed to load jobs.');
        }
    });
});

$('#employeetablebody').ready(function () {
    if (!$('div').is('.EmployeeList')) {
        return;
    }
    $.getScript("/js/employee.js")
        .done(function (script, textStatus) {
            console.log("Script loaded successfully: " + textStatus);
        })
        .fail(function (jqxhr, settings, exception) {
            console.error("Failed to load script: " + exception);
        });
});