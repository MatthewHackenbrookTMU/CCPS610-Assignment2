
function Actions(id) {

}

$('#jobTableBody').ready(function () {
    if (!$('div').is('.JobList')) {
        return;
    }

    $.getScript("/js/job-index.js")
        .done(function (script, textStatus) {
            console.log("Script loaded successfully: " + textStatus);
        })
        .fail(function (jqxhr, settings, exception) {
            console.error("Failed to load script: " + exception);
        });
});

$('.JobForm').ready(function () {
    if (!$('div').is('.JobForm')) {
        return;
    }

    $.getScript("/js/job-form.js")
        .done(function (script, textStatus) {
            console.log("Script loaded successfully: " + textStatus);
        })
        .fail(function (jqxhr, settings, exception) {
            console.error("Failed to load script: " + exception);
        });
});

$('#employeeTableBody').ready(function () {
    if (!$('div').is('.EmployeeList')) {
        return;
    }
    $.getScript("/js/employee-index.js")
        .done(function (script, textStatus) {
            console.log("Script loaded successfully: " + textStatus);
        })
        .fail(function (jqxhr, settings, exception) {
            console.error("Failed to load script: " + exception);
        });
});

$('.EmployeeForm').ready(function () {
    $.getScript("/js/employee-form.js")
        .done(function (script, textStatus) {
            console.log("Script loaded successfully: " + textStatus);
        })
        .fail(function (jqxhr, settings, exception) {
            console.error("Failed to load script: " + exception);
        });
});


$('.Home').ready(function () {
    $.getScript("/js/home.js")
        .done(function (script, textStatus) {
            console.log("Script loaded successfully: " + textStatus);
        })
        .fail(function (jqxhr, settings, exception) {
            console.error("Failed to load script: " + exception);
        });
});