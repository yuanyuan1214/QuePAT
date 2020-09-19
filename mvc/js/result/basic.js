var datare = {};
var lawdata = [];
var famdata = [];
var x = [];
var y = [];
var types = [];

var is_law = 0;
var is_fam = 0;
var is_itemcl = 0;
var is_itemdynam = 0;
var stringcom = "";
var appnums = '';

var company = '';
var appnums_data = '';


$(document).ready(function () {
    
    console.log(window.location.href);
    var url = document.location.toString();//获取当前URL
    if (url.indexOf("?") != -1) {  //判断URL？后面不为空
        var arrUrl = url.split("?");//分割？
        var para = decodeURI(arrUrl[1]);//获取参数部分
        if (para)//判断传入的参数部分不为空
        {
            var arr = para.split("=");//分割=
            appnums = arr[1];//获取参数的值
        }
        else {
            alert("查询数据失败！");
        }
    }
    else {
        alert("查询数据失败！");
    }
    appnums_data = "{str:" + "'" + appnums + "'}";
    console.log(appnums_data);
   
    $.ajax({
        url: "/Home/Result", //改成相应函数接口
        async: false,
        type: 'post',
        contentType: "application/json",
        //data: JSON.stringify(queryJson[0]),
        data: appnums_data,
        dataType: "json",
        traditional: true,
        success: function (data) {
            console.log(data);
            company = data.PROPOSER_NAME;
            datare = data;
            stringcom = "{str:" + "'" + company + "'}";
            var html2 = $("#Tmpl").render(datare);
            $("#itemInfoContainer").append(html2);

        },
        error: function (message) {
            alert("查询数据失败！");
        }
    });
    var list = $(".detail-head.unselect p");
    list[0].addEventListener("click", switchs);
    list[1].addEventListener("click", switchs);
    list[2].addEventListener("click", switchs);
    list[3].addEventListener("click", switchs);
    list[4].addEventListener("click", switchs);
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
    $("#itemyear").css("display", "none");
    $("#itemdynam").css("display", "none");
    $("#itemfam").css("display", "none");
    var sele = $(this).attr("id");
    switch (sele) {
        case 'iteminfor':
            $("#itemInfoContainer").css("display", "block");
            break;
        case 'flztbtn':
            $(".dnp").css("display", "block");
            if (is_law == 0) {
                $.ajax({
                    url: "/Home/Law", //改成相应函数接口
                    async: false,
                    type: 'post',
                    contentType: "application/json",
                    //data: JSON.stringify(queryJson[0]),
                    data: appnums_data,
                    dataType: "json",
                    traditional: true,
                    success: function (data) {
                        console.log(data);
                        lawdata = data;
                        var tablis = $("#legalTemplate").render(lawdata);
                        $("#legalContainer").append(tablis);
                    },
                    error: function (message) {
                        alert("查询数据失败！");
                    }
                });
                is_law = 1;
            }
            break;
        case 'itemCL':
            $("#itemyear").css("display", "block");
            if (is_itemcl == 0) {
                console.log(stringcom);
                $.ajax({
                    url: "/Home/Year", //改成相应函数接口
                    async: false,
                    type: 'post',
                    contentType: "application/json",
                    //data: JSON.stringify(queryJson[0]),
                    data: stringcom,
                    dataType: "json",
                    traditional: true,
                    success: function (data) {
                        console.log(data);
                        for (var i = 0; i < data.length; ++i){
                    x.push(data[i].YEAR);
                    y.push(data[i].QUANT);
                    x.sort();
                }

                    },
                    error: function (message) {
                        alert("查询数据失败！");
                    }
                });
                // 基于准备好的dom，初始化echarts实例
                var myChart = echarts.init(document.getElementById('itemyear'));

                // 指定图表的配置项和数据

                var option = {
                    tooltip: {
                        trigger: 'axis',
                        axisPointer: {
                            type: 'cross'
                        }
                    },
                    legend: { top: '5%' },
                    toolbox: {
                        show: true,
                        feature: {
                            saveAsImage: {}
                        }
                    },
                    color: ["#1c66de"],
                    xAxis: {
                        type: 'category',
                        boundaryGap: false,
                        data: x
                    },
                    yAxis: {
                        type: 'value',
                        axisLabel: {
                            formatter: '{value} 件'
                        },
                        axisPointer: {
                            snap: true
                        },
                        boundaryGap: [0, '30%']
                    },
                    visualMap: {
                        show: false,
                        dimension: 0
                    },
                    series: [{
                        name: '专利数',
                        type: 'line',
                        smooth: true,
                        areaStyle: {},
                        data: y
                    }]

                };

                // 使用刚指定的配置项和数据显示图表。
                myChart.setOption(option);
                is_itemcl = 1;
            }
            break;
        case 'itemDS':
            $("#itemdynam").css("display", "block");
            if (is_itemdynam == 0) {
                $.ajax({
                    url: "/Home/Type", //改成相应函数接口
                    async: false,
                    type: 'post',
                    contentType: "application/json",
                    //data: JSON.stringify(queryJson[0]),
                    data: stringcom,
                    dataType: "json",
                    traditional: true,
                    success: function (data) {
                        console.log(data);
                        for (var i = 0; i < data.length; ++i) {
                            var m = data[i].QUANT;
                            var n = data[i].TYPE;
                            var object = { value: m, name: n };
                            types.push(object);
                        }
                    },
                    error: function (message) {
                        alert("查询数据失败！");
                    }
                });
                // 基于准备好的dom，初始化echarts实例
                var myChart = echarts.init(document.getElementById('itemdynam'));

                // 指定图表的配置项和数据
                var option = {

                    tooltip: {
                        trigger: 'item',
                        formatter: '{a} <br/>{b} : {c} ({d}%)'
                    },
                    color: ["#1c66de"],
                    visualMap: {
                        show: false,
                        min: 80,
                        max: 600,
                        inRange: {
                            colorLightness: [0, 1]
                        }
                    },
                    series: [{
                        name: '分类号',
                        type: 'pie',
                        radius: '70%',
                        center: ['50%', '50%'],
                        data: types.sort(function (a, b) { return a.value - b.value; }),
                        roseType: 'radius',
                        label: {
                            color: '#2b6ec9'
                        },
                        labelLine: {
                            lineStyle: {
                                color: '#2b6ec9'
                            },
                            smooth: 0.2,
                            length: 10,
                            length2: 20
                        },
                        itemStyle: {
                            color: '#1c66de',
                            shadowBlur: 200,
                            shadowColor: '#DCE4FF'
                        },

                        animationType: 'scale',
                        animationEasing: 'elasticOut',
                        animationDelay: function (idx) {
                            return Math.random() * 200;
                        }
                    }]
                };

                // 使用刚指定的配置项和数据显示图表。
                myChart.setOption(option);
                is_itemdynam = 1;
            }
            break;
        case 'itemRT':
            $("#itemfam").css("display", "block");
            if (is_fam == 0) {
                $.ajax({
                    url: "/Home/Famliy", //改成相应函数接口
                    async: false,
                    type: 'post',
                    contentType: "application/json",
                    //data: JSON.stringify(queryJson[0]),
                    data: appnums_data,
                    dataType: "json",
                    traditional: true,
                    success: function (data) {
                        console.log(data);
                        famdata = data;
                        var tabli = $("#famTemplate").render(famdata);
                        $("#familyContainer").append(tabli);
                    },
                    error: function (message) {
                        alert("查询数据失败！");
                    }
                });
                is_fam = 1;
            }
            break;
    }
}
