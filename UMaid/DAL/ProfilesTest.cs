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
    
    public partial class ProfilesTest
    {
        public int ProfileID { get; set; }
        public int UserID { get; set; }
        public Nullable<int> PictureID { get; set; }
        public Nullable<int> AccountNumber { get; set; }
        public Nullable<double> AvgRating { get; set; }
        public string Bio { get; set; }
    
        public virtual PicturesTest PicturesTest { get; set; }
        public virtual UsersTest UsersTest { get; set; }
    }
}