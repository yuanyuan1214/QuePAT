-- province --
INSERT INTO province VALUES('110000', '北京');
INSERT INTO province VALUES('120000', '天津');
INSERT INTO province VALUES('130000', '河北');
INSERT INTO province VALUES('140000', '山西');
INSERT INTO province VALUES('150000', '内蒙古');
INSERT INTO province VALUES('210000', '辽宁');
INSERT INTO province VALUES('220000', '吉林');
INSERT INTO province VALUES('230000', '黑龙江');
INSERT INTO province VALUES('310000', '上海');
INSERT INTO province VALUES('320000', '江苏');
INSERT INTO province VALUES('330000', '浙江');
INSERT INTO province VALUES('340000', '安徽');
INSERT INTO province VALUES('350000', '福建');
INSERT INTO province VALUES('360000', '江西');
INSERT INTO province VALUES('370000', '山东');
INSERT INTO province VALUES('410000', '河南');
INSERT INTO province VALUES('420000', '湖北');
INSERT INTO province VALUES('430000', '湖南');
INSERT INTO province VALUES('440000', '广东');
INSERT INTO province VALUES('450000', '广西');
INSERT INTO province VALUES('460000', '海南');
INSERT INTO province VALUES('500000', '重庆');
INSERT INTO province VALUES('510000', '四川');
INSERT INTO province VALUES('520000', '贵州');
INSERT INTO province VALUES('530000', '云南');
INSERT INTO province VALUES('540000', '西藏');
INSERT INTO province VALUES('610000', '陕西');
INSERT INTO province VALUES('620000', '甘肃');
INSERT INTO province VALUES('630000', '青海');
INSERT INTO province VALUES('640000', '宁夏');
INSERT INTO province VALUES('650000', '新疆');
INSERT INTO province VALUES('710000', '台湾');
INSERT INTO province VALUES('810000', '香港');
INSERT INTO province VALUES('820000', '澳门');

INSERT INTO company(name) VALUES('阿莫科公司');
INSERT INTO company(name) VALUES('中原信达知识产权代理有限责任公司');

INSERT INTO person(id, name) VALUES('ZHANGYAOHUI', '张耀辉');
INSERT INTO person(id, name) VALUES('ZHENGLI', '郑立');

INSERT INTO classification VALUES (
	'G01V1/28',
	'物理',
	'测量；测试',
	'地球物理；重力测量；物质或物体的探测；示踪物（用于指示因事故被掩埋的人的位置，例如，被雪掩埋的人的位置的装置入A63B29/02）〔4，6〕',
	'地震学；地震或声学的勘探或探测',
	'.地震数据的处理，例如，分析、用于解释、用于校正（G01V1/48优先）〔6〕'
);

INSERT INTO patent VALUES (
	'CN96120119',
	'多源多分量地震数据短时区间模优化',
	0,
	'G01V1/28',
	'ZHANGYAOHUI',
	'阿莫科公司',
	'阿莫科公司',
	'110000',
	to_date('1996-09-25', 'yyyy-mm-dd'),
	'CN1157417A',
	to_date('1997-08-20', 'yyyy-mm-dd'),
	'本发明揭示了一种处理多源多分量剪切波地震数据的方法。该方法包括以下几步：获取四分量剪切波地震数据；将此数据转化成相对于一参考轴定义的转角的函数；计算此矩阵元素与时间无关的模；并找出使同线元素模之和与非同线元素模之和的差最大的转角。',
	NULL,
	NULL,
	20,
	'1',
	'cnipa.gov.cn'
);

INSERT INTO family VALUES (
	'US19950533079',
	'CN96120119'
);

INSERT INTO law_status
	VALUES ('CN96120119',to_date('1997-08-20', 'yyyy-mm-dd'), NULL, 4,'公开', NULL);
INSERT INTO law_status
	VALUES ('CN96120119',to_date('1998-12-16', 'yyyy-mm-dd'), NULL, 5,'实质审查请求的生效', NULL);

INSERT INTO SYSTEM.PROXY (APP_NUM,AGENT_ID,AGENCY) VALUES 
('CN96120119','ZHENGLI','中原信达知识产权代理有限责任公司');
