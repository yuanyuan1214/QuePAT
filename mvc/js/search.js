var $$ = function (sel) {
    return document.querySelector(sel);
};
var $All = function (sel) {
    return document.querySelectorAll(sel);
};
var $SON = function (father, son) {
    return father.querySelectorAll(son);
};
var makeArray = function (likeArray) {
    var array = [];
    for (var i = 0; i < likeArray.length; ++i) {
        array.push(likeArray[i]);
    }
    return array;
};

var normal_word = document.getElementById('normal');
var normal_button = document.querySelector("#normal-button");
var law_word = document.getElementById('law');
var law_button = document.querySelector("#law-button");

var n1_s = document.querySelector("#n5");
var n2_s = document.querySelector("#n6");
var n3_s = document.querySelector("#n7");
var n4_s = document.querySelector("#n8");
var n5_s = document.querySelector("#n1");
var n6_s = document.querySelector("#n2");
var n7_s = document.querySelector("#n3");
var n8_s = document.querySelector("#n4");
var n_button = document.querySelector("#n-button");
//var wrappers = $$(".wrapper");
var keyword = "";
var normal_key = "";
var now_index = 1;

var patent_list = [
    /*
    patent{
        app_num:int �����
        name:string ר������
        patent_type:int ר������
        class_code:string ר�������
        designer_id:strig ������ID
        patentee_name:string ר��Ȩ��
        proposername��string �������
        place_code:string ��������������
        abstract:string ժҪ
        main_claim:string ��Ȩ��Ҫ��
        claim:string Ȩ��Ҫ��
        age:string ����
        is_valid:boolean ��Чλ
        link:string ȫ������
    */
]

var show_mormal = [];
var copy_normal = [];
var keywords = ['ƥ��ؼ���1', 'ƥ��ؼ���qwe2', 'ƥ��ؼ���36666'];
var search_key = "";
var _search_word = "";


window.onload = function () {


    normal_button.addEventListener('click', function () {
        let keyword = normal_word.value;
        if (keyword === "") {
            alert("�����ؼ��ʲ���Ϊ�գ�");
        }
        else {
            /* var queryJson = [];
             var row = {};
             row.type = 0;
             row.w1 = keyword;
             row.w2 = "";
             row.w3 = "";
             row.w4 = "";
             row.w5 = "";
             row.w6 = "";
             row.w7 = "";
             row.w8 = "";
             if (row.w1 === "") row.w1 = "666";
             queryJson.push(row);
             var d_test = JSON.stringify(queryJson[0]);
 
             $.ajax({
                 url: "/Main/Search",
                 async: false,
                 type: 'post',
                 contentType: "application/json",
                 data: JSON.stringify(queryJson[0]),
                 dataType: "json",
                 traditional: true,
                 success: function (data) {
                     var json = eval(data);
                     *//*if (json.length === 0) {
                alert("�������Ϊ�գ�");
                return;
            }*//*
            console.log(json);*/
            var uids = $(".username-box.fl .username").attr("title");
            var uid = parseInt(uids);
            var name = $(".username-box.fl .username").text();
            window.location.href = "SearchResult?uid=" + uid + "&user_name=" + name + "&app_num=" + encodeURI(keyword);



            /*},
            error: function (message) {
                alert("�����ѯ����ʧ�ܣ�");
            }
        });*/
        }
    })

    law_button.addEventListener('click', function () {
        let lawword = law_word.value;
        if (lawword === "") {
            alert("�����ؼ��ʲ���Ϊ�գ�");
        }
        else {
            /*var queryJson2 = [];
            var row2 = {};
            row2.type = 2;
            row2.w1 = lawword;
            row2.w2 = "";
            row2.w3 = "";
            row2.w4 = "";
            row2.w5 = "";
            row2.w6 = "";
            row2.w7 = "";
            row2.w8 = "";
            if (row2.w1 === "") row2.w1 = "666";
            queryJson2.push(row2);
            var d_test = JSON.stringify(queryJson2[0]);

            $.ajax({
                url: "/Main/Search",
                async: false,
                type: 'post',
                contentType: "application/json",
                data: JSON.stringify(queryJson2[0]),
                dataType: "json",
                traditional: true,
                success: function (data) {
                    var json = eval(data);
                    *//*if (json.length === 0) {
                alert("�������Ϊ�գ�");
                return;
            }*//*
            console.log(json);*/
            window.location.href = "SearchLaw?id=" + encodeURI(lawword);
            /*normal_list = data.info;
            _search_word = keyword;
            if (normal_list.length != 0) {
                normal_list.forEach(function (v) {
                    var copy = [];
                    v.tags.forEach(function (t) {
                        copy.push(t['tagName']);
                    });
                    v.tags = copy;
                });
            }*/
            /*},
            error: function (message) {
                alert("�����ѯ����ʧ�ܣ�");
            }
        });*/
        }
    })

    n_button.addEventListener('click', function () {
        let word1 = n1_s.value;
        let word2 = n2_s.value;
        let word3 = n3_s.value;
        let word4 = n4_s.value;
        let word5 = n5_s.value;
        let word6 = n6_s.value;
        let word7 = n7_s.value;
        let word8 = n8_s.value;
        if ((word1 === "" || word1 === null) && (word2 === null || word2 === "") && (word3 === null || word3 === "") && (word4 === null || word4 === "") && (word5 === null || word5 === "") && (word6 === null || word6 === "") && (word7 === null || word7 === "") && (word8 === null || word8 === "")) {
            alert("�����ؼ��ʲ���Ϊ�գ�");
            //return;
        }
        if (word1 === "") {
            word1 = null;
        }
        if (word2 === "") {
            word2 = null;
        }
        if (word3 === "") {
            word3 = null;
        }
        if (word4 === "") {
            word4 = null;
        }
        if (word5 === "") {
            word5 = null;
        }
        if (word6 === "") {
            word6 = null;
        }
        if (word7 === "") {
            word7 = null;
        }
        if (word8 === "") {
            word8 = null;
        }

        let row3 = {
            "type": 1,
            "w1": null,
            "w2": null,
            "w3": null,
            "w4": null,
            "w5": null,
            "w6": null,
            "w7": null,
            "w8": null
        }
        row3.w1 = word1;
        row3.w2 = word2;
        row3.w3 = word3;
        row3.w4 = word4;
        row3.w5 = word5;
        row3.w6 = word6;
        row3.w7 = word7;
        row3.w8 = word8;

        var queryJson3 = [];
        /*var row2 = {};
        row2.type = 2;
        row2.w1 = lawword;
        row2.w2 = "";
        row2.w3 = "";
        row2.w4 = "";
        row2.w5 = "";
        row2.w6 = "";
        row2.w7 = "";
        row2.w8 = "";
        if (row2.w1 === "") row2.w1 = "666";*/
        queryJson3.push(row3);
        var d_test = JSON.stringify(queryJson3[0]);

        /* $.ajax({
             url: "/Main/Search",
             async: false,
             type: 'post',
             contentType: "application/json",
             data: JSON.stringify(queryJson3[0]),
             dataType: "json",
             traditional: true,
             success: function (data) {
                 var json = eval(data);*/
        /*if (json.length === 0) {
            alert("�������Ϊ�գ�");
            return;
        }*/
        var address2 = "word1=" + word1 + "*word2=" + word2 + "*word3=" + word3 + "*word4=" + word4 + "*word5=" + word5 + "*word6=" + word6 + "*word7=" + word7 + "*word8=" + word8;
        //console.log(data);
        var address0 = "SearchForm?expression=";



        window.location.href = address0 + address2;//"SearchResult?expression=" + word1 + "/IC*" + word2 + "/IN*" + word3 + "/AN*" + word4 + "/PA*" + word5 + "/TX*" + word6 + "CO*" + word7 + "/AD*" + word8 + "/CS";
        /*normal_list = data.info;
        _search_word = keyword;
        if (normal_list.length != 0) {
            normal_list.forEach(function (v) {
                var copy = [];
                v.tags.forEach(function (t) {
                    copy.push(t['tagName']);
                });
                v.tags = copy;
            });
        }*/
        //},
        /*error: function (message) {
            alert("�����ѯ����ʧ�ܣ�");
        }
    });*/
    })
}



