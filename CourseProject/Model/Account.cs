//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseProject.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public Account()
        {
            this.InetOrders = new HashSet<InetOrder>();
            this.Refills = new HashSet<Refill>();
        }
    
        public int AccountID { get; set; }
        public int ClientID { get; set; }
        public Nullable<decimal> Cash { get; set; }
        public Nullable<decimal> DebtCeiling { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual ICollection<InetOrder> InetOrders { get; set; }
        public virtual ICollection<Refill> Refills { get; set; }
    }
}
