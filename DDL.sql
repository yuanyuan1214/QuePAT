-- 用户模块 --

-- 用户表
CREATE TABLE usr (
	usr_id INTEGER, -- 用户 ID
	login_name VARCHAR(20), -- 用户名
	password VARCHAR(20) NOT NULL, -- 密码
	reg_time TIMESTAMP NOT NULL, -- 创建时间
	phone VARCHAR(20), -- 电话
	email VARCHAR(255), -- 邮箱
	company VARCHAR(255), -- 公司
	address VARCHAR(255), -- 地址
	PRIMARY KEY (usr_id)
);

-- 信息表
CREATE TABLE message (
	msg_id INTEGER, -- 信息 ID
	sender_id INTEGER NOT NULL, -- 发送者
	receiver_id INTEGER NOT NULL, -- 接收者
	title VARCHAR(20) NOT NULL, -- 信息标题
	content VARCHAR(255) NOT NULL, -- 信息正文
	msg_type VARCHAR(20), -- 信息类型 /*->SMALLINT?*/
	send_time TIMESTAMP NOT NULL, -- 发送时间
	is_read CHAR(1) NOT NULL, -- 是否已读
	is_delete CHAR(1) NOT NULL, -- 是否已删除
	PRIMARY KEY (msg_id),
	FOREIGN KEY (sender_id) REFERENCES usr,
	FOREIGN KEY (receiver_id) REFERENCES usr
);

-- 反馈表
CREATE TABLE feedback (
	fb_id INTEGER, -- 反馈 ID
	usr_id INTEGER NOT NULL, -- 用户ID
	fb_time TIMESTAMP NOT NULL, -- 反馈时间
	content VARCHAR(255) NOT NULL, -- 正文
	PRIMARY KEY (fb_id),
	FOREIGN KEY (usr_id) REFERENCES usr
);

-- 议题表
CREATE TABLE discussion (
	disc_id INTEGER, -- 议题 ID
	put_up_usr_id INTEGER NOT NULL, -- 发起者 ID
	topic VARCHAR(20) NOT NULL, -- 主题
	content VARCHAR(255) NOT NULL, -- 议题正文
	init_time TIMESTAMP NOT NULL, -- 发起时间
	PRIMARY KEY (disc_id),
	FOREIGN KEY (put_up_usr_id) REFERENCES usr
);

-- 议题相关领域表
CREATE TABLE related_filed (
	disc_id INTEGER, -- 议题 ID
	rela_field VARCHAR(20), -- 相关领域
	PRIMARY KEY (disc_id, rela_field),
	FOREIGN KEY (disc_id) REFERENCES discussion
);

-- 评论表
CREATE TABLE cmnt (
	disc_id INTEGER, -- 议题 ID
	usr_id INTEGER NOT NULL, -- 用户 ID
	cmnt_time TIMESTAMP NOT NULL, -- 评论时间
	content VARCHAR(255) NOT NULL,  -- 正文
	is_delete CHAR(1) NOT NULL, -- 是否已删除
	PRIMARY KEY (disc_id, usr_id, cmnt_time),
	FOREIGN KEY (disc_id) REFERENCES discussion,
	FOREIGN KEY (usr_id) REFERENCES usr
);

-- 专利模块 --

/*
 * TODO: 化为第一范式
-- 分类表
CREATE TABLE classification (
	code VARCHAR(12), -- 分类号
	sec_sym CHAR(1) NOT NULL, -- 部号
	sec_title VARCHAR(50) NOT NULL, -- 部名称
	class_sym CHAR(2) NOT NULL, -- 大类号
	class_title VARCHAR(50) NOT NULL, -- 大类名称
	subclass_sym CHAR(1) NOT NULL, -- 小类号
	subclass_title VARCHAR(255) NOT NULL, -- 小类名称
	group_sym VARCHAR(3) NOT NULL, -- 大组号
	group_title VARCHAR(255) NOT NULL, -- 大组名称
	subgroup_sym VARCHAR(3) NOT NULL, -- 小组号
	subgroup_title VARCHAR(255) NOT NULL, -- 小组名称
	PRIMARY KEY (code)
);
*/

-- 公司表
CREATE TABLE company (
	name VARCHAR(20), -- 公司名
	address VARCHAR(255) NOT NULL, -- 地址
	abstract VARCHAR(255), -- 公司简介
	PRIMARY KEY (name)
);

-- 自然人表
CREATE TABLE person (
	id VARCHAR(20), -- 身份证号码
	name VARCHAR(20) NOT NULL, -- 姓名
	address VARCHAR(255), -- 住址
	phone_num CHAR(11), -- 联系电话
	email VARCHAR(255),  -- 电子邮箱
	PRIMARY KEY (id)
);

-- 省市表
CREATE TABLE province (
	code CHAR(6), -- 行政区划代码
	name VARCHAR(20) NOT NULL, -- 省市名称
	PRIMARY KEY (code)
);

-- 专利表
CREATE TABLE patent (
	app_num CHAR(14), -- 申请号
	name VARCHAR(255) NOT NULL, -- 专利名称
	/*
	 * 0: 发明
	 * 1: 实用新型
	 * 2: 外观
	 */
	patent_type SMALLINT NOT NULL, -- 专利类型 
	class_code VARCHAR(12) NOT NULL, -- 专利分类号
	designer_id VARCHAR(20) NOT NULL, -- 发明人 ID
	patentee_name VARCHAR(20) NOT NULL, -- 专利权人
	proposer_name VARCHAR(20) NOT NULL, -- 申请机构
	place_code CHAR(6) NOT NULL, -- 所在行政区划代码
	app_date DATE NOT NULL, -- 申请日
	public_num CHAR(14) NOT NULL, -- 公开号
	public_date DATE NOT NULL, -- 公开日
	-- current_status SMALLINT NOT NULL, -- 当前法律状态  /*冗余?*/
	abstract VARCHAR(255), -- 摘要
	main_cliam VARCHAR(255), -- 主权利要求
	claim VARCHAR(255), -- 权利要求
	prio_app_country CHAR(3), -- 优先权受理国国家代码
	age SMALLINT NOT NULL, -- 专利年龄
	is_valid CHAR(1) NOT NULL, -- 有效位
	PRIMARY KEY (app_num),
	-- FOREIGN KEY (class_code) REFERENCES classification,
	FOREIGN KEY (designer_id) REFERENCES person,
	FOREIGN KEY (patentee_name) REFERENCES company,
	FOREIGN KEY (proposer_name) REFERENCES company,
	FOREIGN KEY (place_code) REFERENCES province
);

-- 同族专利表
CREATE TABLE family (
	basic_app_num CHAR(14), -- 基本专利申请号
	app_num CHAR(14), -- 同族专利申请号
	PRIMARY KEY (basic_app_num, app_num),
	FOREIGN KEY (basic_app_num) REFERENCES patent,
	FOREIGN KEY (app_num) REFERENCES patent
);

-- 法律状态表
CREATE TABLE law_status (
	app_num CHAR(14), -- 申请号
	announce_date DATE, -- 公告日
	due_date DATE, -- 到期日
	/*
	 * 0: 申请
	 * 1: 受理
	 * 2: 初审合格
	 * 3: 实审
	 * 4: 公布
	 * 5: 审查意见
	 * 6: 授权
	 * 7: 下证
	 */
	status SMALLINT NOT NULL, -- 法律状态
	msg VARCHAR(20), -- 法律状态信息
	detail VARCHAR(255), -- 详细信息
	PRIMARY KEY (app_num, announce_date),
	FOREIGN KEY (app_num) REFERENCES patent
);

-- 引用专利表
CREATE TABLE cite (
	citing_app_num CHAR(14), -- 引用专利申请号
	cited_app_num CHAR(14), -- 被引专利申请号
	PRIMARY KEY (citing_app_num, cited_app_num),
	FOREIGN KEY (citing_app_num) REFERENCES patent,
	FOREIGN KEY (cited_app_num) REFERENCES patent
);

-- 代理表
CREATE TABLE proxy (
	app_num CHAR(14), -- 专利申请号
	agent_id VARCHAR(20), -- 代理人 ID
	agency VARCHAR(255) NOT NULL, -- 代理机构名称
	PRIMARY KEY (app_num, agent_id),
	FOREIGN KEY (app_num) REFERENCES patent,
	FOREIGN KEY (agent_id) REFERENCES person,
	FOREIGN KEY (agency) REFERENCES company
);
