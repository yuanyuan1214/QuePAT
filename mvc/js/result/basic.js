var datare = {};

var is_itemcl = 0;
var is_itemdynam = 0;

$(document).ready(function () {
    var queryJson = [];
    var row = {};
    row.keyword = "CN96120119";
    if (row.keyword === "") row.keyword = "666";
    queryJson.push(row);
    $.ajax({
        url: "/Home/Result", //改成相应函数接口
        async: false,
        type: 'post',
        contentType: "application/json",
        //data: JSON.stringify(queryJson[0]),
        data: "{str:'CN96120119'}",
        dataType: "json",
        traditional: true,
        success: function (data) {
            console.log(data);
            datare = data;
            var html2 = $("#Tmpl").render(datare);
            $("#itemInfoContainer").append(html2);

        },
        error: function (message) {
            alert("查询数据失败！");
        }
    });
    var tablis = $("#legalTemplate").render(datare);
    $("#legalContainer").append(tablis);
    var tablis = $("#famTemplate").render(datare);
    $("#familyContainer").append(tablis);
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
            break;
        case 'itemCL':
            $("#itemyear").css("display", "block");
            if (is_itemcl == 0) {
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
                        data: ['00:00', '01:15', '02:30', '03:45', '05:00', '06:15', '07:30', '08:45', '10:00', '11:15', '12:30', '13:45', '15:00', '16:15', '17:30', '18:45', '20:00', '21:15', '22:30', '23:45']
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
                        data: [300, 280, 250, 260, 270, 300, 550, 500, 400, 390, 380, 390, 400, 500, 600, 750, 800, 700, 600, 400]
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
                        data: [
                            { value: 335, name: 'A' },
                            { value: 310, name: 'B' },
                            { value: 274, name: 'C' },
                            { value: 235, name: 'D' },
                            { value: 400, name: 'E' }
                        ].sort(function (a, b) { return a.value - b.value; }),
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
            break;
    }
}