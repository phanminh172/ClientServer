$(document).ready(function () {
    $(".nav-link.active .sub-menu").slideDown();
    $(".nav-link.active i").removeClass("fa-angle-right");
    $(".nav-link.active i").addClass("fa-angle-down");

    $("#sidebar-menu .arrow").click(function () {
        $(this).parents("li").toggleClass("active");
        $(this).parents("li").children(".sub-menu").slideToggle();
        $(this).toggleClass("fa-angle-right fa-angle-down");
    });
});