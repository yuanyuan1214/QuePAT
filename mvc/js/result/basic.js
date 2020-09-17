var data_re = {
    'PT': 2,
    'TI': '一种立式测温仪',
    'AN': 'CN202021328177.1',
    'AD': '2020.07.08',
    'CO': '94(深圳)',
    'PN': 'CN211324979U',
    'PD': '2020.08.25',
    'GN': 'CN211324979U',
    'GD': '2020.08.25',
    'MC': 'A61B5/01',
    'IC': 'A61B5/01;G01K13/00',
    'PA': '戴亚英',
    'DZ': '518000 广东省深圳市宝安区松岗街道燕罗公路90号星辉工业城五栋二楼',
    'IN': '戴亚英',
    'PE': '戴亚英',
    'AT': '谭慧',
    'AG': '44682 深圳知帮办专利代理有限公司',
    'AGN': '44682',
    'PR': '',
    'CT': '',
    'KW': '',
    'CC': '',
    'UCC': '',
    'LG': 1, //法律状态
    'AB': '本实用新型涉及防疫的技术领域，特别是涉及一种立式测温仪，其通过把手打开箱门，使工作人员进入至隔离箱的内部，再使被检测人员站立于测温仪的右侧，通过打开测温仪，对被检测人员的体温进行检测，之后通过显示屏将测温仪检测的体温数据以文字的形式显示至显示屏的左端，方便工作人员进行观察，从而减少工作人员与被检测人员进行直接接触，降低工作人员的危险性；包括隔离箱、箱门、第一合页、第二合页、把手、支撑架、测温仪和显示屏，箱门的侧端通过第一合页和第二合页与隔离箱的前端转动连接，并且隔离箱的内部设置有座椅，把手的后端与箱门的前端相连接测温仪的左端通过支撑架与隔离箱的右端相连接，显示屏的侧端与隔离箱内的右端相连接。',
    'CL': '1.一种立式测温仪，其特征在于，包括隔离箱（1）、箱门（2）、第一合页（3）、第二合页（4）、把手（5）、支撑架（6）、测温仪（7）和显示屏（8），箱门（2）的侧端通过第一合页（3）和第二合页（4）与隔离箱（1）的前端转动连接，并且隔离箱（1）的内部设置有座椅（9），把手（5）的后端与箱门（2）的前端相连接测温仪（7）的左端通过支撑架（6）与隔离箱（1）的右端相连接，显示屏（8）的侧端与隔离箱（1）内的右端相连接。',
    'LegalDate': '2020.08.25',
    'LegalStatus': '授权',
    'LegalStatusInfo': '授权',
    'DETAIL': ''
};



$(document).ready(function () {
    $.ajax({
        url: "/Home/FindByApplyNumber",//改成相应函数接口
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
            var html2 = $("#Tmpl").render(data_re);
            $("#itemInfoContainer").append(html2);
        },
        error: function (message) {
            alert("查询数据失败！");
        }
    });
    var tablis = $("#legalTemplate").render(data_re);
    $("#legalContainer").append(tablis);
    var list = $(".detail-head.unselect p");
    list[0].addEventListener("click", switchs);
    list[1].addEventListener("click", switchs);
    $(".username").hover(function () {
        $(".box-content").css("display", "block");
    });
    $(".username").mouseout(function () {
        $(".box-content").css("display", "none");
    });
    $(".personalmenu").mouseover(function () {
        $(".box-content").css("display", "block");
    });
    $(".personalmenu").mouseout(function () {
        $(".box-content").css("display", "none");
    });
});

function switchs() {
    var list = $(".detail-head.unselect p");
    for (var i = 0; i < list.length; ++i) {
        list[i].setAttribute("class", "fmxx");
    }
    $(this).attr("class", "active");
    $("#itemInfoContainer").css("display", "none");
    $(".dnp").css("display", "none");
    var sele = $(this).attr("id");
    switch (sele) {
        case 'iteminfor':
            $("#itemInfoContainer").css("display", "block");
            break;
        case 'flztbtn':
            $(".dnp").css("display", "block");
            break;
    }
}