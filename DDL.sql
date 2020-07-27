-- 用户表
CREATE TABLE usr (
	id INTEGER, -- 用户 ID
	login_name VARCHAR(20), -- 用户名
	password VARCHAR(20) NOT NULL, -- 密码
	reg_time TIMESTAMP NOT NULL, -- 创建时间
	phone VARCHAR(20), -- 电话
	email VARCHAR(255), -- 邮箱
	company VARCHAR(255), -- 公司
	address VARCHAR(255), -- 地址
	PRIMARY KEY (id)
);

-- 信息表
CREATE TABLE message (
	msg_id INTEGER, -- 信息 ID
	sender_id INTEGER, -- 发送者
	receiver_id INTEGER, -- 接收者
	title VARCHAR(20) NOT NULL, -- 信息标题
	content VARCHAR(255), -- 信息正文
	msg_type VARCHAR(20), -- 信息类型
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
	usr_id INTEGER, -- 用户ID
	fb_time TIMESTAMP NOT NULL, -- 反馈时间
	content VARCHAR(255), -- 正文
	PRIMARY KEY (fb_id),
	FOREIGN KEY (usr_id) REFERENCES usr
);

-- 议题表
CREATE TABLE discussion (
	disc_id INTEGER, -- 议题 ID
	put_up_usr_id INTEGER, -- 发起者 ID
	topic VARCHAR(20) NOT NULL, -- 主题
	content VARCHAR(255), -- 议题正文
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

-- 评论
CREATE TABLE cmnt (
	disc_id INTEGER, -- 议题 ID
	usr_id INTEGER, -- 用户 ID
	cmnt_time TIMESTAMP NOT NULL, -- 评论时间
	content VARCHAR(255),  -- 正文
	is_delete CHAR(1) NOT NULL, -- 是否已删除
	PRIMARY KEY (disc_id, usr_id, cmnt_time),
	FOREIGN KEY (disc_id) REFERENCES discussion,
	FOREIGN KEY (usr_id) REFERENCES usr
);