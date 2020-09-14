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
    
    public partial class PATENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PATENT()
        {
            this.CITE = new HashSet<CITE>();
            this.LAW_STATUS = new HashSet<LAW_STATUS>();
            this.PROXY = new HashSet<PROXY>();
        }
    
        public string APP_NUM { get; set; }
        public string NAME { get; set; }
        public decimal PATENT_TYPE { get; set; }
        public string CLASS_CODE { get; set; }
        public string DESIGNER_ID { get; set; }
        public string PATENTEE_NAME { get; set; }
        public string PROPOSER_NAME { get; set; }
        public string PLACE_CODE { get; set; }
        public System.DateTime APP_DATE { get; set; }
        public string PUBLIC_NUM { get; set; }
        public string ABSTRACT { get; set; }
        public string MAIN_CLAIM { get; set; }
        public string CLAIM { get; set; }
        public decimal AGE { get; set; }
        public string IS_VALID { get; set; }
        public string LINK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITE> CITE { get; set; }
        public virtual CLASSIFICATION CLASSIFICATION { get; set; }
        public virtual COMPANY COMPANY { get; set; }
        public virtual COMPANY COMPANY1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LAW_STATUS> LAW_STATUS { get; set; }
        public virtual PERSON PERSON { get; set; }
        public virtual PROVINCE PROVINCE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROXY> PROXY { get; set; }
    }
}
