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
    
    public partial class EmployeeCourse
    {
        public int EmployeeCourseID { get; set; }
        public Nullable<int> Eid { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<byte> Marks { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
