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
    
    public partial class LAW_STATUS
    {
        public string APP_NUM { get; set; }
        public System.DateTime ANNOUNCE_DATE { get; set; }
        public Nullable<System.DateTime> DUE_DATE { get; set; }
        public decimal STATUS { get; set; }
        public string MSG { get; set; }
        public string DETAIL { get; set; }
    
        public virtual PATENT PATENT { get; set; }
    }
}
