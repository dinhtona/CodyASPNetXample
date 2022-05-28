// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function formSubmitted() {
    $(':input[type="submit"]').prop('disabled', true);
    $("#loading-spinner").show();
    $("#fullscreenloading")?.show();
}