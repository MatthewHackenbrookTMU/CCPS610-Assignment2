$(document).ready(function () {
    $('#employeetablebody').ready(function () {
        if (!$('div').is('.Home')) {
            return;
        }

        $('#jobDescriptionModalToggle').click(function () {
            $('#lookupButton').show();
        });

        $('#lookupButton').click(function () {
            var input = $('#jobDescriptionInput').val();
            var resultDiv = $('#lookupResult');
            var loadingSpinner = $('#loadingSpinner');

            loadingSpinner.show();
            resultDiv.empty();

            $.ajax({
                url: '/Job/GetJobDescription/' + encodeURIComponent(input),
                method: 'GET',
                success: function (data) {
                    var table = `
            <table class="table table-striped">
              <thead>
                <tr>
                  <th>Job Title</th>
                  <th>Min Salary</th>
                  <th>Max Salary</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>${data.jobTitle}</td>
                  <td>${data.minSalary}</td>
                  <td>${data.maxSalary}</td>
                </tr>
              </tbody>
            </table>
          `;

                    resultDiv.html(table);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    resultDiv.text('Error: ' + textStatus);
                },
                complete: function () {
                    loadingSpinner.hide();
                }
            });
        });
    });
});