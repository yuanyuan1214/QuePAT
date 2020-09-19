$(document).ready(function() {
    $(".username").hover(function() {
        $(".box-content").css("display", "block");
    });
    $(".username").mouseout(function() {
        $(".box-content").css("display", "none");
    });
    $(".personalmenu").mouseover(function() {
        $(".box-content").css("display", "block");
    });
    $(".personalmenu").mouseout(function() {
        $(".box-content").css("display", "none");
    });
});