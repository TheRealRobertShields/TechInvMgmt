// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    // dropdown lists for forms
    $('.searchDropdown').select2();

    
    var navDropDownLinks = document.getElementById("tablesmenu").querySelectorAll("li");
    var spanTopPosition = 0; 
    for (var i = 0; i < navDropDownLinks.length; i++) {
        console.log(spanTopPosition);
        var hoverTip = navDropDownLinks[i].querySelector("span")
        hoverTip.style.top = spanTopPosition + "px";
        spanTopPosition += 45;
    }
});




