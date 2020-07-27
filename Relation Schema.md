*usr*(<u>usr_id</u>, login_name, password, reg_time, phone, email, company, address)

*message*(<u>msg_id</u>, sender _id, receiver_id, title, content, msg_type, send_time, is_read, is_delete)
FK: sender _id, receiver_id (from *usr*)

*feedback*(<u>fb_id</u>, usr_id, fb_time, content)
FK: user_id (from *usr*)

*discussion*(<u>disc_id</u>, put_up_usr_id, topic, content, init_time)
FK: put_up_usr_id (from *usr*)

*related_filed*(<u>disc_id</u>, <u>rela_field</u>)
FK: disc_id (from *discussion*)

*comment*(<u>disc_id</u>, <u>usr_id</u>, <u>cmnt_time</u>, content, is_delete)
FK: disc_id (from *discussion*), user_id (from *usr*)

*classification*(<u>code</u>, first_dir, first\_dir\_name, sec_dir, sec\_dir\_name, third_dir, third\_dir\_name)

*company*(<u>name</u>, address, abstract)

*patent_of_year*(<u>name</u>, <u>year</u>, patent_num)
FK: name (from *company*)

*person*(<u>ID</u>, name, address, phone_num, email)

*province*(<u>code</u>, name)

*patent*(<u>app_num</u>, name, patent_type, class_code, designer_id, patentee_name, proposer_name, place_code, app_date, public_num, public_date, current_status, abstract, main_cliam, claim, prio_app_country, age, is_valid)
FK: class_code (from *classification*), designer_id (from *person*), patentee_name, proposer_name (from *company*), place_code (from *province*)

*family*(<u>basic\_patent\_app\_num</u>, <u>app_num</u>)
FK: basic\_patent\_app\_num, app_num (from *patent*)

*law_status*(<u>app_num</u>, <u>announce_date</u>, due_date, status, msg, detail)
FK: app_num (from *patent*)

*patent_category*(<u>app_num</u>, <u>category</u>)
FK: app_num (from *patent*)

*cite*(<u>citing\_app\_num</u>, <u>cited\_app\_num</u>)
FK: citing_app_num, cited_app_num (from *patent*)

*in_place*(<u>app_num</u>, <u>province_num</u>)
FK: app_num (from *patent*), province_num (from *province*)

*proxy*(<u>app_num</u>, <u>agent</u>, <u>agency</u>)
FK: app_num (from *patent*), agent (from *person*), agency (from *company*)