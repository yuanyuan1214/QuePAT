//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuePAT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MESSAGE
    {
        public decimal MSG_ID { get; set; }
        public decimal SENDER_ID { get; set; }
        public decimal RECEIVER_ID { get; set; }
        public string TITLE { get; set; }
        public string CONTENT { get; set; }
        public string MSG_TYPE { get; set; }
        public System.DateTime SEND_TIME { get; set; }
        public string IS_READ { get; set; }
        public string IS_DELETE { get; set; }
    
        public virtual USR USR { get; set; }
        public virtual USR USR1 { get; set; }
    }
}
