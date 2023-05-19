﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

checkUserLoggedIn();

function checkUserLoggedIn() {
    var aut_user = localStorage.getItem("token");
    if (aut_user == null) {
        window.location.href="/Account/Login"
    }
}

$(document).ready(function () { 
$ ("#btnLogout").click(function () {
    alert("pakka logout karna hai")
    localStorage.removeItem("user")
    localStorage.removeItem("token")
    window.location.href = "/Account/Login"
    })
})