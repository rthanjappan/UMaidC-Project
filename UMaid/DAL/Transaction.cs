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
    
    public partial class Transaction
    {
        public int transactionID { get; set; }
        public int userID { get; set; }
        public int listingID { get; set; }
        public int bidID { get; set; }
        public Nullable<double> maidRating { get; set; }
        public Nullable<double> customerRating { get; set; }
    
        public virtual Bid Bid { get; set; }
        public virtual Listing Listing { get; set; }
        public virtual User User { get; set; }
    }
}
