//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class USE
    {
        public int UserID { get; set; }
        public Nullable<int> UserTypeID { get; set; }
        public string email { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public Nullable<bool> Pet { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<double> Rating { get; set; }
        public Nullable<int> numOfRatings { get; set; }
    
        public virtual UserType UserType { get; set; }
    }
}