$(document).ready(function () {
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