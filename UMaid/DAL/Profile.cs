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
    
    public partial class Profile
    {
        public int profileID { get; set; }
        public int userID { get; set; }
        public Nullable<int> pictureID { get; set; }
        public Nullable<int> AccountNumber { get; set; }
        public Nullable<double> AvgRating { get; set; }
        public string Bio { get; set; }
    
        public virtual Picture Picture { get; set; }
        public virtual User User { get; set; }
    }
}
