var ori_app_num = "";

function deal_create() {
    $("#app_num").val("");
    $("#patent_name").val("");
    $("#patent_type").val("");
    $("#class_code").val("");
    $("#designer_id").val("");
    $("#patentee_name").val("");
    $("#proposer_name").val("");
    $("#place_code").val("");
    $("#app_date").val("");
    $("#public_num").val("");
    $("#abstract").val("");
    $("#main_claim").val("");
    $("#claim").val("");
    $("#patent_age").val("");
    $("#is_valid").val("");
    $("#full_link").val("");

    $("#com_name1").val("");
    $("#com_address1").val("");
    $("#com_abstract1").val("");
    $("#com_name2").val("");
    $("#com_address2").val("");
    $("#com_abstract2").val("");

    $("#person_id").val("");
    $("#person_name").val("");
    $("#person_address").val("");
    $("#person_phone").val("");
    $("#person_email").val("");

    $(".warning-info").addClass("hid-element");

    $(".manage-main").addClass("hid-element");
    $(".input-area").removeClass("hid-element");
    $("#input-item").text("创建专利");
    $(".btn-info").text("创建");
}
function deal_modify(id) {
    ori_app_num = id;
    $.ajax({
        type: "post",
        url: "./GetPatentById",
        data: { app_num: id },
        success: function (res) {
            var obj = JSON.parse(res);
            $("#app_num").val(obj.APP_NUM);
            $("#app_num").val(obj.APP_NUM);
            $("#patent_name").val(obj.NAME);
            $("#patent_type").val(obj.PATENT_TYPE);
            $("#class_code").val(obj.CLASS_CODE);
            $("#designer_id").val(obj.DESIGNER_ID);
            $("#patentee_name").val(obj.PATENTEE_NAME);
            $("#proposer_name").val(obj.PROPOSER_NAME);
            $("#place_code").val(obj.PLACE_CODE);
            $("#app_date").val(obj.APP_DATE);
            $("#public_num").val(obj.PUBLIC_NUM);
            $("#abstract").val(obj.ABSTRACT);
            $("#main_claim").val(obj.MAIN_CLAIN);
            $("#claim").val(obj.CLAIM);
            $("#patent_age").val(obj.AGE);
            $("#is_valid").val(obj.IS_VALID);
            $("#full_link").val(obj.LINK);

            $("#com_name1").val("");
            $("#com_address1").val("");
            $("#com_abstract1").val("");
            $("#com_name2").val("");
            $("#com_address2").val("");
            $("#com_abstract2").val("");

            $("#person_id").val("");
            $("#person_name").val("");
            $("#person_address").val("");
            $("#person_phone").val("");
            $("#person_email").val("");
            $(".warning-info").addClass("hid-element");

            $(".manage-main").addClass("hid-element");
            $(".input-area").removeClass("hid-element");
            $("#input-item").text("更新专利");
            $(".btn-info").text("更新");
        }
    })
}

function deal_delete(id) {
    $.ajax({
        type: "post",
        url: "./DeletePATENT",
        data: { app_num: id },
        success: function (res) {
            if (res == "1") {
                alert("删除成功！");
                window.location.reload();
            }
            else if (res == "-01") {
                alert("删除失败：待删除的专利申请号不存在，请刷新重试！");
            }
            else if (res == "-32") {
                alert("删除失败：数据库删除操作错误，请刷新重试！");
            }
            else {
                alert("删除失败：数据库未知错误，请刷新重试！");
            }
        },
        error: function () {
            alert("删除失败：未能连接到后端服务器过，请检查网络连接或刷新重试！");
        }
    })
}

var btn_num, row_num, page_num, start_num = 1;

function display_row(curpos) {
    if (curpos == 0) {
        curpos = 1;
        start_num = 1;
    }
    else if (curpos == -1) {
        start_num = page_num - btn_num + 1;
        curpos = page_num - start_num + 1;
    }
    curpos = start_num - 1 + curpos;
    for (var i = 1; i <= row_num; i++) {
        $("#row" + i).addClass("hid-element");
    }
    for (var i = 50 * curpos - 49; i <= 50 * curpos; i++) {
        if (i > row_num) break;
        $("#row" + i).removeClass("hid-element");
    }
    start_num = curpos;
    if (curpos + btn_num > page_num + 1) {
        start_num = page_num - btn_num + 1;
    }
    for (var i = 1; i <= btn_num; i++) {
        $("#li" + i + " > a").text((start_num + i - 1).toString());
        $("#li" + i).removeClass("active");
    }

    var cur_light = 1 + curpos - start_num;
    $("#li" + cur_light).addClass("active");

}

function checkData(mydata) {
    var suc = true;

    // 专利信息检查
    if (mydata.app_num == "") {
        $("#warning-app_num").removeClass("hid-element");
        scrollTo(0, 0);
        suc = false;
    }
    else {
        $("#warning-app_num").addClass("hid-element");
    }

    if (mydata.name == "") {
        $("#warning-patent_name").removeClass("hid-element");
        scrollTo(0, 0);
        suc = false;
    }
    else {
        $("#warning-patent_name").addClass("hid-element");
    }

    if (mydata.patent_type == "") {
        $("#warning-patent_type").removeClass("hid-element");
        scrollTo(0, 0);
        suc = false;
    }
    else {
        $("#warning-patent_type").addClass("hid-element");
    }

    if (mydata.class_code == "") {
        $("#warning-class_code").removeClass("hid-element");
        scrollTo(0, 0);
        suc = false;
    }
    else {
        $("#warning-class_code").addClass("hid-element");
    }

    if (mydata.designer_id == "") {
        $("#warning-designer_id").removeClass("hid-element");
        scrollTo(0, 0);
        suc = false;
    }
    else {
        $("#warning-designer_id").addClass("hid-element");
    }

    if (mydata.patentee_name == "") {
        $("#warning-patentee_name").removeClass("hid-element");
        scrollTo(0, 0);
        suc = false;
    }
    else {
        $("#warning-patentee_name").addClass("hid-element");
    }

    if (mydata.proposer_name == "") {
        $("#warning-proposer_name").removeClass("hid-element");
        scrollTo(0, 0);
        suc = false;
    }
    else {
        $("#warning-proposer_name").addClass("hid-element");
    }

    if (mydata.place_code == "") {
        $("#warning-place_code").removeClass("hid-element");
        scrollTo(0, 0);
        suc = false;
    }
    else {
        $("#warning-place_code").addClass("hid-element");
    }

    if (mydata.app_date == "") {
        $("#warning-app_date").removeClass("hid-element");
        scrollTo(0, 0);
        suc = false;
    }
    else {
        $("#warning-app_date").addClass("hid-element");
    }

    if (mydata.public_num == "") {
        $("#warning-public_num").removeClass("hid-element");
        scrollTo(0, 0);
        suc = false;
    }
    else {
        $("#warning-public_num").addClass("hid-element");
    }

    if (mydata.age == "") {
        $("#warning-patent_age").removeClass("hid-element");
        scrollTo(0, 0);
        suc = false;
    }
    else {
        $("#warning-patent_age").addClass("hid-element");
    }

    if (mydata.is_valid == "") {
        $("#warning-is_valid").removeClass("hid-element");
        scrollTo(0, 0);
        suc = false;
    }
    else {
        $("#warning-is_valid").addClass("hid-element");
    }

    // 公司信息检查
    if (mydata.com_address1 != "" || mydata.com_abstract1 != "") {
        if (mydata.com_name1 == "") {
            $("#warning-com_name1").removeClass("hid-element");
            scrollTo(0, 0);
            suc = false;
        }
        else {
            $("#warning-com_name1").addClass("hid-element");
        }
    }
    else {
        $("#warning-com_name1").addClass("hid-element");
    }

    if (mydata.com_address2 != "" || mydata.com_abstract2 != "") {
        if (mydata.com_name2 == "") {
            $("#warning-com_name2").removeClass("hid-element");
            scrollTo(0, 0);
            suc = false;
        }
        else {
            $("#warning-com_name2").addClass("hid-element");
        }
    }
    else {
        $("#warning-com_name2").addClass("hid-element");
    }

    // 人名信息检查
    if (mydata.person_address != "" || mydata.person_phone != "" || mydata.person_email != ""
        || mydata.person_name != "" || mydata.person_id != "") {
        if (mydata.person_id == "") {
            $("#warning-person_id").removeClass("hid-element");
            scrollTo(0, 0);
            suc = false;
        }
        else {
            $("#warning-person_id").addClass("hid-element");
        }

        if (mydata.person_name == "") {
            $("#warning-person_name").removeClass("hid-element");
            scrollTo(0, 0);
            suc = false;
        }
        else {
            $("#warning-person_name").addClass("hid-element");
        }
    }
    else {
        $("#warning-person_id").addClass("hid-element");
        $("#warning-person_name").addClass("hid-element");
    }

    if (suc == false) {
        alert("操作失败：输入框中存在不合法内容，请检查后重新提交！");
    }

    return suc;
}

//程序停顿
function waiting(time) {
    var start = (new Date()).getTime();
    // 阻塞时间为time，单位为毫秒
    while ((new Date()).getTime() - start < time) {
        continue;
    }
}

//修改专利
function modifyData(mydata) {
    if (!checkData(mydata)) {
        return;
    }

    $.ajax({
        type: "post",
        url: "./ModifyPatentDB",
        data: mydata,
        success: function (res) {
            if (res == "1") {
                alert("操作成功！");
                window.location.reload();
            }
            else if (res == "-01") {
                alert("操作失败：要添加的公司已存在！");
            }
            else if (res == "-02") {
                alert("操作失败：要添加的人已存在！");
            }
            else if (res == "-11") {
                alert("操作失败：您要添加的公司已添加成功，但是缺少专利权人在数据库中的记录，需要二次填报！");
            }
            else if (res == "-12") {
                alert("操作失败：您要添加的公司已添加成功，但是缺少申请公司在数据库中的记录，需要二次填报！");
            }
            else if (res == "-13") {
                alert("操作失败：您要添加的自然人已添加成功，但是仍然缺少发明人在数据库中的记录，请检查输入是否正确！");
            }
            else if (res == "-21") {
                alert("操作失败：缺少专利权人在数据库的记录，请先添加新公司！");
            }
            else if (res == "-22") {
                alert("操作失败：缺少申请公司在数据库的记录，请先添加新公司！");
            }
            else if (res == "-23") {
                alert("操作失败：缺少发明人在数据库的记录，请先添加新自然人！");
            }
            else if (res == "-31") {
                alert("操作失败：数据库新建公司或者自然人错误，请检查输入的各项信息后刷新重试！");
            }
            else if (res == "-32") {
                alert("操作失败：数据库操作专利错误，请检查输入的各项信息后刷新重试！");
            }
            else if (res == "-41") {
                alert("操作失败：您修改了专利申请号，但是原专利号在数据库中未注册，请刷新后重试！");
            }
            else if (res == "-42") {
                alert("操作失败：您所修改专利的专利号在数据库中未注册，请刷新后重试！");
            }
            else {
                alert("操作失败：数据库未知错误，请刷新重试！");
            }
        },
        error: function () {
            alert("操作失败：未能连接到后端服务器过，请检查网络连接或刷新重试！");
        }
    });
}

function admin_logout() {
    //退出登录后返回登录界面
    window.location.href = "MainPage";
}

$(function (ev) {
    btn_num = parseInt($(".pagination").attr("linum"));
    row_num = parseInt($(".table-striped").attr("trnum"));
    page_num = parseInt($(".pagination").attr("pgnum"));
    display_row(1);

    $(".btn-warning").click(function () {
        $(".manage-main").removeClass("hid-element");
        $(".input-area").addClass("hid-element");
    });

    $(".btn-info").click(function () {
        var myact = ($(this).html() == "更新") ? "update" : "create";
        var new_data =
        {
            act: myact,
            ori_app_num: ori_app_num,
            app_num: $("#app_num").val(),
            name: $("#patent_name").val(),
            patent_type: $("#patent_type").val(),
            class_code: $("#class_code").val(),
            designer_id: $("#designer_id").val(),
            patentee_name: $("#patentee_name").val(),
            proposer_name: $("#proposer_name").val(),
            place_code: $("#place_code").val(),
            app_date: $("#app_date").val(),
            public_num: $("#public_num").val(),
            abstract: $("#abstract").val(),
            main_claim: $("#main_claim").val(),
            claim: $("#claim").val(),
            age: $("#patent_age").val(),
            is_valid: $("#is_valid").val(),
            link: $("#full_link").val(),

            com_name1: $("#com_name1").val(),
            com_address1: $("#com_address1").val(),
            com_abstract1: $("#com_abstract1").val(),

            com_name2: $("#com_name2").val(),
            com_address2: $("#com_address2").val(),
            com_abstract2: $("#com_abstract2").val(),

            person_id: $("#person_id").val(),
            person_name: $("#person_name").val(),
            person_address: $("#person_address").val(),
            person_phone: $("#person_phone").val(),
            person_email: $("#person_email").val()
        };

        modifyData(new_data);

    });

});
