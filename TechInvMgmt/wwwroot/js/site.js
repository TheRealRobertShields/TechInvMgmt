// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    // dropdown lists for CREATE forms
    $('.searchDropdown').select2();
    $('#tableOfStuff').DataTable({
        responsive: true
    });

    /*
    // DATATABLES
    var invHeader = document.getElementById("header");
    if (typeof (invHeader) != 'undefined' && invHeader != null) {
        if (invHeader.innerText == "MY INVENTORY") {
            var subinv = document.getElementById("getSubInv").innerText;
            $('#tableOfStuff').DataTable({
                responsive: true,
                "search": {
                    "search": subinv
                }
            });
            document.getElementById("tableOfStuff_filter").style.display = "none";
            document.getElementById("header").textContent = subinv;
        }
        else {
            $('#tableOfStuff').DataTable({
                responsive: true
            });
        }
    }
    */

    
    
});




