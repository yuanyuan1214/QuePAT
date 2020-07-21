*usr*(<u>id</u>, login_name, password, reg_time, phone, email, company, address)

*message*(<u>msg_id</u>, sender _id, receiver_id, title, content, msg_type, send_time, is_read, is_delete)
FK: sender _id, receiver_id (from *usr*)

*feedback*(<u>msg_id</u>, user_id, time, content)
FK: user_id (from *usr*)

*discussion*(<u>ID</u>, put_up_user_ID, topic, content, init_time)
FK: put_up_user_ID (from *usr*)

*related_filed*(<u>discussion_ID</u>, <u>rela_field</u>)
FK: discussion_ID (from *discussion*)

*comment*(<u>discussion_ID</u>, <u>user_ID</u>, <u>time</u>, content, is_delete)

*classification*(<u>code</u>, first_dir, first\_dir\_name, sec_dir, sec\_dir\_name, third_dir, third\_dir\_name)

*company*(<u>ID</u>, name, address, abstract, patent_num)

*patent_of_year*(<u>company_ID</u>, <u>year</u>, patent_num)
FK: company_ID (from *company*)

*person*(<u>ID</u>, name, address, phone_num, email)

*province*(<u>code</u>, name)

*patent*(<u>app_num</u>, name, type, classification_code, designer_id, patentee_ID, proposer_ID, place_code, app_date, public_num, public_data, current_status, abstract, main_cliam, claim, prio_app_country, age, is_valid)
FK: classification_code (from *classification*), designer_id (from *person*), patentee_ID, proposer_ID (from *company*), place_code (from *province*)

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