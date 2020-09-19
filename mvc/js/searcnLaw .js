var pageNum = 1;
var obj;
var lPageNum = 1;
$(function () {
    $(".searchBtn").click(function () {
        var strLaw = $("#inputBox").val();
        var rowLaw = {};
        rowLaw.lawStr = strLaw;
        //var url = "SearchResult?keyword=" + strLaw;
        $.ajax({
            url: "/Main/SearchLaw",
            async: false,
            type: 'post',
            contentType: "application/json",
            data: JSON.stringify(rowLaw),
            dataType: "json",
            traditional: true,
            success: function (res) {
                //var json = eval(res);
                obj = eval(res);//原json
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
                    //for (var i = 0; i < obj.length && i <= 9; i++) {
                        var arr = obj.ANNOUNCE_DATE.split("T");
                        $("#line" + 1).text(arr[0]);
                        $("#date" + 1).text(obj.MSG);
                        $("#li" +  1).css("display", "block");
                    //}
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