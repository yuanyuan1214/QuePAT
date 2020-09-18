var data = {
    'title': '测试标题',
    'name': '网友',
    'releaseTime': '2020/9/17',
    'content': '内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容'
};

var i=1;

$(document).ready(function () {
    /*$( "#blogContent" ).html(
        $( "#contentTemp" ).render(data )
    );*/
    /*$.ajax({
        url: "/Main/Search",//改成相应函数接口
        async: false,
        type: 'post',
        contentType: "application/json",
        data: 'CN96120119',
        dataType: "json",
        traditional: true,
        success: function (data) {
            var datas = eval("(" + data + ")");
            data_re = jQuery.parseJSON(datas);
            console.log(data_re);
            var html2 = $("#contentTemp").render(data_re);
            $("#blogContent").append(html2);
        },
        error: function (message) {
            alert("查询数据失败！");
        }
    });*/



    var html2 = $("#contentTemp").render(data);
    $("#blogContent").append(html2);
});


$(function(){
    $("#submitCom").click(function()
    {
        var content = $("#com-txt").val();
    console.log(i++);
    data.content = content;
    //alert(content);
    var date = new Date();
    var current = date.toLocaleString();
    data.releaseTime=current;
    //alert(current);
    var html = $("#commentTemp").render(data);
    $("#com-result").append(html);

    })
} );


