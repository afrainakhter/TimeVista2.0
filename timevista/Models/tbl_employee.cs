//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeVista2._0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_employee
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string emailid { get; set; }
        public string password { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string employee_id { get; set; }
        public string joining_date { get; set; }
        public string phone { get; set; }
        public string shift { get; set; }
        public string department { get; set; }
        public string role { get; set; }
        public byte status { get; set; }
        public System.DateTime created_at { get; set; }
        public Nullable<int> Lrty { get; set; }
        public Nullable<byte> password_reset { get; set; }
    }
}