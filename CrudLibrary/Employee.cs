//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrudLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.EmployeeCourses = new HashSet<EmployeeCourse>();
        }
    
        public int Eid { get; set; }
        public string EName { get; set; }
        public double ESalary { get; set; }
        public string EGender { get; set; }
        public System.DateTime EDOB { get; set; }
        public Nullable<int> Did { get; set; }
        public byte[] UpdatedDate { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual ICollection<EmployeeCourse> EmployeeCourses { get; set; }
    }
}
