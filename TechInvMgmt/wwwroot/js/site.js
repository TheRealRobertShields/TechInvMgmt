// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.searchDropdown').select2();

    
    var invHeader = document.getElementById("header");
    if (typeof (invHeader) != 'undefined' && invHeader != null) {
        if (invHeader.innerText == "INVENTORY") {
            var subinv = document.getElementById("getSubInv").innerText;
            $('#tableOfStuff').DataTable({
                responsive: true,
                "search": {
                    "search": subinv
                }
            } );
        }
        else {
            $('#tableOfStuff').DataTable({
                responsive: true
            });
        }
    }
    
    
    
});




