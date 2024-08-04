$(document).ready(function () {
    $('#jobTableBody').ready(function () {
        if (!$('div').is('.JobList')) {
            return;
        }

        var loadingSpinner = $('#jobTableLoadingSpinner');
        loadingSpinner.show();

        $.ajax({
            url: '/job/alljobs',
            method: 'GET',
            success: function (data) {
                var tableBody = $('#jobTableBody');
                tableBody.empty(); // Clear existing rows

                data.forEach(function (job) {
                    var row = `<tr>
                        <td>${job.jobId}</td>
                        <td>${job.jobTitle}</td>
                        <td>${job.minSalary ?? 'N/A'}</td>
                        <td>${job.maxSalary ?? 'N/A'}</td>
                        <td class="edit-btn" style="padding: 0;"><a href="/Job/Edit/${job.jobId}" class="btn btn-secondary">Edit</a><a style="margin-left: 100px;" href="/Job/Delete/${job.jobId}" class="btn btn-danger">Delete</a></td>
                    </tr>`;
                    tableBody.append(row);
                });
            },
            error: function () {
                alert('Failed to load jobs.');
            },
            complete: function () {
                loadingSpinner.hide();
            }
        });
    });
});