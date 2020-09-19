
var url = window.location.toString();//获取当前URL
if (url.indexOf("?") != -1) {  //判断URL？后面不为空
    var arrUrl = url.split("?");//分割？
    var para = decodeURI(arrUrl[1]);//获取参数部分
    if (para)//判断传入的参数部分不为空
    {
        var arr = para.split("&");//分割=
        var arr0 = arr[0].split("=");
        uid = arr0[1];
        var arr1 = arr[1].split("=");
        var name = arr1[1];
        var arr2 = arr[2].split("=");
        var value = arr2[1];
        var d = document.getElementById('inputBox');
        d.value = value;
    }
}