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
    
    public partial class Position
    {
        public Position()
        {
            this.Employees = new HashSet<Employee>();
        }
    
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public Nullable<decimal> Salary { get; set; }
    
        public virtual ICollection<Employee> Employees { get; set; }
    }
}