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
    
    public partial class BankAccount_T
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSC { get; set; }
        public string Branch { get; set; }
        public int UserId { get; set; }
    
        public virtual UserProfile_T UserProfile_T { get; set; }
    }
}
