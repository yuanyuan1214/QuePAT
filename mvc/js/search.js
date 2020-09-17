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
//var wrappers = $$(".wrapper");
var keyword="";
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
    //window.model.CookieToModel();
    
   /* search_key = window.model.data.keyword;
    if (search_key != "") {
        $$(".xxx").innerHTML = [
            '<div class=""><p class="text">',
            '   ������...',
            '</p><!----></div>'
        ].join('');


        window.model.data.keyword = "";
        var queryJson = [];
        var row = {};
        row.keyword = search_key;
        if (row.keyword === "") row.keyword = "666";
        queryJson.push(row);
        $.ajax({
            url: "Main/Search",
            async: false,
            type: 'post',
            contentType: "application/json",
            data: JSON.stringify(queryJson[0]),
            dataType: "json",
            traditional: true,
            success: function (data) {
                var data = eval("(" + data + ")");
                normal_list = data.info;
                _search_word = keyword;

                if (normal_list.length !== 0) {
                    normal_list.forEach(function (v) {
                        var copy = [];
                        v.tags.forEach(function (t) {
                            copy.push(t['tagName']);
                        });
                        v.tags = copy;
                    });
                }
            },
            error: function (message) {
                alert("�����ѯ����ʧ�ܣ�");
            }
        });
    }
    else {
        var queryJson = [];
        var row = {};
        row.user_id = userID;
        row.keyword = "111";
        queryJson.push(row);
        $.ajax({
            url: "/Main/Search",
            async: false,
            type: 'post',
            contentType: "application/json",
            data: JSON.stringify(queryJson[0]),
            dataType: "json",
            traditional: true,
            success: function (data) {

            },
            error: function (message) {
                alert("�����ѯ����ʧ�ܣ�");
            }
        });
    }*/

    normal_button.addEventListener('click', function () {
        let keyword = normal_word.value;
        if (keyword === "") {
            alert("�����ؼ��ʲ���Ϊ�գ�");
        }
        else {
            var queryJson = [];
            var row = {};
            row.keyword = keyword;
            if (row.keyword === "") row.keyword = "666";
            queryJson.push(row);

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
                    /*if (json.length === 0) {
                        alert("�������Ϊ�գ�");
                        return;
                    }*/
                    console.log(json);
                    window.location.href = "SearchResult?id=" + encodeURI(keyword);
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
                },
                error: function (message) {
                    alert("�����ѯ����ʧ�ܣ�");
                }
            });
        }
    })
}



/*function sendAjax() {
    var formData = new formData();
    formData.append('normal_word');

    var xhr = new XMLHttpRequest();
    xhr.timeout = 3000;
    xhr.responseType = "text";

    xhr.open('POST', '/server', true);

    xhr.onload = function (e) {

    };
    

    xhr.send(formData);
}*/