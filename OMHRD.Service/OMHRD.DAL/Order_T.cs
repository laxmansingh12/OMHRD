//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OMHRD.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_T
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order_T()
        {
            this.OrderPayment_T = new HashSet<OrderPayment_T>();
            this.OrderProduct_T = new HashSet<OrderProduct_T>();
        }
    
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
    
        public virtual UserProfile_T UserProfile_T { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPayment_T> OrderPayment_T { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct_T> OrderProduct_T { get; set; }
    }
}
