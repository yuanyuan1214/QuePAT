var url = document.location.toString();//��ȡ��ǰURL
if (url.indexOf("?") != -1) {  //�ж�URL�����治Ϊ��
    var arrUrl = url.split("?");//�ָ
    var para = decodeURI(arrUrl[1]);//��ȡ��������
    if (para)//�жϴ���Ĳ������ֲ�Ϊ��
    {
        var arr = para.split("=");//�ָ�=
        var res = arr[1];//��ȡ������ֵ
    }
    var d = document.getElementById('inputBox');
    d.value = res;
    if (res != null) {
        //alert("11111");
        //$(".searchBtn").trigger("click");
        //document.getElementsByClassName("searchBtn")[0].click();
    }
    
}