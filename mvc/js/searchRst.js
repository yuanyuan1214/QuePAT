
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
        var d = document.getElementById('inputBox');
        d.value = value;
    }
}