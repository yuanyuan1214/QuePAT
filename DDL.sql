-- 用户
CREATE TABLE usr (
	id INTEGER, -- 用户ID
	login_name VARCHAR(20), -- 用户名
	password VARCHAR(20) NOT NULL, -- 密码
	reg_time TIMESTAMP NOT NULL, -- 创建时间
	phone VARCHAR(20), -- 电话
	email VARCHAR(255), -- 邮箱
	company VARCHAR(255), -- 公司
	address VARCHAR(255), -- 地址
	PRIMARY KEY (id)
);

-- 信息
CREATE TABLE message (
	msg_id INTEGER, -- 信息ID
	sender_id INTEGER, -- 发送者
	receiver_id INTEGER, -- 接收者
	title VARCHAR(20) NOT NULL, -- 信息标题
	content VARCHAR(255), -- 信息正文
	msg_type VARCHAR(20), -- 信息类型
	send_time TIMESTAMP, -- 发送时间
	is_read CHAR(1) NOT NULL, -- 是否已读
	is_delete CHAR(1) NOT NULL, -- 是否已删除
	PRIMARY KEY (msg_id),
	FOREIGN KEY (sender_id) REFERENCES usr,
	FOREIGN KEY (receiver_id) REFERENCES usr
);
