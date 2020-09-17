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
        app_num:int 申请号
        name:string 专利名称
        patent_type:int 专利类型
        class_code:string 专利分类号
        designer_id:strig 发明人ID
        patentee_name:string 专利权人
        proposername：string 申请机构
        place_code:string 所在行政区代码
        abstract:string 摘要
        main_claim:string 主权利要求
        claim:string 权利要求
        age:string 年龄
        is_valid:boolean 有效位
        link:string 全文链接
    */
]

var show_mormal = [];
var copy_normal = [];
var keywords = ['匹配关键词1', '匹配关键词qwe2', '匹配关键词36666'];
var search_key = "";
var _search_word = "";


window.onload = function () {
    //window.model.CookieToModel();
    
   /* search_key = window.model.data.keyword;
    if (search_key != "") {
        $$(".xxx").innerHTML = [
            '<div class=""><p class="text">',
            '   加载中...',
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
                alert("请求查询数据失败！");
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
                alert("请求查询数据失败！");
            }
        });
    }*/

    normal_button.addEventListener('click', function () {
        let keyword = normal_word.value;
        if (keyword === "") {
            alert("搜索关键词不能为空！");
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
                        alert("检索结果为空！");
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
                    alert("请求查询数据失败！");
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