var uid;

$(document).ready(function () {
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
    var url = window.location.toString();//��ȡ��ǰURL
    if (url.indexOf("?") != -1) {  //�ж�URL�����治Ϊ��
        var arrUrl = url.split("?");//�ָ
        var para = decodeURI(arrUrl[1]);//��ȡ��������
        if (para)//�жϴ���Ĳ������ֲ�Ϊ��
        {
            var arr = para.split("&");//�ָ�=
            var arr0 = arr[0].split("=");
            uid = arr0[1];
            var arr1 = arr[1].split("=");
            var name = arr1[1];
            var arr2 = arr[2].split("=");
            var value = arr2[1];
            $(".username-box.fl .username").attr("title", uid);
            $(".username-box.fl .username").text(name);
        }
    }
});

function clicka() {
    $.ajax({
        type: "post",
        url: "./Logout",
        data: { user_id: uid },
        success: function (res) {
            alert("log out");
            window.open("../Home/MainPage");
           

        }
    });
}