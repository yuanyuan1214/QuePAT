var pageNum = 1;
var obj;
var lPageNum = 1;

var url = document.location.toString();//获取当前URL
if (url.indexOf("?") != -1) {  //判断URL？后面不为空
    var arrUrl = url.split("?");//分割？
    var para = decodeURI(arrUrl[1]);//获取参数部分
    if (para)//判断传入的参数部分不为空
    {
        var arr = para.split("*");//分割=
        var arr0 = arr[0].split("=");
        var arr1 = arr[1].split("=");
        var arr2 = arr[2].split("=");
        var arr3 = arr[3].split("=");
        var arr4 = arr[4].split("=");
        var arr5 = arr[5].split("=");
        var arr6 = arr[6].split("=");
        var arr7 = arr[7].split("=");
        var word1 = arr0[2];//获取参数的值
        var word2 = arr1[1];
        var word3 = arr2[1];
        var word4 = arr3[1];
        var word5 = arr4[1];//有个exppression
        var word6 = arr5[1];
        var word7 = arr6[1];
        var word8 = arr7[1];
    }

    var address = "";
    if (word1 !== "null") {
        address = address + word1 + "/AB"
    }
    else {
        word1 = null;
    }
    if (word2 !== "null") {
        if (address !== "") {
            address = address + "*"
        }
        address = address + word2 + "/IN";
    }
    else {
        word2 = null;
    }
    if (word3 !== "null") {
        if (address !== "") {
            address = address + "*"
        }
        address = address + word3 + "/AN";
    }
    else {
        word3 = null;
    }
    if (word4 !== "null") {
        if (address !== "") {
            address = address + "*"
        }
        address = address + word4 + "/PA";
    }
    else {
        word4 = null;
    }
    if (word5 !== "null") {
        if (address !== "") {
            address = address + "*"
        }
        address = address + word5 + "/TX";
    }
    else {
        word5 = null;
    }
    if (word6 !== "null") {
        if (address !== "") {
            address = address + "*"
        }
        address = address + word6 + "/CO";
    }
    else {
        word6 = null;
    }
    if (word7 !== "null") {
        if (address !== "") {
            address = address + "*"
        }
        address = address + word7 + "/AD";
    }
    else {
        word7 = null;
    }
    if (word8 !== "null") {
        if (address !== "") {
            address = address + "*"
        }
        address = address + word8 + "/CS";
    }
    else {
        word8 = null;
    }


    if (address != null) {
        //alert("11111");
        //$(".searchBtn").trigger("click");
        //document.getElementsByClassName("searchBtn")[0].click();
    }
}

$(function () {
    $(".searchBtn").click(function () {
        var str = $("#inputBox").val();
        var url = "SearchResult?keyword=" + str;
        var d = document.getElementById('inputBox');
        d.value = address;
        $.ajax({
            type: "post",
            url: "./SearchForm",
            data: { searchStr: str, w1: word1, w2: word2, w3: word3, w4: word4, w5: word5, w6: word6, w7: word7, w8: word8 },
            success: function (res) {
                //var json = eval(res);
                obj = eval(res);
                for (var i = 1; i < 10; i++) {
                    $("#li" + i).css("display", "none");
                }
                console.log(obj);
                console.log(typeof obj);
                if (typeof obj == undefined) {
                    $("#line1").text("没有搜索结果，请输入其他关键字");
                    $("#li1").css("display", "block");
                } else {
                    lPageNum = Math.ceil(obj.length / 9);
                    $("#totalPagehtml").text("总页数：" + lPageNum);
                    $("#totalSumhtml").text("总条数：" + obj.length);
                    for (var i = 0; i < obj.length && i <= 9; i++) {
                        var arr = obj[i].APP_DATE.split("T");
                        $("#line" + (i + 1)).text(obj[i].NAME);
                        $("#date" + (i + 1)).text(arr[0]);
                        $("#li" + (i + 1)).css("display", "block");
                    }
                }
                $("#a1").attr("title", obj.NAME);
            },
            error: function () {
                console.log("err");
            }
        });

    });
    document.getElementsByClassName("searchBtn")[0].click();

});
function nextPage() {
    for (var i = 1; i < 10; i++) {
        $("#li" + i).css("display", "none");
    }
    if (pageNum + 1 > lPageNum) {
        return;
    } else {
        for (var i = pageNum * 9; i < obj.length && i < pageNum * 9 + 9; i++) {
            var arr = obj[i].APP_DATE.split("T");
            $("#line" + (i - pageNum * 9 + 1)).text(obj[i].NAME);
            $("#date" + (i - pageNum * 9 + 1)).text(arr[0]);
            $("#li" + (i - pageNum * 9 + 1)).css("display", "block");
        }
        pageNum += 1;
        $("#currenthtml").text("当前页：" + pageNum);
    }
}
function lastPage() {
    for (var i = 1; i < 10; i++) {
        $("#li" + i).css("display", "none");
    }
    if (pageNum - 1 < 1) {
        return;
    } else {
        pageNum -= 2;
        for (var i = pageNum * 9; i < obj.length && i < pageNum * 9 + 9; i++) {
            var arr = obj[i].APP_DATE.split("T");
            $("#line" + (i - pageNum * 9 + 1)).text(obj[i].NAME);
            $("#date" + (i - pageNum * 9 + 1)).text(arr[0]);
            $("#li" + (i - pageNum * 9 + 1)).css("display", "block");
        }
        pageNum += 1;
        $("#currenthtml").text("当前页：" + pageNum);
    }
}
function gotoFirstPage() {
    for (var i = 1; i < 10; i++) {
        $("#li" + i).css("display", "none");
    }
    pageNum = 0;
    for (var i = pageNum * 9; i < obj.length && i < pageNum * 9 + 9; i++) {
        var arr = obj[i].APP_DATE.split("T");
        $("#line" + (i - pageNum * 9 + 1)).text(obj[i].NAME);
        $("#date" + (i - pageNum * 9 + 1)).text(arr[0]);
        $("#li" + (i - pageNum * 9 + 1)).css("display", "block");
    }
    pageNum += 1;
    $("#currenthtml").text("当前页：" + pageNum);
}
function gotoEndPage() {
    for (var i = 1; i < 10; i++) {
        $("#li" + i).css("display", "none");
    }
    pageNum = lPageNum - 1;
    for (var i = pageNum * 9; i < obj.length && i < pageNum * 9 + 9; i++) {
        var arr = obj[i].APP_DATE.split("T");
        $("#line" + (i - pageNum * 9 + 1)).text(obj[i].NAME);
        $("#date" + (i - pageNum * 9 + 1)).text(arr[0]);
        $("#li" + (i - pageNum * 9 + 1)).css("display", "block");
    }
    pageNum += 1;
    $("#currenthtml").text("当前页：" + pageNum);
}
function openPatentDetail(num) {
    var patentNum = (pageNum - 1) * 9 + num - 1;
    var patentCode = obj[i].APP_NUM;
    // 将patentCode接在url后面调用俊妍的页面
}