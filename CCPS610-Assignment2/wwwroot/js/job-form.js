$(document).ready(function () {

    if (window.location.href.toLowerCase().includes("edit")) {
        console.log("Found edit success");
        var jobIdElement = document.getElementById("JobId");
        if (jobIdElement) {
            jobIdElement.readOnly = true;
        }
    } else {
        console.log("Failed to find edit");
        console.log(window.location.href);
    }

});