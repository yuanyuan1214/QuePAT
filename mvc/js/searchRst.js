var url = document.location.toString();//获取当前URL
if (url.indexOf("?") != -1) {  //判断URL？后面不为空
    var arrUrl = url.split("?");//分割？
    var para = decodeURI(arrUrl[1]);//获取参数部分
    if (para)//判断传入的参数部分不为空
    {
        var arr = para.split("=");//分割=
        var res = arr[1];//获取参数的值
    }
    var d = document.getElementById('inputBox');
    d.value = res;
    if (res != null) {
        //alert("11111");
        //$(".searchBtn").trigger("click");
        //document.getElementsByClassName("searchBtn")[0].click();
    }
    
}